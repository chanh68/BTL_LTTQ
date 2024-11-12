using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_NhaCungCap : DBConnect
    {
        //DƯƠNG
        public DTO_NhaCungCap LayThongTinNhaCungCap(string nCC)
        {
            DTO_NhaCungCap ncc = null;
            string query = "SELECT * FROM NhaCungCap WHERE MaNCC = @MaNCC";

            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@MaNCC", nCC);

            try
            {
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ncc = new DTO_NhaCungCap
                    {
                        MaNCC = reader["MaNCC"].ToString(),
                        TenNCC = reader["TenNCC"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        DienThoai = reader["DienThoai"].ToString()
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin khách hàng: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return ncc;
        }

        public DTO_NhaCungCap ThongTinNhaCungCapTheoSoHoaDon(string soHoaDon)
        {
            DTO_NhaCungCap ncc = null;
            string query = @"
            SELECT ncc.MaNCC, ncc.TenNCC, ncc.DiaChi, ncc.DienThoai
            FROM NhaCungCap ncc
            INNER JOIN HoaDonNhap dh ON dh.MaNCC = ncc.MaNCC
            WHERE dh.SoHDN = @SoHDN"; 

            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@SoHDN", soHoaDon);

            try
            {
                OpenConnection(); // Mở kết nối
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) // Nếu có kết quả
                {
                    ncc = new DTO_NhaCungCap
                    {
                        MaNCC = reader["MaNCC"].ToString(),
                        TenNCC = reader["TenNCC"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        DienThoai = reader["DienThoai"].ToString()
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin nhà cung cấp qua số hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection(); // Đảm bảo đóng kết nối
            }

            return ncc;
        }



        public List<DTO_NhaCungCap> LayDanhSachNhaCungCap()
        {
            List<DTO_NhaCungCap> danhSachNCC = new List<DTO_NhaCungCap>();
            string query = "SELECT MaNCC, TenNCC, DiaChi, DienThoai FROM NhaCungCap";

            SqlCommand cmd = new SqlCommand(query, _conn);
            OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DTO_NhaCungCap ncc = new DTO_NhaCungCap
                {
                    MaNCC = reader["MaNCC"].ToString(),
                    TenNCC = reader["TenNCC"].ToString(),
                    DiaChi = reader["DiaChi"].ToString(),
                    DienThoai = reader["DienThoai"].ToString()
                };
                danhSachNCC.Add(ncc);
            }
            CloseConnection();
            return danhSachNCC;
        }
    }
}
