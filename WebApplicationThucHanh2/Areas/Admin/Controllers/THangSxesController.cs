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

    public class THangSxesController : Controller
    {
        private readonly QLBanVaLiDbContext _context;

        public THangSxesController(QLBanVaLiDbContext context)
        {
            _context = context;
        }

        // GET: THangSxes
        public async Task<IActionResult> Index()
        {
            return View(await _context.THangSxes.ToListAsync());
        }

        // GET: THangSxes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tHangSx = await _context.THangSxes
                .FirstOrDefaultAsync(m => m.MaHangSx == id);
            if (tHangSx == null)
            {
                return NotFound();
            }

            return View(tHangSx);
        }

        // GET: THangSxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: THangSxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHangSx,HangSx,MaNuocThuongHieu")] THangSx tHangSx)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tHangSx);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tHangSx);
        }

        // GET: THangSxes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tHangSx = await _context.THangSxes.FindAsync(id);
            if (tHangSx == null)
            {
                return NotFound();
            }
            return View(tHangSx);
        }

        // POST: THangSxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHangSx,HangSx,MaNuocThuongHieu")] THangSx tHangSx)
        {
            if (id != tHangSx.MaHangSx)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tHangSx);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!THangSxExists(tHangSx.MaHangSx))
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
            return View(tHangSx);
        }

        // GET: THangSxes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tHangSx = await _context.THangSxes
                .FirstOrDefaultAsync(m => m.MaHangSx == id);
            if (tHangSx == null)
            {
                return NotFound();
            }

            return View(tHangSx);
        }

        // POST: THangSxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tHangSx = await _context.THangSxes.FindAsync(id);
            if (tHangSx != null)
            {
                _context.THangSxes.Remove(tHangSx);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool THangSxExists(string id)
        {
            return _context.THangSxes.Any(e => e.MaHangSx == id);
        }
    }
}
