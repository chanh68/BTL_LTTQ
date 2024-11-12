using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ChiTietHoaDonNhap
    {
        private string _SoHDN;
        private string _MaHang;
        private string _TenHang;
        private int _SoLuong;
        private decimal _DonGia;
        private decimal _ThanhTien;

        public string SoHDN { get; set; }
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        public DTO_ChiTietHoaDonNhap() { }

        public DTO_ChiTietHoaDonNhap(string maHDN, string maHang, string tenHang, int soLuong, decimal donGia, decimal thanhTien)
        {
            this.SoHDN = maHDN;
            this.MaHang = maHang;
            this.TenHang = tenHang;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }
    }

}
