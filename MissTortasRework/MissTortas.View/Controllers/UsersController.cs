using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Mappings.Interfaces;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.DTO;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Infrastructure.Security.Requirements;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using MissTortas.View.DTO.Security;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(
        IOrderService orderService,
        IAuthorizationService authorizationService,
        ISecurityService securityService,
        IValidator<UserModification> userModificationValidator,
        IUserMapper userMapper
    ) : ControllerBase
    {

        [Authorize(Policy = PolicyName.ReadUsers)]
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserFullDTO>> GetUser(string userId)
        {
            var ret = await securityService.GetUserByIdAsync(userId);
            if (ret is not null)
            {
                return Ok(ret);
            }
            return NotFound();
        }

        [Authorize(Policy = PolicyName.ReadUsers)]
        [HttpGet("me")]
        public async Task<ActionResult<CurrentUserDTO>> CurrentUserDetails()
        {
            var userMetadata = userMapper.ClaimsPrincipalToUserMetadata(User);
            return new CurrentUserDTO { UserData = userMetadata };
        }


        [Authorize(Policy = PolicyName.ReadUsers)]
        [HttpGet]
        public async Task<ActionResult<List<SimpleUser>>> Users()
        {
            var allUsers = await securityService.GetAllUsersAsync();
            var allUserDTO = allUsers.Select(user => new SimpleUser
            {
                Id = user.Id,
                Username = user.UserName!,
                Roles = [.. user.User.Roles.Select(r => r.Name)],
                Enabled = !(user.LockoutEnabled && user.LockoutEnd >= DateTimeOffset.UtcNow),
                Email = user.Email ?? ""
            }).ToList();
            return Ok(allUserDTO);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UserModification(string userId, UserModification userModificationDTO)
        {
            await userModificationValidator.ValidateAndThrowAsync(userModificationDTO);
            var serviceDto = new ApplicationUserModificationDTO
            {
                UserId = userId,
                IsEnabled = userModificationDTO.Enabled,
                Username = userModificationDTO.Username,
                Email = userModificationDTO.Email,
                Roles = userModificationDTO.Roles,
                FirstName = userModificationDTO.FirstName,
                LastName = userModificationDTO.LastName,
                NewPassword = userModificationDTO.NewPassword
            };
            var authResult = await authorizationService.AuthorizeAsync(User, serviceDto, new UpdateUserRequirement());
            if (!authResult.Succeeded)
            {
                return Forbid();
            }

            await securityService.ModifyUserAsync(serviceDto);
            return NoContent();
        }

        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpGet("{userId}/consultancies")]
        public async Task<ActionResult<IEnumerable<ConsultancyDTO>>> GetUserConsultancies(long userId)
        {
            var ret = await orderService.GetUserConsultanciesAsync(userId);
            return ret.ToList();
        }
    }
}
