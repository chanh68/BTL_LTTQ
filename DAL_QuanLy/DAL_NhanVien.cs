using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_NhanVien : DBConnect
    {

        //Dương
        // Phương thức lấy tên nhân viên từ mã nhân viên
        public string LayTenNhanVien(string maNV)
        {
            string sql = "SELECT TenNV FROM NhanVien WHERE MaNV = @MaNV";
            return ExecuteScalar(sql, maNV);
        }

        // Phương thức thực thi câu lệnh SQL và trả về giá trị đầu tiên
        private string ExecuteScalar(string sql, string parameterValue)
        {
            string result = string.Empty;
            try
            {
                OpenConnection(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", parameterValue);
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        result = obj.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin: " + ex.Message);
            }
            finally
            {
                CloseConnection(); // Đảm bảo đóng kết nối
            }
            return result;
        }

        // Phương thức lấy danh sách nhân viên
        public DataTable GetNhanVien()
        {
            DataTable dt = new DataTable();
            OpenConnection();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT MaNV, TenNV FROM NhanVien", _conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu nhân viên: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }


        public DataTable GetUserInfo(string maNV)
        {
            string query = "SELECT NhanVien.*, TaiKhoan.* FROM NhanVien JOIN TaiKhoan ON NhanVien.MaNV = TaiKhoan.MaNV WHERE NhanVien.MaNV = @maNV";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@maNV", maNV);
                DataTable result = new DataTable();

                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while retrieving user info: " + ex.Message);
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
