using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreApi.Models;

namespace NetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly CItemContext _context;

        public ItemController(CItemContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CItemModel>>> GetItems()
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            return await _context.Items.ToListAsync();
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CItemModel>> GetCItemModel(long id)
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            var cItemModel = await _context.Items.FindAsync(id);

            if (cItemModel == null)
            {
                return NotFound();
            }

            return cItemModel;
        }

        // PUT: api/Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCItemModel(long id, CItemModel cItemModel)
        {
            if (id != cItemModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(cItemModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CItemModelExists(id))
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

        // POST: api/Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CItemModel>> PostCItemModel(CItemModel cItemModel)
        {
          if (_context.Items == null)
          {
              return Problem("Entity set 'CItemContext.Items'  is null.");
          }
            _context.Items.Add(cItemModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCItemModel", new { id = cItemModel.Id }, cItemModel);
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCItemModel(long id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var cItemModel = await _context.Items.FindAsync(id);
            if (cItemModel == null)
            {
                return NotFound();
            }

            _context.Items.Remove(cItemModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CItemModelExists(long id)
        {
            return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
