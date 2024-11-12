using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_TaiKhoan : DBConnect
    {

        //Kiểm tra thông tin đăng nhập và trả về mã nhân viên
        public string VerifyUser(string username, string password)
        {
            string query = "SELECT MaNV FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password";
            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                DataTable result = new DataTable();

                try
                {
                    // Sử dụng phương thức mở kết nối
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("Đã xảy ra một lỗi trong quá trình xác thực người dùng: " + ex.Message);
                }
                finally
                {
                    // Sử dụng phương thức đóng kết nối
                    _conn.Close();
                }

                if (result.Rows.Count > 0)
                {
                    return result.Rows[0]["MaNV"].ToString();
                }

                return null;
            }
        }


        //lấy số lượng nhân viên
        public DataTable GetEmployeeCount()
        {
            string query = "SELECT COUNT(*) AS Bang1 FROM TaiKhoan";
            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                DataTable result = new DataTable();
                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("Đã xảy ra lỗi khi lấy số lượng nhân viên: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }

        //lấy danh sách nhân viên theo quyền
        public DataTable GetEmployeeByRole()
        {
            string query = "SELECT QuyenHan, COUNT(*) AS Count FROM TaiKhoan GROUP BY QuyenHan";
            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                DataTable result = new DataTable();
                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("Đã xảy ra lỗi khi nhận nhân viên theo vai trò: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }

        // Lấy tên nhân viên dựa trên mã nhân viên
        public string GetEmployeeNameByAccount(string maNV)
        {
            string query = "SELECT TenNV FROM NhanVien WHERE MaNV = @maNV";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.Add("@maNV", SqlDbType.NVarChar).Value = maNV; // Sử dụng mã nhân viên làm tham số

                try
                {
                    _conn.Open();
                    object result = command.ExecuteScalar(); // Lấy một giá trị (TenNV)
                    if (result != null)
                    {
                        return result.ToString(); // Trả về tên nhân viên
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi trong quá trình tìm tên nhân viên: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }

                return null; // Trả về null nếu không tìm thấy
            }
        }
    }
}
