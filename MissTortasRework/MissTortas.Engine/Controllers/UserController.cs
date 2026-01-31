using Microsoft.AspNetCore.Mvc;
using MissTortas.Engine.DTO;
using MissTortas.Engine.Interfaces;
using System.Collections;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace MissTortas.Engine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController(UserManager<ApplicationUser> userManager,ITokenGenerator tokenGenerator,
                SignInManager<ApplicationUser> signInManager) : Controller
    {

        [HttpGet]
        public async Task<ActionResult<List<UserLoginDTO>>> AllUser()
        {
            var allUsers = await userManager.Users.ToListAsync();
            var allUserDTO = new ArrayList(allUsers.Count);
            foreach (var user in allUsers)
            {
                allUserDTO.Add(new UserLoginDTO { Id = user.Id, Username = user.UserName! });
            }

            return Ok(allUserDTO);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserLoginDTO>> LoginUser(
                LoginRequest request
            )
        {
            var user = await userManager.FindByNameAsync(request.Email);
            if (user is null)
            {
                return NotFound("User not found");
            } 
            var result = await signInManager.PasswordSignInAsync(user, request.Password, true, true);
            if (result != Microsoft.AspNetCore.Identity.SignInResult.Success)
            {
                return Unauthorized("Wrong password");
            }
            var dtoRet = new UserLoginDTO
            {
                Id = user.Id,
                Username = user.UserName!,
                AccessToken = tokenGenerator.GenerateToken(user)
            };
            return dtoRet;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserLoginDTO>> RegisterUser(RegisterRequest request)
        {
            var newUser = new ApplicationUser { Email = request.Email,UserName = request.Email,Guid = Guid.NewGuid() };
            var creation = await userManager.CreateAsync(newUser, request.Password);
            if (creation.Succeeded)
            {
                var userDto = new UserLoginDTO
                {
                    Id = newUser.Id,
                    Username = newUser.UserName,
                    AccessToken = tokenGenerator.GenerateToken(newUser)
                };
                return Ok(userDto);
            }
            
            return BadRequest(creation.Errors); 
        }
    }
}
