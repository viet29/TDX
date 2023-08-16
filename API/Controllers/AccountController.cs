using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
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
    
    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IMapper mapper)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.mapper = mapper;
        this.tokenService = tokenService; 
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto)
    {
        if (await UserExists(registerDto.Username)) 
            return BadRequest("Tên tài khoản đã được sử dụng!");

        var user = mapper.Map<User>(registerDto);

        user.UserName = registerDto.Username.ToLower();

        var result = await userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        var roleResult = await userManager.AddToRoleAsync(user, "Student");

        if (!roleResult.Succeeded) return BadRequest(result.Errors);

        return new UserDTO
        {
            UserName = user.UserName,
            FullName = user.FullName,
            Token = await tokenService.CreateToken(user),
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
    {
        var user = await userManager.Users
            .Include(p => p.AvatarImg)
            .SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

        if (user == null) return Unauthorized("Tài khoản hoặc mật khẩu không chính xác!");

        var result = await signInManager
            .CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!result.Succeeded) return Unauthorized("Tài khoản hoặc mật khẩu không chính xác!");

        return new UserDTO
        {
            UserName = user.UserName,
            Token = await tokenService.CreateToken(user),
            AvatarUrl = user.AvatarImg?.Url,
            FullName = user.FullName
        };
    }

    private async Task<bool> UserExists(string username)
    {
        return await userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
    }
}