using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_ReportSanPham : DBConnect
    {
       // private readonly string connectionString = "Data Source=LAPTOP-L4E28I51\\SQLEXPRESS;Initial Catalog=BTL_TQ3;Integrated Security=True;TrustServerCertificate=True";

        // Lấy dữ liệu của tất cả sản phẩm
        public List<DTO_ReportSanPham> GetAllReportSanPhamData()
        {
            var sanPhamList = new List<DTO_ReportSanPham>();
            OpenConnection();
            //using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(@"
                SELECT 
                    hh.MaHang AS IDSanPham,
                    hh.TenHang AS TenSanPham,
                    ISNULL(Sold.SoLuongBan, 0) AS SoLuongBan,
                    (ISNULL(Purchased.SoLuongNhap, 0) - ISNULL(Sold.SoLuongBan, 0)) AS SoLuongConLai
                FROM 
                    HangHoa hh
                LEFT JOIN 
                    (SELECT MaHang, SUM(SoLuong) AS SoLuongBan
                     FROM ChiTietHoaDonBan
                     GROUP BY MaHang) AS Sold ON hh.MaHang = Sold.MaHang
                LEFT JOIN 
                    (SELECT MaHang, SUM(SoLuong) AS SoLuongNhap
                     FROM ChiTietHoaDonNhap
                     GROUP BY MaHang) AS Purchased ON hh.MaHang = Purchased.MaHang
                ORDER BY 
                    hh.MaHang;", _conn))
            {
                //connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var reportSanPham = new DTO_ReportSanPham
                        {
                            IDSanPham = reader["IDSanPham"]?.ToString() ?? string.Empty,
                            TenSanPham = reader["TenSanPham"]?.ToString() ?? string.Empty,
                            SoLuongBan = reader["SoLuongBan"] != DBNull.Value ? Convert.ToInt32(reader["SoLuongBan"]) : 0,
                            SoLuongConLai = reader["SoLuongConLai"] != DBNull.Value ? Convert.ToInt32(reader["SoLuongConLai"]) : 0
                        };
                        sanPhamList.Add(reportSanPham);
                    }
                }
            }
            CloseConnection();

            return sanPhamList;
        }

        // Lấy dữ liệu cho một sản phẩm cụ thể
        public List<DTO_ReportSanPham> GetReportSanPhamData(string productID)
        {
            var sanPhamList = new List<DTO_ReportSanPham>();

            //using (var connection = new SqlConnection(connectionString))
            OpenConnection();
            using (var command = new SqlCommand(@"
                SELECT 
                    hh.MaHang AS IDSanPham,
                    hh.TenHang AS TenSanPham,
                    ISNULL(Sold.SoLuongBan, 0) AS SoLuongBan,
                    (ISNULL(Purchased.SoLuongNhap, 0) - ISNULL(Sold.SoLuongBan, 0)) AS SoLuongConLai
                FROM 
                    HangHoa hh
                LEFT JOIN 
                    (SELECT MaHang, SUM(SoLuong) AS SoLuongBan
                     FROM ChiTietHoaDonBan
                     GROUP BY MaHang) AS Sold ON hh.MaHang = Sold.MaHang
                LEFT JOIN 
                    (SELECT MaHang, SUM(SoLuong) AS SoLuongNhap
                     FROM ChiTietHoaDonNhap
                     GROUP BY MaHang) AS Purchased ON hh.MaHang = Purchased.MaHang
                WHERE 
                    hh.MaHang = @ProductID
                ORDER BY 
                    hh.MaHang;", _conn))
            {
                command.Parameters.AddWithValue("@ProductID", productID);

                //connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var reportSanPham = new DTO_ReportSanPham
                        {
                            IDSanPham = reader["IDSanPham"]?.ToString() ?? string.Empty,
                            TenSanPham = reader["TenSanPham"]?.ToString() ?? string.Empty,
                            SoLuongBan = reader["SoLuongBan"] != DBNull.Value ? Convert.ToInt32(reader["SoLuongBan"]) : 0,
                            SoLuongConLai = reader["SoLuongConLai"] != DBNull.Value ? Convert.ToInt32(reader["SoLuongConLai"]) : 0
                        };
                        sanPhamList.Add(reportSanPham);
                    }
                }
            }
            CloseConnection();
            return sanPhamList;
        }

        public DataTable ConvertSanPhamListToDataTable(List<DTO_ReportSanPham> list)
        {
            var table = new DataTable();

            table.Columns.Add("IDSanPham", typeof(string));
            table.Columns.Add("TenSanPham", typeof(string));
            table.Columns.Add("SoLuongBan", typeof(int));
            table.Columns.Add("SoLuongConLai", typeof(int));

            foreach (var item in list)
            {
                table.Rows.Add(item.IDSanPham, item.TenSanPham, item.SoLuongBan, item.SoLuongConLai);
            }

            return table;
        }
    }
}
