using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_KhachHang : DBConnect
    {
        public DataTable GetCustomerCount()
        {
            string query = "SELECT COUNT(*) AS Bang2 FROM KhachHang";
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
                    throw new Exception("An error occurred while getting customer count: " + ex.Message);
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
