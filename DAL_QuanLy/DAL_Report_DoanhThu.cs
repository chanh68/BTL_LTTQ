using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_Report_DoanhThu
    {
        private string connectionString = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True";

        public List<DTO_ReportDoanhThu> GetReportData()
        {
            List<DTO_ReportDoanhThu> reportList = new List<DTO_ReportDoanhThu>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Sử dụng truy vấn mà bạn cung cấp
                string query = @"
                SELECT hb.SoHDB AS InvoiceNumber,
                       SUM(ct.SoLuong * ct.DonGiaBan * (1 - ISNULL(ct.GiamGia, 0))) AS Revenue,
                       hb.NgayBan AS SaleDate,
                       SUM(ct.SoLuong) AS ProductCount,
                       hh.MaHang AS ProductCode,
                       hh.TenHang AS ProductName
                FROM HoaDonBan hb
                JOIN ChiTietHoaDonBan ct ON hb.SoHDB = ct.SoHDB
                JOIN HangHoa hh ON ct.MaHang = hh.MaHang
                GROUP BY hb.SoHDB, hb.NgayBan, hh.MaHang, hh.TenHang";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_ReportDoanhThu report = new DTO_ReportDoanhThu
                            {
                                InvoiceNumber = reader["InvoiceNumber"].ToString(),
                                Revenue = Convert.ToDecimal(reader["Revenue"]),
                                SaleDate = Convert.ToDateTime(reader["SaleDate"]),
                                ProductCount = Convert.ToInt32(reader["ProductCount"]),
                                ProductCode = reader["ProductCode"].ToString(),
                                ProductName = reader["ProductName"].ToString()
                            };
                            reportList.Add(report);
                        }
                    }
                }
            }

            return reportList;
        }
    }
}
