using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_KhachHang
    {
        private string _MaKhach;
        private string _TenKhach;
        private string _DienThoai;
        private string _DiaChi;

        public string MaKhach
        {
            get { return _MaKhach; }
            set { _MaKhach = value; }
        }

        public string TenKhach
        {
            get { return _TenKhach; }
            set { _TenKhach = value; }
        }

        public string DienThoai
        {
            get { return _DienThoai; }
            set { _DienThoai = value; }
        }

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }

        public DTO_KhachHang() { }

        public DTO_KhachHang(string maKH, string tenKH, string dienThoai, string diaChi)
        {
            this.MaKhach = maKH;
            this.TenKhach = tenKH;
            this.DienThoai = dienThoai;
            this.DiaChi = diaChi;
        }
    }
}
