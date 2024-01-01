using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using PreparationService.Data;

namespace PreparationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreparationsController : ControllerBase
    {
        private readonly PreparationServiceContext _context;

        public PreparationsController(PreparationServiceContext context)
        {
            _context = context;
        }

        // GET: api/Preparations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medication>>> GetPreparation()
        {
          if (_context.Preparation == null)
          {
              return NotFound();
          }
            return await _context.Preparation.ToListAsync();
        }

        // GET: api/Preparations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetPreparation(int id)
        {
          if (_context.Preparation == null)
          {
              return NotFound();
          }
            var preparation = await _context.Preparation.FindAsync(id);

            if (preparation == null)
            {
                return NotFound();
            }

            return preparation;
        }

        // PUT: api/Preparations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreparation(int id, Medication preparation)
        {
            if (id != preparation.MedicationID)
            {
                return BadRequest();
            }

            _context.Entry(preparation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreparationExists(id))
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

        // POST: api/Preparations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medication>> PostPreparation(Medication preparation)
        {
          if (_context.Preparation == null)
          {
              return Problem("Entity set 'PreparationServiceContext.Preparation'  is null.");
          }
            _context.Preparation.Add(preparation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreparation", new { id = preparation.MedicationID }, preparation);
        }

        // DELETE: api/Preparations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedication(int id)
        {
            if (_context.Preparation == null)
            {
                return NotFound();
            }
            var preparation = await _context.Preparation.FindAsync(id);
            if (preparation == null)
            {
                return NotFound();
            }

            _context.Preparation.Remove(preparation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreparationExists(int id)
        {
            return (_context.Preparation?.Any(e => e.MedicationID == id)).GetValueOrDefault();
        }
    }
}
