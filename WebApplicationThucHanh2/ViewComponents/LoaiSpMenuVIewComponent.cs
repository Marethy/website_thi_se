using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationThucHanh2.Data;
using System.Threading.Tasks;
using System.Linq;

public class LoaiSpMenuViewComponent : ViewComponent
{
    private readonly QLBanVaLiDbContext _context;

    public LoaiSpMenuViewComponent(QLBanVaLiDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var items= await _context.TLoaiSps.OrderBy(p => p.Loai).ToListAsync();
        return View(items); 
    }
}
 