namespace QLVT_DATHANG
{
    partial class FormDonDatHang
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
            System.Windows.Forms.Label mAKHOLabel;
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label nhaCCLabel;
            System.Windows.Forms.Label nGAYLabel;
            System.Windows.Forms.Label masoDDHLabel;
            System.Windows.Forms.Label mAVTLabel;
            System.Windows.Forms.Label sOLUONGLabel;
            System.Windows.Forms.Label dONGIALabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnLamMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.btnMENU = new DevExpress.XtraBars.BarSubItem();
            this.btnDDH = new DevExpress.XtraBars.BarButtonItem();
            this.btnCTDH = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.chinhanhCB = new System.Windows.Forms.ComboBox();
            this.DS = new QLVT_DATHANG.DS();
            this.bdsDH = new System.Windows.Forms.BindingSource(this.components);
            this.datHangTableAdapter = new QLVT_DATHANG.DSTableAdapters.DatHangTableAdapter();
            this.tableAdapterManager = new QLVT_DATHANG.DSTableAdapters.TableAdapterManager();
            this.cTDDHTableAdapter = new QLVT_DATHANG.DSTableAdapters.CTDDHTableAdapter();
            this.phieuNhapTableAdapter = new QLVT_DATHANG.DSTableAdapters.PhieuNhapTableAdapter();
            this.gcDatHang = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMasoDDH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhaCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bdsCTDDH = new System.Windows.Forms.BindingSource(this.components);
            this.bdsPN = new System.Windows.Forms.BindingSource(this.components);
            this.groupControlDDH = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChonVatTu = new System.Windows.Forms.Button();
            this.txtDONGIA = new DevExpress.XtraEditors.SpinEdit();
            this.txtSOLUONG = new DevExpress.XtraEditors.SpinEdit();
            this.txtMAVT = new DevExpress.XtraEditors.TextEdit();
            this.gcCTDDH = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMasoDDH1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBoxDDH = new System.Windows.Forms.GroupBox();
            this.btnChonMaKho = new System.Windows.Forms.Button();
            this.txtMAKHO = new DevExpress.XtraEditors.TextEdit();
            this.txtMANV = new DevExpress.XtraEditors.TextEdit();
            this.txtNCC = new DevExpress.XtraEditors.TextEdit();
            this.dteNGAY = new DevExpress.XtraEditors.DateEdit();
            this.txtMADDH = new DevExpress.XtraEditors.TextEdit();
            mAKHOLabel = new System.Windows.Forms.Label();
            mANVLabel = new System.Windows.Forms.Label();
            nhaCCLabel = new System.Windows.Forms.Label();
            nGAYLabel = new System.Windows.Forms.Label();
            masoDDHLabel = new System.Windows.Forms.Label();
            mAVTLabel = new System.Windows.Forms.Label();
            sOLUONGLabel = new System.Windows.Forms.Label();
            dONGIALabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDDH)).BeginInit();
            this.groupControlDDH.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDONGIA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOLUONG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAVT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCTDDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.groupBoxDDH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAKHO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMANV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAY.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMADDH.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mAKHOLabel
            // 
            mAKHOLabel.AutoSize = true;
            mAKHOLabel.Location = new System.Drawing.Point(23, 111);
            mAKHOLabel.Name = "mAKHOLabel";
            mAKHOLabel.Size = new System.Drawing.Size(47, 13);
            mAKHOLabel.TabIndex = 19;
            mAKHOLabel.Text = "MAKHO:";
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(193, 72);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(39, 13);
            mANVLabel.TabIndex = 17;
            mANVLabel.Text = "MANV:";
            // 
            // nhaCCLabel
            // 
            nhaCCLabel.AutoSize = true;
            nhaCCLabel.Location = new System.Drawing.Point(23, 72);
            nhaCCLabel.Name = "nhaCCLabel";
            nhaCCLabel.Size = new System.Drawing.Size(47, 13);
            nhaCCLabel.TabIndex = 15;
            nhaCCLabel.Text = "Nha CC:";
            // 
            // nGAYLabel
            // 
            nGAYLabel.AutoSize = true;
            nGAYLabel.Location = new System.Drawing.Point(194, 34);
            nGAYLabel.Name = "nGAYLabel";
            nGAYLabel.Size = new System.Drawing.Size(38, 13);
            nGAYLabel.TabIndex = 13;
            nGAYLabel.Text = "NGAY:";
            // 
            // masoDDHLabel
            // 
            masoDDHLabel.AutoSize = true;
            masoDDHLabel.Location = new System.Drawing.Point(10, 34);
            masoDDHLabel.Name = "masoDDHLabel";
            masoDDHLabel.Size = new System.Drawing.Size(60, 13);
            masoDDHLabel.TabIndex = 11;
            masoDDHLabel.Text = "Maso DDH:";
            // 
            // mAVTLabel
            // 
            mAVTLabel.AutoSize = true;
            mAVTLabel.Location = new System.Drawing.Point(38, 40);
            mAVTLabel.Name = "mAVTLabel";
            mAVTLabel.Size = new System.Drawing.Size(38, 13);
            mAVTLabel.TabIndex = 0;
            mAVTLabel.Text = "MAVT:";
            // 
            // sOLUONGLabel
            // 
            sOLUONGLabel.AutoSize = true;
            sOLUONGLabel.Location = new System.Drawing.Point(218, 40);
            sOLUONGLabel.Name = "sOLUONGLabel";
            sOLUONGLabel.Size = new System.Drawing.Size(59, 13);
            sOLUONGLabel.TabIndex = 2;
            sOLUONGLabel.Text = "SOLUONG:";
            // 
            // dONGIALabel
            // 
            dONGIALabel.AutoSize = true;
            dONGIALabel.Location = new System.Drawing.Point(25, 89);
            dONGIALabel.Name = "dONGIALabel";
            dONGIALabel.Size = new System.Drawing.Size(51, 13);
            dONGIALabel.TabIndex = 4;
            dONGIALabel.Text = "DONGIA:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnGhi,
            this.btnXoa,
            this.btnPhucHoi,
            this.btnLamMoi,
            this.btnThoat,
            this.barButtonItem1,
            this.btnMENU,
            this.btnDDH,
            this.btnCTDH});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 18;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGhi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPhucHoi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLamMoi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThoat),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMENU)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 2;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 3;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Caption = "Phục Hồi ";
            this.btnPhucHoi.Id = 4;
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhucHoi_ItemClick);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Caption = "Làm mới";
            this.btnLamMoi.Id = 5;
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLamMoi_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 8;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // btnMENU
            // 
            this.btnMENU.Caption = "Chọn chế độ";
            this.btnMENU.Id = 15;
            this.btnMENU.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDDH),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCTDH)});
            this.btnMENU.Name = "btnMENU";
            // 
            // btnDDH
            // 
            this.btnDDH.Caption = "Đơn đặt hàng";
            this.btnDDH.Id = 16;
            this.btnDDH.Name = "btnDDH";
            this.btnDDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDDH_ItemClick);
            // 
            // btnCTDH
            // 
            this.btnCTDH.Caption = "Chi tiết đơn hàng";
            this.btnCTDH.Id = 17;
            this.btnCTDH.Name = "btnCTDH";
            this.btnCTDH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCTDH_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlTop.Size = new System.Drawing.Size(902, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 510);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlBottom.Size = new System.Drawing.Size(902, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 469);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(902, 41);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 469);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 12;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.chinhanhCB);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 41);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(7);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(902, 46);
            this.panelControl1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chi nhánh";
            // 
            // chinhanhCB
            // 
            this.chinhanhCB.FormattingEnabled = true;
            this.chinhanhCB.Location = new System.Drawing.Point(198, 10);
            this.chinhanhCB.Margin = new System.Windows.Forms.Padding(7);
            this.chinhanhCB.Name = "chinhanhCB";
            this.chinhanhCB.Size = new System.Drawing.Size(380, 21);
            this.chinhanhCB.TabIndex = 1;
            this.chinhanhCB.SelectedIndexChanged += new System.EventHandler(this.chinhanhCB_SelectedIndexChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsDH
            // 
            this.bdsDH.DataMember = "DatHang";
            this.bdsDH.DataSource = this.DS;
            // 
            // datHangTableAdapter
            // 
            this.datHangTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = this.cTDDHTableAdapter;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = this.datHangTableAdapter;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = this.phieuNhapTableAdapter;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT_DATHANG.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // cTDDHTableAdapter
            // 
            this.cTDDHTableAdapter.ClearBeforeFill = true;
            // 
            // phieuNhapTableAdapter
            // 
            this.phieuNhapTableAdapter.ClearBeforeFill = true;
            // 
            // gcDatHang
            // 
            this.gcDatHang.DataSource = this.bdsDH;
            this.gcDatHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcDatHang.Location = new System.Drawing.Point(0, 87);
            this.gcDatHang.MainView = this.gridView1;
            this.gcDatHang.MenuManager = this.barManager1;
            this.gcDatHang.Name = "gcDatHang";
            this.gcDatHang.Size = new System.Drawing.Size(902, 134);
            this.gcDatHang.TabIndex = 13;
            this.gcDatHang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasoDDH,
            this.colNGAY,
            this.colNhaCC,
            this.colMANV,
            this.colMAKHO});
            this.gridView1.GridControl = this.gcDatHang;
            this.gridView1.Name = "gridView1";
            // 
            // colMasoDDH
            // 
            this.colMasoDDH.FieldName = "MasoDDH";
            this.colMasoDDH.Name = "colMasoDDH";
            this.colMasoDDH.Visible = true;
            this.colMasoDDH.VisibleIndex = 0;
            // 
            // colNGAY
            // 
            this.colNGAY.FieldName = "NGAY";
            this.colNGAY.Name = "colNGAY";
            this.colNGAY.Visible = true;
            this.colNGAY.VisibleIndex = 1;
            // 
            // colNhaCC
            // 
            this.colNhaCC.FieldName = "NhaCC";
            this.colNhaCC.Name = "colNhaCC";
            this.colNhaCC.Visible = true;
            this.colNhaCC.VisibleIndex = 2;
            // 
            // colMANV
            // 
            this.colMANV.FieldName = "MANV";
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 3;
            // 
            // colMAKHO
            // 
            this.colMAKHO.FieldName = "MAKHO";
            this.colMAKHO.Name = "colMAKHO";
            this.colMAKHO.Visible = true;
            this.colMAKHO.VisibleIndex = 4;
            // 
            // bdsCTDDH
            // 
            this.bdsCTDDH.DataMember = "FK_CTDDH_DatHang";
            this.bdsCTDDH.DataSource = this.bdsDH;
            // 
            // bdsPN
            // 
            this.bdsPN.DataMember = "FK_PhieuNhap_DatHang";
            this.bdsPN.DataSource = this.bdsDH;
            // 
            // groupControlDDH
            // 
            this.groupControlDDH.Controls.Add(this.groupBox1);
            this.groupControlDDH.Controls.Add(this.gcCTDDH);
            this.groupControlDDH.Controls.Add(this.groupBoxDDH);
            this.groupControlDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDDH.Location = new System.Drawing.Point(0, 221);
            this.groupControlDDH.Name = "groupControlDDH";
            this.groupControlDDH.Size = new System.Drawing.Size(902, 289);
            this.groupControlDDH.TabIndex = 19;
            this.groupControlDDH.Text = "Đặt hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChonVatTu);
            this.groupBox1.Controls.Add(dONGIALabel);
            this.groupBox1.Controls.Add(this.txtDONGIA);
            this.groupBox1.Controls.Add(sOLUONGLabel);
            this.groupBox1.Controls.Add(this.txtSOLUONG);
            this.groupBox1.Controls.Add(mAVTLabel);
            this.groupBox1.Controls.Add(this.txtMAVT);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(400, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 140);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết đơn đặt hàng";
            // 
            // btnChonVatTu
            // 
            this.btnChonVatTu.Location = new System.Drawing.Point(239, 76);
            this.btnChonVatTu.Name = "btnChonVatTu";
            this.btnChonVatTu.Size = new System.Drawing.Size(110, 39);
            this.btnChonVatTu.TabIndex = 6;
            this.btnChonVatTu.Text = "Chọn Vật Tư";
            this.btnChonVatTu.UseVisualStyleBackColor = true;
            this.btnChonVatTu.Click += new System.EventHandler(this.btnChonVatTu_Click);
            // 
            // txtDONGIA
            // 
            this.txtDONGIA.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCTDDH, "DONGIA", true));
            this.txtDONGIA.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDONGIA.Location = new System.Drawing.Point(82, 86);
            this.txtDONGIA.MenuManager = this.barManager1;
            this.txtDONGIA.Name = "txtDONGIA";
            this.txtDONGIA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDONGIA.Size = new System.Drawing.Size(100, 20);
            this.txtDONGIA.TabIndex = 5;
            // 
            // txtSOLUONG
            // 
            this.txtSOLUONG.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCTDDH, "SOLUONG", true));
            this.txtSOLUONG.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSOLUONG.Location = new System.Drawing.Point(283, 37);
            this.txtSOLUONG.MenuManager = this.barManager1;
            this.txtSOLUONG.Name = "txtSOLUONG";
            this.txtSOLUONG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSOLUONG.Size = new System.Drawing.Size(100, 20);
            this.txtSOLUONG.TabIndex = 3;
            // 
            // txtMAVT
            // 
            this.txtMAVT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCTDDH, "MAVT", true));
            this.txtMAVT.Location = new System.Drawing.Point(82, 37);
            this.txtMAVT.MenuManager = this.barManager1;
            this.txtMAVT.Name = "txtMAVT";
            this.txtMAVT.Size = new System.Drawing.Size(100, 20);
            this.txtMAVT.TabIndex = 1;
            // 
            // gcCTDDH
            // 
            this.gcCTDDH.DataSource = this.bdsCTDDH;
            this.gcCTDDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcCTDDH.Location = new System.Drawing.Point(400, 23);
            this.gcCTDDH.MainView = this.gridView2;
            this.gcCTDDH.MenuManager = this.barManager1;
            this.gcCTDDH.Name = "gcCTDDH";
            this.gcCTDDH.Size = new System.Drawing.Size(500, 124);
            this.gcCTDDH.TabIndex = 3;
            this.gcCTDDH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasoDDH1,
            this.colMAVT,
            this.colSOLUONG,
            this.colDONGIA});
            this.gridView2.GridControl = this.gcCTDDH;
            this.gridView2.Name = "gridView2";
            // 
            // colMasoDDH1
            // 
            this.colMasoDDH1.FieldName = "MasoDDH";
            this.colMasoDDH1.Name = "colMasoDDH1";
            this.colMasoDDH1.Visible = true;
            this.colMasoDDH1.VisibleIndex = 0;
            // 
            // colMAVT
            // 
            this.colMAVT.FieldName = "MAVT";
            this.colMAVT.Name = "colMAVT";
            this.colMAVT.Visible = true;
            this.colMAVT.VisibleIndex = 1;
            // 
            // colSOLUONG
            // 
            this.colSOLUONG.FieldName = "SOLUONG";
            this.colSOLUONG.Name = "colSOLUONG";
            this.colSOLUONG.Visible = true;
            this.colSOLUONG.VisibleIndex = 2;
            // 
            // colDONGIA
            // 
            this.colDONGIA.FieldName = "DONGIA";
            this.colDONGIA.Name = "colDONGIA";
            this.colDONGIA.Visible = true;
            this.colDONGIA.VisibleIndex = 3;
            // 
            // groupBoxDDH
            // 
            this.groupBoxDDH.Controls.Add(this.btnChonMaKho);
            this.groupBoxDDH.Controls.Add(mAKHOLabel);
            this.groupBoxDDH.Controls.Add(this.txtMAKHO);
            this.groupBoxDDH.Controls.Add(mANVLabel);
            this.groupBoxDDH.Controls.Add(this.txtMANV);
            this.groupBoxDDH.Controls.Add(nhaCCLabel);
            this.groupBoxDDH.Controls.Add(this.txtNCC);
            this.groupBoxDDH.Controls.Add(nGAYLabel);
            this.groupBoxDDH.Controls.Add(this.dteNGAY);
            this.groupBoxDDH.Controls.Add(masoDDHLabel);
            this.groupBoxDDH.Controls.Add(this.txtMADDH);
            this.groupBoxDDH.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxDDH.Location = new System.Drawing.Point(2, 23);
            this.groupBoxDDH.Name = "groupBoxDDH";
            this.groupBoxDDH.Size = new System.Drawing.Size(398, 264);
            this.groupBoxDDH.TabIndex = 3;
            this.groupBoxDDH.TabStop = false;
            this.groupBoxDDH.Text = "Đơn đặt hàng";
            // 
            // btnChonMaKho
            // 
            this.btnChonMaKho.Location = new System.Drawing.Point(213, 106);
            this.btnChonMaKho.Name = "btnChonMaKho";
            this.btnChonMaKho.Size = new System.Drawing.Size(114, 35);
            this.btnChonMaKho.TabIndex = 21;
            this.btnChonMaKho.Text = "Chọn Kho";
            this.btnChonMaKho.UseVisualStyleBackColor = true;
            this.btnChonMaKho.Click += new System.EventHandler(this.btnChonMaKho_Click_1);
            // 
            // txtMAKHO
            // 
            this.txtMAKHO.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDH, "MAKHO", true));
            this.txtMAKHO.Location = new System.Drawing.Point(76, 108);
            this.txtMAKHO.MenuManager = this.barManager1;
            this.txtMAKHO.Name = "txtMAKHO";
            this.txtMAKHO.Size = new System.Drawing.Size(100, 20);
            this.txtMAKHO.TabIndex = 20;
            // 
            // txtMANV
            // 
            this.txtMANV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDH, "MANV", true));
            this.txtMANV.Location = new System.Drawing.Point(238, 69);
            this.txtMANV.MenuManager = this.barManager1;
            this.txtMANV.Name = "txtMANV";
            this.txtMANV.Size = new System.Drawing.Size(100, 20);
            this.txtMANV.TabIndex = 18;
            // 
            // txtNCC
            // 
            this.txtNCC.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDH, "NhaCC", true));
            this.txtNCC.Location = new System.Drawing.Point(76, 69);
            this.txtNCC.MenuManager = this.barManager1;
            this.txtNCC.Name = "txtNCC";
            this.txtNCC.Size = new System.Drawing.Size(100, 20);
            this.txtNCC.TabIndex = 16;
            // 
            // dteNGAY
            // 
            this.dteNGAY.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDH, "NGAY", true));
            this.dteNGAY.EditValue = null;
            this.dteNGAY.Location = new System.Drawing.Point(238, 31);
            this.dteNGAY.MenuManager = this.barManager1;
            this.dteNGAY.Name = "dteNGAY";
            this.dteNGAY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteNGAY.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteNGAY.Size = new System.Drawing.Size(100, 20);
            this.dteNGAY.TabIndex = 14;
            // 
            // txtMADDH
            // 
            this.txtMADDH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDH, "MasoDDH", true));
            this.txtMADDH.Location = new System.Drawing.Point(76, 31);
            this.txtMADDH.MenuManager = this.barManager1;
            this.txtMADDH.Name = "txtMADDH";
            this.txtMADDH.Size = new System.Drawing.Size(100, 20);
            this.txtMADDH.TabIndex = 12;
            // 
            // FormDonDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(902, 530);
            this.Controls.Add(this.groupControlDDH);
            this.Controls.Add(this.gcDatHang);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormDonDatHang";
            this.Text = "FormDonDatHang";
            this.Load += new System.EventHandler(this.FormDonDatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDDH)).EndInit();
            this.groupControlDDH.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDONGIA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSOLUONG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAVT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCTDDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.groupBoxDDH.ResumeLayout(false);
            this.groupBoxDDH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAKHO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMANV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAY.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMADDH.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraBars.BarButtonItem btnLamMoi;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox chinhanhCB;
        private System.Windows.Forms.BindingSource bdsDH;
        private DS DS;
        private DSTableAdapters.DatHangTableAdapter datHangTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcDatHang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMasoDDH;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAY;
        private DevExpress.XtraGrid.Columns.GridColumn colNhaCC;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private DSTableAdapters.CTDDHTableAdapter cTDDHTableAdapter;
        private System.Windows.Forms.BindingSource bdsCTDDH;
        private DSTableAdapters.PhieuNhapTableAdapter phieuNhapTableAdapter;
        private System.Windows.Forms.BindingSource bdsPN;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarSubItem btnMENU;
        private DevExpress.XtraBars.BarButtonItem btnDDH;
        private DevExpress.XtraBars.BarButtonItem btnCTDH;
        private DevExpress.XtraEditors.GroupControl groupControlDDH;
        private System.Windows.Forms.GroupBox groupBoxDDH;
        private System.Windows.Forms.Button btnChonMaKho;
        private DevExpress.XtraEditors.TextEdit txtMAKHO;
        private DevExpress.XtraEditors.TextEdit txtMANV;
        private DevExpress.XtraEditors.TextEdit txtNCC;
        private DevExpress.XtraEditors.DateEdit dteNGAY;
        private DevExpress.XtraEditors.TextEdit txtMADDH;
        private DevExpress.XtraGrid.GridControl gcCTDDH;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colMasoDDH1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAVT;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colDONGIA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChonVatTu;
        private DevExpress.XtraEditors.SpinEdit txtDONGIA;
        private DevExpress.XtraEditors.SpinEdit txtSOLUONG;
        private DevExpress.XtraEditors.TextEdit txtMAVT;
    }
}