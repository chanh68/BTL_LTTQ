using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;

namespace GUI_QuanLy
{
    public partial class GUI_TrangChu : Form
    {
        private BUS_TaiKhoan bus_TaiKhoan;
        private string tenNV;
        public GUI_TrangChu()
        {
            InitializeComponent();
            customizeDesing();
        }
        public GUI_TrangChu(string tenNguoiDung)
        {
            InitializeComponent();
            //subMenu
            customizeDesing();
            //Tên người dùng
            bus_TaiKhoan = new BUS_TaiKhoan();
            tenNV = tenNguoiDung;
            LoadEmployeeName();
        }
        //PHƯƠNG THỨC TRẢ VỀ TÊN NGƯỜI DÙNG
        private void LoadEmployeeName()
        {
            string tenNV = bus_TaiKhoan.GetEmployeeNameByAccount(Global.MaNV);
            if (!string.IsNullOrEmpty(tenNV))
            {
                txtNguoiDung.Text = "Xin chào: " + tenNV;
            }
            else
            {
                MessageBox.Show("Không tìm thấy tên nhân viên!");
            }
        }

        //sideBar
        private void customizeDesing()
        {
            panelSPSubmenu.Visible = false;
            panelHDSubmenu.Visible = false;
            panelNSSubmenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelSPSubmenu.Visible == true) 
                panelSPSubmenu.Visible = false;
            if (panelHDSubmenu.Visible == true)
                panelHDSubmenu.Visible = false;
            if (panelNSSubmenu.Visible == true)
                panelNSSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu) 
        {
            if (subMenu.Visible == false) 
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
            
        }
        //subMenu
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSPSubmenu);
        }
        private void btnThongTinSanPham_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new InfoProduct());
            hideSubMenu();
        }

        private void btnTraCuuTinhTrang_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            showSubMenu(panelHDSubmenu);
        }

        private void btnHoaDonBan_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new GUI_HoaDonBan());
            //hideSubMenu();
        }

        private void btnHoaDonNhap_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new GUI_HoaDonNhap());
            //hideSubMenu();
        }

        private void btnNhanSu_Click(object sender, EventArgs e)
        {
            showSubMenu(panelNSSubmenu);
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new HomePage());
        }
        private void btnAvatar_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Information());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }


        //Phuong thuc chuyen trang
        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Signin loginForm = new Signin();
                loginForm.Show();
                this.Hide();
            }
        }
        private void GUI_TrangChu_Load(object sender, EventArgs e)
        {

        }
        private void pictureBoxAvatar_Click(object sender, EventArgs e)
        {
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {

        }

        private void lblTenNguoiDung_Click(object sender, EventArgs e)
        {

        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {

        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {

        }

        private void panelNSSubmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void panelHDSubmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSPSubmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogo_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelHeaderBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNguoiDung_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelHeaderTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }
    }
}
