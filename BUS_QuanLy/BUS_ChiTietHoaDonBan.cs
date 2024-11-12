using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_ChiTietHoaDonBan
    {
        DAL_ChiTietHoaDonBan dalCT = new DAL_ChiTietHoaDonBan();

        // Phương thức lấy chi tiết hóa đơn từ mã hóa đơn
        public List<DTO_ChiTietHoaDonBan> LayChiTietHoaDon(string soHDB)
        {
            return dalCT.LayChiTietHoaDon(soHDB);
        }

        public void ThemChiTietHoaDon(DTO_ChiTietHoaDonBan ct)
        {
            dalCT.ThemChiTietHoaDon(ct);
        }

        public bool CapNhatChiTietHoaDon(DTO_ChiTietHoaDonBan ct)
        {
            return dalCT.CapNhatChiTietHoaDon(ct);
        }

        public bool XoaChiTietHoaDonTheoSoHDB(string soHDB)
        {
            return dalCT.XoaChiTietHoaDonTheoSoHDB(soHDB);
        }
    }
}