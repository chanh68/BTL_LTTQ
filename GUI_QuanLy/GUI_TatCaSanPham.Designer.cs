namespace GUI_QuanLy
{
    partial class GUI_TatCaSanPham
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_TatCaSanPham));
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.cbSearch = new System.Windows.Forms.ComboBox();
			this.txtSearch = new Bunifu.UI.WinForms.BunifuTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(29, 180);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(859, 440);
			this.flowLayoutPanel1.TabIndex = 4;
			// 
			// cbSearch
			// 
			this.cbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.cbSearch.FormattingEnabled = true;
			this.cbSearch.Items.AddRange(new object[] {
            "Mã hàng",
            "Tên hàng"});
			this.cbSearch.Location = new System.Drawing.Point(12, 29);
			this.cbSearch.Name = "cbSearch";
			this.cbSearch.Size = new System.Drawing.Size(122, 28);
			this.cbSearch.TabIndex = 5;
			this.cbSearch.Text = "Tra cứu theo";
			this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// txtSearch
			// 
			this.txtSearch.AcceptsReturn = false;
			this.txtSearch.AcceptsTab = false;
			this.txtSearch.AnimationSpeed = 200;
			this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
			this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
			this.txtSearch.BackColor = System.Drawing.Color.Transparent;
			this.txtSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.BackgroundImage")));
			this.txtSearch.BorderColorActive = System.Drawing.Color.DodgerBlue;
			this.txtSearch.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.txtSearch.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
			this.txtSearch.BorderColorIdle = System.Drawing.Color.Silver;
			this.txtSearch.BorderRadius = 1;
			this.txtSearch.BorderThickness = 1;
			this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
			this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSearch.DefaultFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.txtSearch.DefaultText = "";
			this.txtSearch.FillColor = System.Drawing.Color.White;
			this.txtSearch.HideSelection = true;
			this.txtSearch.IconLeft = null;
			this.txtSearch.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSearch.IconPadding = 10;
			this.txtSearch.IconRight = null;
			this.txtSearch.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSearch.Lines = new string[0];
			this.txtSearch.Location = new System.Drawing.Point(12, 105);
			this.txtSearch.MaxLength = 32767;
			this.txtSearch.MinimumSize = new System.Drawing.Size(1, 1);
			this.txtSearch.Modified = false;
			this.txtSearch.Multiline = false;
			this.txtSearch.Name = "txtSearch";
			stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
			stateProperties5.FillColor = System.Drawing.Color.Empty;
			stateProperties5.ForeColor = System.Drawing.Color.Empty;
			stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtSearch.OnActiveState = stateProperties5;
			stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
			this.txtSearch.OnDisabledState = stateProperties6;
			stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
			stateProperties7.FillColor = System.Drawing.Color.Empty;
			stateProperties7.ForeColor = System.Drawing.Color.Empty;
			stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtSearch.OnHoverState = stateProperties7;
			stateProperties8.BorderColor = System.Drawing.Color.Silver;
			stateProperties8.FillColor = System.Drawing.Color.White;
			stateProperties8.ForeColor = System.Drawing.Color.Empty;
			stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
			this.txtSearch.OnIdleState = stateProperties8;
			this.txtSearch.Padding = new System.Windows.Forms.Padding(3);
			this.txtSearch.PasswordChar = '\0';
			this.txtSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
			this.txtSearch.PlaceholderText = "Thông tin sản phẩm";
			this.txtSearch.ReadOnly = false;
			this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtSearch.SelectedText = "";
			this.txtSearch.SelectionLength = 0;
			this.txtSearch.SelectionStart = 0;
			this.txtSearch.ShortcutsEnabled = true;
			this.txtSearch.Size = new System.Drawing.Size(331, 32);
			this.txtSearch.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
			this.txtSearch.TabIndex = 8;
			this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtSearch.TextMarginBottom = 0;
			this.txtSearch.TextMarginLeft = 3;
			this.txtSearch.TextMarginTop = 0;
			this.txtSearch.TextPlaceholder = "Thông tin sản phẩm";
			this.txtSearch.UseSystemPasswordChar = false;
			this.txtSearch.WordWrap = true;
			this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.label1.Location = new System.Drawing.Point(8, 75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 20);
			this.label1.TabIndex = 9;
			this.label1.Text = "Nhập sản phẩm cần tra cứu:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.cbSearch);
			this.panel1.Location = new System.Drawing.Point(29, 11);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(380, 169);
			this.panel1.TabIndex = 10;
			// 
			// GUI_TatCaSanPham
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(30)))), ((int)(((byte)(53)))));
			this.ClientSize = new System.Drawing.Size(926, 640);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "GUI_TatCaSanPham";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GUI_TatCaSanPham";
			this.Load += new System.EventHandler(this.GUI_TatCaSanPham_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cbSearch;
        private Bunifu.UI.WinForms.BunifuTextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}