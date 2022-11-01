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
    public class ShoppingHistorysController : ControllerBase
    {
        private readonly AppleDBContext _context;

        public ShoppingHistorysController(AppleDBContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingHistorys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingHistory>>> GetShoppingHistories()
        {
          if (_context.ShoppingHistories == null)
          {
              return NotFound();
          }
            return await _context.ShoppingHistories.ToListAsync();
        }

        // GET: api/ShoppingHistorys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingHistory>> GetShoppingHistory(int id)
        {
          if (_context.ShoppingHistories == null)
          {
              return NotFound();
          }
            var shoppingHistory = await _context.ShoppingHistories.FindAsync(id);

            if (shoppingHistory == null)
            {
                return NotFound();
            }

            return shoppingHistory;
        }

        // PUT: api/ShoppingHistorys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingHistory(int id, ShoppingHistory shoppingHistory)
        {
            if (id != shoppingHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingHistoryExists(id))
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

        // POST: api/ShoppingHistorys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingHistory>> PostShoppingHistory(ShoppingHistory shoppingHistory)
        {
          if (_context.ShoppingHistories == null)
          {
              return Problem("Entity set 'AppleDBContext.ShoppingHistories'  is null.");
          }
            _context.ShoppingHistories.Add(shoppingHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingHistory", new { id = shoppingHistory.Id }, shoppingHistory);
        }

        // DELETE: api/ShoppingHistorys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingHistory(int id)
        {
            if (_context.ShoppingHistories == null)
            {
                return NotFound();
            }
            var shoppingHistory = await _context.ShoppingHistories.FindAsync(id);
            if (shoppingHistory == null)
            {
                return NotFound();
            }

            _context.ShoppingHistories.Remove(shoppingHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingHistoryExists(int id)
        {
            return (_context.ShoppingHistories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
