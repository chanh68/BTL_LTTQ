using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace GUI_QuanLy
{
    public partial class SidebarControl : UserControl
    {
        private Timer timerSanPham;
        private Timer timerHoaDon;
        private Timer timerNhanSu;
        private bool menuSanPhamExpand = false;
        private bool menuHoaDonExpand = false;
        private bool menuNhanSuExpand = false;
        public SidebarControl()
        {
            InitializeComponent();
            btnTrangChu.Refresh();
            btnNhanSu.Refresh();
            btnSanPham.Refresh();
            btnThongTin.Refresh();
            btnDanhMuc.Refresh();
            btnTraCuu.Refresh();
            btnHoaDon.Refresh();
            btnNhaCungCap.Refresh();
            btnKhachHang.Refresh();
            btnHoaDonBan.Refresh();
            btnHoaDonNhap.Refresh();
            btnLuong.Refresh();
            btnDanhSach.Refresh();
            btnTaiKhoan.Refresh();
            btnThongKe.Refresh();
            timerSanPham = new Timer();
            timerSanPham.Interval = 10;
            timerHoaDon = new Timer();
            timerHoaDon.Interval = 10;
            timerNhanSu = new Timer();
            timerNhanSu.Interval = 10;
            timerSanPham.Tick += new EventHandler(timerSanPham_Tick);
            timerHoaDon.Tick += new EventHandler(timerHoaDon_Tick);
            timerNhanSu.Tick += new EventHandler(timerNhanSu_Tick);
        }
        private void SidebarControl_Load(object sender, EventArgs e)
        {
            panelSP.Height = 38;
            panelHoaDon.Height = 38;
            panelNhanSu.Height = 38;
            menuSanPhamExpand = false;
            menuHoaDonExpand = false;
            menuNhanSuExpand = false;
        }
        private void timerSanPham_Tick(object sender, EventArgs e)
            {
                int expandSpeed = 10;
                int menuExpandedHeight = 160;
                int panelHoaDonollapsedHeight = 38;

                if (!menuSanPhamExpand)
                {
                    if (panelSP.Height < menuExpandedHeight)
                    {
                        panelSP.Height += expandSpeed;
                        if (panelSP.Height >= menuExpandedHeight)
                        {
                            panelSP.Height = menuExpandedHeight;
                            timerSanPham.Stop();
                            menuSanPhamExpand = true;
                        MoveButtons1(110);
                    }
                }
                }
                else
                {
                    if (panelSP.Height > panelHoaDonollapsedHeight)
                    {
                        panelSP.Height -= expandSpeed;
                        if (panelSP.Height <= panelHoaDonollapsedHeight)
                        {
                            panelSP.Height = panelHoaDonollapsedHeight;
                            timerSanPham.Stop();
                            menuSanPhamExpand = false;
                        MoveButtons1(-110);
                    }
                }
                }
            }

        private void timerHoaDon_Tick(object sender, EventArgs e)
        {
            int expandSpeed = 10;
            int menuExpandedHeight = 120;
            int panelHoaDonollapsedHeight = 38;

            if (!menuHoaDonExpand)
            {
                if (panelHoaDon.Height < menuExpandedHeight)
                {
                    panelHoaDon.Height += expandSpeed;
                    if (panelHoaDon.Height >= menuExpandedHeight)
                    {
                        panelHoaDon.Height = menuExpandedHeight;
                        timerHoaDon.Stop();
                        menuHoaDonExpand = true;
                        MoveButtons(80);
                    }
                }
            }
            else
            {
                if (panelHoaDon.Height > panelHoaDonollapsedHeight)
                {
                    panelHoaDon.Height -= expandSpeed;
                    if (panelHoaDon.Height <= panelHoaDonollapsedHeight)
                    {
                        panelHoaDon.Height = panelHoaDonollapsedHeight;
                        timerHoaDon.Stop();
                        menuHoaDonExpand = false;
                        MoveButtons(-80);
                    }
                }
            }
        }
        private void timerNhanSu_Tick(object sender, EventArgs e)
        {
            int expandSpeed = 10;
            int menuExpandedHeight = 160;
            int panelHoaDonollapsedHeight = 38;

            if (!menuNhanSuExpand)
            {
                if (panelNhanSu.Height < menuExpandedHeight)
                {
                    panelNhanSu.Height += expandSpeed;
                    if (panelNhanSu.Height >= menuExpandedHeight)
                    {
                        panelNhanSu.Height = menuExpandedHeight;
                        timerNhanSu.Stop();
                        menuNhanSuExpand = true;
                        MoveButtons2(110);
                    }
                }
            }
            else
            {
                if (panelNhanSu.Height > panelHoaDonollapsedHeight)
                {
                    panelNhanSu.Height -= expandSpeed;
                    if (panelNhanSu.Height <= panelHoaDonollapsedHeight)
                    {
                        panelNhanSu.Height = panelHoaDonollapsedHeight;
                        timerNhanSu.Stop();
                        menuNhanSuExpand = false;
                        MoveButtons2(-110);
                    }
                }
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            if (!menuSanPhamExpand)
            {
                timerSanPham.Start();
            }
            else
            {
                // Nếu menu đã mở, không làm gì cả
            }
        }
        private void btnThongTin_Click(object sender, EventArgs e)
        {
            timerSanPham.Start();   
            InfoProduct infoProduct = new InfoProduct();
            infoProduct.ShowDialog();
        }



        private void btnHoaDon_Click(object sender, EventArgs e)
            {
                timerHoaDon.Start();
            }
           private void btnNhanSu_Click(object sender, EventArgs e)
           {
            timerNhanSu.Start();
           }
        private void MoveButtons(int offsetY)
        {
            btnKhachHang.Location = new Point(btnKhachHang.Location.X, btnKhachHang.Location.Y + offsetY);
            panelNhanSu.Location = new Point(panelNhanSu.Location.X, panelNhanSu.Location.Y + offsetY);
            btnNhaCungCap.Location = new Point(btnNhaCungCap.Location.X, btnNhaCungCap.Location.Y + offsetY);
            btnThongKe.Location = new Point(btnThongKe.Location.X, btnThongKe.Location.Y + offsetY);
            picTK.Location = new Point(picTK.Location.X, picTK.Location.Y + offsetY);
            picKH.Location = new Point(picKH.Location.X, picKH.Location.Y + offsetY);
            picNCC.Location = new Point(picNCC.Location.X, picNCC.Location.Y + offsetY);
            btnThoat.Location = new Point(btnThoat.Location.X, btnThoat.Location.Y + offsetY);

        }
        private void MoveButtons1(int offsetY)
        {
            panelHoaDon.Location = new Point(panelHoaDon.Location.X, panelHoaDon.Location.Y + offsetY);
            btnKhachHang.Location = new Point(btnKhachHang.Location.X, btnKhachHang.Location.Y + offsetY);
            panelNhanSu.Location = new Point(panelNhanSu.Location.X, panelNhanSu.Location.Y + offsetY);
            btnNhaCungCap.Location = new Point(btnNhaCungCap.Location.X, btnNhaCungCap.Location.Y + offsetY);
            btnThongKe.Location = new Point(btnThongKe.Location.X, btnThongKe.Location.Y + offsetY);
            picTK.Location = new Point(picTK.Location.X, picTK.Location.Y + offsetY);
            picKH.Location = new Point(picKH.Location.X, picKH.Location.Y + offsetY);
            btnThoat.Location = new Point(btnThoat.Location.X, btnThoat.Location.Y + offsetY);
            picNCC.Location = new Point(picNCC.Location.X, picNCC.Location.Y + offsetY);
        }
        private void MoveButtons2(int offsetY)
        {
            btnNhaCungCap.Location = new Point(btnNhaCungCap.Location.X, btnNhaCungCap.Location.Y + offsetY);
            picNCC.Location = new Point(picNCC.Location.X, picNCC.Location.Y + offsetY);
            btnThongKe.Location = new Point(btnThongKe.Location.X, btnThongKe.Location.Y + offsetY);
            picTK.Location = new Point(picTK.Location.X,picTK.Location.Y + offsetY);
            btnThoat.Location = new Point(btnThoat.Location.X, btnThoat.Location.Y + offsetY);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.ShowDialog();
        }


    }
    }

