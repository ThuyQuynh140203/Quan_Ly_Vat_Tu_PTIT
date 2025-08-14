namespace QLVT_DATHANG
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.nhanvien = new DevExpress.XtraBars.BarButtonItem();
            this.vattu = new DevExpress.XtraBars.BarButtonItem();
            this.khohang = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnLPN = new DevExpress.XtraBars.BarButtonItem();
            this.btnLPX = new DevExpress.XtraBars.BarButtonItem();
            this.btnDDH = new DevExpress.XtraBars.BarButtonItem();
            this.btnInDSNV = new DevExpress.XtraBars.BarButtonItem();
            this.btnInDSVT = new DevExpress.XtraBars.BarButtonItem();
            this.btnChiTietTGNXHH = new DevExpress.XtraBars.BarButtonItem();
            this.hethong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageHeThong = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.danhmuc = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.nghiepvu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.baocao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MANV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HOTEN = new System.Windows.Forms.ToolStripStatusLabel();
            this.NHOM = new System.Windows.Forms.ToolStripStatusLabel();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnDangNhap,
            this.btnTaoTaiKhoan,
            this.btnDangXuat,
            this.nhanvien,
            this.vattu,
            this.khohang,
            this.barButtonItem1,
            this.btnLPN,
            this.btnLPX,
            this.btnDDH,
            this.btnInDSNV,
            this.btnInDSVT,
            this.btnChiTietTGNXHH});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 17;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.hethong,
            this.danhmuc,
            this.nghiepvu,
            this.baocao});
            this.ribbonControl1.Size = new System.Drawing.Size(758, 158);
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Caption = "Đăng nhập";
            this.btnDangNhap.Id = 2;
            this.btnDangNhap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangNhap.ImageOptions.Image")));
            this.btnDangNhap.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDangNhap.ImageOptions.LargeImage")));
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangNhap_ItemClick);
            // 
            // btnTaoTaiKhoan
            // 
            this.btnTaoTaiKhoan.Caption = "Tạo tài khoản";
            this.btnTaoTaiKhoan.Id = 4;
            this.btnTaoTaiKhoan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTaoTaiKhoan.ImageOptions.Image")));
            this.btnTaoTaiKhoan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTaoTaiKhoan.ImageOptions.LargeImage")));
            this.btnTaoTaiKhoan.Name = "btnTaoTaiKhoan";
            this.btnTaoTaiKhoan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoTaiKhoan_ItemClick);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Caption = "Đăng xuất";
            this.btnDangXuat.Id = 5;
            this.btnDangXuat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.ImageOptions.Image")));
            this.btnDangXuat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.ImageOptions.LargeImage")));
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangXuat_ItemClick);
            // 
            // nhanvien
            // 
            this.nhanvien.Caption = "Nhân viên";
            this.nhanvien.Id = 6;
            this.nhanvien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("nhanvien.ImageOptions.Image")));
            this.nhanvien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("nhanvien.ImageOptions.LargeImage")));
            this.nhanvien.Name = "nhanvien";
            this.nhanvien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.nhanvien_ItemClick);
            // 
            // vattu
            // 
            this.vattu.Caption = "Vật Tư";
            this.vattu.Id = 7;
            this.vattu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("vattu.ImageOptions.Image")));
            this.vattu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("vattu.ImageOptions.LargeImage")));
            this.vattu.Name = "vattu";
            this.vattu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.vattu_ItemClick);
            // 
            // khohang
            // 
            this.khohang.Caption = "Kho hàng";
            this.khohang.Id = 8;
            this.khohang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("khohang.ImageOptions.Image")));
            this.khohang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("khohang.ImageOptions.LargeImage")));
            this.khohang.Name = "khohang";
            this.khohang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.khohang_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnLPN
            // 
            this.btnLPN.Caption = "Lập Phiếu nhập";
            this.btnLPN.Id = 11;
            this.btnLPN.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLPN.ImageOptions.Image")));
            this.btnLPN.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLPN.ImageOptions.LargeImage")));
            this.btnLPN.Name = "btnLPN";
            this.btnLPN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLPN_ItemClick);
            // 
            // btnLPX
            // 
            this.btnLPX.Caption = "Lập phiếu xuất";
            this.btnLPX.Id = 12;
            this.btnLPX.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLPX.ImageOptions.Image")));
            this.btnLPX.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLPX.ImageOptions.LargeImage")));
            this.btnLPX.Name = "btnLPX";
            this.btnLPX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLPX_ItemClick);
            // 
            // btnDDH
            // 
            this.btnDDH.Caption = "Đơn đặt hàng";
            this.btnDDH.Id = 13;
            this.btnDDH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDDH.ImageOptions.Image")));
            this.btnDDH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDDH.ImageOptions.LargeImage")));
            this.btnDDH.Name = "btnDDH";
            this.btnDDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDDH_ItemClick);
            // 
            // btnInDSNV
            // 
            this.btnInDSNV.Caption = "In danh sách nhân viên";
            this.btnInDSNV.Id = 14;
            this.btnInDSNV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInDSNV.ImageOptions.Image")));
            this.btnInDSNV.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInDSNV.ImageOptions.LargeImage")));
            this.btnInDSNV.Name = "btnInDSNV";
            this.btnInDSNV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInDSNV_ItemClick);
            // 
            // btnInDSVT
            // 
            this.btnInDSVT.Caption = "In danh sách vật tư";
            this.btnInDSVT.Id = 15;
            this.btnInDSVT.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInDSVT.ImageOptions.Image")));
            this.btnInDSVT.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInDSVT.ImageOptions.LargeImage")));
            this.btnInDSVT.Name = "btnInDSVT";
            this.btnInDSVT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInDSVT_ItemClick);
            // 
            // btnChiTietTGNXHH
            // 
            this.btnChiTietTGNXHH.Caption = "Chi tiết số lượng trị giá nhập xuất hàng hóa";
            this.btnChiTietTGNXHH.Id = 16;
            this.btnChiTietTGNXHH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChiTietTGNXHH.ImageOptions.LargeImage")));
            this.btnChiTietTGNXHH.Name = "btnChiTietTGNXHH";
            this.btnChiTietTGNXHH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChiTietTGNXHH_ItemClick);
            // 
            // hethong
            // 
            this.hethong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageHeThong});
            this.hethong.Name = "hethong";
            this.hethong.Text = "Hệ thống";
            // 
            // ribbonPageHeThong
            // 
            this.ribbonPageHeThong.ItemLinks.Add(this.btnDangNhap);
            this.ribbonPageHeThong.ItemLinks.Add(this.btnTaoTaiKhoan);
            this.ribbonPageHeThong.ItemLinks.Add(this.btnDangXuat);
            this.ribbonPageHeThong.Name = "ribbonPageHeThong";
            // 
            // danhmuc
            // 
            this.danhmuc.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.danhmuc.Name = "danhmuc";
            this.danhmuc.Text = "Danh mục";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.nhanvien);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.vattu);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.khohang);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // nghiepvu
            // 
            this.nghiepvu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7});
            this.nghiepvu.Name = "nghiepvu";
            this.nghiepvu.Text = "Nghiệp Vụ";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDDH);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnLPN);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnLPX);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // baocao
            // 
            this.baocao.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup8,
            this.ribbonPageGroup9});
            this.baocao.Name = "baocao";
            this.baocao.Text = "Báo cáo";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnInDSNV);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btnInDSVT);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.btnChiTietTGNXHH);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "ribbonPage3";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MANV,
            this.HOTEN,
            this.NHOM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 381);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(758, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MANV
            // 
            this.MANV.Name = "MANV";
            this.MANV.Size = new System.Drawing.Size(42, 17);
            this.MANV.Text = "MANV";
            // 
            // HOTEN
            // 
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Size = new System.Drawing.Size(46, 17);
            this.HOTEN.Text = "HOTEN";
            // 
            // NHOM
            // 
            this.NHOM.Name = "NHOM";
            this.NHOM.Size = new System.Drawing.Size(45, 17);
            this.NHOM.Text = "NHOM";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 403);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Ribbon = this.ribbonControl1;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageHeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPage hethong;
        private DevExpress.XtraBars.Ribbon.RibbonPage danhmuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnDangNhap;
        private DevExpress.XtraBars.BarButtonItem btnTaoTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.Ribbon.RibbonPage nghiepvu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Ribbon.RibbonPage baocao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        public System.Windows.Forms.ToolStripStatusLabel HOTEN;
        public System.Windows.Forms.ToolStripStatusLabel NHOM;
        public System.Windows.Forms.ToolStripStatusLabel MANV;
        private DevExpress.XtraBars.BarButtonItem nhanvien;
        private DevExpress.XtraBars.BarButtonItem vattu;
        private DevExpress.XtraBars.BarButtonItem khohang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnLPN;
        private DevExpress.XtraBars.BarButtonItem btnLPX;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btnDDH;
        private DevExpress.XtraBars.BarButtonItem btnInDSNV;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem btnInDSVT;
        private DevExpress.XtraBars.BarButtonItem btnChiTietTGNXHH;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
    }
}

