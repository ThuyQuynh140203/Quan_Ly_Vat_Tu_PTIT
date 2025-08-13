namespace QLVT_DATHANG
{
    partial class FormTaoTaiKhoan
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
            this.btnChonNhanVien = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.chinhanhRD = new System.Windows.Forms.RadioButton();
            this.userRD = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtXACNHAN = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMATKHAU = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMANV = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtXACNHAN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMATKHAU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMANV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChonNhanVien
            // 
            this.btnChonNhanVien.Location = new System.Drawing.Point(521, 69);
            this.btnChonNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.btnChonNhanVien.Name = "btnChonNhanVien";
            this.btnChonNhanVien.Size = new System.Drawing.Size(120, 47);
            this.btnChonNhanVien.TabIndex = 25;
            this.btnChonNhanVien.Text = "Chọn Nhân Viên";
            this.btnChonNhanVien.UseVisualStyleBackColor = true;
            this.btnChonNhanVien.Click += new System.EventHandler(this.btnChonNhanVien_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(407, 322);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(92, 42);
            this.btnThoat.TabIndex = 24;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(187, 322);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(92, 42);
            this.btnXacNhan.TabIndex = 23;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // chinhanhRD
            // 
            this.chinhanhRD.AutoSize = true;
            this.chinhanhRD.Enabled = false;
            this.chinhanhRD.Location = new System.Drawing.Point(374, 258);
            this.chinhanhRD.Margin = new System.Windows.Forms.Padding(2);
            this.chinhanhRD.Name = "chinhanhRD";
            this.chinhanhRD.Size = new System.Drawing.Size(68, 17);
            this.chinhanhRD.TabIndex = 22;
            this.chinhanhRD.TabStop = true;
            this.chinhanhRD.Text = "chinhanh";
            this.chinhanhRD.UseVisualStyleBackColor = true;
            // 
            // userRD
            // 
            this.userRD.AutoSize = true;
            this.userRD.Enabled = false;
            this.userRD.Location = new System.Drawing.Point(249, 258);
            this.userRD.Margin = new System.Windows.Forms.Padding(2);
            this.userRD.Name = "userRD";
            this.userRD.Size = new System.Drawing.Size(46, 17);
            this.userRD.TabIndex = 21;
            this.userRD.TabStop = true;
            this.userRD.Text = "user";
            this.userRD.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 258);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "Vai Trò";
            // 
            // txtXACNHAN
            // 
            this.txtXACNHAN.Location = new System.Drawing.Point(245, 190);
            this.txtXACNHAN.Margin = new System.Windows.Forms.Padding(2);
            this.txtXACNHAN.Name = "txtXACNHAN";
            this.txtXACNHAN.Size = new System.Drawing.Size(186, 20);
            this.txtXACNHAN.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 190);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Xác Nhận Mật Khẩu";
            // 
            // txtMATKHAU
            // 
            this.txtMATKHAU.Location = new System.Drawing.Point(245, 136);
            this.txtMATKHAU.Margin = new System.Windows.Forms.Padding(2);
            this.txtMATKHAU.Name = "txtMATKHAU";
            this.txtMATKHAU.Size = new System.Drawing.Size(186, 20);
            this.txtMATKHAU.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Mật Khẩu";
            // 
            // txtMANV
            // 
            this.txtMANV.Enabled = false;
            this.txtMANV.Location = new System.Drawing.Point(245, 81);
            this.txtMANV.Margin = new System.Windows.Forms.Padding(2);
            this.txtMANV.Name = "txtMANV";
            this.txtMANV.Size = new System.Drawing.Size(186, 20);
            this.txtMANV.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã Nhân Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 36);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tạo Tài Khoản";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 390);
            this.Controls.Add(this.btnChonNhanVien);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.chinhanhRD);
            this.Controls.Add(this.userRD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtXACNHAN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMATKHAU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMANV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormTaoTaiKhoan";
            this.Text = "FormTaoTaiKhoan";
            this.Load += new System.EventHandler(this.FormTaoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtXACNHAN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMATKHAU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMANV.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChonNhanVien;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.RadioButton chinhanhRD;
        private System.Windows.Forms.RadioButton userRD;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtXACNHAN;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtMATKHAU;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtMANV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}