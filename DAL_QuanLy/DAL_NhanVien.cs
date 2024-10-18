using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_NhanVien : DBConnect
    {
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
