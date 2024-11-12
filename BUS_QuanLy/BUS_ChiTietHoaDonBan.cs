using DAL_QuanLy;
using DTO_QuanLy;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BUS_QuanLy
{
    public class BUS_ChiTietHoaDonBan
    {
        DAL_ChiTietHoaDonBan dalCT = new DAL_ChiTietHoaDonBan();

        // Phương thức lấy chi tiết hóa đơn từ mã hóa đơn
        public List<DTO_ChiTietHoaDonBan> LayChiTietHoaDon(string soHDB)
        {
            return dalCT.LayChiTietHoaDon(soHDB);
        }

        public void ThemChiTietHoaDon(DTO_ChiTietHoaDonBan ct)
        {
            dalCT.ThemChiTietHoaDon(ct);
        }

        public bool XoaChiTietHoaDonTheoSoHDB(string soHDB)
        {
            return dalCT.XoaChiTietHoaDonTheoSoHDB(soHDB);
        }

        // Phương thức in chi tiết hóa đơn ra Excel
        public void InChiTietHoaDon(string soHDB)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            BUS_ChiTietHoaDonBan busCT = new BUS_ChiTietHoaDonBan();
            BUS_KhachHang busKH = new BUS_KhachHang(); // Lấy thông tin khách hàng

            List<DTO_ChiTietHoaDonBan> chiTietList = busCT.LayChiTietHoaDon(soHDB); // Lấy chi tiết hóa đơn
            DTO_KhachHang khachHang = busKH.ThongTinKhachHangTheoSoHoaDon(soHDB); // Lấy thông tin khách hàng


            using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add("Chi Tiết Hóa Đơn");

                // Thêm thông tin khách hàng và địa chỉ quán
                workSheet.Cells[1, 1].Value = "Thông Tin Khách Hàng:";
                workSheet.Cells[2, 1].Value = "Tên Khách Hàng: " + khachHang.TenKhach;
                workSheet.Cells[3, 1].Value = "Địa Chỉ: " + khachHang.DiaChi;
                workSheet.Cells[4, 1].Value = "Số Điện Thoại: " + khachHang.DienThoai;

                workSheet.Cells[5, 1].Value = "Thông Tin Cửa Hàng:";
                workSheet.Cells[6, 1].Value = "Tên Cửa Hàng:  Đồ Gốm CNTT4";
                workSheet.Cells[7, 1].Value = "Địa Chỉ: Số 3 đường Cầu Giấy, quận Đống Đa, thành phố Hà Nội. ";
                workSheet.Cells[8, 1].Value = "Số Điện Thoại : 0987654321";

                // Đặt tiêu đề cột cho chi tiết hóa đơn
                workSheet.Cells[9, 1].Value = "Mã Hàng";
                workSheet.Cells[9, 2].Value = "Tên Hàng";
                workSheet.Cells[9, 3].Value = "Số Lượng";
                workSheet.Cells[9, 4].Value = "Giảm Giá";
                workSheet.Cells[9, 5].Value = "Đơn Giá";
                workSheet.Cells[9, 6].Value = "Thành Tiền";

                // Định dạng tiêu đề cột
                using (var range = workSheet.Cells[9, 1, 9, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                }

                // Ghi dữ liệu vào worksheet
                for (int i = 0; i < chiTietList.Count; i++)
                {
                    workSheet.Cells[i + 10, 1].Value = chiTietList[i].MaHang;
                    workSheet.Cells[i + 10, 2].Value = chiTietList[i].TenHang;
                    workSheet.Cells[i + 10, 3].Value = chiTietList[i].SoLuong;
                    workSheet.Cells[i + 10, 4].Value = chiTietList[i].GiamGia;
                    workSheet.Cells[i + 10, 5].Value = chiTietList[i].DonGiaBan;
                    workSheet.Cells[i + 10, 6].Value = chiTietList[i].ThanhTien;
                }

                // Tính toán tổng tiền
                decimal tongTien = chiTietList.Sum(item => item.ThanhTien);
                workSheet.Cells[chiTietList.Count + 10, 5].Value = "Tổng Tiền:";
                workSheet.Cells[chiTietList.Count + 10, 6].Value = tongTien;

                // Định dạng dòng tổng tiền (in đậm, căn giữa)
                using (var range = workSheet.Cells[chiTietList.Count + 10, 5, chiTietList.Count + 10, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Lưu file Excel
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"ChiTietHoaDon_{soHDB}.xlsx");
                FileInfo excelFile = new FileInfo(filePath);
                excel.SaveAs(excelFile);

                // Thông báo cho người dùng
                Console.WriteLine("Đã in chi tiết hóa đơn ra file Excel tại: " + filePath);
            }    
        }
    }
}
