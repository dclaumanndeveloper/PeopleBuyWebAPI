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
    public class DailyOffersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DailyOffersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyOffers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyOffer>>> GetDailyOffer()
        {
            return await _context.DailyOffer.ToListAsync();
        }

        // GET: api/DailyOffers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyOffer>> GetDailyOffer(int id)
        {
            var dailyOffer = await _context.DailyOffer.FindAsync(id);

            if (dailyOffer == null)
            {
                return NotFound();
            }

            return dailyOffer;
        }

        // PUT: api/DailyOffers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyOffer(int id, DailyOffer dailyOffer)
        {
            if (id != dailyOffer.ID)
            {
                return BadRequest();
            }

            _context.Entry(dailyOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyOfferExists(id))
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

        // POST: api/DailyOffers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DailyOffer>> PostDailyOffer(DailyOffer dailyOffer)
        {
            _context.DailyOffer.Add(dailyOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyOffer", new { id = dailyOffer.ID }, dailyOffer);
        }

        // DELETE: api/DailyOffers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyOffer(int id)
        {
            var dailyOffer = await _context.DailyOffer.FindAsync(id);
            if (dailyOffer == null)
            {
                return NotFound();
            }

            _context.DailyOffer.Remove(dailyOffer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DailyOfferExists(int id)
        {
            return _context.DailyOffer.Any(e => e.ID == id);
        }
    }
}
