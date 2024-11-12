using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dalKH = new DAL_KhachHang();

        //Phương thức lấy thông tin khách hàng
        public DTO_KhachHang LayThongTinKhachHang(string maKH)
        {
            return dalKH.LayThongTinKhachHang(maKH);
        }

        public List<DTO_KhachHang> LayDanhSachKhachHang()
        {
            return dalKH.LayDanhSachKhachHang();
        }
        public DTO_KhachHang ThongTinKhachHangTheoSoHoaDon(string soHoaDon)
        {
            return dalKH.ThongTinKhachHangTheoSoHoaDon(soHoaDon);
        }
    }
}
