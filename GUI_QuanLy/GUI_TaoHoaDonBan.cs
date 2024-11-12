using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLy;
using BUS_QuanLy;
using COMExcel = Microsoft.Office.Interop.Excel;
using DAL_QuanLy;

namespace GUI_QuanLy
{
    public partial class GUI_TaoHoaDonBan : Form
    {
        private BUS_ChiTietHoaDonBan busCTHDB = new BUS_ChiTietHoaDonBan();
        private BUS_HoaDonBan busHDB = new BUS_HoaDonBan();
        private BUS_HangHoa busHH = new BUS_HangHoa();
        private BUS_KhachHang busKH = new BUS_KhachHang();
        private BUS_NhanVien busNV = new BUS_NhanVien();
        DataTable dt;
        public GUI_TaoHoaDonBan()
        {
            InitializeComponent();
        }

        public GUI_TaoHoaDonBan (string soHDB)
        {
            InitializeComponent();
        }

        DataTable ChiTietHoaDonBan;
        private void GUI_TaoHoaDonBan_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
            txtMaHD.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";

        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHD.Text = Functions.CreateKey("HDB");
        }


        private void ResetValues()
        {
            txtMaHD.Text = "";
            txtNgayBan.Text = DateTime.Now.ToShortDateString();
            cbbMaMV.Text = "";
            cbbMaKH.Text = "";
            txtTongTien.Text = "0";
            lblBangChu.Text = "Bằng chữ: ";
            cbbMaHang.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblHoaDonBanHang_Click(object sender, EventArgs e)
        {

        }

        private void lblMaHang_Click(object sender, EventArgs e)
        {

        }

        private void lblHuongDan_Click(object sender, EventArgs e)
        {

        }



        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void cbbMaMV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbMaMV_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
