using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using MonitoringService.Data;

namespace MonitoringService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoringsController : ControllerBase
    {
        private readonly MonitoringServiceContext _context;

        public MonitoringsController(MonitoringServiceContext context)
        {
            _context = context;
        }

        // GET: api/Monitorings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetMonitoring()
        {
          if (_context.Monitoring == null)
          {
              return NotFound();
          }
            return await _context.Monitoring.ToListAsync();
        }

        // GET: api/Monitorings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetMonitoring(int id)
        {
          if (_context.Monitoring == null)
          {
              return NotFound();
          }
            var monitoring = await _context.Monitoring.FindAsync(id);

            if (monitoring == null)
            {
                return NotFound();
            }

            return monitoring;
        }

        // PUT: api/Monitorings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonitoring(int id, Order monitoring)
        {
            if (id != monitoring.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(monitoring).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitoringExists(id))
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

        // POST: api/Monitorings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostMonitoring(Order monitoring)
        {
          if (_context.Monitoring == null)
          {
              return Problem("Entity set 'MonitoringServiceContext.Monitoring'  is null.");
          }
            _context.Monitoring.Add(monitoring);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonitoring", new { id = monitoring.OrderID }, monitoring);
        }

        // DELETE: api/Monitorings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonitoring(int id)
        {
            if (_context.Monitoring == null)
            {
                return NotFound();
            }
            var monitoring = await _context.Monitoring.FindAsync(id);
            if (monitoring == null)
            {
                return NotFound();
            }

            _context.Monitoring.Remove(monitoring);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonitoringExists(int id)
        {
            return (_context.Monitoring?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
