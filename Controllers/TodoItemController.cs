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
    public class TodoItemController : ControllerBase
    {
        private readonly CTodoContext _context;

        public TodoItemController(CTodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CTodoItemModel>>> GetColTodoItem()
        {
          if (_context.ColTodoItem == null)
          {
              return NotFound();
          }
            return await _context.ColTodoItem.ToListAsync();
        }

        // GET: api/TodoItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CTodoItemModel>> GetCTodoItemModel(long id)
        {
          if (_context.ColTodoItem == null)
          {
              return NotFound();
          }
            var cTodoItemModel = await _context.ColTodoItem.FindAsync(id);

            if (cTodoItemModel == null)
            {
                return NotFound();
            }

            return cTodoItemModel;
        }

        // PUT: api/TodoItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCTodoItemModel(long id, CTodoItemModel cTodoItemModel)
        {
            if (id != cTodoItemModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(cTodoItemModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CTodoItemModelExists(id))
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

        // POST: api/TodoItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CTodoItemModel>> PostCTodoItemModel(CTodoItemModel cTodoItemModel)
        {
          if (_context.ColTodoItem == null)
          {
              return Problem("Entity set 'CTodoContext.ColTodoItem'  is null.");
          }
            _context.ColTodoItem.Add(cTodoItemModel);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetCTodoItemModel", new { id = cTodoItemModel.Id }, cTodoItemModel);
            return CreatedAtAction(nameof(GetCTodoItemModel), new { id = cTodoItemModel.Id }, cTodoItemModel);
        }

        // DELETE: api/TodoItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCTodoItemModel(long id)
        {
            if (_context.ColTodoItem == null)
            {
                return NotFound();
            }
            var cTodoItemModel = await _context.ColTodoItem.FindAsync(id);
            if (cTodoItemModel == null)
            {
                return NotFound();
            }

            _context.ColTodoItem.Remove(cTodoItemModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CTodoItemModelExists(long id)
        {
            return (_context.ColTodoItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
