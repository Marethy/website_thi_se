using WebApplicationThucHanh2.Models;
namespace WebApplicationThucHanh2.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(int id);
        TLoaiSp GetLoaiSp(int id);  
        IEnumerable<TLoaiSp> GetLoaiSps();
    }
}
