﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DTO_QuanLy;
using System.Runtime.InteropServices.ComTypes;

namespace DAL_QuanLy
{
    public class DAL_Report_DoanhThu
    {
        private readonly string connectionString = "Data Source=DESKTOP-R4RPQKD;Initial Catalog=BTL_6;Integrated Security=True;Encrypt=False";

        public List<DTO_ReportDoanhThu> GetReportData(DateTime startDate, DateTime endDate)
        {
            var reportList = new List<DTO_ReportDoanhThu>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(@"
                SELECT hb.SoHDB AS InvoiceNumber,
                       SUM(ct.SoLuong * ct.DonGiaBan * (1 - ISNULL(ct.GiamGia, 0))) AS Revenue,
                       hb.NgayBan AS SaleDate,
                       SUM(ct.SoLuong) AS ProductCount,
                       hh.MaHang AS ProductCode,
                       hh.TenHang AS ProductName
                FROM HoaDonBan hb
                JOIN ChiTietHoaDonBan ct ON hb.SoHDB = ct.SoHDB
                JOIN HangHoa hh ON ct.MaHang = hh.MaHang
                WHERE hb.NgayBan BETWEEN @StartDate AND @EndDate
                GROUP BY hb.SoHDB, hb.NgayBan, hh.MaHang, hh.TenHang", connection))
            {
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var report = new DTO_ReportDoanhThu
                        {
                            InvoiceNumber = reader["InvoiceNumber"]?.ToString() ?? string.Empty,
                            Revenue = reader["Revenue"] != DBNull.Value ? Convert.ToDecimal(reader["Revenue"]) : 0,
                            SaleDate = reader["SaleDate"] != DBNull.Value ? Convert.ToDateTime(reader["SaleDate"]) : DateTime.MinValue,
                            ProductCount = reader["ProductCount"] != DBNull.Value ? Convert.ToInt32(reader["ProductCount"]) : 0,
                            ProductCode = reader["ProductCode"]?.ToString() ?? string.Empty,
                            ProductName = reader["ProductName"]?.ToString() ?? string.Empty
                        };
                        reportList.Add(report);
                    }
                }
            }

            return reportList;
        }

        public DataTable ConvertToDataTable(List<DTO_ReportDoanhThu> list)
        {
            var table = new DataTable();


            table.Columns.Add("InvoiceNumber", typeof(string));
            table.Columns.Add("Revenue", typeof(decimal));
            table.Columns.Add("SaleDate", typeof(DateTime));
            table.Columns.Add("ProductCount", typeof(int));
            table.Columns.Add("ProductCode", typeof(string));
            table.Columns.Add("ProductName", typeof(string));


            decimal totalRevenue = 0;
            foreach (var item in list)
            {
                table.Rows.Add(item.InvoiceNumber, item.Revenue, item.SaleDate, item.ProductCount, item.ProductCode, item.ProductName);
                totalRevenue += item.Revenue;
            }
            DataRow totalRow = table.NewRow();
            totalRow["InvoiceNumber"] = "Tổng Doanh Thu";
            totalRow["Revenue"] = totalRevenue;
            table.Rows.Add(totalRow);
            return table;
        }
    }
}
