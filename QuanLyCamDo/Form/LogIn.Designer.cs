namespace QuanLyCamDo
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.groupControlDangNhap = new DevExpress.XtraEditors.GroupControl();
            this.bt_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.bt_DangNhap = new DevExpress.XtraEditors.SimpleButton();
            this.tb_MatKhau = new DevExpress.XtraEditors.TextEdit();
            this.lb_MatKhau = new System.Windows.Forms.Label();
            this.tb_TaiKhoan = new DevExpress.XtraEditors.TextEdit();
            this.lb_TaiKhoan = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDangNhap)).BeginInit();
            this.groupControlDangNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_TaiKhoan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlDangNhap
            // 
            this.groupControlDangNhap.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControlDangNhap.CaptionImageOptions.Image")));
            this.groupControlDangNhap.Controls.Add(this.bt_Thoat);
            this.groupControlDangNhap.Controls.Add(this.bt_DangNhap);
            this.groupControlDangNhap.Controls.Add(this.tb_MatKhau);
            this.groupControlDangNhap.Controls.Add(this.lb_MatKhau);
            this.groupControlDangNhap.Controls.Add(this.tb_TaiKhoan);
            this.groupControlDangNhap.Controls.Add(this.lb_TaiKhoan);
            this.groupControlDangNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDangNhap.Location = new System.Drawing.Point(0, 0);
            this.groupControlDangNhap.Name = "groupControlDangNhap";
            this.groupControlDangNhap.Size = new System.Drawing.Size(286, 158);
            this.groupControlDangNhap.TabIndex = 1;
            this.groupControlDangNhap.Text = "Thông tin đăng nhập";
            // 
            // bt_Thoat
            // 
            this.bt_Thoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_Thoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_Thoat.ImageOptions.Image")));
            this.bt_Thoat.Location = new System.Drawing.Point(186, 124);
            this.bt_Thoat.Name = "bt_Thoat";
            this.bt_Thoat.Size = new System.Drawing.Size(87, 23);
            this.bt_Thoat.TabIndex = 8;
            this.bt_Thoat.Text = "Thoát";
            this.bt_Thoat.Click += new System.EventHandler(this.bt_Thoat_Click);
            // 
            // bt_DangNhap
            // 
            this.bt_DangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bt_DangNhap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bt_DangNhap.ImageOptions.Image")));
            this.bt_DangNhap.Location = new System.Drawing.Point(89, 124);
            this.bt_DangNhap.Name = "bt_DangNhap";
            this.bt_DangNhap.Size = new System.Drawing.Size(87, 23);
            this.bt_DangNhap.TabIndex = 7;
            this.bt_DangNhap.Text = "Đăng Nhập";
            this.bt_DangNhap.Click += new System.EventHandler(this.bt_DangNhap_Click);
            // 
            // tb_MatKhau
            // 
            this.tb_MatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_MatKhau.EditValue = "Snowfox123@";
            this.tb_MatKhau.Location = new System.Drawing.Point(89, 64);
            this.tb_MatKhau.Name = "tb_MatKhau";
            this.tb_MatKhau.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tb_MatKhau.Properties.Appearance.Options.UseBackColor = true;
            this.tb_MatKhau.Properties.UseSystemPasswordChar = true;
            this.tb_MatKhau.Size = new System.Drawing.Size(184, 20);
            this.tb_MatKhau.TabIndex = 3;
            // 
            // lb_MatKhau
            // 
            this.lb_MatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_MatKhau.AutoSize = true;
            this.lb_MatKhau.Location = new System.Drawing.Point(8, 70);
            this.lb_MatKhau.Name = "lb_MatKhau";
            this.lb_MatKhau.Size = new System.Drawing.Size(55, 13);
            this.lb_MatKhau.TabIndex = 2;
            this.lb_MatKhau.Text = "Mật khẩu:";
            // 
            // tb_TaiKhoan
            // 
            this.tb_TaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_TaiKhoan.EditValue = "snowfox";
            this.tb_TaiKhoan.Location = new System.Drawing.Point(89, 33);
            this.tb_TaiKhoan.Name = "tb_TaiKhoan";
            this.tb_TaiKhoan.Size = new System.Drawing.Size(184, 20);
            this.tb_TaiKhoan.TabIndex = 1;
            // 
            // lb_TaiKhoan
            // 
            this.lb_TaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_TaiKhoan.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_TaiKhoan.Location = new System.Drawing.Point(11, 36);
            this.lb_TaiKhoan.Name = "lb_TaiKhoan";
            this.lb_TaiKhoan.Size = new System.Drawing.Size(51, 13);
            this.lb_TaiKhoan.TabIndex = 0;
            this.lb_TaiKhoan.Text = "Tài Khoản:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 158);
            this.Controls.Add(this.groupControlDangNhap);
            this.Name = "Login";
            this.Text = "ĐĂNG NHẬP";
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDangNhap)).EndInit();
            this.groupControlDangNhap.ResumeLayout(false);
            this.groupControlDangNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_MatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_TaiKhoan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDangNhap;
        private DevExpress.XtraEditors.SimpleButton bt_Thoat;
        private DevExpress.XtraEditors.SimpleButton bt_DangNhap;
        private DevExpress.XtraEditors.TextEdit tb_MatKhau;
        private System.Windows.Forms.Label lb_MatKhau;
        private DevExpress.XtraEditors.TextEdit tb_TaiKhoan;
        private DevExpress.XtraEditors.LabelControl lb_TaiKhoan;
    }
}

