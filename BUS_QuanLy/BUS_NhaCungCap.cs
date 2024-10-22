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
    public class BUS_NhaCungCap
    {
        DAL_NhaCungCap dalNhaCungCap = new DAL_NhaCungCap();

        // Lấy danh sách nhà cung cấp
        public DataTable getNhaCungCap()
        {
            return dalNhaCungCap.getNhaCungCap();
        }

        // Thêm nhà cung cấp
        public bool themNhaCungCap(DTO_NhaCungCap ncc)
        {
            return dalNhaCungCap.themNhaCungCap(ncc);
        }

        // Sửa thông tin nhà cung cấp
        public bool suaNhaCungCap(DTO_NhaCungCap ncc)
        {
            return dalNhaCungCap.suaNhaCungCap(ncc);
        }

        // Xóa nhà cung cấp
        public bool xoaNhaCungCap(string maNCC)
        {
            return dalNhaCungCap.xoaNhaCungCap(maNCC);
        }

        // Kiểm tra nhà cung cấp tồn tại
        public bool KiemTraNhaCungCapTonTai(string maNCC)
        {
            return dalNhaCungCap.KiemTraNhaCungCapTonTai(maNCC);
        }

        public DataTable TimKiemNCC(string searchTerm, string searchField)
        {
            return dalNhaCungCap.TimKiemNCC(searchTerm, searchField);
        }

    }
}