using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using ValidationService.Data;

namespace ValidationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationsController : ControllerBase
    {
        private readonly ValidationServiceContext _context;

        public ValidationsController(ValidationServiceContext context)
        {
            _context = context;
        }

        // GET: api/Validations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetValidation()
        {
          if (_context.Validation == null)
          {
              return NotFound();
          }
            return await _context.Validation.ToListAsync();
        }

        // GET: api/Validations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetValidation(int id)
        {
          if (_context.Validation == null)
          {
              return NotFound();
          }
            var validation = await _context.Validation.FindAsync(id);

            if (validation == null)
            {
                return NotFound();
            }

            return validation;
        }

        // PUT: api/Validations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValidation(int id, Order validation)
        {
            if (id != validation.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(validation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValidationExists(id))
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

        // POST: api/Validations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostValidation(Order order)
        {
          if (_context.Validation == null)
          {
              return Problem("Entity set 'ValidationServiceContext.Validation'  is null.");
          }
            _context.Validation.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);
        }

        // DELETE: api/Validations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Validation == null)
            {
                return NotFound();
            }
            var order = await _context.Validation.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Validation.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValidationExists(int id)
        {
            return (_context.Validation?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
