using BUS_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace GUI_QuanLy
{
    public partial class GUI_TaoHoaDonNhap : Form
    {
        BUS_HangHoa busHH = new BUS_HangHoa();
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_TaiKhoan busTK = new BUS_TaiKhoan();
        BUS_NhaCungCap busNCC = new BUS_NhaCungCap();
        BUS_HoaDonNhap busHDN = new BUS_HoaDonNhap();
        BUS_ChiTietHoaDonNhap busCT = new BUS_ChiTietHoaDonNhap();

        BindingSource bindingSource = new BindingSource();
        private List<DTO_ChiTietHoaDonNhap> chiTietHoaDonNhapList = new List<DTO_ChiTietHoaDonNhap>();


        public GUI_TaoHoaDonNhap()
        {
            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnXoa.Enabled = false;
            txtMaHD.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenNCC.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtTongTien.Text = "0";

            LoadDataComboBox();

            // Tạo mã hóa đơn mới nếu vào chế độ thêm mới
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                txtMaHD.Text = busHDN.TaoMaHoaDon();
                cbMaMV.Text = Global.MaNV;
                txtTenNV.Text = busTK.GetEmployeeNameByAccount(Global.MaNV);
            }
        }

        //Nạp dữ liệu vào combobox
        private void LoadDataComboBox()
        {
            // Nạp danh sách mã khách hàng
            cbMaNCC.DataSource = busNCC.LayDanhSachNhaCungCap();
            cbMaNCC.DisplayMember = "MaNCC";
            cbMaNCC.ValueMember = "MaNCC";

            // Nạp danh sách mã hàng
            cbMaHang.DataSource = busHH.LayDanhSachHangHoa();
            cbMaHang.DisplayMember = "MaHang";
            cbMaHang.ValueMember = "MaHang";
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            foreach (var row in chiTietHoaDonNhapList)
            {
                tongTien += row.ThanhTien;
            }
            txtTongTien.Text = tongTien.ToString("N0");
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

        private void cbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maNCC = cbMaNCC.SelectedValue.ToString();
            var khachHang = busNCC.LayThongTinNhaCungCap(maNCC);

            if (khachHang != null)
            {
                txtTenNCC.Text = khachHang.TenNCC;
                txtDiaChi.Text = khachHang.DiaChi;
                txtSDT.Text = khachHang.DienThoai;
            }
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
                txtTenHang.Text = row.Cells["TenHangHoa"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Kiểm tra dữ liệu hợp lệ trước khi tính toán
                if (int.TryParse(txtSoLuong.Text, out int soLuong) && decimal.TryParse(txtDonGia.Text, out decimal donGia))
                {
                    decimal thanhTien = soLuong * donGia;

                    // Tìm chi tiết hóa đơn tương ứng với mã hàng được chọn
                    var selectedItem = chiTietHoaDonNhapList.Find(item => item.MaHang == cbMaHang.SelectedValue.ToString());

                    if (selectedItem != null)
                    {
                        // Cập nhật số lượng và thành tiền của chi tiết hóa đơn
                        selectedItem.SoLuong = soLuong;
                        selectedItem.ThanhTien = thanhTien;
                    }
                    else
                    {
                        // Tạo chi tiết hóa đơn mới
                        DTO_ChiTietHoaDonNhap chiTiet = new DTO_ChiTietHoaDonNhap
                        {
                            MaHang = cbMaHang.SelectedValue.ToString(),
                            TenHang = txtTenHang.Text,
                            SoLuong = soLuong,
                            DonGia = donGia,
                            ThanhTien = thanhTien
                        };

                        // Thêm vào danh sách chi tiết hóa đơn
                        chiTietHoaDonNhapList.Add(chiTiet);
                    }

                    // Cập nhật DataGridView
                    bindingSource.DataSource = null; // Reset DataSource
                    bindingSource.DataSource = chiTietHoaDonNhapList;
                    dgvDSMatHang.DataSource = bindingSource;
                    // Ẩn cột "SoHDB"
                    dgvDSMatHang.Columns["SoHDN"].Visible = false;

                    // Đổi tên các cột
                    dgvDSMatHang.Columns["MaHang"].HeaderText = "Mã Hàng";
                    dgvDSMatHang.Columns["TenHang"].HeaderText = "Tên Hàng";
                    dgvDSMatHang.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dgvDSMatHang.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgvDSMatHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";

                    // Cập nhật tổng tiền
                    CapNhatTongTien();

                    // Reset các trường nhập liệu
                    txtSoLuong.Clear();
                    cbMaHang.Focus();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                }
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường thông tin không được để trống
            if (string.IsNullOrEmpty(txtMaHD.Text) ||
                string.IsNullOrEmpty(cbMaNCC.Text) ||
                string.IsNullOrEmpty(cbMaMV.Text) ||
                chiTietHoaDonNhapList.Count == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hóa đơn và ít nhất một chi tiết hóa đơn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu có trường không hợp lệ
            }

            // Kiểm tra giá trị số lượng và giảm giá
            foreach (var chiTiet in chiTietHoaDonNhapList)
            {
                if (chiTiet.SoLuong < 1)
                {
                    MessageBox.Show("Số lượng không được nhỏ hơn 1.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DTO_HoaDonNhap hoaDon = new DTO_HoaDonNhap
            {
                SoHDN = txtMaHD.Text,
                NgayNhap = dtpNgayNhap.Value,
                MaNV = cbMaMV.Text,
                MaNCC = cbMaNCC.Text,
                TongTien = decimal.Parse(txtTongTien.Text)
            };

            // Thêm hóa đơn mới
            busHDN.ThemHoaDon(hoaDon);

            // Lấy lại SoHDB vừa thêm (nếu mã tự động sinh ra)
            hoaDon.SoHDN = busHDN.LaySoHDNCuoi();

            // Thêm chi tiết hóa đơn
            foreach (var chiTiet in chiTietHoaDonNhapList)
            {
                chiTiet.SoHDN = hoaDon.SoHDN;
                busCT.ThemChiTietHoaDon(chiTiet);
            }

            MessageBox.Show("Hóa đơn đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bindingSource.ResetBindings(false);

            // Kích hoạt nút xóa sau khi lưu thành công
            btnXoa.Enabled = true;
            btnIn.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                busHDN.XoaHoaDon(txtMaHD.Text);
                MessageBox.Show("Xóa hóa đơn thành công!");
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            busCT.InChiTietHoaDon(txtMaHD.Text);
            MessageBox.Show("In hóa đơn thành công!");
        }
    }
}
