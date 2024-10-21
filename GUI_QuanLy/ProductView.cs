using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class ProductView : UserControl
    {
        public event EventHandler onSelect = null;
        public ProductView()
        {
            InitializeComponent();
        }

        private void pbProduct_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this,e);
        }
        public int id {  get; set; }
        public string Pcost { get; set; }
        public string Pname
        {
            get
            {
                return lblName.Text;
            }
            set
            {
                lblName.Text = value;
            }
        }
        public string Price
        { get { return lblPrice.Text; } set { lblPrice.Text = value; } }
        public Image Pimage {
            get { return pbProduct.Image; } set { pbProduct.Image = value; }
        }
    }
}
