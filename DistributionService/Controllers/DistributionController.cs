using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using DistributionService.Data;

namespace DistributionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributionController : ControllerBase
    {
        private readonly DistributionServiceContext _context;

        public DistributionController(DistributionServiceContext context)
        {
            _context = context;
        }

        // GET: api/Distributions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetDistribution()
        {
          if (_context.Distribution == null)
          {
              return NotFound();
          }
            return await _context.Distribution.ToListAsync();
        }

        // GET: api/Distributions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetDistribution(int id)
        {
          if (_context.Distribution == null)
          {
              return NotFound();
          }
            var distribution = await _context.Distribution.FindAsync(id);

            if (distribution == null)
            {
                return NotFound();
            }

            return distribution;
        }

        // PUT: api/Distributions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistribution(int id, Order distribution)
        {
            if (id != distribution.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(distribution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/GetDistributions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostDistribution(Order order)
        {
          if (_context.Distribution == null)
          {
              return Problem("Entity set 'DistributionServiceContext.GetDistribution'  is null.");
          }
            _context.Distribution.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistribution", new { id = order.OrderID }, order);
        }

        // DELETE: api/GetDistributions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistribution(int id)
        {
            if (_context.Distribution == null)
            {
                return NotFound();
            }
            var order = await _context.Distribution.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Distribution.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Distribution?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
