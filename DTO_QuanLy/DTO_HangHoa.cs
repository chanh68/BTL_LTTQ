﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HangHoa
    {
        private string _MaHang;
        private string _TenHang;
        private string _MaLoai;
        private string _MaKichThuoc;
        private string _MaCongDung;
        private string _MaLoaiMen;
        private string _MaHinhKhoi;
        private string _MaMau;
        private string _MaNuocSX;
        private int _SoLuong;
        private decimal _DonGiaNhap;
        private decimal _DonGiaBan;
        private string _Anh;
        private string _GhiChu;

        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MaLoai { get; set; }
        public string MaKichThuoc { get; set; }
        public string MaCongDung { get; set; }
        public string MaLoaiMen { get; set; }
        public string MaHinhKhoi { get; set; }
        public string MaMau { get; set; }
        public string MaNuocSX { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public string Anh { get; set; }
        public string GhiChu { get; set; }

        public DTO_HangHoa() { }

        public DTO_HangHoa(string maHang, string tenHangHoa, string maLoai, string maKichThuoc, string maCongDung, string maLoaiMen, string maHinhKhoi, string maMau, string maNuocSX, int soLuong, decimal donGiaNhap, decimal donGiaBan, string anh, string ghiChu)
        {
            this.MaHang = maHang;
            this.TenHang = tenHangHoa;
            this.MaLoai = maLoai;
            this.MaKichThuoc = maKichThuoc;
            this.MaCongDung = maCongDung;
            this.MaLoaiMen = maLoaiMen;
            this.MaHinhKhoi = maHinhKhoi;
            this.MaMau = maMau;
            this.MaNuocSX = maNuocSX;
            this.SoLuong = soLuong;
            this.DonGiaNhap = donGiaNhap;
            this.DonGiaBan = donGiaBan;
            this.Anh = anh;
            this.GhiChu = ghiChu;
        }
    }

}
