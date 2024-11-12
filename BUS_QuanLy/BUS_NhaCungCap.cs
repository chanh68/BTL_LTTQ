using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_NhaCungCap
    {
        DAL_NhaCungCap dalNCC = new DAL_NhaCungCap();

        public DTO_NhaCungCap LayThongTinNhaCungCap(string nCC)
        {
            return dalNCC.LayThongTinNhaCungCap(nCC);
        }

        public DTO_NhaCungCap ThongTinNhaCungCapTheoSoHoaDon(string soHoaDon)
        {
            return dalNCC.ThongTinNhaCungCapTheoSoHoaDon(soHoaDon);
        }

        public List<DTO_NhaCungCap> LayDanhSachNhaCungCap()
        {
            return dalNCC.LayDanhSachNhaCungCap();
        }
    }
}
