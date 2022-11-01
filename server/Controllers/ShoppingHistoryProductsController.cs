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
    public class ShoppingHistoryProductsController : ControllerBase
    {
        private readonly AppleDBContext _context;

        public ShoppingHistoryProductsController(AppleDBContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingHistoryProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingHistoryProduct>>> GetShoppingHistoryProducts()
        {
          if (_context.ShoppingHistoryProducts == null)
          {
              return NotFound();
          }
            return await _context.ShoppingHistoryProducts.ToListAsync();
        }

        // GET: api/ShoppingHistoryProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingHistoryProduct>> GetShoppingHistoryProduct(int id)
        {
          if (_context.ShoppingHistoryProducts == null)
          {
              return NotFound();
          }
            var shoppingHistoryProduct = await _context.ShoppingHistoryProducts.FindAsync(id);

            if (shoppingHistoryProduct == null)
            {
                return NotFound();
            }

            return shoppingHistoryProduct;
        }

        // PUT: api/ShoppingHistoryProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingHistoryProduct(int id, ShoppingHistoryProduct shoppingHistoryProduct)
        {
            if (id != shoppingHistoryProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingHistoryProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingHistoryProductExists(id))
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

        // POST: api/ShoppingHistoryProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingHistoryProduct>> PostShoppingHistoryProduct(ShoppingHistoryProduct shoppingHistoryProduct)
        {
          if (_context.ShoppingHistoryProducts == null)
          {
              return Problem("Entity set 'AppleDBContext.ShoppingHistoryProducts'  is null.");
          }
            _context.ShoppingHistoryProducts.Add(shoppingHistoryProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingHistoryProduct", new { id = shoppingHistoryProduct.Id }, shoppingHistoryProduct);
        }

        // DELETE: api/ShoppingHistoryProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingHistoryProduct(int id)
        {
            if (_context.ShoppingHistoryProducts == null)
            {
                return NotFound();
            }
            var shoppingHistoryProduct = await _context.ShoppingHistoryProducts.FindAsync(id);
            if (shoppingHistoryProduct == null)
            {
                return NotFound();
            }

            _context.ShoppingHistoryProducts.Remove(shoppingHistoryProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingHistoryProductExists(int id)
        {
            return (_context.ShoppingHistoryProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
