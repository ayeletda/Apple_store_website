using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchAirpodsProductsController : ControllerBase
    {
        private readonly AppleDBContext _context;

        public WatchAirpodsProductsController(AppleDBContext context)
        {
            _context = context;
        }

        // GET: api/WatchAirpodsProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WatchAirpodsProduct>>> GetWatchAirpodsProducts()
        {
          if (_context.WatchAirpodsProducts == null)
          {
              return NotFound();
          }
            return await _context.WatchAirpodsProducts.ToListAsync();
        }

        // GET: api/WatchAirpodsProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WatchAirpodsProduct>> GetWatchAirpodsProduct(int id)
        {
          if (_context.WatchAirpodsProducts == null)
          {
              return NotFound();
          }
            var watchAirpodsProduct = await _context.WatchAirpodsProducts.FindAsync(id);

            if (watchAirpodsProduct == null)
            {
                return NotFound();
            }

            return watchAirpodsProduct;
        }

        // PUT: api/WatchAirpodsProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWatchAirpodsProduct(int id, WatchAirpodsProduct watchAirpodsProduct)
        {
            if (id != watchAirpodsProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(watchAirpodsProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchAirpodsProductExists(id))
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

        // POST: api/WatchAirpodsProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WatchAirpodsProduct>> PostWatchAirpodsProduct(WatchAirpodsProduct watchAirpodsProduct)
        {
          if (_context.WatchAirpodsProducts == null)
          {
              return Problem("Entity set 'AppleDBContext.WatchAirpodsProducts'  is null.");
          }
            _context.WatchAirpodsProducts.Add(watchAirpodsProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWatchAirpodsProduct", new { id = watchAirpodsProduct.Id }, watchAirpodsProduct);
        }

        // DELETE: api/WatchAirpodsProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWatchAirpodsProduct(int id)
        {
            if (_context.WatchAirpodsProducts == null)
            {
                return NotFound();
            }
            var watchAirpodsProduct = await _context.WatchAirpodsProducts.FindAsync(id);
            if (watchAirpodsProduct == null)
            {
                return NotFound();
            }

            _context.WatchAirpodsProducts.Remove(watchAirpodsProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WatchAirpodsProductExists(int id)
        {
            return (_context.WatchAirpodsProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
