using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleBuyWebAPI.Data;
using PeopleBuyWebAPI.Models;

namespace PeopleBuyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalPersonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LegalPersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LegalPersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalPerson>>> GetLegalPerson()
        {
            return await _context.LegalPerson.ToListAsync();
        }

        // GET: api/LegalPersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LegalPerson>> GetLegalPerson(int id)
        {
            var legalPerson = await _context.LegalPerson.FindAsync(id);

            if (legalPerson == null)
            {
                return NotFound();
            }

            return legalPerson;
        }

        // PUT: api/LegalPersons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegalPerson(int id, LegalPerson legalPerson)
        {
            if (id != legalPerson.ID)
            {
                return BadRequest();
            }

            _context.Entry(legalPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegalPersonExists(id))
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

        // POST: api/LegalPersons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LegalPerson>> PostLegalPerson(LegalPerson legalPerson)
        {
            _context.LegalPerson.Add(legalPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLegalPerson", new { id = legalPerson.ID }, legalPerson);
        }

        // DELETE: api/LegalPersons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLegalPerson(int id)
        {
            var legalPerson = await _context.LegalPerson.FindAsync(id);
            if (legalPerson == null)
            {
                return NotFound();
            }

            _context.LegalPerson.Remove(legalPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LegalPersonExists(int id)
        {
            return _context.LegalPerson.Any(e => e.ID == id);
        }
    }
}
