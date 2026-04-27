using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.DTO.Security;
using MissTortas.Infrastructure.Security;
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
        IUserContextProvider userContextProvider
        ) : ControllerBase
    {

        [Authorize(Policy = PolicyName.ReadUsers)]
        [HttpGet]
        public async Task<ActionResult<List<SimpleUser>>> Users()
        {
            var allUsers = await securityService.GetAllUsersAsync();
            var allUserDTO = allUsers.Select(user => new SimpleUser
            {
                Id = user.Id,
                Username = user.UserName!,
                Roles = [.. user.User.Roles.Select(r => r.Name)]
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
                Roles = userModificationDTO.Roles
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
