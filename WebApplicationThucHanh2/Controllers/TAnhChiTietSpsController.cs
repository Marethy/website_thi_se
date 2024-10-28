using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationThucHanh2.Data;
using WebApplicationThucHanh2.Models;

namespace WebApplicationThucHanh2.Controllers
{
    public class TAnhChiTietSpsController : Controller
    {
        private readonly QLBanVaLiDbContext _context;

        public TAnhChiTietSpsController(QLBanVaLiDbContext context)
        {
            _context = context;
        }

        // GET: TAnhChiTietSps
        public async Task<IActionResult> Index()
        {
            var qLBanVaLiDbContext = _context.TAnhChiTietSps.Include(t => t.MaChiTietSpNavigation);
            return View(await qLBanVaLiDbContext.ToListAsync());
        }

        // GET: TAnhChiTietSps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAnhChiTietSp = await _context.TAnhChiTietSps
                .Include(t => t.MaChiTietSpNavigation)
                .FirstOrDefaultAsync(m => m.MaChiTietSp == id);
            if (tAnhChiTietSp == null)
            {
                return NotFound();
            }

            return View(tAnhChiTietSp);
        }

        // GET: TAnhChiTietSps/Create
        public IActionResult Create()
        {
            ViewData["MaChiTietSp"] = new SelectList(_context.TChiTietSanPhams, "MaChiTietSp", "MaChiTietSp");
            return View();
        }

        // POST: TAnhChiTietSps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChiTietSp,TenFileAnh,ViTri")] TAnhChiTietSp tAnhChiTietSp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tAnhChiTietSp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChiTietSp"] = new SelectList(_context.TChiTietSanPhams, "MaChiTietSp", "MaChiTietSp", tAnhChiTietSp.MaChiTietSp);
            return View(tAnhChiTietSp);
        }

        // GET: TAnhChiTietSps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAnhChiTietSp = await _context.TAnhChiTietSps.FindAsync(id);
            if (tAnhChiTietSp == null)
            {
                return NotFound();
            }
            ViewData["MaChiTietSp"] = new SelectList(_context.TChiTietSanPhams, "MaChiTietSp", "MaChiTietSp", tAnhChiTietSp.MaChiTietSp);
            return View(tAnhChiTietSp);
        }

        // POST: TAnhChiTietSps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaChiTietSp,TenFileAnh,ViTri")] TAnhChiTietSp tAnhChiTietSp)
        {
            if (id != tAnhChiTietSp.MaChiTietSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tAnhChiTietSp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TAnhChiTietSpExists(tAnhChiTietSp.MaChiTietSp))
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
            ViewData["MaChiTietSp"] = new SelectList(_context.TChiTietSanPhams, "MaChiTietSp", "MaChiTietSp", tAnhChiTietSp.MaChiTietSp);
            return View(tAnhChiTietSp);
        }

        // GET: TAnhChiTietSps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tAnhChiTietSp = await _context.TAnhChiTietSps
                .Include(t => t.MaChiTietSpNavigation)
                .FirstOrDefaultAsync(m => m.MaChiTietSp == id);
            if (tAnhChiTietSp == null)
            {
                return NotFound();
            }

            return View(tAnhChiTietSp);
        }

        // POST: TAnhChiTietSps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tAnhChiTietSp = await _context.TAnhChiTietSps.FindAsync(id);
            if (tAnhChiTietSp != null)
            {
                _context.TAnhChiTietSps.Remove(tAnhChiTietSp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TAnhChiTietSpExists(string id)
        {
            return _context.TAnhChiTietSps.Any(e => e.MaChiTietSp == id);
        }

       
    }
}
