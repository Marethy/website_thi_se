using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationThucHanh2.Data;
using WebApplicationThucHanh2.Models;

namespace WebApplicationThucHanh2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TLoaiSpsController : Controller
    {
        private readonly QLBanVaLiDbContext _context;

        public TLoaiSpsController(QLBanVaLiDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TLoaiSps
        public async Task<IActionResult> Index()
        {
            return View(await _context.TLoaiSps.ToListAsync());
        }

        // GET: Admin/TLoaiSps/Details/5
                
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tLoaiSp = await _context.TLoaiSps
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (tLoaiSp == null)
            {
                return NotFound();
            }

            return View(tLoaiSp);
        }

        // GET: Admin/TLoaiSps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TLoaiSps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,Loai")] TLoaiSp tLoaiSp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tLoaiSp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tLoaiSp);
        }

        // GET: Admin/TLoaiSps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tLoaiSp = await _context.TLoaiSps.FindAsync(id);
            if (tLoaiSp == null)
            {
                return NotFound();
            }
            return View(tLoaiSp);
        }

        // POST: Admin/TLoaiSps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaLoai,Loai")] TLoaiSp tLoaiSp)
        {
            if (id != tLoaiSp.MaLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tLoaiSp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TLoaiSpExists(tLoaiSp.MaLoai))
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
            return View(tLoaiSp);
        }

        // GET: Admin/TLoaiSps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tLoaiSp = await _context.TLoaiSps
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (tLoaiSp == null)
            {
                return NotFound();
            }

            return View(tLoaiSp);
        }

        // POST: Admin/TLoaiSps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tLoaiSp = await _context.TLoaiSps.FindAsync(id);
            if (tLoaiSp != null)
            {
                _context.TLoaiSps.Remove(tLoaiSp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TLoaiSpExists(string id)
        {
            return _context.TLoaiSps.Any(e => e.MaLoai == id);
        }
    }
}
