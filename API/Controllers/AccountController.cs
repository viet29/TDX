using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            this._context = context;
            this._tokenService = tokenService;
        }

        [HttpPost("register")] // POST: api/account/register 
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDto)
        {
            if (await UserExists(registerDto.Username))
            {
                return BadRequest("Tài khoản đã tồn tại!");
            }

            using var hmac = new HMACSHA512();

            var user = new User
            {
                Username = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }
        
        [HttpPost("login")] // POST: api/account/login 
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x =>  x.Username == loginDto.Username);

            if (user == null)
            {
                return Unauthorized("Invalid Username!");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            if(!user.PasswordHash.SequenceEqual(computedHash)) {
                return Unauthorized("Invalid Password!");
            }

            return new UserDTO
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        } 


        private async Task<bool> UserExists (string username)
        {
            return await _context.Users.AnyAsync(x => x.Username == username.ToLower());
        } 


    }
}
