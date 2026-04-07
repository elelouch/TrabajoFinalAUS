using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Infrastructure;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Security;
using MissTortas.Presentation.DTO.Orders;
using MissTortas.Services;
using MissTortas.Services.DTO.Orders;
using MissTortas.Services.Interfaces;
using System.Security.Claims;
using CreateConsultancy = MissTortas.Presentation.DTO.Orders.CreateConsultancy;
using CreateConsultancyServiceDTO = MissTortas.Services.DTO.Orders.CreateConsultancyDTO;
using UpdateConsultancy = MissTortas.Presentation.DTO.Orders.UpdateConsultancy;
using UpdateConsultancyServiceDTO = MissTortas.Services.DTO.Orders.UpdateConsultancyDTO;

namespace MissTortas.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersConsultanciesController(IOrderService orderService, ISimpleStorage simpleStorage) : Controller
    {

        [Authorize(Policy = PolicyName.ManageOrders)]
        [HttpPut]
        public async Task<ActionResult<ConsultancyDTO>> PutConsultancy(UpdateConsultancy dto)
        {
            var consultancyDTO = new UpdateConsultancyServiceDTO
            {
                BakeryNotes = dto.BakeryNotes,
                ConsultancyId = dto.Id,
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
            var id = principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("The user must have the jwt sub claim");
            var idLong = Convert.ToInt64(id);
            var ret = await orderService.GetUserConsultanciesAsync(idLong);
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
