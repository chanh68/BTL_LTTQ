//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.IO;
//using System.Windows.Forms;
//using DAL_QuanLy;

//namespace GUI_QuanLy
//{
//    public partial class GUI_TatCaSanPham : Form
//    {
//        private readonly DAL_HangHoa db = new DAL_HangHoa();

//        public GUI_TatCaSanPham()
//        {
//            InitializeComponent();
//        }

//        private void GUI_TatCaSanPham_Load(object sender, EventArgs e)
//        {
//            LoadSanPhamFromDatabase();
//        }

//        private Image ConvertByteArrayToImage(byte[] imageData)
//        {
//            if (imageData == null || imageData.Length == 0)
//                return null;

//            try
//            {
//                using (MemoryStream ms = new MemoryStream(imageData))
//                {
//                    return Image.FromStream(ms);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi khi tạo hình ảnh từ byte array: {ex.Message}");
//                return null;
//            }
//        }

//        public void AddItems(string id, string name, string price, byte[] imageBytes)
//        {
//            var productImage = ConvertByteArrayToImage(imageBytes);

//            var ur = new urSanPham()
//            {
//                Pname = name,
//                Price = price,
//                Pimage = productImage,
//                id = id
//            };

//            productView.Margin = new Padding(10);
//            flowLayoutPanel1.Controls.Add(productView);

//            productView.onSelect += (ss, ee) =>
//            {
//                // Logic xử lý khi chọn sản phẩm giống như trong lớp Sale
//                // Bạn có thể tùy chỉnh để thêm vào `DataGridView` nếu cần
//                var selectedProduct = (ProductView)ss;
//                MessageBox.Show($"Sản phẩm {selectedProduct.Pname} đã được chọn!");
//            };
//        }

//        private void LoadSanPhamFromDatabase()
//        {
//            flowLayoutPanel1.Controls.Clear();

//            DataTable dt = db.GetInfo(); // Hàm này trả về tất cả thông tin sản phẩm từ DAL_HangHoa

//            if (dt.Rows.Count > 0)
//            {
//                foreach (DataRow row in dt.Rows)
//                {
//                    string id = row["MaHang"].ToString();
//                    string name = row["TenHang"].ToString();
//                    string price = row["DonGiaBan"].ToString();
//                    byte[] imageBytes = (byte[])row["Anh"];

//                    AddItems(id, name, price, imageBytes);
//                }
//            }
//            else
//            {
//                MessageBox.Show("Không tìm thấy sản phẩm nào.");
//            }
//        }

//        private void txtSearch_TextChanged_1(object sender, EventArgs e)
//        {
//            foreach (var item in flowLayoutPanel1.Controls)
//            {
//                if (item is ProductView productView)
//                {
//                    if (cbSearch.SelectedItem?.ToString() == "Mã hàng")
//                    {
//                        productView.Visible = productView.id.ToLower().Contains(txtSearch.Text.Trim().ToLower());
//                    }
//                    else if (cbSearch.SelectedItem?.ToString() == "Tên hàng")
//                    {
//                        productView.Visible = productView.Pname.ToLower().Contains(txtSearch.Text.Trim().ToLower());
//                    }
//                    else
//                    {
//                        MessageBox.Show("Sản phẩm không tồn tại");
//                    }
//                }
//            }
//        }
//    }
//}
