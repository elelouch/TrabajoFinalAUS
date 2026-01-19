using Microsoft.AspNetCore.Mvc;
using MissTortas.Engine.DTO;
using MissTortas.Services.Interfaces;
using MissTortas.Services.DTO;
using System.Collections;
using MissTortas.Services.DTO.User;

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
        public async Task<ActionResult<UserDTO>> PostUser(CreateUserDTO dto)
        {
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
