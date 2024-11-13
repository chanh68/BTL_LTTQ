using DAL_QuanLy;
using DTO_QuanLy;
using System.Data;
using System;
using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;

namespace BUS_QuanLy
{
    public class BUS_HoaDonBan
    {
        DAL_HoaDonBan dalHDB = new DAL_HoaDonBan();
        DAL_ChiTietHoaDonBan dalCT = new DAL_ChiTietHoaDonBan();

        // Phương thức lấy toàn bộ danh sách hóa đơn bán
        public DataTable LayDanhSachHoaDonBan()
        {
            return dalHDB.LayDanhSachHoaDonBan();
        }

        // Phương thức xóa hóa đơn bán (DONE)
        public bool XoaHoaDon(string soHDB)
        {
            // Đầu tiên, xóa các chi tiết hóa đơn liên quan
            bool xoaChiTietThanhCong = dalCT.XoaChiTietHoaDonTheoSoHDB(soHDB);

            if (xoaChiTietThanhCong)
            {
                // Nếu xóa chi tiết thành công, tiếp tục xóa hóa đơn
                return dalHDB.XoaHoaDonBan(soHDB);
            }
            else
            {
                Console.WriteLine("Không thể xóa chi tiết hóa đơn, hủy thao tác xóa hóa đơn.");
                return false;
            }
        }

        public DataTable TimKiemHoaDon(string keyword, string month, string year)
        {
            return dalHDB.TimKiemHoaDon(keyword, month, year);
        }

        public string TaoMaHoaDon()
        {
            int stt = dalHDB.LaySoThuTuHoaDonTrongNgay();
            string ngayHienTai = DateTime.Now.ToString("ddMMyyyy");
            return $"HDB{stt:D5}{ngayHienTai}"; // Tạo mã hóa đơn với định dạng HDBxxxxxDDMMYYYY
        }

        public void ThemHoaDon(DTO_HoaDonBan hd)
        {
            dalHDB.ThemHoaDon(hd);
        }

        public string LaySoHDBCuoi()
        {
            return dalHDB.LaySoHDBCuoi();
        }

        // Phương thức lấy thông tin hóa đơn
        public DTO_HoaDonBan LayThongTinHoaDon(string soHDB)
        {
            return dalHDB.LayThongTinHoaDon(soHDB);
        }

        // Phương thức in danh sách hóa đơn ra Excel

        public void InDanhSachHoaDon()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            DataTable dtHDB = LayDanhSachHoaDonBan(); // Lấy danh sách hóa đơn
            using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add("Danh Sách Hóa Đơn");

                // Đặt tiêu đề cột
                workSheet.Cells[1, 1].Value = "Số HDB";
                workSheet.Cells[1, 2].Value = "Ngày Bán";
                workSheet.Cells[1, 3].Value = "Mã NV";
                workSheet.Cells[1, 4].Value = "Mã Khách";
                workSheet.Cells[1, 5].Value = "Giảm Giá";
                workSheet.Cells[1, 6].Value = "Tổng Tiền";

                // Ghi dữ liệu vào worksheet
                for (int i = 0; i < dtHDB.Rows.Count; i++)
                {
                    workSheet.Cells[i + 2, 1].Value = dtHDB.Rows[i]["SoHDB"];
                    workSheet.Cells[i + 2, 2].Value = dtHDB.Rows[i]["NgayBan"];
                    workSheet.Cells[i + 2, 3].Value = dtHDB.Rows[i]["MaNV"];
                    workSheet.Cells[i + 2, 4].Value = dtHDB.Rows[i]["MaKhach"];
                    workSheet.Cells[i + 2, 5].Value = dtHDB.Rows[i]["GiamGia"];
                    workSheet.Cells[i + 2, 6].Value = dtHDB.Rows[i]["TongTien"];
                }

                // Lưu file Excel
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"DanhSachHoaDon_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
                FileInfo excelFile = new FileInfo(filePath);
                excel.SaveAs(excelFile);

                // Thông báo cho người dùng
                Console.WriteLine("Đã in danh sách hóa đơn ra file Excel tại: " + filePath);
            }
        }


    }
}