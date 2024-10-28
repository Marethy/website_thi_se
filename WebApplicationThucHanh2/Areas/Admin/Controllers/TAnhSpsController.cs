using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationThucHanh2.Data;
using WebApplicationThucHanh2.Models;

namespace WebApplicationThucHanh2.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class TAnhSpsController : Controller
    {
        private readonly QLBanVaLiDbContext _context;

        public TAnhSpsController(QLBanVaLiDbContext context)
        {
            _context = context;
        }

        // GET: TAnhSps
        public async Task<IActionResult> Index()
        {
            var qLBanVaLiDbContext = _context.TAnhSps.Include(t => t.MaSpNavigation);
            return View(await qLBanVaLiDbContext.ToListAsync());
        }

        // GET: TAnhSps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAnhSp = await _context.TAnhSps
                .Include(t => t.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (tAnhSp == null)
            {
                return NotFound();
            }

            return View(tAnhSp);
        }

        // GET: TAnhSps/Create
        public IActionResult Create()
        {
            ViewData["MaSp"] = new SelectList(_context.TDanhMucSps, "MaSp", "MaSp");
            return View();
        }

        // POST: TAnhSps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,TenFileAnh,ViTri")] TAnhSp tAnhSp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tAnhSp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaSp"] = new SelectList(_context.TDanhMucSps, "MaSp", "MaSp", tAnhSp.MaSp);
            return View(tAnhSp);
        }

        // GET: TAnhSps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAnhSp = await _context.TAnhSps.FindAsync(id);
            if (tAnhSp == null)
            {
                return NotFound();
            }
            ViewData["MaSp"] = new SelectList(_context.TDanhMucSps, "MaSp", "MaSp", tAnhSp.MaSp);
            return View(tAnhSp);
        }

        // POST: TAnhSps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSp,TenFileAnh,ViTri")] TAnhSp tAnhSp)
        {
            if (id != tAnhSp.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tAnhSp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TAnhSpExists(tAnhSp.MaSp))
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
            ViewData["MaSp"] = new SelectList(_context.TDanhMucSps, "MaSp", "MaSp", tAnhSp.MaSp);
            return View(tAnhSp);
        }

        // GET: TAnhSps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAnhSp = await _context.TAnhSps
                .Include(t => t.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (tAnhSp == null)
            {
                return NotFound();
            }

            return View(tAnhSp);
        }

        // POST: TAnhSps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tAnhSp = await _context.TAnhSps.FindAsync(id);
            if (tAnhSp != null)
            {
                _context.TAnhSps.Remove(tAnhSp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TAnhSpExists(string id)
        {
            return _context.TAnhSps.Any(e => e.MaSp == id);
        }
    }
}
