using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookStore.Server.Data;
using BookStore.Shared;

namespace BookStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesItemsController : ControllerBase
    {
        private readonly DataContext _context;

        public SalesItemsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SalesItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesItem>>> GetSalesItems()
        {
          if (_context.SalesItems == null)
          {
              return NotFound();
          }
            return await _context.SalesItems
                .Include(si => si.Sale)
                .Include(si => si.Sale!.Customer)
                .Include(si => si.Book)
                .ToListAsync();
        }

        // GET: api/SalesItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesItem>> GetSalesItem(int id)
        {
          if (_context.SalesItems == null)
          {
              return NotFound();
          }
            var salesItem = await _context.SalesItems
				.Include(si => si.Sale)
				.Include(si => si.Sale!.Customer)
				.Include(si => si.Book)
				.FirstOrDefaultAsync(si => si.SalesItemId == id);

            if (salesItem == null)
            {
                return NotFound();
            }

            return salesItem;
        }

        // PUT: api/SalesItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesItem(int id, SalesItem salesItem)
        {
            if (id != salesItem.SalesItemId)
            {
                return BadRequest();
            }

            _context.Entry(salesItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesItemExists(id))
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

        // POST: api/SalesItems
        [HttpPost]
        public async Task<ActionResult<SalesItem>> PostSalesItem(SalesItem salesItem)
        {
          if (_context.SalesItems == null)
          {
              return Problem("Entity set 'DataContext.SalesItems'  is null.");
          }
            _context.SalesItems.Add(salesItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesItem", new { id = salesItem.SalesItemId }, salesItem);
        }

        [HttpPost("bundle")]
        public async Task<ActionResult<SalesItem>> PostSalesItemsBundle(List<SalesItem> salesItem)
        {
            if (_context.SalesItems == null)
            {
                return Problem("Entity set 'DataContext.SalesItems'  is null.");
            }
            foreach (var saleItem in salesItem)
            {
                _context.SalesItems.Add(saleItem);
                await _context.SaveChangesAsync();

            }

            return CreatedAtAction("GetSalesItem", salesItem);
        }

        // DELETE: api/SalesItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesItem(int id)
        {
            if (_context.SalesItems == null)
            {
                return NotFound();
            }
            var salesItem = await _context.SalesItems.FindAsync(id);
            if (salesItem == null)
            {
                return NotFound();
            }

            _context.SalesItems.Remove(salesItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesItemExists(int id)
        {
            return (_context.SalesItems?.Any(e => e.SalesItemId == id)).GetValueOrDefault();
        }
    }
}
