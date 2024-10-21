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

namespace GUI_QuanLy
{

    public partial class NhanVien_Sua : Form
    {
        private string maNV;
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public NhanVien_Sua(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            LoadData();
            // Đăng ký sự kiện TextChanged cho txtMaCV
            txtMaCV.TextChanged += txtMaCV_TextChanged;
        }
        private void txtMaCV_TextChanged(object sender, EventArgs e)
        {
            // Lấy mã công việc từ textbox
            string maCV = txtMaCV.Text.Trim();

            // Nếu mã công việc không rỗng, gọi phương thức lấy vai trò
            if (!string.IsNullOrEmpty(maCV) && System.Text.RegularExpressions.Regex.IsMatch(maCV, @"^CV\d+$"))
            {
                string vaiTro = busNhanVien.GetVaiTroByMaCV(maCV);

                // Hiển thị vai trò vào txtVaiTro
                txtVaiTro.Text = vaiTro;
                // Thay đổi màu nền nếu vai trò không rỗng
                if (!string.IsNullOrEmpty(vaiTro))
                {
                    txtVaiTro.BackColor = Color.White; // Màu nền khi có giá trị
                }
                else
                {
                    txtVaiTro.BackColor = Color.FromArgb(120, 120, 120);  // Màu nền khi không có giá trị
                }
            }
            else
            {
                // Nếu mã công việc rỗng, xóa nội dung txtVaiTro
                txtVaiTro.Clear();
                txtVaiTro.BackColor = Color.FromArgb(120, 120, 120);
            }
        }

        private void LoadData()
        {
            // Lấy danh sách nhân viên từ BLL
            DataTable dt = busNhanVien.getNhanVien();
            foreach (DataRow row in dt.Rows)
            {
                if (row["MaNV"].ToString() == maNV)
                {
                    txtMaNV.Text = row["MaNV"].ToString();
                    txtTenNV.Text = row["TenNV"].ToString();
                    txtGT.Text = row["GioiTinh"].ToString();
                    dtpNgaySinh.Value = Convert.ToDateTime(row["NgaySinh"]);
                    txtSDT.Text = row["DienThoai"].ToString();
                    txtDiaChi.Text = row["DiaChi"].ToString();
                    txtMaCV.Text = row["MaCV"].ToString();
                    txtSoNgayPhep.Text = row["SoNgayPhep"].ToString();
                    txtSoNgayNghi.Text = row["SoNgayNghi"].ToString();
                    dtpNgayTuyen.Value = Convert.ToDateTime(row["NgayTuyen"]);
                    txtCCCD.Text = row["CCCD"].ToString();

                    // Lấy vai trò của mã công việc
                    string maCV = row["MaCV"].ToString();
                    string vaiTro = busNhanVien.GetVaiTroByMaCV(maCV); // Lấy vai trò từ BLL

                    // Hiển thị vai trò vào txtVaiTro
                    txtVaiTro.Text = vaiTro;
                    break;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng DTO_NhanVien từ dữ liệu trong các TextBox và DateTimePicker
            DTO_NhanVien nv = new DTO_NhanVien
            {
                MaNV = txtMaNV.Text,
                TenNV = txtTenNV.Text,
                GioiTinh = txtGT.Text,
                NgaySinh = dtpNgaySinh.Value, // Lấy giá trị từ DateTimePicker
                DienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text,
                MaCV = txtMaCV.Text,
                SoNgayPhep = int.Parse(txtSoNgayPhep.Text),
                SoNgayNghi = int.Parse(txtSoNgayNghi.Text),
                NgayTuyen = dtpNgayTuyen.Value, // Lấy giá trị từ DateTimePicker
                CCCD = txtCCCD.Text
            };

            // Gọi phương thức cập nhật trong BLL
            if (busNhanVien.CapNhatNhanVien(nv))
            {
                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Trả về kết quả thành công
                this.Close(); // Đóng form
            }
            else
            {
                MessageBox.Show("Cập nhật nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            TKNhanVien suaForm = new TKNhanVien();
            this.Hide(); // Ẩn form hiện tại trước khi gọi ShowDialog()
            DialogResult result = suaForm.ShowDialog();
            // Kiểm tra nếu form cha vẫn còn tồn tại và chưa bị dispose
            if (!this.IsDisposed)
            {
                this.Show(); // Hiện lại form hiện tại sau khi form sửa đóng
            }
        }
    }
}
