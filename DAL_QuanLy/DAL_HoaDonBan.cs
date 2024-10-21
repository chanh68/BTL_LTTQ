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

        // Phương thức trả về toàn bộ danh sách HDB từ bảng HoaDonBan
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
                // Mở kết nối từ DBConnect
                OpenConnection();

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
                // Đóng kết nối từ DBConnect
                CloseConnection();
            }

            return maHDB; // Trả về mã hóa đơn bán mới
        }

        // Phương thức thêm hóa đơn bán
        public bool themHDB(DTO_HoaDonBan hdb)
        {
            try
            {
                // Mở kết nối từ DBConnect
                OpenConnection();

                // Sinh mã hóa đơn bán
                hdb.MaHDB = GenerateMaHDB();

                // Chuỗi truy vấn thêm hóa đơn bán
                string SQL = "INSERT INTO HoaDonBan (MaHDB, MaKH, NgayBan, TongTien) VALUES (@MaHDB, @MaKH, @NgayBan, @TongTien)";

                // Tạo command
                SqlCommand cmd = new SqlCommand(SQL, _conn);

                // Thêm tham số vào command
                cmd.Parameters.AddWithValue("@MaHDB", hdb.MaHDB);
                cmd.Parameters.AddWithValue("@MaKH", hdb.MaKH);
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
                // Đóng kết nối từ DBConnect
                CloseConnection();
            }

            return false;
        }
    }

}
