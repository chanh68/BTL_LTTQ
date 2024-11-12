using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_NhanVien
    {
        private DAL_NhanVien dalNV = new DAL_NhanVien();

        // Phương thức lấy tên nhân viên từ mã nhân viên
        public string LayTenNhanVien(string maNV)
        {
            return dalNV.LayTenNhanVien(maNV);
        }
    }

}
