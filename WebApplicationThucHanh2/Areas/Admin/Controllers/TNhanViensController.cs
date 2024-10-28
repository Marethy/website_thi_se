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
    public class TNhanViensController : Controller
    {
        private readonly QLBanVaLiDbContext _context;

        public TNhanViensController(QLBanVaLiDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TNhanViens
        public async Task<IActionResult> Index()
        {
            var qLBanVaLiDbContext = _context.TNhanViens.Include(t => t.UsernameNavigation);
            return View(await qLBanVaLiDbContext.ToListAsync());
        }

        // GET: Admin/TNhanViens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tNhanVien = await _context.TNhanViens
                .Include(t => t.UsernameNavigation)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (tNhanVien == null)
            {
                return NotFound();
            }

            return View(tNhanVien);
        }

        // GET: Admin/TNhanViens/Create
        public IActionResult Create()
        {
            ViewData["Username"] = new SelectList(_context.TUsers, "Username", "Username");
            return View();
        }

        // POST: Admin/TNhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhanVien,Username,TenNhanVien,NgaySinh,SoDienThoai1,SoDienThoai2,DiaChi,ChucVu,AnhDaiDien,GhiChu")] TNhanVien tNhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tNhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Username"] = new SelectList(_context.TUsers, "Username", "Username", tNhanVien.Username);
            return View(tNhanVien);
        }

        // GET: Admin/TNhanViens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tNhanVien = await _context.TNhanViens.FindAsync(id);
            if (tNhanVien == null)
            {
                return NotFound();
            }
            ViewData["Username"] = new SelectList(_context.TUsers, "Username", "Username", tNhanVien.Username);
            return View(tNhanVien);
        }

        // POST: Admin/TNhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNhanVien,Username,TenNhanVien,NgaySinh,SoDienThoai1,SoDienThoai2,DiaChi,ChucVu,AnhDaiDien,GhiChu")] TNhanVien tNhanVien)
        {
            if (id != tNhanVien.MaNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tNhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TNhanVienExists(tNhanVien.MaNhanVien))
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
            ViewData["Username"] = new SelectList(_context.TUsers, "Username", "Username", tNhanVien.Username);
            return View(tNhanVien);
        }

        // GET: Admin/TNhanViens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tNhanVien = await _context.TNhanViens
                .Include(t => t.UsernameNavigation)
                .FirstOrDefaultAsync(m => m.MaNhanVien == id);
            if (tNhanVien == null)
            {
                return NotFound();
            }

            return View(tNhanVien);
        }

        // POST: Admin/TNhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tNhanVien = await _context.TNhanViens.FindAsync(id);
            if (tNhanVien != null)
            {
                _context.TNhanViens.Remove(tNhanVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TNhanVienExists(string id)
        {
            return _context.TNhanViens.Any(e => e.MaNhanVien == id);
        }
    }
}
