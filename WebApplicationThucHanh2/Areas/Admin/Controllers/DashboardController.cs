using Microsoft.AspNetCore.Mvc;
using WebApplicationThucHanh2.Data;

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
            var ProductCataLog = _context.TDanhMucSps.ToList();
           /* var ProductCatalog = _context.TDanhMucSps.AsNoTracking().OrderBy(p => p.MaSp).ToPagedList(pageNumber, pageSize);
            PagedList<TDanhMucSp> ProductCatalog = new PagedList<TDanhMucSp>(_context.TDanhMucSps.AsNoTracking().OrderBy(p => p.MaSp), pageNumber, pageSize);*/
            return View(ProductCatalog);
        }
    }
}