using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_HoaDonBan : DBConnect
    {
        public DAL_HoaDonBan() { }
        // Phuong thuc tra ve toan bo danh sach hdb tu bang HDB
        public DataTable LayDanhSachHoaDonBan()
        {
            DataTable dtHDB = new DataTable();
            OpenConnection(); // Mở kết nối
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM HoaDonBan", _conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtHDB);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách hóa đơn bán: " + ex.Message);
            }
            finally
            {
                CloseConnection(); // Đảm bảo đóng kết nối
            }
            return dtHDB;
        }

        // Phương thức lấy thông tin hóa đơn (Chi tiết)
        public DTO_HoaDonBan LayThongTinHoaDon(string soHDB)
        {
            DTO_HoaDonBan hoaDon = null;
            string query = "SELECT * FROM HoaDonBan WHERE SoHDB = @SoHDB";

            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@SoHDB", soHDB);

                try
                {
                    OpenConnection(); // Mở kết nối
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hoaDon = new DTO_HoaDonBan
                            {
                                SoHDB = reader["SoHDB"].ToString(),
                                NgayBan = reader["NgayBan"] != DBNull.Value ? (DateTime)reader["NgayBan"] : default(DateTime),
                                
                                MaKhach = reader["MaKhach"].ToString(),
                                GiamGia = reader["GiamGia"] != DBNull.Value ? decimal.Parse(reader["GiamGia"].ToString()) : (decimal?)null,
                                TongTien = reader["TongTien"] != DBNull.Value ? decimal.Parse(reader["TongTien"].ToString()) : (decimal?)null
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy thông tin hóa đơn: " + ex.Message);
                }
                finally
                {
                    CloseConnection(); // Đảm bảo đóng kết nối
                }
            }

            return hoaDon;
        }

        //Phương thức tìm kiếm(Done)
        public DataTable TimKiemHoaDon(string keyword, string month, string year)
        {
            DataTable dt = new DataTable();
            OpenConnection();
            try
            {
                // Xây dựng câu truy vấn động
                string query = "SELECT * FROM HoaDonBan WHERE 1=1";

                // Thêm điều kiện tìm kiếm theo keyword nếu có
                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " AND (SoHDB LIKE @keyword OR MaKhach LIKE @keyword)";
                }

                // Thêm điều kiện tìm kiếm theo tháng nếu có
                if (!string.IsNullOrEmpty(month))
                {
                    query += " AND MONTH(NgayBan) = @month";
                }

                // Thêm điều kiện tìm kiếm theo năm nếu có
                if (!string.IsNullOrEmpty(year))
                {
                    query += " AND YEAR(NgayBan) = @year";
                }

                using (SqlCommand command = new SqlCommand(query, _conn))
                {
                    // Thêm tham số cho keyword nếu có
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    }
                    // Thêm tham số cho month nếu có
                    if (!string.IsNullOrEmpty(month))
                    {
                        command.Parameters.AddWithValue("@month", month);
                    }
                    // Thêm tham số cho year nếu có
                    if (!string.IsNullOrEmpty(year))
                    {
                        command.Parameters.AddWithValue("@year", year);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return dt;
        }

        // Phương thức xóa hóa đơn bán (DONE)
        public bool XoaHoaDonBan(string soHDB)
        {
            try
            {
                OpenConnection(); // Gọi phương thức từ DBConnect
                string query = "DELETE FROM HoaDonBan WHERE SoHDB = @SoHDB";
                SqlCommand command = new SqlCommand(query, _conn);
                command.Parameters.AddWithValue("@SoHDB", soHDB);

                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa hóa đơn: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection(); // Đảm bảo kết nối được đóng
            }
        }

        //Phương thức tạo mã hóa đơn bán
        public int LaySoThuTuHoaDonTrongNgay()
        {
            int soThuTu = 1;
            string query = "SELECT COUNT(*) FROM HoaDonBan WHERE CONVERT(DATE, NgayBan) = CONVERT(DATE, GETDATE())";

            SqlCommand cmd = new SqlCommand(query, _conn);
            try
            {
                OpenConnection();
                soThuTu += (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy số thứ tự hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return soThuTu;
        }

        //Phương thức cập nhật hóa đơn bán
        public bool CapNhatHoaDon(DTO_HoaDonBan hoaDon)
        {
            try
            {
                string query = "UPDATE HoaDonBan SET NgayBan = @NgayBan, MaNV = @MaNV, MaKhach = @MaKhach, TongTien = @TongTien WHERE SoHDB = @SoHDB";

                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("@NgayBan", hoaDon.NgayBan);
                cmd.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);
                cmd.Parameters.AddWithValue("@MaKhach", hoaDon.MaKhach);
                cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                cmd.Parameters.AddWithValue("@SoHDB", hoaDon.SoHDB);

                OpenConnection();
                int result = cmd.ExecuteNonQuery();
                CloseConnection();

                return result > 0; // Trả về true nếu cập nhật thành công
            }
            catch (Exception ex)
            {
                CloseConnection();
                return false;
            }
        }



        //Phương thức thêm hóa đơn bán
        public void ThemHoaDon(DTO_HoaDonBan hdb)
        {
            string query = "INSERT INTO HoaDonBan(SoHDB, NgayBan, MaNV, MaKhach, GiamGia, TongTien)" +
                             "VALUES (@SoHDB, @NgayBan, @MaNV, @MaKhach, @GiamGia, @TongTien)";
            SqlCommand cmd = new SqlCommand(query, _conn);

            cmd.Parameters.AddWithValue("@SoHDB", hdb.SoHDB);
            cmd.Parameters.AddWithValue("@NgayBan", hdb.NgayBan);
            cmd.Parameters.AddWithValue("@MaNV", hdb.MaNV);
            cmd.Parameters.AddWithValue("@MaKhach", hdb.MaKhach);
            cmd.Parameters.AddWithValue("@GiamGia", hdb.GiamGia);
            cmd.Parameters.AddWithValue("@TongTien", hdb.TongTien);
            try
            {
                OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection(); // Đảm bảo đóng kết nối
            }
        }




        public string LayNgayBan(string maHDBan)
        {
            string sql = "SELECT NgayBan FROM HoaDonBan WHERE SoHDB = @SoHDB";
            return ExecuteScalar(sql, maHDBan);
        }

        public string LayMaNhanVien(string maHDBan)
        {
            string sql = "SELECT MaNhanVien FROM HoaDonBan WHERE SoHDB = @SoHDBn";
            return ExecuteScalar(sql, maHDBan);
        }

        public string LayMaKhach(string maHDBan)
        {
            string sql = "SELECT MaKhach FROM HoaDonBan WHERE SoHDB = @SoHDB";
            return ExecuteScalar(sql, maHDBan);
        }

        public string LayTongTien(string maHDBan)
        {
            string sql = "SELECT TongTien FROM HoaDonBan WHERE SoHDB = @SoHDB";
            return ExecuteScalar(sql, maHDBan);
        }

        private string ExecuteScalar(string sql, string maHDBan)
        {
            string result = string.Empty;
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@SoHDB", maHDBan);
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                        result = obj.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin hóa đơn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public DataTable getHoaDonBan()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HoaDonBan", _conn);
            DataTable dtHDB = new DataTable();
            da.Fill(dtHDB);
            return dtHDB;
        }

        // Phương thức sinh mã hóa đơn bán
        public string GenerateMaHDB()
        {
            string maHDB = "";
            try
            {
                // Kết nối
                _conn.Open();

                // Lấy mã hóa đơn bán lớn nhất hiện có
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 MaHDB FROM HoaDonBan ORDER BY MaHDB DESC", _conn);
                object result = cmd.ExecuteScalar(); // Trả về giá trị lớn nhất

                if (result != null)
                {
                    // Tách phần số của mã hóa đơn
                    string lastMaHDB = result.ToString();
                    int lastNumber = int.Parse(lastMaHDB.Substring(3)); // Lấy số sau 'HDB'
                    int newNumber = lastNumber + 1; // Tăng số lên 1

                    // Định dạng lại mã hóa đơn mới
                    maHDB = "HDB" + newNumber.ToString("D2"); // Định dạng với 2 chữ số
                }
                else
                {
                    // Nếu chưa có hóa đơn nào, khởi tạo mã đầu tiên
                    maHDB = "HDB01";
                }
            }
            catch (Exception e)
            {
                // Xử lý lỗi (nếu cần)
                Console.WriteLine("Lỗi: " + e.Message);
            }
            finally
            {
                // Đóng kết nối
                _conn.Close();
            }

            return maHDB; // Trả về mã hóa đơn bán mới
        }

        // Phuong thuc Them HDB
        public bool themHDB(DTO_HoaDonBan hdb)
        {
            try
            {
                //Ket noi
                _conn.Open();

                // Sinh mã hóa đơn bán
                hdb.SoHDB = GenerateMaHDB();


                // Query string - Chuỗi truy vấn thêm hóa đơn bán
                string SQL = "INSERT INTO HoaDonBan (MaHDB, MaKH, NgayBan, TongTien) VALUES (@MaHDB, @MaKH, @NgayBan, @TongTien)";

                // Tạo command
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                // Thêm tham số vào command
                cmd.Parameters.AddWithValue("@MaHDB", hdb.SoHDB);
                cmd.Parameters.AddWithValue("@MaKH", hdb.MaKhach);
                cmd.Parameters.AddWithValue("@NgayBan", hdb.NgayBan);
                cmd.Parameters.AddWithValue("@TongTien", hdb.TongTien);

                // Thực hiện truy vấn
                int result = cmd.ExecuteNonQuery(); // Số lượng bản ghi bị ảnh hưởng

                return result > 0; // Trả về true nếu thêm thành công
            }
            catch (Exception e)
            {
                // Xử lý lỗi (nếu cần)
                Console.WriteLine("Lỗi: " + e.Message);
            }

            finally
            {
                // Đóng kết nối
                _conn.Close();
            }

            return false;
        }
        public DataTable GetTotalRevenue()
        {
            string query = "SELECT SUM(TongTien) AS Bang3 FROM HoaDonBan";
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
                    throw new Exception("An error occurred while getting total revenue: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }
        public DataTable GetTotalDiscount()
        {
            string query = "SELECT SUM(GiamGia) AS Bang3 FROM HoaDonBan";
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
                    throw new Exception("An error occurred while getting total discount: " + ex.Message);
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
