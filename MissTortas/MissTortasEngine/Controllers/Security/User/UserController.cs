using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissTortasEngine.Model;
using MissTortasEngine.Model.Security.User;

namespace MissTortasEngine.Controllers.Security.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MissTortasEngineContext _context;

        public UserController(MissTortasEngineContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserBase>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserBase>> GetUserBase(int id)
        {
            var userBase = await _context.Users.FindAsync(id);

            if (userBase == null)
            {
                return NotFound();
            }

            return userBase;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserBase(int id, UserBase userBase)
        {
            if (id != userBase.Id)
            {
                return BadRequest();
            }

            _context.Entry(userBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserBase>> PostUser(UserRegistrationDTO userDto)
        {
            var newUser = new UserBase { Username = userDto.Username, Email = userDto.Email, };
            var passwordHasher = new PasswordHasher<UserBase>();
            var hashedPassword = passwordHasher.HashPassword(newUser, userDto.Password);
            newUser.Password = hashedPassword;
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(UserBase), new { id = newUser.Id }, newUser);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserBase(int id)
        {
            var userBase = await _context.Users.FindAsync(id);
            if (userBase == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userBase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserBaseExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
