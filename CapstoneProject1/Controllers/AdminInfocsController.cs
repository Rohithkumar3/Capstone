using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapstoneProject1.Data;
using CapstoneProject1.Models;

namespace CapstoneProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminInfocsController : ControllerBase
    {
        private readonly CapstoneProject1Context _context;

        public AdminInfocsController(CapstoneProject1Context context)
        {
            _context = context;
        }

        // GET: api/AdminInfocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminInfocs>>> GetAdminInfocs()
        {
          if (_context.AdminInfocs == null)
          {
              return NotFound();
          }
            return await _context.AdminInfocs.ToListAsync();
        }

        // GET: api/AdminInfocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminInfocs>> GetAdminInfocs(int id)
        {
          if (_context.AdminInfocs == null)
          {
              return NotFound();
          }
            var adminInfocs = await _context.AdminInfocs.FindAsync(id);

            if (adminInfocs == null)
            {
                return NotFound();
            }

            return adminInfocs;
        }

        // PUT: api/AdminInfocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminInfocs(int id, AdminInfocs adminInfocs)
        {
            if (id != adminInfocs.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(adminInfocs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminInfocsExists(id))
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

        // POST: api/AdminInfocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminInfocs>> PostAdminInfocs(AdminInfocs adminInfocs)
        {
          if (_context.AdminInfocs == null)
          {
              return Problem("Entity set 'CapstoneProject1Context.AdminInfocs'  is null.");
          }
            _context.AdminInfocs.Add(adminInfocs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminInfocs", new { id = adminInfocs.AdminId }, adminInfocs);
        }

        // DELETE: api/AdminInfocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminInfocs(int id)
        {
            if (_context.AdminInfocs == null)
            {
                return NotFound();
            }
            var adminInfocs = await _context.AdminInfocs.FindAsync(id);
            if (adminInfocs == null)
            {
                return NotFound();
            }

            _context.AdminInfocs.Remove(adminInfocs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminInfocsExists(int id)
        {
            return (_context.AdminInfocs?.Any(e => e.AdminId == id)).GetValueOrDefault();
        }
    }
}
