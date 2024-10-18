using System;
using System.Data;
using System.Windows.Forms;
using DAL_QuanLy; 

namespace GUI_QuanLy
{
    public partial class Information: Form
    {
        string maNV = Global.MaNV;
        private DAL_NhanVien dalNhanVien;

        public Information()
        {
            InitializeComponent();
            dalNhanVien = new DAL_NhanVien();
            LoadUserInfo(maNV);
        }

        private void LoadUserInfo(string maNV)
        {
            DataTable result = dalNhanVien.GetUserInfo(maNV);

            if (result.Rows.Count > 0)
            {
                lblHoten.Text = $"Họ và tên: {result.Rows[0]["TenNV"]}";
                lblCV.Text = $"Công việc: {result.Rows[0]["QuyenHan"]}";
                lblMa.Text = $"Mã nhân viên: {result.Rows[0]["MaNV"]}";
                lblCa.Text = $"Ngày tuyển: {Convert.ToDateTime(result.Rows[0]["NgayTuyen"]).ToShortDateString()}";
                lblNgaySinh.Text = $"Ngày sinh: {Convert.ToDateTime(result.Rows[0]["NgaySinh"]).ToShortDateString()}";
                lblSdt.Text = $"Số điện thoại: {result.Rows[0]["DienThoai"]}";
                lblDiaChi.Text = $"Địa chỉ: {result.Rows[0]["DiaChi"]}";
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
