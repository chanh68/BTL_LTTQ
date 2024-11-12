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

namespace GUI_QuanLy
{
    public partial class GUI_TaoHoaDonBan : Form
    {
        public GUI_TaoHoaDonBan()
        {
            InitializeComponent();
        }

        DataTable ChiTietHoaDonBan;
        private void GUI_TaoHoaDonBan_Load(object sender, EventArgs e)
        {
            btnThemHoaDon.Enabled = true;
            btnLuuHoaDon.Enabled = false;
            btnInHoaDon.Enabled = false;
            btnHuyHoaDon.Enabled = false;
            txtMaHD.ReadOnly = true;

            txtTenNV.ReadOnly = true;

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

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}