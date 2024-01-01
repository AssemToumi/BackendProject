using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using PrescriptionService.Data;

namespace PrescriptionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly PrescriptionServiceContext _context;

        public PrescriptionsController(PrescriptionServiceContext context)
        {
            _context = context;
        }

        // GET: api/Prescriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPrescription()
        {
          if (_context.Prescription == null)
          {
              return NotFound();
          }
            return await _context.Prescription.ToListAsync();
        }

        // GET: api/Prescriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPrescription(int id)
        {
          if (_context.Prescription == null)
          {
              return NotFound();
          }
            var prescription = await _context.Prescription.FindAsync(id);

            if (prescription == null)
            {
                return NotFound();
            }

            return prescription;
        }

        // PUT: api/Prescriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescription(int id, Patient prescription)
        {
            if (id != prescription.PatientId)
            {
                return BadRequest();
            }

            _context.Entry(prescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescriptionExists(id))
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

        // POST: api/Prescriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPrescription(Patient prescription)
        {
          if (_context.Prescription == null)
          {
              return Problem("Entity set 'PrescriptionServiceContext.Prescription'  is null.");
          }
            _context.Prescription.Add(prescription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrescription", new { id = prescription.PatientId }, prescription);
        }

        // DELETE: api/Prescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            if (_context.Prescription == null)
            {
                return NotFound();
            }
            var patient = await _context.Prescription.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Prescription.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrescriptionExists(int id)
        {
            return (_context.Prescription?.Any(e => e.PatientId == id)).GetValueOrDefault();
        }
    }
}
