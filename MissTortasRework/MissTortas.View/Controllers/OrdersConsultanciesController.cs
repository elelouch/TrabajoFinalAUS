using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using System.Security.Claims;
using CreateConsultancy = MissTortas.View.DTO.Orders.CreateConsultancy;
using CreateConsultancyServiceDTO = MissTortas.Services.DTO.Orders.CreateConsultancyDTO;
using UpdateConsultancy = MissTortas.View.DTO.Orders.UpdateConsultancy;
using UpdateConsultancyServiceDTO = MissTortas.Services.DTO.Orders.UpdateConsultancyDTO;

namespace MissTortas.View.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersConsultanciesController(
        IOrderService orderService,
        UserManager<ApplicationUser> userManager,
        ISimpleStorage simpleStorage
        ) : Controller
    {

        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpPut("{id}")]
        public async Task<ActionResult<ConsultancyDTO>> PutConsultancy(long id, UpdateConsultancy dto)
        {
            var consultancyDTO = new UpdateConsultancyServiceDTO
            {
                BakeryNotes = dto.BakeryNotes,
                ConsultancyId = id,
                Status = dto.NewStatus
            };
            var consultancy = await orderService.UpdateConsultancyAsync(consultancyDTO);
            return consultancy;
        }

        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultancyDTO>> GetConsultancy(long id)
        {
            return await orderService.GetConsultancyAsync(id);
        }

        [Authorize(Policy = PolicyName.PlaceOrders)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsultancyDTO>>> GetConsultancies()
        {
            ClaimsPrincipal principal = User;
            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("The user must have the jwt sub claim");
            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
            {
                return NotFound();
            }
            var ret = await orderService.GetUserConsultanciesAsync(user.UserId);
            return ret.ToList();
        }

        [Authorize(Policy = PolicyName.PlaceOrders)]
        [HttpPost]
        public async Task<ActionResult<ConsultancyDTO>> PostConsultancy([FromForm] CreateConsultancy dto, [FromForm] List<IFormFile> files)
        {
            var consultancyDTO = new CreateConsultancyServiceDTO
            {
                ClientId = dto.ClientId,
                AssigneeId = dto.AssigneeId,
                Description = dto.Description,
                Title = dto.Title,
            };
            var consultancy = await orderService.CreateConsultancyAsync(consultancyDTO);
            await simpleStorage.SaveConsultancyFileAsync(files, consultancy.Id);
            return consultancy;
        }
    }
}
