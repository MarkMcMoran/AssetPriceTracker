using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssetPriceTracker.Models;

namespace AssetPriceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoItemsController : ControllerBase
    {
        private readonly CryptoItemContext _context;

        public CryptoItemsController(CryptoItemContext context)
        {
            _context = context;
        }

        // GET: api/CryptoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CryptoItem>>> GetCryptoItem()
        {
          if (_context.CryptoItem == null)
          {
              return NotFound();
          }
            return await _context.CryptoItem.ToListAsync();
        }

        // GET: api/CryptoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CryptoItem>> GetCryptoItem(long id)
        {
          if (_context.CryptoItem == null)
          {
              return NotFound();
          }
            var cryptoItem = await _context.CryptoItem.FindAsync(id);

            if (cryptoItem == null)
            {
                return NotFound();
            }

            return cryptoItem;
        }

        // PUT: api/CryptoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCryptoItem(long id, CryptoItem cryptoItem)
        {
            if (id != cryptoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(cryptoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CryptoItemExists(id))
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

        // POST: api/CryptoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CryptoItem>> PostCryptoItem(CryptoItem cryptoItem)
        {
          if (_context.CryptoItem == null)
          {
              return Problem("Entity set 'CryptoItemContext.CryptoItem'  is null.");
          }
            _context.CryptoItem.Add(cryptoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCryptoItem", new { id = cryptoItem.Id }, cryptoItem);
        }

        // DELETE: api/CryptoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCryptoItem(long id)
        {
            if (_context.CryptoItem == null)
            {
                return NotFound();
            }
            var cryptoItem = await _context.CryptoItem.FindAsync(id);
            if (cryptoItem == null)
            {
                return NotFound();
            }

            _context.CryptoItem.Remove(cryptoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CryptoItemExists(long id)
        {
            return (_context.CryptoItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
