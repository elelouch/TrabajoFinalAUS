using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissTortasEngine.Model;
using MissTortasEngine.Model.Order;
using MissTortasEngine.Model.Security.User;

namespace MissTortasEngine.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MissTortasEngineContext _context;

        public OrderController(MissTortasEngineContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderBase>>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderBase>> GetOrderBase(long id)
        {
            var orderBase = await _context.OrderItems.FindAsync(id);

            if (orderBase == null)
            {
                return NotFound();
            }

            return orderBase;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderBase(long id, OrderBase orderBase)
        {
            if (id != orderBase.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderBaseExists(id))
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

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderBase>> PostOrderBase(OrderRegistrationDTO orderDto)
        {
            var orderType = await _context.OrderTypes.FindAsync(orderDto.OrderType);
            if (orderType == null)
            {
                return NotFound("Order type not found");
            }
            var orderManager = await _context.Users.FindAsync(orderDto.OrderManager);
            if (orderManager == null)
            {
                return NotFound("Order manager not found");
            }
            var client = await _context.Users.FindAsync(orderDto.OrderManager);
            if (client == null)
            {
                return NotFound("Client not found");
            }
            var newOrder = new OrderBase { OrderType = orderType, OrderManager = orderManager, Client = client };
            _context.OrderItems.Add(newOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderBase), new { id = newOrder.Id }, newOrder);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderBase(long id)
        {
            var orderBase = await _context.OrderItems.FindAsync(id);
            if (orderBase == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderBase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderBaseExists(long id)
        {
            return _context.OrderItems.Any(e => e.Id == id);
        }
    }
}
