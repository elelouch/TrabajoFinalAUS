using Microsoft.AspNetCore.Mvc;
using MissTortas.Engine.DTO;
using MissTortas.Services.Interfaces;
using MissTortas.Services.DTO;
using System.Collections;
using MissTortas.Services.DTO.User;
using MissTortas.Engine.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MissTortas.Engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController()]
    public class UserController(UserManager<User> userManager) : Controller
    {
        private readonly UserManager<User> userManager = userManager;
        
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> AllUser()
        {
            var allUsers = await userManager.Users.ToListAsync();
            var allUserDTO = new ArrayList(allUsers.Count);
            foreach (var user in allUsers)
            {
                allUserDTO.Add(new UserDTO { Id = user.Id, Username = user.UserName! });
            }

            return Ok(allUserDTO);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> LoginUser(LoginUserDTO dto, IValidator<LoginUserDTO> validator, SignInManager<User> signInManager)
        {
            await validator.ValidateAndThrowAsync(dto);
            var user = await userManager.FindByNameAsync(dto.Username);
            if (user is null)
            {
                return NotFound("User not found");
            }
            var result = await signInManager.PasswordSignInAsync(user, dto.Password, true, true);
            if (result != Microsoft.AspNetCore.Identity.SignInResult.Success)
            {
                return Unauthorized("Wrong password");
            }
            var dtoRet = new UserDTO
            {
                Id = user.Id,
                Username = user.UserName!
            };
            return Ok(dtoRet);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> RegisterUser(CreateUserDTO dto, IValidator<CreateUserDTO> validator)
        {
            await validator.ValidateAndThrowAsync(dto);
            var newUser = new User
            {
                Email = dto.Email,
                UserName = dto.Username
            };
            userManager.CreateAsync(newUser, dto);
            var registerUser = await userManager.RegisterUserAsync(new UserRegistrationDTO
            {
                Username = dto.Username,
                Password = dto.Password,
                Email = dto.Email
            });

            var userDto = new UserDTO
            {
                Id = registerUser.Id,
                Username = registerUser.UserName!
            };
            return Ok(userDto);
        }
    }
}
