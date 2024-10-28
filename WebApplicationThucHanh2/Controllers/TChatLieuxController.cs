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
    public class TChatLieuxController : Controller
    {
        private readonly QLBanVaLiDbContext _context;

        public TChatLieuxController(QLBanVaLiDbContext context)
        {
            _context = context;
        }

        // GET: TChatLieux
        public async Task<IActionResult> Index()
        {
            return View(await _context.TChatLieus.ToListAsync());
        }

        // GET: TChatLieux/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tChatLieu = await _context.TChatLieus
                .FirstOrDefaultAsync(m => m.MaChatLieu == id);
            if (tChatLieu == null)
            {
                return NotFound();
            }

            return View(tChatLieu);
        }

        // GET: TChatLieux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TChatLieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChatLieu,ChatLieu")] TChatLieu tChatLieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tChatLieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tChatLieu);
        }

        // GET: TChatLieux/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tChatLieu = await _context.TChatLieus.FindAsync(id);
            if (tChatLieu == null)
            {
                return NotFound();
            }
            return View(tChatLieu);
        }

        // POST: TChatLieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaChatLieu,ChatLieu")] TChatLieu tChatLieu)
        {
            if (id != tChatLieu.MaChatLieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tChatLieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TChatLieuExists(tChatLieu.MaChatLieu))
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
            return View(tChatLieu);
        }

        // GET: TChatLieux/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tChatLieu = await _context.TChatLieus
                .FirstOrDefaultAsync(m => m.MaChatLieu == id);
            if (tChatLieu == null)
            {
                return NotFound();
            }

            return View(tChatLieu);
        }

        // POST: TChatLieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tChatLieu = await _context.TChatLieus.FindAsync(id);
            if (tChatLieu != null)
            {
                _context.TChatLieus.Remove(tChatLieu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TChatLieuExists(string id)
        {
            return _context.TChatLieus.Any(e => e.MaChatLieu == id);
        }
    }
}
