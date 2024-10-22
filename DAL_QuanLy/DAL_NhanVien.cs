using DTO_QuanLy;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_NhanVien : DBConnect
    {
        public DataTable getNhanVien()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM NhanVien", _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Thêm nhân viên
        public bool themNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                string query = "INSERT INTO NhanVien (MaNV, TenNV, MaCV, CCCD, GioiTinh, NgaySinh, DienThoai, DiaChi, SoNgayPhep, SoNgayNghi, NgayTuyen) VALUES (@MaNV, @TenNV, @MaCV, @CCCD, @GioiTinh, @NgaySinh, @DienThoai, @DiaChi, @SoNgayPhep, @SoNgayNghi, @NgayTuyen)";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@MaCV", nv.MaCV);
                cmd.Parameters.AddWithValue("@SoNgayPhep", nv.SoNgayPhep);
                cmd.Parameters.AddWithValue("@SoNgayNghi", nv.SoNgayNghi);
                cmd.Parameters.AddWithValue("@NgayTuyen", nv.NgayTuyen);
                cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("SQL Error: " + sqlEx.Message);
                throw new Exception("Có lỗi khi thêm nhân viên: " + sqlEx.Message);
                return false;
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

        public bool CapNhatNhanVien(DTO_NhanVien nv)
        {
            try
            {
                _conn.Open();
                string query = "UPDATE NhanVien SET TenNV = @TenNV, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, DienThoai = @DienThoai, DiaChi = @DiaChi, MaCV = @MaCV, SoNgayPhep = @SoNgayPhep, SoNgayNghi = @SoNgayNghi, NgayTuyen = @NgayTuyen, CCCD = @CCCD WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@TenNV", nv.TenNV);
                cmd.Parameters.AddWithValue("@GioiTinh", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@DienThoai", nv.DienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@MaCV", nv.MaCV);
                cmd.Parameters.AddWithValue("@SoNgayPhep", nv.SoNgayPhep);
                cmd.Parameters.AddWithValue("@SoNgayNghi", nv.SoNgayNghi);
                cmd.Parameters.AddWithValue("@NgayTuyen", nv.NgayTuyen);
                cmd.Parameters.AddWithValue("@CCCD", nv.CCCD);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi cập nhật nhân viên: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        public bool xoaNhanVien(string maNV)
        {
            try
            {
                _conn.Open();
                string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("lỗi: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        // Phương thức lấy vai trò từ mã công việc
        public string GetVaiTroByMaCV(string maCV)
        {
            string vaiTro = string.Empty;
            string query = "SELECT TenCV FROM CongViec WHERE MaCV = @MaCV";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@MaCV", maCV);

                try
                {
                    _conn.Open();
                    object result = command.ExecuteScalar(); // Thực hiện truy vấn và lấy giá trị đầu tiên

                    if (result != null)
                    {
                        vaiTro = result.ToString(); // Gán vai trò nếu tìm thấy
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
                finally
                {
                    _conn.Close(); // Đóng kết nối
                }
            }

            return vaiTro; // Trả về vai trò (có thể là chuỗi rỗng nếu không tìm thấy)
        }

        public bool KiemTraMaNV(string maNV)
        {
            try
            {
                _conn.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
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

        public bool KiemTraMaCV(string maCV)
        {
            try
            {
                _conn.Open();
                string query = "SELECT COUNT(*) FROM CongViec WHERE MaCV = @MaCV";
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@MaCV", maCV);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
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

        public DataTable TimKiemNV(string searchTerm, string searchField)
        {

            // Sử dụng `COLLATE` để thực hiện so sánh không phân biệt dấu và không phân biệt hoa thường.
            string query = $@"SELECT * FROM NhanVien WHERE {searchField} COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%' + @searchTerm + '%'";


            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("@searchTerm", searchTerm);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable GetUserInfo(string maNV)
        {
            string query = "SELECT NhanVien.*, TaiKhoan.* FROM NhanVien JOIN TaiKhoan ON NhanVien.MaNV = TaiKhoan.MaNV WHERE NhanVien.MaNV = @maNV";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@maNV", maNV);
                DataTable result = new DataTable();

                try
                {
                    _conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while retrieving user info: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }

                return result;
            }
        }
        public DataTable GetEmployData()
        {
            string query = "SELECT MaNV AS iD, TenNV as name FROM NhanVien";
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
