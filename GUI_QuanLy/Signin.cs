using System;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;

namespace GUI_QuanLy
{
    public partial class Signin : Form
    {
        private BUS_TaiKhoan busTaiKhoan; // Sử dụng lớp BUS thay vì DAL
        private bool isPasswordVisible = false;

        public Signin()
        {
            InitializeComponent();
            busTaiKhoan = new BUS_TaiKhoan(); // Khởi tạo lớp BUS
        }

        // Xử lý sự kiện khi nhấn nút Đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Uname = txtUser.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // Kiểm tra tên đăng nhập và mật khẩu đã được nhập hay chưa
            if (string.IsNullOrEmpty(Uname))
            {
                MessageBox.Show("Yêu cầu nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Yêu cầu nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi tầng BUS để xác thực người dùng
            string maNV = busTaiKhoan.VerifyUser(Uname, pass);
            if (maNV != null)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lưu mã nhân viên vào biến toàn cục hoặc chuyển tiếp thông tin
                Global.MaNV = maNV;

                // Chuyển sang giao diện chính sau khi đăng nhập thành công
                GUI_TrangChu gUI_TrangChu = new GUI_TrangChu(Global.MaNV);
                gUI_TrangChu.Show();
                this.Hide(); // Ẩn form đăng nhập
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện tải form
        private void Signin_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•'; // Đặt ký tự ẩn cho mật khẩu
        }

        // Hiển thị mật khẩu
        private void btnShow_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0'; // Hiển thị mật khẩu
            btnShow.Visible = false;
            btnHide.Visible = true;
        }

        // Ẩn mật khẩu
        private void btnHide_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•'; // Ẩn mật khẩu
            btnHide.Visible = false;
            btnShow.Visible = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
