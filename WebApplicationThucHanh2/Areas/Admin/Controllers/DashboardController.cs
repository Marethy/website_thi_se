using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationThucHanh2.Data;
using WebApplicationThucHanh2.Models;
using X.PagedList;
using X.PagedList.Extensions;

namespace WebApplicationThucHanh2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Dashboard")]
    [Route("Admin")]

    public class DashboardController : Controller
    {
        private readonly QLBanVaLiDbContext _context = new QLBanVaLiDbContext();

        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("ProductCatalog")]
        public IActionResult ProductCatalog(int? page)
        {
            int pageSize = 10; 
            int pageNumber = page== null ? 1 : page.Value;
            var ProductCatalog = _context.TDanhMucSps.AsNoTracking().OrderBy(p => p.MaSp).ToPagedList(pageNumber, pageSize);
            PagedList<TDanhMucSp> listProduct = new PagedList<TDanhMucSp>(_context.TDanhMucSps.AsNoTracking().OrderBy(p => p.MaSp), pageNumber, pageSize);
            return View(listProduct);
        }
        [Route("AddProduct")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.MaChatLieu = new SelectList(_context.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(_context.TChatLieus.ToList(), "MaHangSx", "HangSx");

            ViewBag.MaLoai = new SelectList(_context.TChatLieus.ToList(), "MaNuoc", "TenNuoc");

            ViewBag.MaDt = new SelectList(_context.TChatLieus.ToList(), "MaDt", "TenDt");


            return View();
        }
        [Route("AddProduct")]
        [HttpPost]  
        public IActionResult AddProduct(TDanhMucSp product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                _context.SaveChanges();
                return RedirectToAction("ProductCatalog");
            }
            return View(product);
        }   
    }
}