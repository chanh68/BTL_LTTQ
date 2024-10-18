using DTO_QuanLy;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DAL_HangHoa : DBConnect
    {
        // Lấy số lượng sản phẩm trong kho
        public DataTable GetTotalProductsCount()
        {
            string query = "SELECT COUNT(MaHang) AS Bang3 FROM HangHoa";
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
                    throw new Exception("An error occurred while getting total products count: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }

        // Lấy tổng số lượng sản phẩm tồn kho
        public DataTable GetTotalStockQuantity()
        {
            string query = "SELECT SUM(SoLuong) AS Bang3 FROM HangHoa";
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
                    throw new Exception("An error occurred while getting total stock quantity: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
                return result;
            }
        }
        public DataTable GetHangHoaData()
        {
            string query = "SELECT TenHang, SoLuong, DonGiaBan, GhiChu FROM HangHoa";
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
                    // Xử lý lỗi tại đây
                    throw new Exception("An error occurred while fetching HangHoa data: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return dataTable;
        }
        public void UpdateHangHoa(DTO_HangHoa hangHoa)
        {
            string query = "UPDATE HangHoa SET SoLuong = @SoLuong, DonGiaBan = @DonGiaBan, GhiChu = @GhiChu, Anh = @Anh WHERE TenHang = @TenHang";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@SoLuong", hangHoa.SoLuong);
                command.Parameters.AddWithValue("@DonGiaBan", hangHoa.DonGiaBan);
                command.Parameters.AddWithValue("@GhiChu", hangHoa.GhiChu);
                command.Parameters.AddWithValue("@Anh", hangHoa.Anh);
                command.Parameters.AddWithValue("@TenHang", hangHoa.TenHangHoa);

                try
                {
                    _conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Xử lý lỗi
                    throw new Exception("Có lỗi khi cập nhật dữ liệu: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }


        public void AddHangHoa(string maHang, string tenHang, string maLoai, string maKT, string maMen, string maMau, int soLuong, decimal dgb, decimal dgn, string anh, string ghiChu, string maCD, string maHK, string maNuocSX)
        {
            string insertQuery = @"
        INSERT INTO HangHoa (MaHang, TenHang, MaLoai, MaKichThuoc, MaLoaiMen, MaMau, SoLuong, DonGiaBan, DonGiaNhap, Anh, GhiChu, MaCongDung, MaHinhKhoi, MaNuocSX) 
        VALUES (@MaHang, @TenHang, @MaLoai, @MaKT, @MaMen, @MaMau, @SoLuong, @DGB, @DGN, @Anh, @GhiChu, @MaCD, @MaHK, @MaNuocSX)";

            using (SqlCommand command = new SqlCommand(insertQuery, _conn))
            {
                command.Parameters.AddWithValue("@MaHang", maHang);
                command.Parameters.AddWithValue("@TenHang", tenHang);
                command.Parameters.AddWithValue("@MaLoai", maLoai);
                command.Parameters.AddWithValue("@MaKT", maKT);
                command.Parameters.AddWithValue("@MaMen", maMen);
                command.Parameters.AddWithValue("@MaMau", maMau);
                command.Parameters.AddWithValue("@SoLuong", soLuong);
                command.Parameters.AddWithValue("@DGB", dgb);
                command.Parameters.AddWithValue("@DGN", dgn);
                command.Parameters.AddWithValue("@Anh", anh);
                command.Parameters.AddWithValue("@GhiChu", ghiChu);
                command.Parameters.AddWithValue("@MaCD", maCD);
                command.Parameters.AddWithValue("@MaHK", maHK);
                command.Parameters.AddWithValue("@MaNuocSX", maNuocSX);

                try
                {
                    _conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while adding HangHoa: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }
        public bool CheckMaHangExists(string maHang)
        {
            string checkQuery = "SELECT COUNT(*) FROM HangHoa WHERE MaHang = @MaHang";
            using (SqlCommand command = new SqlCommand(checkQuery, _conn))
            {
                command.Parameters.AddWithValue("@MaHang", maHang);

                try
                {
                    _conn.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while checking MaHang: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }
        public DTO_HangHoa GetHangHoaByTenHang(string tenHang)
        {
            string query = "SELECT * FROM HangHoa WHERE TenHang = @TenHang";
            DTO_HangHoa hangHoa = null;

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@TenHang", tenHang);

                try
                {
                    _conn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            hangHoa = new DTO_HangHoa
                            {
                                MaHang = reader["MaHang"].ToString(),
                                TenHangHoa = reader["TenHang"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                DonGiaBan = Convert.ToDecimal(reader["DonGiaBan"]),
                                GhiChu = reader["GhiChu"].ToString(),
                                Anh = reader["Anh"].ToString()
                                // Lấy các thông tin khác tương tự
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while fetching HangHoa data: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }

            return hangHoa;
        }
        public bool DeleteHangHoa(string tenHang)
        {
            string query = "DELETE FROM HangHoa WHERE TenHang = @TenHang";

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                command.Parameters.AddWithValue("@TenHang", tenHang);

                try
                {
                    _conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu xóa thành công
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while deleting HangHoa: " + ex.Message);
                }
                finally
                {
                    _conn.Close();
                }
            }
        }

    }
}
