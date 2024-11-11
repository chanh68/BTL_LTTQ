using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dalTaiKhoan = new DAL_TaiKhoan();

        // Lấy danh sách tài khoản
        public DataTable getTaiKhoan()
        {
            return dalTaiKhoan.getTaiKhoan();
        }

        // Thêm tài khoản
        public bool themTaiKhoan(DTO_TaiKhoan tk)
        {
            return dalTaiKhoan.themTaiKhoan(tk);
        }

        // Sửa tài khoản
        public bool suaTaiKhoan(DTO_TaiKhoan tk)
        {
            return dalTaiKhoan.suaTaiKhoan(tk);
        }

        // Xóa tài khoản
        public bool xoaTaiKhoan(string maTK)
        {
            return dalTaiKhoan.xoaTaiKhoan(maTK);
        }

        // Kiểm tra tài khoản tồn tại
        public bool KiemTraTaiKhoanTonTai(string maTK)
        {
            return dalTaiKhoan.KiemTraTaiKhoanTonTai(maTK);
        }

        public bool KiemTraMaNV(string maNV)
        {
            return dalTaiKhoan.KiemTraMaNVTonTai(maNV); // giả sử bạn đã tạo đối tượng DAL để truy cập
        }

    }
}