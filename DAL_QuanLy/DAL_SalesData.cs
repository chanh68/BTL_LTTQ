using DTO_QuanLy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_SalesData
    {
        //public (decimal DoanhThu, int SoSanPham) GetSalesData(DateTime date)
        //{
        //    decimal Doanhthu = 0;
        //    int Sosanpham = 0;
        //    string connectionstring = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True";
        //    using (SqlConnection connection = new SqlConnection(connectionstring))
        //    {
        //        connection.Open();
        //        string query = @"
        //                         SELECT 
        //                                SUM(hb.TongTien) AS TotalSales,
        //                                SUM(ct.SoLuong) AS TotalProducts  
        //                         FROM HoaDonBan hb
        //                         JOIN ChiTietHoaDonBan ct ON hb.SoHDB = ct.SoHDB
        //                         WHERE hb.NgayBan = @NgayBan";

        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@NgayBan", date);

        //            using (SqlDataReader reader = cmd.ExecuteReader()) 
        //            {
        //                //if (reader.HasRows)
        //                //{
        //                    if (reader.Read())
        //                    {
        //                        decimal doanhthu = reader["TotalSales"] != DBNull.Value ? Convert.ToDecimal(reader["TotalSales"]) : 0;
        //                        int sosanpham = reader["TotalProducts"] != DBNull.Value ? Convert.ToInt32(reader["TotalProducts"]) : 0;
        //                        return (doanhthu, sosanpham);
        //                    }
        //                //}
        //                //else 
        //                //{
        //                //    return (0, 0);
        //                //}
        //            }
        //        }
        //    }
        //    return (Doanhthu, Sosanpham);
        //}

        //public List<DTO_Product> GetProductRanking()
        //{
        //    List<DTO_Product > productList = new List<DTO_Product>();

        //    string connectionString = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True";

        //    using (SqlConnection connection = new SqlConnection(connectionString)) 
        //    {
        //        connection.Open();
        //        string query = @"
        //     SELECT 
        //                ROW_NUMBER() OVER (ORDER BY SUM(ct.SoLuong) DESC) AS Rank,
        //                hh.TenHang AS ProductInfo,
        //                SUM(ct.SoLuong * ct.DonGiaBan * (1 - ct.GiamGia)) AS Revenue, -- Tính doanh thu với mã giảm giá
        //                SUM(ct.SoLuong) AS Quantity
        //                FROM ChiTietHoaDonBan ct JOIN 
        //                HoaDonBan hb ON ct.SoHDB = hb.SoHDB JOIN 
        //                HangHoa hh ON ct.MaHang = hh.MaHang  -- Sử dụng bảng HangHoa thay cho SanPham
        //                GROUP BY hh.TenHang
        //                ORDER BY SUM(ct.SoLuong) DESC";

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            try
        //            {
        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    if (!reader.HasRows)
        //                    {
        //                        Console.WriteLine("No rows found.");
        //                        return productList;
        //                    }

        //                    while (reader.Read())
        //                    {
        //                        var product = new DTO_Product
        //                        {
        //                            Rank = reader.IsDBNull(0) ? 0 : (int)reader.GetInt64(0),
        //                            ProductInfo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
        //                            Revenue = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
        //                            Quantity = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
        //                        };
        //                        productList.Add(product);
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("Error: " + ex.Message);
        //            }
        //        }

        //    }
        //    return productList;
        //}

        public (decimal DoanhThu, int SoSanPham) GetSalesDataForPeriod(DateTime startDate, DateTime endDate)
        {
            decimal doanhThu = 0;
            int soSanPham = 0;
            string connectionString = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT 
                        SUM(hb.TongTien) AS TotalSales,
                        SUM(ct.SoLuong) AS TotalProducts  
                    FROM HoaDonBan hb
                    JOIN ChiTietHoaDonBan ct ON hb.SoHDB = ct.SoHDB
                    WHERE hb.NgayBan BETWEEN @StartDate AND @EndDate";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            doanhThu = reader["TotalSales"] != DBNull.Value ? Convert.ToDecimal(reader["TotalSales"]) : 0;
                            soSanPham = reader["TotalProducts"] != DBNull.Value ? Convert.ToInt32(reader["TotalProducts"]) : 0;
                        }
                    }
                }
            }
            return (doanhThu, soSanPham);
        }

        public List<DTO_Product> GetProductSalesDataForPeriod(DateTime startDate, DateTime endDate)
        {
            List<DTO_Product> productList = new List<DTO_Product>();

            string connectionString = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY SUM(ct.SoLuong) DESC) AS Rank,
                        hh.TenHang AS ProductInfo,
                        SUM(ct.SoLuong * ct.DonGiaBan * (1 - ISNULL(ct.GiamGia, 0))) AS Revenue,
                        SUM(ct.SoLuong) AS Quantity
                    FROM ChiTietHoaDonBan ct
                    JOIN HoaDonBan hb ON ct.SoHDB = hb.SoHDB
                    JOIN HangHoa hh ON ct.MaHang = hh.MaHang
                    WHERE hb.NgayBan BETWEEN @StartDate AND @EndDate
                    GROUP BY hh.TenHang
                    ORDER BY SUM(ct.SoLuong) DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new DTO_Product
                            {
                                Rank = reader.IsDBNull(0) ? 0 : (int)reader.GetInt64(0),
                                ProductInfo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                Revenue = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
                                Quantity = reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                            };
                            productList.Add(product);
                        }
                    }
                }
            }
            return productList;
        }

        public List<(string WeekLabel, decimal DoanhThu, int SoSanPham)> GetSalesDataGroupedByWeek(DateTime startDate, DateTime endDate)
        {
            List<(string WeekLabel, decimal DoanhThu, int SoSanPham)> salesDataList = new List<(string WeekLabel, decimal DoanhThu, int SoSanPham)>();

            string connectionString = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT 
                DATENAME(WEEK, hb.NgayBan) + '-' + DATENAME(YEAR, hb.NgayBan) AS WeekLabel,
                SUM(hb.TongTien) AS DoanhThu,
                SUM(ct.SoLuong) AS SoSanPham
            FROM HoaDonBan hb
            JOIN ChiTietHoaDonBan ct ON hb.SoHDB = ct.SoHDB
            WHERE hb.NgayBan BETWEEN @StartDate AND @EndDate
            GROUP BY DATENAME(WEEK, hb.NgayBan), DATENAME(YEAR, hb.NgayBan)
            ORDER BY DATENAME(YEAR, hb.NgayBan), DATENAME(WEEK, hb.NgayBan)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string weekLabel = reader["WeekLabel"].ToString();
                            decimal doanhThu = reader["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(reader["DoanhThu"]) : 0;
                            int soSanPham = reader["SoSanPham"] != DBNull.Value ? Convert.ToInt32(reader["SoSanPham"]) : 0;

                            salesDataList.Add((weekLabel, doanhThu, soSanPham));
                        }
                    }
                }
            }

            return salesDataList;
        }
        // Lấy số lượng nhân viên hiện có trong hệ thống (dựa vào ngày vào làm)
        public int GetEmployeeCountForPeriod(DateTime startDate, DateTime endDate)
        {
            int employeeCount = 0;
            string connectionString = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT COUNT(DISTINCT MaNV) AS EmployeeCount
                    FROM NhanVien
                    WHERE NgayVaoLam <= @EndDate"; // Giả sử có cột NgayVaoLam

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employeeCount = reader["EmployeeCount"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeCount"]) : 0;
                        }
                    }
                }
            }
            return employeeCount;
        }

        // Lấy số lượng đơn hàng trong khoảng thời gian
        public int GetOrderCountForPeriod(DateTime startDate, DateTime endDate)
        {
            int orderCount = 0;
            string connectionString = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT COUNT(DISTINCT SoHDB) AS OrderCount
                    FROM HoaDonBan
                    WHERE NgayBan BETWEEN @StartDate AND @EndDate";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            orderCount = reader["OrderCount"] != DBNull.Value ? Convert.ToInt32(reader["OrderCount"]) : 0;
                        }
                    }
                }
            }
            return orderCount;
        }
        public (decimal DoanhThu, int SoSanPham, int SoDonHang, int SoNhanVien) GetTotalSalesData()
        {
            decimal doanhThu = 0;
            int soSanPham = 0;
            int soDonHang = 0;
            int soNhanVien = 0;
            string connectionString = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT 
                SUM(hb.TongTien) AS TotalSales,
                SUM(ct.SoLuong) AS TotalProducts,
                COUNT(DISTINCT hb.SoHDB) AS TotalOrders,
                COUNT(DISTINCT nv.MaNV) AS TotalEmployees
            FROM HoaDonBan hb
            JOIN ChiTietHoaDonBan ct ON hb.SoHDB = ct.SoHDB
            LEFT JOIN NhanVien nv ON hb.MaNV = nv.MaNV";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            doanhThu = reader["TotalSales"] != DBNull.Value ? Convert.ToDecimal(reader["TotalSales"]) : 0;
                            soSanPham = reader["TotalProducts"] != DBNull.Value ? Convert.ToInt32(reader["TotalProducts"]) : 0;
                            soDonHang = reader["TotalOrders"] != DBNull.Value ? Convert.ToInt32(reader["TotalOrders"]) : 0;
                            soNhanVien = reader["TotalEmployees"] != DBNull.Value ? Convert.ToInt32(reader["TotalEmployees"]) : 0;
                        }
                    }
                }
            }
            return (doanhThu, soSanPham, soDonHang, soNhanVien);
        }

    }
}
