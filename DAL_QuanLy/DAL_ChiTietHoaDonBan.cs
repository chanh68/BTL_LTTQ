using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_ChiTietHoaDonBan : DBConnect
    {
        // Lấy tổng số lượng sản phẩm đã bán
        public DataTable GetTotalSoldQuantity()
        {
            string query = "SELECT SUM(SoLuong) AS Bang3 FROM ChiTietHoaDonBan";
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
                    throw new Exception("An error occurred while getting total sold quantity: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }
        public DataTable GetTotalCustomerCount()
        {
            string query = "SELECT COUNT(MaKhach) AS Bang4 FROM HoaDonBan";
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
