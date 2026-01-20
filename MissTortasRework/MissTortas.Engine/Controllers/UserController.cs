using Microsoft.AspNetCore.Mvc;
using MissTortas.Engine.DTO;
using MissTortas.Services.Interfaces;
using MissTortas.Services.DTO;
using System.Collections;
using MissTortas.Services.DTO.User;
using MissTortas.Engine.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace MissTortas.Engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController()]
    public class UserController(IUserService userService) : Controller
    {
        private readonly IUserService userService = userService;
        
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> AllUser()
        {
            var allUsers = await userService.AllUserAsync();
            var allUserDTO = new ArrayList(allUsers.Count);
            foreach (var user in allUsers)
            {
                allUserDTO.Add(new UserDTO { Id = user.Id, Username = user.UserName! });
            }

            return Ok(allUserDTO);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> LoginUser(LoginUserDTO dto, IValidator<LoginUserDTO> validator)
        {
            await validator.ValidateAndThrowAsync(dto);

            await userService.LoginUserAsync(new UserLoginDTO
            {
               Username = dto.Username,
               Password = dto.Password
            });
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> RegistarUser(CreateUserDTO dto, IValidator<CreateUserDTO> validator)
        {
            await validator.ValidateAndThrowAsync(dto);
            
            var registerUser = await userService.RegisterUserAsync(new UserRegistrationDTO
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
