using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class Edit : Form
    {
        private readonly DAL_HangHoa dalHangHoa;
        public DTO_HangHoa HangHoa { get; set; }

        public Edit(DTO_HangHoa hangHoa)
        {
            InitializeComponent();
            dalHangHoa = new DAL_HangHoa(); // Khởi tạo DAL
            HangHoa = hangHoa;
            LoadHangHoaData();
        }

        private void LoadHangHoaData()
        {
            if (HangHoa != null) // Kiểm tra nếu có dữ liệu hàng hóa để load
            {
                txtMaHang.Text = HangHoa.MaHang;
                txtTenHang.Text = HangHoa.TenHangHoa;
                txtSoLuong.Text = HangHoa.SoLuong.ToString();
                txtDGB.Text = HangHoa.DonGiaBan.ToString();
                txtGhiChu.Text = HangHoa.GhiChu;
                txtAnh.Text = HangHoa.Anh;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                UpdateHangHoa();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHang.Text) ||
        string.IsNullOrWhiteSpace(txtTenHang.Text) ||
        string.IsNullOrWhiteSpace(txtMaLoai.Text) ||
        string.IsNullOrWhiteSpace(txtMaKT.Text) ||
        string.IsNullOrWhiteSpace(txtMaMen.Text) ||
        string.IsNullOrWhiteSpace(txtMaMau.Text) ||
        string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
        string.IsNullOrWhiteSpace(txtDGB.Text) ||
        string.IsNullOrWhiteSpace(txtDGN.Text) ||
        string.IsNullOrWhiteSpace(txtAnh.Text) ||
        string.IsNullOrWhiteSpace(txtGhiChu.Text) ||
        string.IsNullOrWhiteSpace(txtMaCD.Text) ||
        string.IsNullOrWhiteSpace(txtMaHK.Text) ||
        string.IsNullOrWhiteSpace(txtMaNuocSX.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã hàng đã tồn tại chưa
            string maHang = txtMaHang.Text;
            DAL_HangHoa dalHangHoa = new DAL_HangHoa();

            if (dalHangHoa.CheckMaHangExists(maHang))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                return;
            }

            // Kiểm tra số lượng và đơn giá có phải số hay không
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || !decimal.TryParse(txtDGB.Text, out decimal dgb) || !decimal.TryParse(txtDGN.Text, out decimal dgn))
            {
                MessageBox.Show("Số lượng và đơn giá phải là số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xử lý ảnh
            string anh = txtAnh.Text;
            if (!System.IO.File.Exists(anh))
            {
                MessageBox.Show("Vui lòng chọn ảnh hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm mới thông tin hàng vào cơ sở dữ liệu
            string tenHang = txtTenHang.Text;
            string maLoai = txtMaLoai.Text;
            string maKT = txtMaKT.Text;
            string maMen = txtMaMen.Text;
            string maMau = txtMaMau.Text;
            string ghiChu = txtGhiChu.Text;
            string maCD = txtMaCD.Text;
            string maHK = txtMaHK.Text;
            string maNuoc = txtMaNuocSX.Text;

            // Sử dụng phương thức từ DAL
            dalHangHoa.AddHangHoa(maHang, tenHang, maLoai, maKT, maMen, maMau, soLuong, dgb, dgn, anh, ghiChu, maCD, maHK, maNuoc);
            Success.Show();
            clearData();
            if (ValidateInputs())
            {
                //AddNewHangHoa();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateInputs()
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtMaHang.Text) ||
                string.IsNullOrWhiteSpace(txtTenHang.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDGB.Text) ||
                string.IsNullOrWhiteSpace(txtAnh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra số lượng và đơn giá có phải số hay không
            if (!int.TryParse(txtSoLuong.Text, out _) ||
                !decimal.TryParse(txtDGB.Text, out _))
            {
                MessageBox.Show("Số lượng và đơn giá phải là số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra ảnh
            if (!System.IO.File.Exists(txtAnh.Text))
            {
                MessageBox.Show("Vui lòng chọn ảnh hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void UpdateHangHoa()
        {
            HangHoa.TenHangHoa = txtTenHang.Text;
            HangHoa.SoLuong = int.Parse(txtSoLuong.Text);
            HangHoa.DonGiaBan = decimal.Parse(txtDGB.Text);
            HangHoa.GhiChu = txtGhiChu.Text;
            HangHoa.Anh = txtAnh.Text;

            dalHangHoa.UpdateHangHoa(HangHoa);
            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            this.Close();
            InfoProduct infoProduct = new InfoProduct();
            infoProduct.ShowDialog();
        }
private void btnChonAnh_Click(object sender, EventArgs e)
{
    using (OpenFileDialog openFileDialog = new OpenFileDialog())
    {
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            // Hiển thị đường dẫn tệp vào txtAnh
            txtAnh.Text = openFileDialog.FileName;

            // Hiển thị ảnh trong PictureBox
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
}
    }
}
