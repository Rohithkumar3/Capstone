using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstoneProject1.Data;
using CapstoneProject1.Models;
using Mvc.Models;

namespace Mvc.Controllers
{
    public class AdminInfocsController : Controller
    {
        private readonly CapstoneProject1Context _context;

        public AdminInfocsController(CapstoneProject1Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                // Check if the provided credentials are valid
                var user = await _context.AdminInfocs
                    .FirstOrDefaultAsync(u => u.EmailId == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    // Redirect to a dashboard or another page after successful login
                    return RedirectToAction("Index", "EmpInfoes");
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid login attempt";
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }

            return View(model);
        }



        // GET: AdminInfocs
        public async Task<IActionResult> Index()
        {
              return _context.AdminInfocs != null ? 
                          View(await _context.AdminInfocs.ToListAsync()) :
                          Problem("Entity set 'CapstoneProject1Context.AdminInfocs'  is null.");
        }

        // GET: AdminInfocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminInfocs == null)
            {
                return NotFound();
            }

            var adminInfocs = await _context.AdminInfocs
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (adminInfocs == null)
            {
                return NotFound();
            }

            return View(adminInfocs);
        }

        // GET: AdminInfocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminInfocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,EmailId,Password")] AdminInfocs adminInfocs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminInfocs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminInfocs);
        }

        // GET: AdminInfocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminInfocs == null)
            {
                return NotFound();
            }

            var adminInfocs = await _context.AdminInfocs.FindAsync(id);
            if (adminInfocs == null)
            {
                return NotFound();
            }
            return View(adminInfocs);
        }

        // POST: AdminInfocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminId,EmailId,Password")] AdminInfocs adminInfocs)
        {
            if (id != adminInfocs.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminInfocs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminInfocsExists(adminInfocs.AdminId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(adminInfocs);
        }

        // GET: AdminInfocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminInfocs == null)
            {
                return NotFound();
            }

            var adminInfocs = await _context.AdminInfocs
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (adminInfocs == null)
            {
                return NotFound();
            }

            return View(adminInfocs);
        }

        // POST: AdminInfocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminInfocs == null)
            {
                return Problem("Entity set 'CapstoneProject1Context.AdminInfocs'  is null.");
            }
            var adminInfocs = await _context.AdminInfocs.FindAsync(id);
            if (adminInfocs != null)
            {
                _context.AdminInfocs.Remove(adminInfocs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminInfocsExists(int id)
        {
          return (_context.AdminInfocs?.Any(e => e.AdminId == id)).GetValueOrDefault();
        }
    }
}
