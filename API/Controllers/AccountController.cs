using API.Data;
using API.DTO;
using API.Entities;
using API.Entities.Requests;
using API.Entities.Responses;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly ITokenService tokenService;
    private readonly IMapper mapper;
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly IUserRepository userRepository;
    private readonly IPhotoService photoService;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
        ITokenService tokenService, IMapper mapper, IUserRepository userRepository, IPhotoService photoService, DataContext context)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.mapper = mapper;
        this.tokenService = tokenService;
        this.userRepository = userRepository;
        this.photoService = photoService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserAuthResponse>> Register(RegisterRequest registerDto)
    {
        if(registerDto.Password != registerDto.RepeatPassword)
        {
            return BadRequest("Mật khẩu nhập lại không đúng!");
        }

        if (await UserExists(registerDto.UserName)) 
            return BadRequest("Tên tài khoản đã được sử dụng!");

        var user = mapper.Map<User>(registerDto);

        user.UserName = registerDto.UserName.ToLower();

        var result = await userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded) return BadRequest("Sai định dạng, vui lòng nhập lại");

        var roleResult = await userManager.AddToRoleAsync(user, "Student");

        if (!roleResult.Succeeded) return BadRequest(result.Errors);


        return new UserAuthResponse
        {
            UserName = user.UserName,
            FullName = user.FullName,
            Token = await tokenService.CreateToken(user),
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserAuthResponse>> Login(LoginRequest loginDto)
    {
        var user = await userManager.Users
            .Include(p => p.AvatarImg)
            .SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

        if (user == null) return Unauthorized("Tài khoản hoặc mật khẩu không chính xác!");

        var result = await signInManager
            .CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded) return Unauthorized("Tài khoản hoặc mật khẩu không chính xác!");

        //If succeeded
        user.LastActive = DateTime.Now;

        userRepository.Update(user);
        await userRepository.SaveAllAsync();

        return new UserAuthResponse
        {
            UserName = user.UserName,
            Token = await tokenService.CreateToken(user),
            AvatarUrl = user.AvatarImg?.Url,
            FullName = user.FullName

        };
    }

    [HttpPut("edit")]
    [Authorize]
    public async Task<ActionResult> UpdateUser(UserUpdateDTO userUpdateDTO)
    {
        var user = await userRepository.GetUserByUsernameAsync(User.GetUsername());

        if (user == null) return NotFound("Không tìm thấy người dùng");

        mapper.Map(userUpdateDTO, user);

        if (await userRepository.SaveAllAsync())
            return NoContent();

        return BadRequest("Sửa đổi thất bại!");
    }

    [HttpPost("updateAvatar")]
    [Authorize]
    public async Task<ActionResult> ChangeAvatarImage(IFormFile file)
    {
        var user = await userRepository.GetUserByUsernameAsync(User.GetUsername());

        if (user == null) return NotFound();

        var res = await photoService.AddPhotoAsync(file);

        if (res.Error != null) return BadRequest(res.Error.Message);

        var oldAvatar = user.AvatarImg;

        if(oldAvatar != null)
        {
            if(oldAvatar.PublicId != null)
                await photoService.DeletePhotoAsync(oldAvatar.PublicId);
        }

        var newAvatar = new Photo
        {
            Url = res.SecureUrl.AbsoluteUri,
            PublicId = res.PublicId
        };

        user.AvatarImg = newAvatar;

        if (await userRepository.SaveAllAsync())
            return Ok(newAvatar);
            
        return BadRequest("Thay đổi không thành công, vui lòng thử lại sau!");
    }

    [HttpPost("changePassword")]
    [Authorize]
    public async Task<ActionResult> ChangePassword(ChangePasswordRequest passwordRequest)
    {
        if (passwordRequest == null) return BadRequest("Vui lòng thử lại sau!");

        if (!passwordRequest.NewPassword.Equals(passwordRequest.RptNewPassword)) return BadRequest("Mật khẩu nhập lại không chính xác");

        var user = await userRepository.GetUserByUsernameAsync(User.GetUsername());

        var result = await userManager.ChangePasswordAsync(user, passwordRequest.OldPassword, passwordRequest.NewPassword);

        if (!result.Succeeded)
            return Unauthorized("Mật khẩu không chính xác!");

        return Ok(result);
    }




    private async Task<bool> UserExists(string username)
    {
        return await userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
    }
}