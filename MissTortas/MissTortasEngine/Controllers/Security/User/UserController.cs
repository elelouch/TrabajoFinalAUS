using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissTortas.Engine;
using MissTortas.Engine.DTO;
using MissTortas.Services;
using MissTortas.Services.DTO;
using MissTortas.Services.Interfaces;

namespace MissTortas.Engine.Controllers.Security.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController (IUserService userService) : ControllerBase
    {
        private readonly IUserService userService = userService;

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserBase(long id)
        {
            var userBase = await userService.FindUser(id);

            if (userBase == null)
            {
                return NotFound();
            }

            return new UserDTO
            { 
                Username = userBase.UserName!,
                Id = userBase.Id,
            };
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDTO>> PostUser(UserRegistrationDTO userDto)
        {
            var serviceUserRegistrationDTO = new Services.DTO.User.UserRegistrationDTO
            {
                Password = userDto.Password,
                Username = userDto.Username,
                Email = userDto.Email
            };
            var user = await userService.RegisterUserAsync(serviceUserRegistrationDTO);
            return new UserDTO
            {
                Username = user.UserName!,
                Id = user.Id,
                Message = "User created succesfully"
            };
        }

    }
}
