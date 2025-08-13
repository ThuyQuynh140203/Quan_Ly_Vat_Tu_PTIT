namespace QLVT_DATHANG
{
    partial class FormChiTietSoLuongTriGiaNhapXuat
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
            this.inbaocaoBTN = new System.Windows.Forms.Button();
            this.xemtruocBTN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.loaiPhieuCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateDenNgay = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // inbaocaoBTN
            // 
            this.inbaocaoBTN.Location = new System.Drawing.Point(502, 299);
            this.inbaocaoBTN.Margin = new System.Windows.Forms.Padding(2);
            this.inbaocaoBTN.Name = "inbaocaoBTN";
            this.inbaocaoBTN.Size = new System.Drawing.Size(123, 40);
            this.inbaocaoBTN.TabIndex = 17;
            this.inbaocaoBTN.Text = "In Báo Cáo";
            this.inbaocaoBTN.UseVisualStyleBackColor = true;
            this.inbaocaoBTN.Click += new System.EventHandler(this.inbaocaoBTN_Click);
            // 
            // xemtruocBTN
            // 
            this.xemtruocBTN.Location = new System.Drawing.Point(212, 299);
            this.xemtruocBTN.Margin = new System.Windows.Forms.Padding(2);
            this.xemtruocBTN.Name = "xemtruocBTN";
            this.xemtruocBTN.Size = new System.Drawing.Size(110, 40);
            this.xemtruocBTN.TabIndex = 16;
            this.xemtruocBTN.Text = "Xem Trước";
            this.xemtruocBTN.UseVisualStyleBackColor = true;
            this.xemtruocBTN.Click += new System.EventHandler(this.xemtruocBTN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(393, 184);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "Đến Ngày";
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.EditValue = null;
            this.dateTuNgay.Location = new System.Drawing.Point(212, 187);
            this.dateTuNgay.Margin = new System.Windows.Forms.Padding(2);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTuNgay.Size = new System.Drawing.Size(127, 20);
            this.dateTuNgay.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(85, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Từ Ngày";
            // 
            // loaiPhieuCB
            // 
            this.loaiPhieuCB.FormattingEnabled = true;
            this.loaiPhieuCB.Items.AddRange(new object[] {
            "NHAP",
            "XUAT"});
            this.loaiPhieuCB.Location = new System.Drawing.Point(212, 123);
            this.loaiPhieuCB.Margin = new System.Windows.Forms.Padding(2);
            this.loaiPhieuCB.Name = "loaiPhieuCB";
            this.loaiPhieuCB.Size = new System.Drawing.Size(181, 21);
            this.loaiPhieuCB.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Loại Phiếu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 36);
            this.label1.TabIndex = 9;
            this.label1.Text = "Chi Tiết Số Lượng Trị Giá Nhập Xuất";
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.EditValue = null;
            this.dateDenNgay.Location = new System.Drawing.Point(498, 184);
            this.dateDenNgay.Margin = new System.Windows.Forms.Padding(2);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDenNgay.Size = new System.Drawing.Size(127, 20);
            this.dateDenNgay.TabIndex = 18;
            // 
            // FormChiTietSoLuongTriGiaNhapXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 408);
            this.Controls.Add(this.dateDenNgay);
            this.Controls.Add(this.inbaocaoBTN);
            this.Controls.Add(this.xemtruocBTN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTuNgay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loaiPhieuCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormChiTietSoLuongTriGiaNhapXuat";
            this.Text = "FormChiTietSoLuongTriGiaNhapXuat";
            this.Load += new System.EventHandler(this.FormChiTietSoLuongTriGiaNhapXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDenNgay.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inbaocaoBTN;
        private System.Windows.Forms.Button xemtruocBTN;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit dateTuNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox loaiPhieuCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dateDenNgay;
    }
}