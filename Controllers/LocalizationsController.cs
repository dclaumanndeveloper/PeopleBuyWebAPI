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
    public class LocalizationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LocalizationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Localizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localization>>> GetLocalization()
        {
            return await _context.Localization.ToListAsync();
        }

        // GET: api/Localizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Localization>> GetLocalization(int id)
        {
            var localization = await _context.Localization.FindAsync(id);

            if (localization == null)
            {
                return NotFound();
            }

            return localization;
        }

        // PUT: api/Localizations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalization(int id, Localization localization)
        {
            if (id != localization.ID)
            {
                return BadRequest();
            }

            _context.Entry(localization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalizationExists(id))
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

        // POST: api/Localizations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Localization>> PostLocalization(Localization localization)
        {
            _context.Localization.Add(localization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalization", new { id = localization.ID }, localization);
        }

        // DELETE: api/Localizations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalization(int id)
        {
            var localization = await _context.Localization.FindAsync(id);
            if (localization == null)
            {
                return NotFound();
            }

            _context.Localization.Remove(localization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocalizationExists(int id)
        {
            return _context.Localization.Any(e => e.ID == id);
        }
    }
}
