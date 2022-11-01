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
    public class MacIpadIphoneProductsController : ControllerBase
    {
        private readonly AppleDBContext _context;

        public MacIpadIphoneProductsController(AppleDBContext context)
        {
            _context = context;
        }

        // GET: api/MacIpadIphoneProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MacIpadIphoneProduct>>> GetMacIpadIphoneProducts()
        {
          if (_context.MacIpadIphoneProducts == null)
          {
              return NotFound();
          }
            return await _context.MacIpadIphoneProducts.ToListAsync();
        }

        // GET: api/MacIpadIphoneProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MacIpadIphoneProduct>> GetMacIpadIphoneProduct(int id)
        {
          if (_context.MacIpadIphoneProducts == null)
          {
              return NotFound();
          }
            var macIpadIphoneProduct = await _context.MacIpadIphoneProducts.FindAsync(id);

            if (macIpadIphoneProduct == null)
            {
                return NotFound();
            }

            return macIpadIphoneProduct;
        }

        // PUT: api/MacIpadIphoneProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMacIpadIphoneProduct(int id, MacIpadIphoneProduct macIpadIphoneProduct)
        {
            if (id != macIpadIphoneProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(macIpadIphoneProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MacIpadIphoneProductExists(id))
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

        // POST: api/MacIpadIphoneProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MacIpadIphoneProduct>> PostMacIpadIphoneProduct(MacIpadIphoneProduct macIpadIphoneProduct)
        {
          if (_context.MacIpadIphoneProducts == null)
          {
              return Problem("Entity set 'AppleDBContext.MacIpadIphoneProducts'  is null.");
          }
            _context.MacIpadIphoneProducts.Add(macIpadIphoneProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMacIpadIphoneProduct", new { id = macIpadIphoneProduct.Id }, macIpadIphoneProduct);
        }

        // DELETE: api/MacIpadIphoneProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMacIpadIphoneProduct(int id)
        {
            if (_context.MacIpadIphoneProducts == null)
            {
                return NotFound();
            }
            var macIpadIphoneProduct = await _context.MacIpadIphoneProducts.FindAsync(id);
            if (macIpadIphoneProduct == null)
            {
                return NotFound();
            }

            _context.MacIpadIphoneProducts.Remove(macIpadIphoneProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MacIpadIphoneProductExists(int id)
        {
            return (_context.MacIpadIphoneProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
