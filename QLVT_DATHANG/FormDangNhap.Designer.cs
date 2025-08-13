namespace QLVT_DATHANG
{
    partial class FormDangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TaiKhoanTB = new System.Windows.Forms.MaskedTextBox();
            this.MatKhauTB = new System.Windows.Forms.MaskedTextBox();
            this.ChiNhanhCB = new System.Windows.Forms.ComboBox();
            this.dangNhapBTNClick = new System.Windows.Forms.Button();
            this.thoatBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi Nhánh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tài Khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật Khẩu";
            // 
            // TaiKhoanTB
            // 
            this.TaiKhoanTB.Location = new System.Drawing.Point(148, 90);
            this.TaiKhoanTB.Name = "TaiKhoanTB";
            this.TaiKhoanTB.Size = new System.Drawing.Size(268, 21);
            this.TaiKhoanTB.TabIndex = 3;
            // 
            // MatKhauTB
            // 
            this.MatKhauTB.Location = new System.Drawing.Point(148, 132);
            this.MatKhauTB.Name = "MatKhauTB";
            this.MatKhauTB.Size = new System.Drawing.Size(268, 21);
            this.MatKhauTB.TabIndex = 4;
            // 
            // ChiNhanhCB
            // 
            this.ChiNhanhCB.FormattingEnabled = true;
            this.ChiNhanhCB.Location = new System.Drawing.Point(148, 55);
            this.ChiNhanhCB.Name = "ChiNhanhCB";
            this.ChiNhanhCB.Size = new System.Drawing.Size(267, 21);
            this.ChiNhanhCB.TabIndex = 5;
            this.ChiNhanhCB.SelectedIndexChanged += new System.EventHandler(this.ChiNhanhCB_SelectedIndexChanged);
            // 
            // dangNhapBTNClick
            // 
            this.dangNhapBTNClick.Location = new System.Drawing.Point(148, 191);
            this.dangNhapBTNClick.Margin = new System.Windows.Forms.Padding(2);
            this.dangNhapBTNClick.Name = "dangNhapBTNClick";
            this.dangNhapBTNClick.Size = new System.Drawing.Size(70, 28);
            this.dangNhapBTNClick.TabIndex = 7;
            this.dangNhapBTNClick.Text = "Đăng Nhập";
            this.dangNhapBTNClick.UseVisualStyleBackColor = true;
            this.dangNhapBTNClick.Click += new System.EventHandler(this.dangNhapBTNClick_Click);
            // 
            // thoatBTN
            // 
            this.thoatBTN.Location = new System.Drawing.Point(343, 191);
            this.thoatBTN.Margin = new System.Windows.Forms.Padding(2);
            this.thoatBTN.Name = "thoatBTN";
            this.thoatBTN.Size = new System.Drawing.Size(72, 28);
            this.thoatBTN.TabIndex = 8;
            this.thoatBTN.Text = "Thoát";
            this.thoatBTN.UseVisualStyleBackColor = true;
            this.thoatBTN.Click += new System.EventHandler(this.thoatBTN_Click);
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 287);
            this.Controls.Add(this.thoatBTN);
            this.Controls.Add(this.dangNhapBTNClick);
            this.Controls.Add(this.ChiNhanhCB);
            this.Controls.Add(this.MatKhauTB);
            this.Controls.Add(this.TaiKhoanTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDangNhap";
            this.Text = "FormDangNhap";
            this.Load += new System.EventHandler(this.FormDangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox TaiKhoanTB;
        private System.Windows.Forms.MaskedTextBox MatKhauTB;
        private System.Windows.Forms.ComboBox ChiNhanhCB;
        private System.Windows.Forms.Button dangNhapBTNClick;
        private System.Windows.Forms.Button thoatBTN;
    }
}