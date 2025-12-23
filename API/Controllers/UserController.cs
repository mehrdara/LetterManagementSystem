using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Common;
using Application.DTOs;
using Application.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    public class UserController : AppBaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.OrganizationMail,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            Console.WriteLine(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            Console.WriteLine(result);

            if (!result.Succeeded)
            {
                return BadRequest(new
                {
                    message = "Registeration failed",
                    errors = result.Errors.Select(e => e.Description)
                });
            }

            return Ok(new { message = "Registeration complete" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
            Console.WriteLine(result);

            if (result.Succeeded)
            {
                return Ok(new { Message = "خوش آمدید" });
            }

            if (result.IsLockedOut) return BadRequest("Account is locked.");

            return Unauthorized(new
            {
                message = "login failed",
                errors = result
            });
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { Message = "Logged out!" });
        }
        [HttpGet("users")]
        public async Task<ActionResult<List<UserNameDto>>> GetUsersLookup()
        {
            var result = await MediatorSender.Send(new GetUserNamesQuery());
            return Ok(result);
        }
    }
    public record RegisterRequestDto(
         string OrganizationMail,
         string UserName,
         string Password,
         string FirstName,
         string LastName
    );
    public record LoginRequest(string UserName, string Password);
}
