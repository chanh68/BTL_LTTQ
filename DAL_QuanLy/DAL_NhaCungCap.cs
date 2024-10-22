using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using System.Data.SqlClient;
using System.Data;

namespace DAL_QuanLy
{
    public class DAL_NhaCungCap : DBConnect
    {
        public DAL_NhaCungCap() { }

        // Lấy toàn bộ danh sách nhà cung cấp
        public DataTable getNhaCungCap()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NhaCungCap", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Thêm nhà cung cấp mới
        public bool themNhaCungCap(DTO_NhaCungCap ncc)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, DienThoai) VALUES (@MaNCC, @TenNCC, @DiaChi, @DienThoai)";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNCC", ncc.MaNCC);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", ncc.DienThoai);

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

        // Sửa thông tin nhà cung cấp
        public bool suaNhaCungCap(DTO_NhaCungCap ncc)
        {
            try
            {
                _conn.Open();
                string query = "UPDATE NhaCungCap SET TenNCC = @TenNCC, DiaChi = @DiaChi, DienThoai = @DienThoai WHERE MaNCC = @MaNCC";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNCC", ncc.MaNCC);
                cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                cmd.Parameters.AddWithValue("@DiaChi", ncc.DiaChi);
                cmd.Parameters.AddWithValue("@DienThoai", ncc.DienThoai);

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

        // Xóa nhà cung cấp
        public bool xoaNhaCungCap(string maNCC)
        {
            try
            {
                _conn.Open();
                string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNCC", maNCC);

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

        // Kiểm tra nhà cung cấp tồn tại
        public bool KiemTraNhaCungCapTonTai(string maNCC)
        {
            try
            {
                _conn.Open();
                string query = "SELECT COUNT(*) FROM NhaCungCap WHERE MaNCC = @MaNCC";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                int count = (int)cmd.ExecuteScalar(); // Đếm số lượng nhà cung cấp với mã đã cho
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

        public DataTable TimKiemNCC(string searchTerm, string searchField)
        {

            // Sử dụng `COLLATE` để thực hiện so sánh không phân biệt dấu và không phân biệt hoa thường.
            string query = $@"SELECT * FROM NhaCungCap WHERE {searchField} COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @searchTerm + '%'";


            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@searchTerm", searchTerm);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
    }
}