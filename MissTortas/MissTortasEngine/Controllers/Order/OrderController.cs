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
    public class OrderController : ControllerBase
    {
        private readonly MissTortasEngineContext _context;

        public OrderController(MissTortasEngineContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderBase(long id)
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
        public async Task<IActionResult> PutOrderBase(long id, OrderDTO orderBase)
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
        public async Task<ActionResult<OrderDTO>> PostOrderBase(OrderDTO orderDto)
        {
            _context.
            _context.OrderItems.Add(orderDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderBase), new { id = orderDto.Id }, orderDto);
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
