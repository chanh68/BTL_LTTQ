﻿//using DAL_QuanLy;
//using DTO_QuanLy;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace GUI_QuanLy
//{
//    public partial class urSanPham : UserControl
//    {
//        public event EventHandler onSelect = null;
//        private readonly DAL_HangHoa dalHangHoa;
//        public DTO_HangHoa HangHoa { get; set; }
//        private readonly InfoProduct infoProductForm;

//        // Tham số để xác định chế độ (thêm, sửa, hay thông tin)
//        private string mode;


//        public urSanPham()
//        {
//            InitializeComponent();
//        }

//        private void txtPic_Click(object sender, EventArgs e)
//        {
//            onSelect?.Invoke(this, e);

//        }
//        public string id
//        {
//            get { return txtMaHang.Text; }
//            set { txtMaHang.Text = value; }
//        }
//        public string Pcost { get; set; }
//        public string Pname
//        {
//            get { return txtTenHang.Text; }
//            set { txtTenHang.Text = value; }
//        }
//        public string Price
//        {
//            get { return txtGia.Text; }
//            set { txtGia.Text = value; }
//        }
//        public Image PImage
//        {
//            get { return txtPic.Image; }
//            set { txtPic.Image = value; }
//        }

//        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
//        {

//        }



//        private void txtPic_Click_1(object sender, EventArgs e)
//        {

//        }

//        private void bunifuButton1_Click(object sender, EventArgs e)
//        {
//            Edit e = new Edit();
//            e.Show();

//        }



//        private void bunifuLabel2_Click(object sender, EventArgs e)
//        {

//        }
//    }

//}