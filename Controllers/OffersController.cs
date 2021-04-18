using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleBuyWebAPI.Data;
using PeopleBuyWebAPI.Models;
using System.Net.Http;

namespace PeopleBuyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OffersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffer()
        {
            return await _context.Offer.ToListAsync();
        }

        // GET: api/Offers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> GetOffer(int id)
        {
            var offer = await _context.Offer.FindAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            return offer;
        }

        // PUT: api/Offers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffer(int id, Offer offer)
        {
            if (id != offer.ID)
            {
                return BadRequest();
            }

            _context.Entry(offer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(id))
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

        // POST: api/Offers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Offer>> PostOffer(Offer offer)
        {
            _context.Offer.Add(offer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffer", new { id = offer.ID }, offer);
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var offer = await _context.Offer.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            _context.Offer.Remove(offer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        public JsonResult GetOffer(double alcance, double latitude, double longitude, int categoriaId, String buscanome, String key)
        {
            List<Offer> offers = new List<Offer>();
            List<Offer> offerfiltred = new List<Offer>();
            String chave = "v24w!7RarunEVC*A@7Za!UfATeTrac";
            if (key.Equals(chave))
            {

                if (categoriaId == 0)
                {
                    if (buscanome != null)
                    {
                        offers = new List<Offer>(_context.Offer.Include(x => x.LegalPerson.Localization).Where(x => x.Name.Contains(buscanome) || x.Description.Contains(buscanome) && x.Active.Equals('S')).OrderBy(m => m.Price).ToList());
                    }
                    else
                    {
                        offers = new List<Offer>(_context.Offer.Include(x => x.LegalPerson.Localization).Where(x => x.Active.Equals('S')).OrderBy(m => m.Price).ToList());
                    }
                }
                if (categoriaId != 0)
                {
                    if (buscanome != null)
                    {
                        offers = new List<Offer>(_context.Offer.Include(x => x.LegalPerson.Localization).Where(x => x.Category.ID == categoriaId && x.Name.Contains(buscanome) || x.Description.Contains(buscanome) && x.Active.Equals('S')).OrderBy(m => m.Price).ToList());
                    }
                    else
                    {
                        offers = new List<Offer>(_context.Offer.Include(x => x.LegalPerson.Localization).Where(x => x.Category.ID == categoriaId && x.Active.Equals('S')).OrderBy(m => m.Price).ToList());
                    }
                }

                foreach (var offer in offers)
                {
                    double calculo = CalculationGeoCoding.Calculate(offer.LegalPerson.Localization.Latitude, offer.LegalPerson.Localization.Longitude, latitude, longitude);
                    if (calculo <= alcance && calculo >= 0)
                    {
                        offerfiltred.Add(offer);
                    }
                }
                JsonResult json = new JsonResult(offerfiltred);
                return json;
            }
            else
            {
                return null;
            }
        }

        private bool OfferExists(int id)
        {
            return _context.Offer.Any(e => e.ID == id);
        }
    }
}
