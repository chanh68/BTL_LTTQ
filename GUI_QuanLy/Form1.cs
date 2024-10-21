using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadHomePage();
        }

        private void LoadHomePage()
        {
            HomePage homePage = new HomePage();
            LoadFormIntoPanel(homePage);
        }
        public void LoadFormIntoPanel(Form childForm)
        {
            // Xóa các control hiện tại trong panel
            panelAll.Controls.Clear();

            // Thiết lập form con
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelAll.Controls.Add(childForm);
            childForm.Show();
        }
    }
}