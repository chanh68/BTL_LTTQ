namespace GUI_QuanLy
{
    partial class ProductView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bunifuShadowPanel1 = new Bunifu.UI.WinForms.BunifuShadowPanel();
            this.pbProduct = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.bunifuShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuShadowPanel1
            // 
            this.bunifuShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShadowPanel1.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuShadowPanel1.BorderRadius = 1;
            this.bunifuShadowPanel1.BorderThickness = 1;
            this.bunifuShadowPanel1.Controls.Add(this.lblPrice);
            this.bunifuShadowPanel1.Controls.Add(this.lblName);
            this.bunifuShadowPanel1.Controls.Add(this.pbProduct);
            this.bunifuShadowPanel1.Controls.Add(this.guna2PictureBox1);
            this.bunifuShadowPanel1.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
            this.bunifuShadowPanel1.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
            this.bunifuShadowPanel1.Location = new System.Drawing.Point(24, 41);
            this.bunifuShadowPanel1.Name = "bunifuShadowPanel1";
            this.bunifuShadowPanel1.PanelColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuShadowPanel1.PanelColor2 = System.Drawing.Color.WhiteSmoke;
            this.bunifuShadowPanel1.ShadowColor = System.Drawing.Color.DarkGray;
            this.bunifuShadowPanel1.ShadowDept = 2;
            this.bunifuShadowPanel1.ShadowDepth = 5;
            this.bunifuShadowPanel1.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Surrounded;
            this.bunifuShadowPanel1.ShadowTopLeftVisible = false;
            this.bunifuShadowPanel1.Size = new System.Drawing.Size(193, 230);
            this.bunifuShadowPanel1.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Flat;
            this.bunifuShadowPanel1.TabIndex = 0;
            // 
            // pbProduct
            // 
            this.pbProduct.Image = global::GUI_QuanLy.Properties.Resources.angela;
            this.pbProduct.ImageRotate = 0F;
            this.pbProduct.Location = new System.Drawing.Point(36, 0);
            this.pbProduct.Name = "pbProduct";
            this.pbProduct.Size = new System.Drawing.Size(133, 126);
            this.pbProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProduct.TabIndex = 1;
            this.pbProduct.TabStop = false;
            this.pbProduct.Click += new System.EventHandler(this.pbProduct_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(4, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(186, 227);
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 129);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(201, 51);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Product name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(4, 180);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(189, 50);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "200";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.bunifuShadowPanel1);
            this.Name = "ProductView";
            this.Size = new System.Drawing.Size(245, 298);
            this.bunifuShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuShadowPanel bunifuShadowPanel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox pbProduct;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
    }
}
