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
    public class ShoppingCartProductsController : ControllerBase
    {
        private readonly AppleDBContext _context;

        public ShoppingCartProductsController(AppleDBContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingCartProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCartProduct>>> GetShoppingCartProducts()
        {
          if (_context.ShoppingCartProducts == null)
          {
              return NotFound();
          }
            return await _context.ShoppingCartProducts.ToListAsync();
        }

        // GET: api/ShoppingCartProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartProduct>> GetShoppingCartProduct(int id)
        {
          if (_context.ShoppingCartProducts == null)
          {
              return NotFound();
          }
            var shoppingCartProduct = await _context.ShoppingCartProducts.FindAsync(id);

            if (shoppingCartProduct == null)
            {
                return NotFound();
            }

            return shoppingCartProduct;
        }

        // PUT: api/ShoppingCartProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingCartProduct(int id, ShoppingCartProduct shoppingCartProduct)
        {
            if (id != shoppingCartProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingCartProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCartProductExists(id))
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

        // POST: api/ShoppingCartProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingCartProduct>> PostShoppingCartProduct(ShoppingCartProduct shoppingCartProduct)
        {
          if (_context.ShoppingCartProducts == null)
          {
              return Problem("Entity set 'AppleDBContext.ShoppingCartProducts'  is null.");
          }
            _context.ShoppingCartProducts.Add(shoppingCartProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingCartProduct", new { id = shoppingCartProduct.Id }, shoppingCartProduct);
        }

        // DELETE: api/ShoppingCartProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingCartProduct(int id)
        {
            if (_context.ShoppingCartProducts == null)
            {
                return NotFound();
            }
            var shoppingCartProduct = await _context.ShoppingCartProducts.FindAsync(id);
            if (shoppingCartProduct == null)
            {
                return NotFound();
            }

            _context.ShoppingCartProducts.Remove(shoppingCartProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingCartProductExists(int id)
        {
            return (_context.ShoppingCartProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
