using Microsoft.AspNetCore.Mvc;
using System.Collections;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using MissTortas.Services.Mapper;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Presentation.DTO.Security;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SecurityController(
        UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager,
        ITokenGenerator tokenGenerator,
        SignInManager<ApplicationUser> signInManager) : Controller
    {

        [Authorize(Policy = "UserAdministrator")]
        [HttpGet("user")]
        public async Task<ActionResult<List<UserLogin>>> AllUser()
        {
            var allUsers = await userManager.Users.ToListAsync();
            var allUserDTO = new ArrayList(allUsers.Count);
            foreach (var user in allUsers)
            {
                allUserDTO.Add(new UserLogin { Id = user.Id, Username = user.UserName! });
            }
            return Ok(allUserDTO);
        }

        [AllowAnonymous]
        [HttpPost("user/login")]
        public async Task<ActionResult<UserLogin>> LoginUser(
                LoginRequest request
            )
        {
            var user = await userManager.FindByNameAsync(request.Email);
            if (user is null)
            {
                return NotFound("User not found. Checkout credentials.");
            }
            var result = await signInManager.PasswordSignInAsync(user, request.Password, true, true);
            if (result != SignInResult.Success)
            {
                return Unauthorized("Wrong credentials, check if username or password are right.");
            }

            var dtoRet = new UserLogin
            {
                Id = user.Id,
                Username = user.UserName!,
                AccessToken = tokenGenerator.GenerateToken(user)
            };
            return dtoRet;
        }

        [Authorize(Policy = "UserAdministrator")]
        [HttpPost("role/permission")]


        [AllowAnonymous]
        [HttpPost("user/register")]
        public async Task<ActionResult<UserLogin>> RegisterUser(RegisterRequest request)
        {
            var newUser = new ApplicationUser 
            { 
                Email = request.Email, 
                UserName = request.Email, 
                Guid = Guid.NewGuid(), 
                EmailConfirmed = false,
                LockoutEnabled = true
            };

            var userCreation = await userManager.CreateAsync(newUser, request.Password);
            if (!userCreation.Succeeded)
            {
                return BadRequest(userCreation.Errors);
            }
            var newRoleName = $"{newUser.Id}-{newUser.UserName}";
            var trivialRole = new ApplicationRole {Trivial = true, Name=newRoleName}; 
            var roleCreation = await roleManager.CreateAsync(trivialRole);
            if(!roleCreation.Succeeded)
            {
                return BadRequest(userCreation.Errors);
            }
            var trivialRoleAssign = await userManager.AddToRoleAsync(newUser, newRoleName);
            if (!trivialRoleAssign.Succeeded)
            {
                return BadRequest(trivialRoleAssign.Errors);
            }
            await userManager.AddToRoleAsync(newUser, ApplicationRole.UserRole.Name!);

            var userDto = new UserLogin
            {
                Id = newUser.Id,
                Username = newUser.UserName
            };
            return Ok(userDto);
        }


    }
}
