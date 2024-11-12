using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_TaiKhoan
    {
        private DAL_QuanLy.DAL_TaiKhoan dalTaiKhoan;

        public BUS_TaiKhoan()
        {
            dalTaiKhoan = new DAL_QuanLy.DAL_TaiKhoan();
        }

        // Phương thức xác thực tài khoản
        public string VerifyUser(string username, string password)
        {
            // Có thể thêm các logic kiểm tra trước khi gọi DAL
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null; // Tên đăng nhập hoặc mật khẩu không hợp lệ
            }

            // Gọi phương thức DAL để xác thực người dùng
            return dalTaiKhoan.VerifyUser(username, password);
        }

        // Phương thức lấy số lượng nhân viên
        public int GetEmployeeCount()
        {
            DataTable dataTable = dalTaiKhoan.GetEmployeeCount();
            if (dataTable.Rows.Count > 0)
            {
                return int.Parse(dataTable.Rows[0]["Bang1"].ToString());
            }
            return 0;
        }

        // Phương thức lấy danh sách nhân viên theo quyền
        public DataTable GetEmployeeByRole()
        {
            return dalTaiKhoan.GetEmployeeByRole();
        }

        // Phương thức lấy tên nhân viên từ mã nhân viên
        public string GetEmployeeNameByAccount(string maNV)
        {
            return dalTaiKhoan.GetEmployeeNameByAccount(maNV); // Gọi DAL để lấy tên nhân viên
        }

        // Phương thức lấy mã nhân viên từ tài khoản
        public string GetEmployeeIdByLogin(string username, string password)
        {
            return dalTaiKhoan.GetEmployeeIdByLogin(username, password);
        }
    }
}
