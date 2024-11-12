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
//using COMExcel = Microsoft.Office.Interop.Excel;
using DAL_QuanLy;

namespace GUI_QuanLy
{
    public partial class GUI_TaoHoaDonBan : Form
    {
        BUS_KhachHang busKH = new BUS_KhachHang();
        BUS_HangHoa busHH = new BUS_HangHoa();
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_HoaDonBan busHDB = new BUS_HoaDonBan();
        BUS_ChiTietHoaDonBan busCT = new BUS_ChiTietHoaDonBan();
        BUS_TaiKhoan busTK = new BUS_TaiKhoan();

        BindingSource bindingSource = new BindingSource();
        private List<DTO_ChiTietHoaDonBan> chiTietHoaDonBanList = new List<DTO_ChiTietHoaDonBan>();

        // Khởi tạo giao diện thêm hóa đơn mới
        public GUI_TaoHoaDonBan()
        {
            InitializeComponent();
            LoadForm();
        }

        // Khởi tạo giao diện sửa hóa đơn
        public GUI_TaoHoaDonBan(string soHDB)
        {
            InitializeComponent();
            LoadHoaDon(soHDB);
        }

        private void LoadForm()
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
            txtMaHD.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";

            LoadDataComboBox();

            // Tạo mã hóa đơn mới nếu vào chế độ thêm mới
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                txtMaHD.Text = busHDB.TaoMaHoaDon();
                txtTenNV.Text = busTK.GetEmployeeNameByAccount(cbMaMV.Text);
            }
        }

        //Nạp dữ liệu vào combobox
        private void LoadDataComboBox()
        {
            // Nạp danh sách mã khách hàng
            cbMaKH.DataSource = busKH.LayDanhSachKhachHang();
            cbMaKH.DisplayMember = "MaKhach";
            cbMaKH.ValueMember = "MaKhach";

            // Nạp danh sách mã hàng
            cbMaHang.DataSource = busHH.LayDanhSachHangHoa();
            cbMaHang.DisplayMember = "MaHang";
            cbMaHang.ValueMember = "MaHang";
        }


        // Hàm tải thông tin hóa đơn để sửa
        private void LoadHoaDon(string maHDB)
        {
            // Điều chỉnh trạng thái các nút và trường dữ liệu cho chế độ chỉnh sửa
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            //btnXoa.Enabled = false;    
            //btnIn.Enabled = false;      

            // Vô hiệu hóa một số trường không cần chỉnh sửa
            txtMaHD.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            dtpNgayBan.Enabled = false;
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtTongTien.ReadOnly = true;

            var hoaDon = busHDB.LayThongTinHoaDon(maHDB);
            if (hoaDon != null)
            {
                txtMaHD.Text = hoaDon.SoHDB;
                dtpNgayBan.Value = hoaDon.NgayBan;
                cbMaMV.Text = hoaDon.MaNV;
                txtTenNV.Text = busNV.LayTenNhanVien(hoaDon.MaNV);
            }

            var khacHang = busKH.LayThongTinKhachHang(hoaDon.MaKhach);
            if (khacHang != null)
            {
                cbMaKH.SelectedValue = khacHang.MaKhach;
                txtTenKH.Text = khacHang.TenKhach;
                txtDiaChi.Text = khacHang.DiaChi;
                txtSDT.Text = khacHang.DienThoai;
            }

            LoadDataComboBox();

            List<DTO_ChiTietHoaDonBan> ChiTietHoaDonBan = busCT.LayChiTietHoaDon(maHDB);
            dgvDSMatHang.DataSource = ChiTietHoaDonBan;
            bindingSource.DataSource = ChiTietHoaDonBan;
            dgvDSMatHang.DataSource = bindingSource;

            // Ẩn cột SoHDB
            dgvDSMatHang.Columns["SoHDB"].Visible = false;
            // Đổi tên các cột
            dgvDSMatHang.Columns["MaHang"].HeaderText = "Mã Hàng";
            dgvDSMatHang.Columns["TenHang"].HeaderText = "Tên Hàng";
            dgvDSMatHang.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvDSMatHang.Columns["DonGiaBan"].HeaderText = "Đơn Giá";
            dgvDSMatHang.Columns["GiamGia"].HeaderText = "Giảm Giá (%)";
            dgvDSMatHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";

            CapNhatTongTien();
        }

        // Cập nhật tổng tiền
        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            foreach (var row in chiTietHoaDonBanList)
            {
                tongTien += row.ThanhTien;
            }
            txtTongTien.Text = tongTien.ToString("N0");
        }

        private void GUI_TaoHoaDonBan_Load(object sender, EventArgs e)
        {
        }

        private void cbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaHang.SelectedIndex != null)
            {
                string maHH = cbMaHang.SelectedValue.ToString();
                var hangHoa = busHH.LayThongTinHangHoa(maHH);

                if (hangHoa != null)
                {
                    txtTenHang.Text = hangHoa.TenHangHoa;
                    txtDonGia.Text = hangHoa.DonGiaBan.ToString("N0");
                }

            }
        }

        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maKH = cbMaKH.SelectedValue.ToString();
            var khachHang = busKH.LayThongTinKhachHang(maKH);

            if (khachHang != null)
            {
                txtTenKH.Text = khachHang.TenKhach;
                txtDiaChi.Text = khachHang.DiaChi;
                txtSDT.Text = khachHang.DienThoai;
            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Kiểm tra dữ liệu hợp lệ trước khi tính toán
                if (int.TryParse(txtSoLuong.Text, out int soLuong) && decimal.TryParse(txtDonGia.Text, out decimal donGia))
                {
                    decimal giamGia = string.IsNullOrEmpty(txtGiamGia.Text) ? 0 : decimal.Parse(txtGiamGia.Text);
                    decimal thanhTien = soLuong * donGia * (1 - giamGia / 100);

                    // Tìm chi tiết hóa đơn tương ứng với mã hàng được chọn
                    var selectedItem = chiTietHoaDonBanList.Find(item => item.MaHang == cbMaHang.SelectedValue.ToString());

                    if (selectedItem != null)
                    {
                        // Cập nhật số lượng và thành tiền của chi tiết hóa đơn
                        selectedItem.SoLuong = soLuong;
                        selectedItem.GiamGia = giamGia;
                        selectedItem.ThanhTien = thanhTien;
                    }
                    else
                    {
                        // Tạo chi tiết hóa đơn mới
                        DTO_ChiTietHoaDonBan chiTiet = new DTO_ChiTietHoaDonBan
                        {
                            MaHang = cbMaHang.SelectedValue.ToString(),
                            TenHang = txtTenHang.Text,
                            SoLuong = soLuong,
                            GiamGia = giamGia,
                            DonGiaBan = donGia,
                            ThanhTien = thanhTien
                        };

                        // Thêm vào danh sách chi tiết hóa đơn
                        chiTietHoaDonBanList.Add(chiTiet);
                    }

                    // Cập nhật DataGridView
                    bindingSource.DataSource = null; // Reset DataSource
                    bindingSource.DataSource = chiTietHoaDonBanList; // Gán lại DataSource
                    dgvDSMatHang.DataSource = bindingSource;
                    // Ẩn cột "SoHDB"
                    dgvDSMatHang.Columns["SoHDB"].Visible = false;

                    // Đổi tên các cột
                    dgvDSMatHang.Columns["MaHang"].HeaderText = "Mã Hàng";
                    dgvDSMatHang.Columns["TenHang"].HeaderText = "Tên Hàng";
                    dgvDSMatHang.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgvDSMatHang.Columns["DonGiaBan"].HeaderText = "Đơn Giá";
                    dgvDSMatHang.Columns["GiamGia"].HeaderText = "Giảm Giá (%)";
                    dgvDSMatHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";

                    // Cập nhật tổng tiền
                    CapNhatTongTien();

                    // Reset các trường nhập liệu
                    txtSoLuong.Clear();
                    txtGiamGia.Clear();
                    txtGiamGia.Text = "0";
                    txtSoLuong.Focus(); // Đặt con trỏ lại vào ô nhập số lượng
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnXoa.Enabled = true;
            btnIn.Enabled = false;
            txtMaHD.Text = busHDB.TaoMaHoaDon();
            chiTietHoaDonBanList.Clear();
            bindingSource.ResetBindings(false);  // Cập nhật BindingSource
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            DTO_HoaDonBan hoaDon = new DTO_HoaDonBan
            {
                SoHDB = txtMaHD.Text,
                NgayBan = dtpNgayBan.Value,
                MaNV = cbMaMV.Text,
                MaKhach = cbMaKH.Text,
                TongTien = decimal.Parse(txtTongTien.Text)
            };

            // Kiểm tra nếu là hóa đơn mới hay cập nhật hóa đơn cũ
            if (string.IsNullOrEmpty(txtMaHD.Text) || txtMaHD.Text == busHDB.TaoMaHoaDon()) // Hóa đơn mới
            {
                busHDB.ThemHoaDon(hoaDon);
                // Thêm chi tiết hóa đơn
                foreach (var chiTiet in chiTietHoaDonBanList)
                {
                    chiTiet.SoHDB = txtMaHD.Text; // Gán mã hóa đơn cho chi tiết hóa đơn
                    busCT.ThemChiTietHoaDon(chiTiet);
                }
                MessageBox.Show("Hóa đơn đã được thêm thành công!");
            }
            else // Cập nhật hóa đơn cũ
            {
                busHDB.CapNhatHoaDon(hoaDon);
                // Cập nhật chi tiết hóa đơn
                foreach (var chiTiet in chiTietHoaDonBanList)
                {
                    busCT.CapNhatChiTietHoaDon(chiTiet);
                }
                MessageBox.Show("Hóa đơn đã được cập nhật thành công!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                busHDB.XoaHoaDon(txtMaHD.Text);
                MessageBox.Show("Xóa hóa đơn thành công!");
                this.Close();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Gọi hàm in hóa đơn
            MessageBox.Show("In hóa đơn thành công!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDSMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu hàng được chọn hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy hàng đã chọn
                DataGridViewRow row = dgvDSMatHang.Rows[e.RowIndex];

                // Cập nhật các ô nhập liệu với thông tin từ hàng đã chọn
                cbMaHang.SelectedValue = row.Cells["MaHang"].Value.ToString();
                txtTenHang.Text = row.Cells["TenHang"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGiaBan"].Value.ToString();
                txtGiamGia.Text = row.Cells["GiamGia"].Value.ToString();
            }
        }
    }
}