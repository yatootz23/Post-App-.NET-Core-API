using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using postapp.Dtos;
using postapp.Models;
using postapp.Interfaces;

namespace postapp.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService tokenService;
        public AccountController(UserManager<AppUser> _userManager, ITokenService _tokenService)
        {
            userManager = _userManager;
            tokenService = _tokenService;
        }


      [HttpPost("register")]
      public async Task<IActionResult> Register([FromBody] RegisterDto registerDto){
        try
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var appUser = new AppUser{
                UserName = registerDto.Username,
                Email = registerDto.Email
            };

            var createdUser = await userManager.CreateAsync(appUser, registerDto.Password);

            if(createdUser.Succeeded){
                var roleResult = await userManager.AddToRoleAsync(appUser, "User");
                if(roleResult.Succeeded){
                    return Ok(
                        new NewUserDto{
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            Token = tokenService.CreateToken(appUser)
                        }
                    );
                } else{
                    return StatusCode(500, roleResult.Errors.ToString());
                }
            } else{
                return StatusCode(500, createdUser.Errors.ToString());
            }
            
        }
        catch (Exception e)
        {
            
            return StatusCode(500, e.Message);
        }
      }

    // [HttpPost("login")]
    // public async Task<IActionResult> Login([FromBody] LoginDto loginDto){
        
    // } 
    }
}