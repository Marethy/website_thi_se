using WebApplicationThucHanh2.Data;
using WebApplicationThucHanh2.Models;

namespace WebApplicationThucHanh2.Repository
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly QLBanVaLiDbContext _context= new QLBanVaLiDbContext();
        public TLoaiSp Add(TLoaiSp loaiSp)
        {
           _context.TLoaiSps.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public TLoaiSp Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp GetLoaiSp(int id)
        {
            return _context.TLoaiSps.Find(id);
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp; 
        }
    }
}
