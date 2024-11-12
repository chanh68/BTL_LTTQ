namespace GUI_QuanLy
{
    partial class GUI_HoaDonNhap
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
            this.dgvDSHDN = new System.Windows.Forms.DataGridView();
            this.panelTimKiem = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblNhapTimKiem = new System.Windows.Forms.Label();
            this.cbbDMTimKiem = new System.Windows.Forms.ComboBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.panelSLHoaDon = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXuatFileExcel = new System.Windows.Forms.Button();
            this.btnThemHoaDon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHDN)).BeginInit();
            this.panelTimKiem.SuspendLayout();
            this.panelSLHoaDon.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSHDN
            // 
            this.dgvDSHDN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDSHDN.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDSHDN.ColumnHeadersHeight = 29;
            this.dgvDSHDN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDSHDN.GridColor = System.Drawing.SystemColors.Info;
            this.dgvDSHDN.Location = new System.Drawing.Point(34, 253);
            this.dgvDSHDN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDSHDN.Name = "dgvDSHDN";
            this.dgvDSHDN.RowHeadersWidth = 51;
            this.dgvDSHDN.RowTemplate.Height = 24;
            this.dgvDSHDN.Size = new System.Drawing.Size(859, 366);
            this.dgvDSHDN.TabIndex = 7;
            // 
            // panelTimKiem
            // 
            this.panelTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(53)))), ((int)(((byte)(74)))));
            this.panelTimKiem.Controls.Add(this.btnTimKiem);
            this.panelTimKiem.Controls.Add(this.txtTimKiem);
            this.panelTimKiem.Controls.Add(this.lblNhapTimKiem);
            this.panelTimKiem.Controls.Add(this.cbbDMTimKiem);
            this.panelTimKiem.Controls.Add(this.lblTimKiem);
            this.panelTimKiem.Location = new System.Drawing.Point(67, 25);
            this.panelTimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTimKiem.Name = "panelTimKiem";
            this.panelTimKiem.Size = new System.Drawing.Size(375, 201);
            this.panelTimKiem.TabIndex = 6;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(30)))), ((int)(((byte)(53)))));
            this.btnTimKiem.Location = new System.Drawing.Point(113, 150);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(127, 36);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(28, 103);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(320, 29);
            this.txtTimKiem.TabIndex = 3;
            // 
            // lblNhapTimKiem
            // 
            this.lblNhapTimKiem.AutoSize = true;
            this.lblNhapTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhapTimKiem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblNhapTimKiem.Location = new System.Drawing.Point(25, 67);
            this.lblNhapTimKiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNhapTimKiem.Name = "lblNhapTimKiem";
            this.lblNhapTimKiem.Size = new System.Drawing.Size(197, 21);
            this.lblNhapTimKiem.TabIndex = 2;
            this.lblNhapTimKiem.Text = "Nhập nội dung tìm kiếm";
            // 
            // cbbDMTimKiem
            // 
            this.cbbDMTimKiem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDMTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(30)))), ((int)(((byte)(53)))));
            this.cbbDMTimKiem.FormattingEnabled = true;
            this.cbbDMTimKiem.Location = new System.Drawing.Point(157, 18);
            this.cbbDMTimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbDMTimKiem.Name = "cbbDMTimKiem";
            this.cbbDMTimKiem.Size = new System.Drawing.Size(192, 29);
            this.cbbDMTimKiem.TabIndex = 1;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTimKiem.Location = new System.Drawing.Point(25, 20);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(120, 21);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm theo";
            // 
            // panelSLHoaDon
            // 
            this.panelSLHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(53)))), ((int)(((byte)(74)))));
            this.panelSLHoaDon.Controls.Add(this.label1);
            this.panelSLHoaDon.Location = new System.Drawing.Point(509, 25);
            this.panelSLHoaDon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelSLHoaDon.Name = "panelSLHoaDon";
            this.panelSLHoaDon.Size = new System.Drawing.Size(295, 132);
            this.panelSLHoaDon.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số lượng hóa đơn";
            // 
            // btnXuatFileExcel
            // 
            this.btnXuatFileExcel.BackColor = System.Drawing.Color.White;
            this.btnXuatFileExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatFileExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(30)))), ((int)(((byte)(53)))));
            this.btnXuatFileExcel.Location = new System.Drawing.Point(674, 176);
            this.btnXuatFileExcel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXuatFileExcel.Name = "btnXuatFileExcel";
            this.btnXuatFileExcel.Size = new System.Drawing.Size(130, 47);
            this.btnXuatFileExcel.TabIndex = 9;
            this.btnXuatFileExcel.Text = "Xuất DS Excel";
            this.btnXuatFileExcel.UseVisualStyleBackColor = false;
            // 
            // btnThemHoaDon
            // 
            this.btnThemHoaDon.BackColor = System.Drawing.Color.White;
            this.btnThemHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(30)))), ((int)(((byte)(53)))));
            this.btnThemHoaDon.Location = new System.Drawing.Point(516, 176);
            this.btnThemHoaDon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThemHoaDon.Name = "btnThemHoaDon";
            this.btnThemHoaDon.Size = new System.Drawing.Size(130, 47);
            this.btnThemHoaDon.TabIndex = 8;
            this.btnThemHoaDon.Text = "Thêm hóa đơn";
            this.btnThemHoaDon.UseVisualStyleBackColor = false;
            // 
            // GUI_HoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(30)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(920, 664);
            this.Controls.Add(this.dgvDSHDN);
            this.Controls.Add(this.panelTimKiem);
            this.Controls.Add(this.panelSLHoaDon);
            this.Controls.Add(this.btnXuatFileExcel);
            this.Controls.Add(this.btnThemHoaDon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GUI_HoaDonNhap";
            this.Text = "GUI_HoaDonNhap";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSHDN)).EndInit();
            this.panelTimKiem.ResumeLayout(false);
            this.panelTimKiem.PerformLayout();
            this.panelSLHoaDon.ResumeLayout(false);
            this.panelSLHoaDon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSHDN;
        private System.Windows.Forms.Panel panelTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblNhapTimKiem;
        private System.Windows.Forms.ComboBox cbbDMTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Panel panelSLHoaDon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXuatFileExcel;
        private System.Windows.Forms.Button btnThemHoaDon;
    }
}