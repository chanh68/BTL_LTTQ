using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ChiTietHoaDonBan
    {
        private string _SoHDB;
        private string _MaHang;
        private int _SoLuong;
        private decimal _GiamGia;
        private decimal _DonGiaBan;
        private decimal _ThanhTien;
        private string _TenHang;

        public string SoHDB { get; set; }
        public string MaHang { get; set; }
        public int SoLuong { get; set; }
        public decimal GiamGia { get; set; }
        public decimal DonGiaBan { get; set; }
        public decimal ThanhTien { get; set; }
        public string TenHang { get; set; }

        public DTO_ChiTietHoaDonBan() { }

        public DTO_ChiTietHoaDonBan(string soHDB, string maHang, int soLuong, decimal giamGia, decimal donGiaBan, decimal thanhTien, string tenHang)
        {
            this.SoHDB = soHDB;
            this.MaHang = maHang;
            this.SoLuong = soLuong;
            this.GiamGia = giamGia;
            this.DonGiaBan = donGiaBan;
            this.ThanhTien = thanhTien;
            this.TenHang = tenHang;
        }
    }

}