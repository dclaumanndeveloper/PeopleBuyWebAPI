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
    public class PhysicalPersonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PhysicalPersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PhysicalPersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhysicalPerson>>> GetPhysicalPerson()
        {
            return await _context.PhysicalPerson.ToListAsync();
        }

        // GET: api/PhysicalPersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhysicalPerson>> GetPhysicalPerson(int id)
        {
            var physicalPerson = await _context.PhysicalPerson.FindAsync(id);

            if (physicalPerson == null)
            {
                return NotFound();
            }

            return physicalPerson;
        }

        // PUT: api/PhysicalPersons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhysicalPerson(int id, PhysicalPerson physicalPerson)
        {
            if (id != physicalPerson.ID)
            {
                return BadRequest();
            }

            _context.Entry(physicalPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhysicalPersonExists(id))
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

        // POST: api/PhysicalPersons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhysicalPerson>> PostPhysicalPerson(PhysicalPerson physicalPerson)
        {
            _context.PhysicalPerson.Add(physicalPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhysicalPerson", new { id = physicalPerson.ID }, physicalPerson);
        }

        // DELETE: api/PhysicalPersons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhysicalPerson(int id)
        {
            var physicalPerson = await _context.PhysicalPerson.FindAsync(id);
            if (physicalPerson == null)
            {
                return NotFound();
            }

            _context.PhysicalPerson.Remove(physicalPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhysicalPersonExists(int id)
        {
            return _context.PhysicalPerson.Any(e => e.ID == id);
        }
    }
}
