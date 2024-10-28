using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationThucHanh2.Data;
using WebApplicationThucHanh2.Models;
using X.PagedList;

namespace WebApplicationThucHanh2.Controllers
{
    public class HomeController : Controller
    {
        QLBanVaLiDbContext _context = new QLBanVaLiDbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize =10;
            int pageNumber = page ==null || page <= 0 ? 1 : page.Value - 1;
            var ListProduct = _context.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> model = new PagedList<TDanhMucSp>(ListProduct, pageNumber, pageSize);
            return View(model);
        }

        public IActionResult GetProductByCategory(String id)
        {
            List<TDanhMucSp> listProduct= _context.TDanhMucSps.Where(x => x.MaLoai == id).OrderBy(x => x.TenSp).ToList();
            return View(listProduct);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

            
    }
}
