using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissTortasEngine.Model;
using MissTortasEngine.Model.Order;

namespace MissTortasEngine.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTypeController : ControllerBase
    {
        private readonly MissTortasEngineContext _context;

        public OrderTypeController(MissTortasEngineContext context)
        {
            _context = context;
        }

        // GET: api/OrderType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderType>>> GetOrderType()
        {
            return await _context.OrderTypes.ToListAsync();
        }

        // GET: api/OrderType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderType>> GetOrderType(long id)
        {
            var orderType = await _context.OrderTypes.FindAsync(id);

            if (orderType == null)
            {
                return NotFound();
            }

            return orderType;
        }

        // PUT: api/OrderType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderType(long id, OrderType orderType)
        {
            if (id != orderType.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderTypeExists(id))
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

        // POST: api/OrderType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderType>> PostOrderType(OrderType orderType)
        {
            _context.OrderTypes.Add(orderType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderType), new { id = orderType.Id }, orderType);
        }

        // DELETE: api/OrderType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderType(long id)
        {
            var orderType = await _context.OrderTypes.FindAsync(id);
            if (orderType == null)
            {
                return NotFound();
            }

            _context.OrderTypes.Remove(orderType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderTypeExists(long id)
        {
            return _context.OrderTypes.Any(e => e.Id == id);
        }
    }
}
