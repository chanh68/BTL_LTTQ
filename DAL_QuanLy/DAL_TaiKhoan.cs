using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_TaiKhoan : DBConnect
    {
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
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi kết nối hoặc truy vấn tại đây
                    throw new Exception("An error occurred while verifying user: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }

                if (result.Rows.Count > 0)
                {
                    return result.Rows[0]["MaNV"].ToString();
                }

                return null; 
            }
        }
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
                    throw new Exception("An error occurred while getting employee count: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }

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
                    throw new Exception("An error occurred while getting employee by role: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }
    }
}
