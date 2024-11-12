using Guna.UI.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DAL_QuanLy; // Ensure you have this using directive

namespace GUI_QuanLy
{
    public partial class GUI_TatCaSanPham : Form
    {
        private DAL_HangHoa db = new DAL_HangHoa();
        public GUI_TatCaSanPham()
        {
            InitializeComponent();
        }
        private void GUI_TatCaSanPham_Load(object sender, EventArgs e)
        {
            LoadSanPhamFromDatabase();

        }
        public void addItems(string id, string name, string price, Image image)
        {
            var w = new urSanPham()
            {
                Pname = name,
                Price = price,
                PImage = image,
                id = id
            };

            w.Margin = new Padding(10);
            flowLayoutPanel1.Controls.Add(w);
        }



        private void LoadSanPhamFromDatabase()
        {
            flowLayoutPanel1.Controls.Clear(); // Xóa các sản phẩm trước đó

            string query = "SELECT * FROM HangHoa";

            // Thêm điều kiện tìm kiếm nếu có


            using (SqlCommand cmd = new SqlCommand(query, db.Connection))
            {

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    db.OpenConnection();
                    da.Fill(dt);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error loading products from database: " + ex.Message);
                }
                finally
                {
                    db.CloseConnection();
                }

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string id = row["MaHang"].ToString();
                        string name = row["TenHang"].ToString();
                        string price = row["DonGiaBan"].ToString();

                        // Đường dẫn ảnh
                        string imagePath = Path.Combine("D:\\github\\BTL_LTTQ2\\GUI_QuanLy\\Resources", row["Anh"].ToString());
                        Image productImage = File.Exists(imagePath) ? Image.FromFile(imagePath) : Image.FromFile(@"C:\Users\ninhc\OneDrive\Hình ảnh\Mat.jpg");

                        // Thêm sản phẩm vào FlowLayoutPanel
                        addItems(id, name, price, productImage);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào.");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }




        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {


            foreach (var item in flowLayoutPanel1.Controls)
            {
                var pro = (urSanPham)item;
                if (cbSearch.SelectedItem?.ToString() == "Mã hàng")
                {
                    pro.Visible = pro.id.ToLower().Contains(txtSearch.Text.Trim().ToLower());
                }
                else if (cbSearch.SelectedItem?.ToString() == "Tên hàng")
                {
                    pro.Visible = pro.Pname.ToLower().Contains(txtSearch.Text.Trim().ToLower());
                }
                else
                    MessageBox.Show($"Sản Phẩm không tồn tại");
            }
        }
    }

}

