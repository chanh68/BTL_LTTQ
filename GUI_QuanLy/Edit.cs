using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class Edit : Form
    {
        private readonly DAL_HangHoa dalHangHoa;
        public DTO_HangHoa HangHoa { get; set; }
        private readonly InfoProduct infoProductForm;

        // Tham số để xác định chế độ (thêm, sửa, hay thông tin)
        private string mode;

        public Edit(DTO_HangHoa hangHoa, InfoProduct infoProduct, string mode)
        {
            InitializeComponent();
            dalHangHoa = new DAL_HangHoa();
            HangHoa = hangHoa;
            infoProductForm = infoProduct;
            this.mode = mode; // Lưu chế độ

            // Cập nhật tiêu đề form dựa trên chế độ
            if (mode == "Thêm")
            {
                btnTitle.Text = "Thêm Sản Phẩm";
            }
            else if (mode == "Sửa")
            {
                btnTitle.Text = "Sửa Sản Phẩm";
            }
            else if (mode == "Thông tin")
            {
                btnTitle.Text = "Thông Tin Sản Phẩm";
            }
            else
            {
                this.Text = "Edit";
            }

            LoadHangHoaData();

            // Kiểm tra chế độ để hiển thị nút tương ứng
            if (mode == "Thêm")
            {
                btnLuu.Visible = false; // Ẩn nút Lưu
                btnThem.Visible = true;  // Hiện nút Thêm
            }
            else if (mode == "Sửa")
            {
                btnLuu.Visible = true;   // Hiện nút Lưu
                btnThem.Visible = false;  // Ẩn nút Thêm
            }
            else // Thông tin sản phẩm
            {
                btnLuu.Visible = false; // Ẩn nút Lưu
                btnThem.Visible = false; // Ẩn nút Thêm
            }
        }


        private void LoadHangHoaData()
        {
            if (HangHoa != null)
            {
                txtMaHang.Text = HangHoa.MaHang; // Đã có
                txtTenHang.Text = HangHoa.TenHangHoa; // Đã có
                txtSoLuong.Text = HangHoa.SoLuong.ToString(); // Đã có
                txtDGB.Text = HangHoa.DonGiaBan.ToString(); // Đã có
                txtDGN.Text = HangHoa.DonGiaNhap.ToString();
                txtGhiChu.Text = HangHoa.GhiChu; // Đã có

                // Hiển thị ảnh từ byte[]
                if (HangHoa.Anh != null && HangHoa.Anh.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(HangHoa.Anh))
                    {
                        picpoc.Image = Image.FromStream(ms);
                    }
                }

                // Cập nhật thêm các thuộc tính còn lại
                txtMaLoai.Text = HangHoa.MaLoai; // Thêm
                txtMaKT.Text = HangHoa.MaKichThuoc; // Thêm
                txtMaMen.Text = HangHoa.MaLoaiMen; // Thêm
                txtMaMau.Text = HangHoa.MaMau; // Thêm
                txtMaCD.Text = HangHoa.MaCongDung; // Thêm
                txtMaHK.Text = HangHoa.MaHinhKhoi; // Thêm
                txtMaNuocSX.Text = HangHoa.MaNuocSX; // Thêm
            }

            // Nếu chế độ là "Thông tin sản phẩm", khóa các trường nhập
            if (mode == "Thông tin")
            {
                txtMaHang.Enabled = false;
                txtTenHang.Enabled = false;
                txtSoLuong.Enabled = false;
                txtDGB.Enabled = false;
                txtGhiChu.Enabled = false;
                txtMaLoai.Enabled = false; // Khóa các trường nhập thêm
                txtMaKT.Enabled = false;
                txtMaMen.Enabled = false;
                txtMaMau.Enabled = false;
                txtMaCD.Enabled = false;
                txtMaHK.Enabled = false;
                txtDGN.Enabled = false;
                txtMaNuocSX.Enabled = false;
                btnChonAnh.Enabled = false; // Khóa nút chọn ảnh
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                UpdateHangHoa();
                this.DialogResult = DialogResult.OK;
                this.Close(); // Đóng form Edit
                infoProductForm.LoadData(); // Tải lại dữ liệu trong InfoProduct
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã hàng đã tồn tại chưa
            string maHang = txtMaHang.Text;
            if (dalHangHoa.CheckMaHangExists(maHang))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                return;
            }

            // Xử lý ảnh
            byte[] anh = GetImageBytes(txtAnh.Text);
            if (anh == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenHang = txtTenHang.Text;
            string maLoai = txtMaLoai.Text;
            string maKT = txtMaKT.Text;
            string maMen = txtMaMen.Text;
            string maMau = txtMaMau.Text;
            int soLuong = int.Parse(txtSoLuong.Text);
            decimal dgb = decimal.Parse(txtDGB.Text);
            decimal dgn = decimal.Parse(txtDGN.Text);
            string ghiChu = txtGhiChu.Text;
            string maCD = txtMaCD.Text;
            string maHK = txtMaHK.Text;
            string maNuoc = txtMaNuocSX.Text;

            dalHangHoa.AddHangHoa(maHang, tenHang, maLoai, maKT, maMen, maMau, soLuong, dgb, dgn, anh, ghiChu, maCD, maHK, maNuoc);
            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearData();
            this.Close(); // Đóng form Edit
            infoProductForm.LoadData(); // Tải lại dữ liệu trong InfoProduct
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMaHang.Text) ||
                string.IsNullOrWhiteSpace(txtTenHang.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDGB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text, out _) ||
                !decimal.TryParse(txtDGB.Text, out _))
            {
                MessageBox.Show("Số lượng và đơn giá phải là số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void UpdateHangHoa()
        {
            // Cập nhật các thuộc tính của HangHoa từ các điều khiển
            HangHoa.TenHangHoa = txtTenHang.Text;
            HangHoa.SoLuong = int.Parse(txtSoLuong.Text);
            HangHoa.DonGiaBan = decimal.Parse(txtDGB.Text);
            HangHoa.DonGiaNhap = decimal.Parse(txtDGN.Text); // Cập nhật Đơn giá nhập nếu có
            HangHoa.GhiChu = txtGhiChu.Text;
            HangHoa.MaLoai = txtMaLoai.Text; // Cập nhật các thuộc tính khác
            HangHoa.MaKichThuoc = txtMaKT.Text;
            HangHoa.MaLoaiMen = txtMaMen.Text;
            HangHoa.MaMau = txtMaMau.Text;
            HangHoa.MaCongDung = txtMaCD.Text;
            HangHoa.MaHinhKhoi = txtMaHK.Text;
            HangHoa.MaNuocSX = txtMaNuocSX.Text;

            // Chuyển đổi đường dẫn ảnh thành byte[]
            byte[] anh = GetImageBytes(txtAnh.Text);
            if (anh != null)
            {
                HangHoa.Anh = anh;
            }

            // Gọi phương thức cập nhật trong DAL
            dalHangHoa.UpdateHangHoa(HangHoa);

            // Hiển thị thông báo thành công
            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtAnh.Text = openFileDialog.FileName;
                    try
                    {
                        picpoc.Image = new Bitmap(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private byte[] GetImageBytes(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                return null;

            try
            {
                return File.ReadAllBytes(filePath);
            }
            catch
            {
                MessageBox.Show("Không thể đọc file ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void clearData()
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtMaLoai.Clear();
            txtMaKT.Clear();
            txtMaMen.Clear();
            txtMaMau.Clear();
            txtSoLuong.Clear();
            txtDGB.Clear();
            txtDGN.Clear();
            txtAnh.Clear();
            txtGhiChu.Clear();
            txtMaCD.Clear();
            txtMaHK.Clear();
            txtMaNuocSX.Clear();
            picpoc.Image = null;
        }

private void btnTitle_Click(object sender, EventArgs e)
{
    this.DialogResult = DialogResult.Cancel; // Gán kết quả là Cancel
    this.Close(); // Đóng form hiện tại
}
    }
}
