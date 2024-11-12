using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_KhachHang : DBConnect
    {

        //DƯƠNG
        public DTO_KhachHang LayThongTinKhachHang(string maKH)
        {
            DTO_KhachHang kh = null;
            string query = "SELECT * FROM KhachHang WHERE MaKhach = @MaKhach";

            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@MaKhach", maKH);

                try
                {
                    OpenConnection(); // Mở kết nối
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            kh = new DTO_KhachHang
                            {
                                MaKhach = reader["MaKhach"].ToString(),
                                TenKhach = reader["TenKhach"].ToString(),
                                DiaChi = reader["DiaChi"].ToString(),
                                DienThoai = reader["DienThoai"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy thông tin khách hàng: " + ex.Message);
                }
                finally
                {
                    CloseConnection(); // Đảm bảo đóng kết nối
                }
                return kh;
            }
        }

        public List<DTO_KhachHang> LayDanhSachKhachHang()
        {
            List<DTO_KhachHang> danhSachKhachHang = new List<DTO_KhachHang>();
            string query = "SELECT MaKhach, TenKhach, DiaChi, DienThoai FROM KhachHang";

            SqlCommand cmd = new SqlCommand(query, _conn);
            OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DTO_KhachHang khachHang = new DTO_KhachHang
                {
                    MaKhach = reader["MaKhach"].ToString(),
                    TenKhach = reader["TenKhach"].ToString(),
                    DiaChi = reader["DiaChi"].ToString(),
                    DienThoai = reader["DienThoai"].ToString()
                };
                danhSachKhachHang.Add(khachHang);
            }
            CloseConnection();
            return danhSachKhachHang;
        }


        //Tìm kiếm khách hàng theo số điện thoại
        public DTO_KhachHang TimKiemKhachHangTheoSDT(string sdt)
        {
            DTO_KhachHang KhachHang = null;
            string query = "SELECT * FROM KhachHang WHERE DienThoai = @DienThoai";

            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@DienThoai", sdt);
            try
            {
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    KhachHang = new DTO_KhachHang
                    {
                        MaKhach = reader["MaKhach"].ToString(),
                        TenKhach = reader["TenKH"].ToString(),
                        DiaChi = reader["DiaChi"].ToString(),
                        DienThoai = reader["DienThoai"].ToString()
                    };
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return KhachHang;
        }

        public int LaySoLuongKhachHang()
        {
            int soLuong = 0;
            string query = "SELECT COUNT(*) FROM KhachHang";

            SqlCommand cmd = new SqlCommand(query, _conn);
            try
            {
                OpenConnection();
                soLuong = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đếm số lượng khách hàng: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return soLuong;
        }

        // Phương thức lấy danh sách khách hàng
        public DataTable GetKhachHang()
        {
            DataTable dt = new DataTable();
            OpenConnection();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT MaKhach, TenKH FROM KhachHang", _conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu khách hàng: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

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
