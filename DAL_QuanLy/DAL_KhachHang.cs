using DTO_QuanLy;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_KhachHang : DBConnect
    {
        public DAL_KhachHang() { }

        // Lấy toàn bộ danh sách khách hàng
        public DataTable getKhachHang()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KhachHang", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Thêm khách hàng mới
        public bool themKhachHang(DTO_KhachHang kh)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO KhachHang (MaKhach, TenKhach, DiaChi, DienThoai) VALUES (@MaKhach, @TenKhach, @DiaChi, @DienThoai)";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaKhach", kh.MaKhach);
                cmd.Parameters.AddWithValue("@TenKhach", kh.TenKhach);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", kh.DienThoai);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Sửa thông tin khách hàng
        public bool suaKhachHang(DTO_KhachHang kh)
        {
            try
            {
                _conn.Open();
                string query = "UPDATE KhachHang SET TenKhach = @TenKhach, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaKhach = @MaKhach";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaKhach", kh.MaKhach);
                cmd.Parameters.AddWithValue("@TenKhach", kh.TenKhach);
                cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", kh.DienThoai);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Xóa khách hàng
        public bool xoaKhachHang(string maKhach)
        {
            try
            {
                _conn.Open();
                string query = "DELETE FROM KhachHang WHERE MaKhach = @MaKhach";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaKhach", maKhach);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Kiểm tra khách hàng tồn tại
        public bool KiemTraKhachHangTonTai(string maKhach)
        {
            try
            {
                _conn.Open();
                string query = "SELECT COUNT(*) FROM KhachHang WHERE MaKhach = @MaKhach";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaKhach", maKhach);

                int count = (int)cmd.ExecuteScalar(); // Đếm số lượng khách hàng với mã đã cho
                return count > 0; // Trả về true nếu tồn tại
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }
        }

        public DataTable TimKiemKhachHang(string searchTerm, string searchField)
        {

            // Sử dụng `COLLATE` để thực hiện so sánh không phân biệt dấu và không phân biệt hoa thường.
            string query = $@"SELECT * FROM KhachHang WHERE {searchField} COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @searchTerm + '%'";


            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@searchTerm", searchTerm);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
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
        public DataTable GetCustomerData()
        {
            string query = "SELECT MaKhach AS iD, TenKhach as name FROM KhachHang";
            DataTable dataTable = new DataTable();

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
                catch (SqlException ex)
                {
                    throw new Exception("Có lỗi xảy ra khi lấy dữ liệu từ bảng Customer: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return dataTable;
        }
    }
}
