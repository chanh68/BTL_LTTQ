using DAL_QuanLy;
using DTO_QuanLy;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_HoaDonNhap
    {
        DAL_HoaDonNhap dalHDN = new DAL_HoaDonNhap();
        DAL_ChiTietHoaDonNhap dalCT = new DAL_ChiTietHoaDonNhap();


        // Phương thức lấy toàn bộ danh sách hóa đơn bán
        public DataTable LayDanhSachHoaDonNhap()
        {
            return dalHDN.LayDanhSachHoaDonNhap();
        }

        // Phương thức xóa hóa đơn 
        public bool XoaHoaDon(string soHDN)
        {
            // Đầu tiên, xóa các chi tiết hóa đơn liên quan
            bool xoaChiTietThanhCong = dalCT.XoaChiTietHoaDonTheoSoHDN(soHDN);

            if (xoaChiTietThanhCong)
            {
                // Nếu xóa chi tiết thành công, tiếp tục xóa hóa đơn
                return dalHDN.XoaHoaDonBan(soHDN);
            }
            else
            {
                Console.WriteLine("Không thể xóa chi tiết hóa đơn, hủy thao tác xóa hóa đơn.");
                return false;
            }
        }

        public DataTable TimKiemHoaDon(string keyword, string month, string year)
        {
            return dalHDN.TimKiemHoaDon(keyword, month, year);
        }

        public string TaoMaHoaDon()
        {
            int stt = dalHDN.LaySoThuTuHoaDonTrongNgay();
            string ngayHienTai = DateTime.Now.ToString("ddMMyyyy");
            return $"HDN{stt:D5}{ngayHienTai}";
        }

        public void ThemHoaDon(DTO_HoaDonNhap hd)
        {
            dalHDN.ThemHoaDon(hd);
        }

        public string LaySoHDNCuoi()
        {
            return dalHDN.LaySoHDNCuoi();
        }

        // Phương thức lấy thông tin hóa đơn
        public DTO_HoaDonNhap LayThongTinHoaDon(string soHDN)
        {
            return dalHDN.LayThongTinHoaDon(soHDN);
        }

        // Phương thức in danh sách hóa đơn ra Excel

        public void InDanhSachHoaDon()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            DataTable dtHDN = LayDanhSachHoaDonNhap(); // Lấy danh sách hóa đơn
            using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add("Danh Sách Hóa Đơn");

                // Đặt tiêu đề cột
                workSheet.Cells[1, 1].Value = "Số HDN";
                workSheet.Cells[1, 2].Value = "Ngày Nhập";
                workSheet.Cells[1, 3].Value = "Mã NV";
                workSheet.Cells[1, 4].Value = "Mã NCC";
                workSheet.Cells[1, 5].Value = "Tổng Tiền";

                // Ghi dữ liệu vào worksheet
                for (int i = 0; i < dtHDN.Rows.Count; i++)
                {
                    workSheet.Cells[i + 2, 1].Value = dtHDN.Rows[i]["SoHDN"];
                    workSheet.Cells[i + 2, 2].Value = dtHDN.Rows[i]["NgayNhap"];
                    workSheet.Cells[i + 2, 3].Value = dtHDN.Rows[i]["MaNV"];
                    workSheet.Cells[i + 2, 4].Value = dtHDN.Rows[i]["MaNCC"];
                    workSheet.Cells[i + 2, 5].Value = dtHDN.Rows[i]["TongTien"];
                }

                // Lưu file Excel
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "DanhSachHoaDon.xlsx");
                FileInfo excelFile = new FileInfo(filePath);
                excel.SaveAs(excelFile);

                // Thông báo cho người dùng
                Console.WriteLine("Đã in danh sách hóa đơn ra file Excel tại: " + filePath);
            }
        }

    }
}
