using DAL_QuanLy;
using DTO_QuanLy;
using System.Data;
using System;
using System.Collections.Generic;

namespace BUS_QuanLy
{
    public class BUS_HoaDonBan
    {
        DAL_HoaDonBan dalHDB = new DAL_HoaDonBan();
        DAL_ChiTietHoaDonBan dalCT = new DAL_ChiTietHoaDonBan();

        // Phương thức lấy toàn bộ danh sách hóa đơn bán
        public DataTable LayDanhSachHoaDonBan()
        {
            return dalHDB.LayDanhSachHoaDonBan();
        }

        // Phương thức xóa hóa đơn bán (DONE)
        public bool XoaHoaDon(string soHDB)
        {
            // Đầu tiên, xóa các chi tiết hóa đơn liên quan
            bool xoaChiTietThanhCong = dalCT.XoaChiTietHoaDonTheoSoHDB(soHDB);

            if (xoaChiTietThanhCong)
            {
                // Nếu xóa chi tiết thành công, tiếp tục xóa hóa đơn
                return dalHDB.XoaHoaDonBan(soHDB);
            }
            else
            {
                Console.WriteLine("Không thể xóa chi tiết hóa đơn, hủy thao tác xóa hóa đơn.");
                return false;
            }
        }

        public DataTable TimKiemHoaDon(string keyword, string month, string year)
        {
            return dalHDB.TimKiemHoaDon(keyword, month, year);
        }

        public bool CapNhatHoaDon(DTO_HoaDonBan hoaDon)
        {
            return dalHDB.CapNhatHoaDon(hoaDon);
        }

        public string TaoMaHoaDon()
        {
            int stt = dalHDB.LaySoThuTuHoaDonTrongNgay();
            string ngayHienTai = DateTime.Now.ToString("ddMMyyyy");
            return $"HDB{stt:D5}{ngayHienTai}";
        }

        public void ThemHoaDon(DTO_HoaDonBan hd)
        {
            dalHDB.ThemHoaDon(hd);
        }

        public string LaySoHDBCuoi()
        {
            return dalHDB.LaySoHDBCuoi();
        }

        //public string LayNgayBan(string maHDB)
        //{
        //    return dalHDB.LayNgayBan(maHDB);
        //}

        //public string LayMaNhanVen(string maHDB)
        //{
        //    return dalHDB.LayMaNhanVien(maHDB);
        //}

        //public string LayMaKhach(string maHDB)
        //{
        //    return dalHDB.LayMaKhach(maHDB);
        //}

        //public string LayTongTien(string maHDB)
        //{
        //    return dalHDB.LayTongTien(maHDB);
        //}

        // Phương thức lấy thông tin hóa đơn
        public DTO_HoaDonBan LayThongTinHoaDon(string soHDB)
        {
            return dalHDB.LayThongTinHoaDon(soHDB);
        }


    }
}
