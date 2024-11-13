using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_ReportNhanVien
    {
        private string connectionString = "Data Source=DESKTOP-S8N7JNH\\SQLEXPRESS;Initial Catalog=BTL_TQ3;Integrated Security=True;TrustServerCertificate=True";

        public List<DTO_NhanVien> GetNhanVienData()
        {
            List<DTO_NhanVien> nhanVienList = new List<DTO_NhanVien>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT MaNV, TenNV, MaCV, GioiTinh, NgaySinh, DienThoai, NgayTuyen
                    FROM NhanVien";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var nhanVien = new DTO_NhanVien
                            {
                                MaNV = reader["MaNV"].ToString(),
                                TenNV = reader["TenNV"].ToString(),
                                MaCV = reader["MaCV"].ToString(),
                                GioiTinh = reader["GioiTinh"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                DienThoai = reader["DienThoai"].ToString(),
                                NgayTuyen = Convert.ToDateTime(reader["NgayTuyen"])
                            };

                            nhanVienList.Add(nhanVien);
                        }
                    }
                }
            }

            return nhanVienList;
        }

        public DataTable ConvertNhanVienListToDataTable(List<DTO_NhanVien> list)
        {
            var table = new DataTable();
            table.Columns.Add("MaNV", typeof(string));
            table.Columns.Add("TenNV", typeof(string));
            table.Columns.Add("MaCV", typeof(string));
            table.Columns.Add("GioiTinh", typeof(string));
            table.Columns.Add("NgaySinh", typeof(DateTime));
            table.Columns.Add("DienThoai", typeof(string));
            table.Columns.Add("NgayTuyen", typeof(DateTime));

            foreach (var item in list)
            {
                table.Rows.Add(item.MaNV, item.TenNV, item.MaCV, item.GioiTinh, item.NgaySinh, item.DienThoai, item.NgayTuyen);
            }

            return table;
        }
    }
}
