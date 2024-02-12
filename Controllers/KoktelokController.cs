using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KoktelosAPIKezdemeny.Models;

namespace KoktelosAPIKezdemeny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoktelokController : ControllerBase
    {
        private readonly Koktelok_Adatbazisa _context;

        public KoktelokController(Koktelok_Adatbazisa context)
        {
            _context = context;
        }

        // GET: api/Koktelok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Koktel>>> GetKoktelok()
        {
          if (_context.Koktelok == null)
          {
              return NotFound();
          }
            return await _context.Koktelok.ToListAsync();
        }

        // GET: api/Koktelok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Koktel>> GetKoktel(int id)
        {
          if (_context.Koktelok == null)
          {
              return NotFound();
          }
            var koktel = await _context.Koktelok.FindAsync(id);

            if (koktel == null)
            {
                return NotFound();
            }

            return koktel;
        }

        // PUT: api/Koktelok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKoktel(int id, Koktel koktel)
        {
            if (id != koktel.Id)
            {
                return BadRequest();
            }

            _context.Entry(koktel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KoktelExists(id))
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

        // POST: api/Koktelok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Koktel>> PostKoktel(Koktel koktel)
        {
          if (_context.Koktelok == null)
          {
              return Problem("Entity set 'Koktelok_Adatbazisa.Koktelok'  is null.");
          }
            _context.Koktelok.Add(koktel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKoktel", new { id = koktel.Id }, koktel);
        }

        // DELETE: api/Koktelok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKoktel(int id)
        {
            if (_context.Koktelok == null)
            {
                return NotFound();
            }
            var koktel = await _context.Koktelok.FindAsync(id);
            if (koktel == null)
            {
                return NotFound();
            }

            _context.Koktelok.Remove(koktel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KoktelExists(int id)
        {
            return (_context.Koktelok?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
