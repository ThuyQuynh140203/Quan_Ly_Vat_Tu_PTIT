namespace QLVT_DATHANG
{
    partial class FormNhanVien
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
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label hOLabel;
            System.Windows.Forms.Label tENLabel;
            System.Windows.Forms.Label dIACHILabel;
            System.Windows.Forms.Label nGAYSINHLabel;
            System.Windows.Forms.Label lUONGLabel;
            System.Windows.Forms.Label mACNLabel;
            System.Windows.Forms.Label trangThaiXoaLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnLamMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnChuyenCN = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.chinhanhCB = new System.Windows.Forms.ComboBox();
            this.DS = new QLVT_DATHANG.DS();
            this.bdsNV = new System.Windows.Forms.BindingSource(this.components);
            this.NhanVienTableAdapter = new QLVT_DATHANG.DSTableAdapters.NhanVienTableAdapter();
            this.tableAdapterManager = new QLVT_DATHANG.DSTableAdapters.TableAdapterManager();
            this.gcNhanVien = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYSINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMACN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThaiXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelNHAPLIEU = new DevExpress.XtraEditors.PanelControl();
            this.trangThaiXoaCB = new System.Windows.Forms.CheckBox();
            this.txtMACN = new DevExpress.XtraEditors.TextEdit();
            this.txtLUONG = new DevExpress.XtraEditors.SpinEdit();
            this.dteNGAYSINH = new DevExpress.XtraEditors.DateEdit();
            this.txtDIACHI = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN = new DevExpress.XtraEditors.TextEdit();
            this.txtHO = new DevExpress.XtraEditors.TextEdit();
            this.txtMANV = new DevExpress.XtraEditors.TextEdit();
            this.bdsDH = new System.Windows.Forms.BindingSource(this.components);
            this.datHangTableAdapter = new QLVT_DATHANG.DSTableAdapters.DatHangTableAdapter();
            this.bdsPN = new System.Windows.Forms.BindingSource(this.components);
            this.phieuNhapTableAdapter = new QLVT_DATHANG.DSTableAdapters.PhieuNhapTableAdapter();
            this.bdsPX = new System.Windows.Forms.BindingSource(this.components);
            this.phieuXuatTableAdapter = new QLVT_DATHANG.DSTableAdapters.PhieuXuatTableAdapter();
            mANVLabel = new System.Windows.Forms.Label();
            hOLabel = new System.Windows.Forms.Label();
            tENLabel = new System.Windows.Forms.Label();
            dIACHILabel = new System.Windows.Forms.Label();
            nGAYSINHLabel = new System.Windows.Forms.Label();
            lUONGLabel = new System.Windows.Forms.Label();
            mACNLabel = new System.Windows.Forms.Label();
            trangThaiXoaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNHAPLIEU)).BeginInit();
            this.panelNHAPLIEU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMACN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLUONG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYSINH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYSINH.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIACHI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMANV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPX)).BeginInit();
            this.SuspendLayout();
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(81, 33);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(39, 13);
            mANVLabel.TabIndex = 0;
            mANVLabel.Text = "MANV:";
            // 
            // hOLabel
            // 
            hOLabel.AutoSize = true;
            hOLabel.Location = new System.Drawing.Point(250, 33);
            hOLabel.Name = "hOLabel";
            hOLabel.Size = new System.Drawing.Size(26, 13);
            hOLabel.TabIndex = 2;
            hOLabel.Text = "HO:";
            // 
            // tENLabel
            // 
            tENLabel.AutoSize = true;
            tENLabel.Location = new System.Drawing.Point(403, 33);
            tENLabel.Name = "tENLabel";
            tENLabel.Size = new System.Drawing.Size(30, 13);
            tENLabel.TabIndex = 4;
            tENLabel.Text = "TEN:";
            // 
            // dIACHILabel
            // 
            dIACHILabel.AutoSize = true;
            dIACHILabel.Location = new System.Drawing.Point(73, 126);
            dIACHILabel.Name = "dIACHILabel";
            dIACHILabel.Size = new System.Drawing.Size(47, 13);
            dIACHILabel.TabIndex = 6;
            dIACHILabel.Text = "DIACHI:";
            // 
            // nGAYSINHLabel
            // 
            nGAYSINHLabel.AutoSize = true;
            nGAYSINHLabel.Location = new System.Drawing.Point(58, 100);
            nGAYSINHLabel.Name = "nGAYSINHLabel";
            nGAYSINHLabel.Size = new System.Drawing.Size(62, 13);
            nGAYSINHLabel.TabIndex = 8;
            nGAYSINHLabel.Text = "NGAYSINH:";
            // 
            // lUONGLabel
            // 
            lUONGLabel.AutoSize = true;
            lUONGLabel.Location = new System.Drawing.Point(75, 74);
            lUONGLabel.Name = "lUONGLabel";
            lUONGLabel.Size = new System.Drawing.Size(45, 13);
            lUONGLabel.TabIndex = 10;
            lUONGLabel.Text = "LUONG:";
            // 
            // mACNLabel
            // 
            mACNLabel.AutoSize = true;
            mACNLabel.Location = new System.Drawing.Point(319, 70);
            mACNLabel.Name = "mACNLabel";
            mACNLabel.Size = new System.Drawing.Size(40, 13);
            mACNLabel.TabIndex = 12;
            mACNLabel.Text = "MACN:";
            // 
            // trangThaiXoaLabel
            // 
            trangThaiXoaLabel.AutoSize = true;
            trangThaiXoaLabel.Location = new System.Drawing.Point(525, 126);
            trangThaiXoaLabel.Name = "trangThaiXoaLabel";
            trangThaiXoaLabel.Size = new System.Drawing.Size(83, 13);
            trangThaiXoaLabel.TabIndex = 14;
            trangThaiXoaLabel.Text = "Trang Thai Xoa:";
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
            this.btnChuyenCN,
            this.btnThoat});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnChuyenCN),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThoat)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick_1);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 2;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick_1);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 3;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick_1);
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
            this.btnLamMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLamMoi_ItemClick_1);
            // 
            // btnChuyenCN
            // 
            this.btnChuyenCN.Caption = "Chuyển Chi Nhánh";
            this.btnChuyenCN.Id = 7;
            this.btnChuyenCN.Name = "btnChuyenCN";
            this.btnChuyenCN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChuyenCN_ItemClick_1);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 8;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick_1);
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
            this.barDockControlTop.Size = new System.Drawing.Size(984, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 736);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlBottom.Size = new System.Drawing.Size(984, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 695);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(984, 41);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 695);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.chinhanhCB);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 41);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(7);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(984, 66);
            this.panelControl1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chi nhánh";
            // 
            // chinhanhCB
            // 
            this.chinhanhCB.FormattingEnabled = true;
            this.chinhanhCB.Location = new System.Drawing.Point(191, 24);
            this.chinhanhCB.Margin = new System.Windows.Forms.Padding(7);
            this.chinhanhCB.Name = "chinhanhCB";
            this.chinhanhCB.Size = new System.Drawing.Size(527, 21);
            this.chinhanhCB.TabIndex = 1;
            this.chinhanhCB.SelectedIndexChanged += new System.EventHandler(this.chinhanhCB_SelectedIndexChanged_1);
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsNV
            // 
            this.bdsNV.DataMember = "NhanVien";
            this.bdsNV.DataSource = this.DS;
            // 
            // NhanVienTableAdapter
            // 
            this.NhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = this.NhanVienTableAdapter;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT_DATHANG.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // gcNhanVien
            // 
            this.gcNhanVien.DataSource = this.bdsNV;
            this.gcNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcNhanVien.Location = new System.Drawing.Point(0, 107);
            this.gcNhanVien.MainView = this.gridView1;
            this.gcNhanVien.MenuManager = this.barManager1;
            this.gcNhanVien.Name = "gcNhanVien";
            this.gcNhanVien.Size = new System.Drawing.Size(984, 220);
            this.gcNhanVien.TabIndex = 11;
            this.gcNhanVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMANV,
            this.colHO,
            this.colTEN,
            this.colDIACHI,
            this.colNGAYSINH,
            this.colLUONG,
            this.colMACN,
            this.colTrangThaiXoa});
            this.gridView1.GridControl = this.gcNhanVien;
            this.gridView1.Name = "gridView1";
            // 
            // colMANV
            // 
            this.colMANV.FieldName = "MANV";
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 0;
            // 
            // colHO
            // 
            this.colHO.FieldName = "HO";
            this.colHO.Name = "colHO";
            this.colHO.Visible = true;
            this.colHO.VisibleIndex = 1;
            // 
            // colTEN
            // 
            this.colTEN.FieldName = "TEN";
            this.colTEN.Name = "colTEN";
            this.colTEN.Visible = true;
            this.colTEN.VisibleIndex = 2;
            // 
            // colDIACHI
            // 
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 3;
            // 
            // colNGAYSINH
            // 
            this.colNGAYSINH.FieldName = "NGAYSINH";
            this.colNGAYSINH.Name = "colNGAYSINH";
            this.colNGAYSINH.Visible = true;
            this.colNGAYSINH.VisibleIndex = 4;
            // 
            // colLUONG
            // 
            this.colLUONG.FieldName = "LUONG";
            this.colLUONG.Name = "colLUONG";
            this.colLUONG.Visible = true;
            this.colLUONG.VisibleIndex = 5;
            // 
            // colMACN
            // 
            this.colMACN.FieldName = "MACN";
            this.colMACN.Name = "colMACN";
            this.colMACN.Visible = true;
            this.colMACN.VisibleIndex = 6;
            // 
            // colTrangThaiXoa
            // 
            this.colTrangThaiXoa.FieldName = "TrangThaiXoa";
            this.colTrangThaiXoa.Name = "colTrangThaiXoa";
            this.colTrangThaiXoa.Visible = true;
            this.colTrangThaiXoa.VisibleIndex = 7;
            // 
            // panelNHAPLIEU
            // 
            this.panelNHAPLIEU.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelNHAPLIEU.Controls.Add(trangThaiXoaLabel);
            this.panelNHAPLIEU.Controls.Add(this.trangThaiXoaCB);
            this.panelNHAPLIEU.Controls.Add(mACNLabel);
            this.panelNHAPLIEU.Controls.Add(this.txtMACN);
            this.panelNHAPLIEU.Controls.Add(lUONGLabel);
            this.panelNHAPLIEU.Controls.Add(this.txtLUONG);
            this.panelNHAPLIEU.Controls.Add(nGAYSINHLabel);
            this.panelNHAPLIEU.Controls.Add(this.dteNGAYSINH);
            this.panelNHAPLIEU.Controls.Add(dIACHILabel);
            this.panelNHAPLIEU.Controls.Add(this.txtDIACHI);
            this.panelNHAPLIEU.Controls.Add(tENLabel);
            this.panelNHAPLIEU.Controls.Add(this.txtTEN);
            this.panelNHAPLIEU.Controls.Add(hOLabel);
            this.panelNHAPLIEU.Controls.Add(this.txtHO);
            this.panelNHAPLIEU.Controls.Add(mANVLabel);
            this.panelNHAPLIEU.Controls.Add(this.txtMANV);
            this.panelNHAPLIEU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNHAPLIEU.Location = new System.Drawing.Point(0, 327);
            this.panelNHAPLIEU.Name = "panelNHAPLIEU";
            this.panelNHAPLIEU.Size = new System.Drawing.Size(984, 409);
            this.panelNHAPLIEU.TabIndex = 16;
            // 
            // trangThaiXoaCB
            // 
            this.trangThaiXoaCB.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bdsNV, "TrangThaiXoa", true));
            this.trangThaiXoaCB.Location = new System.Drawing.Point(614, 121);
            this.trangThaiXoaCB.Name = "trangThaiXoaCB";
            this.trangThaiXoaCB.Size = new System.Drawing.Size(38, 24);
            this.trangThaiXoaCB.TabIndex = 15;
            this.trangThaiXoaCB.UseVisualStyleBackColor = true;
            // 
            // txtMACN
            // 
            this.txtMACN.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNV, "MACN", true));
            this.txtMACN.Location = new System.Drawing.Point(365, 67);
            this.txtMACN.MenuManager = this.barManager1;
            this.txtMACN.Name = "txtMACN";
            this.txtMACN.Size = new System.Drawing.Size(100, 20);
            this.txtMACN.TabIndex = 13;
            // 
            // txtLUONG
            // 
            this.txtLUONG.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNV, "LUONG", true));
            this.txtLUONG.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLUONG.Location = new System.Drawing.Point(126, 71);
            this.txtLUONG.MenuManager = this.barManager1;
            this.txtLUONG.Name = "txtLUONG";
            this.txtLUONG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtLUONG.Size = new System.Drawing.Size(134, 20);
            this.txtLUONG.TabIndex = 11;
            // 
            // dteNGAYSINH
            // 
            this.dteNGAYSINH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNV, "NGAYSINH", true));
            this.dteNGAYSINH.EditValue = null;
            this.dteNGAYSINH.Location = new System.Drawing.Point(126, 97);
            this.dteNGAYSINH.MenuManager = this.barManager1;
            this.dteNGAYSINH.Name = "dteNGAYSINH";
            this.dteNGAYSINH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteNGAYSINH.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteNGAYSINH.Size = new System.Drawing.Size(134, 20);
            this.dteNGAYSINH.TabIndex = 9;
            // 
            // txtDIACHI
            // 
            this.txtDIACHI.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNV, "DIACHI", true));
            this.txtDIACHI.Location = new System.Drawing.Point(126, 123);
            this.txtDIACHI.MenuManager = this.barManager1;
            this.txtDIACHI.Name = "txtDIACHI";
            this.txtDIACHI.Size = new System.Drawing.Size(379, 20);
            this.txtDIACHI.TabIndex = 7;
            // 
            // txtTEN
            // 
            this.txtTEN.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNV, "TEN", true));
            this.txtTEN.Location = new System.Drawing.Point(439, 30);
            this.txtTEN.MenuManager = this.barManager1;
            this.txtTEN.Name = "txtTEN";
            this.txtTEN.Size = new System.Drawing.Size(100, 20);
            this.txtTEN.TabIndex = 5;
            // 
            // txtHO
            // 
            this.txtHO.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNV, "HO", true));
            this.txtHO.Location = new System.Drawing.Point(282, 30);
            this.txtHO.MenuManager = this.barManager1;
            this.txtHO.Name = "txtHO";
            this.txtHO.Size = new System.Drawing.Size(100, 20);
            this.txtHO.TabIndex = 3;
            // 
            // txtMANV
            // 
            this.txtMANV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNV, "MANV", true));
            this.txtMANV.Location = new System.Drawing.Point(126, 30);
            this.txtMANV.MenuManager = this.barManager1;
            this.txtMANV.Name = "txtMANV";
            this.txtMANV.Size = new System.Drawing.Size(100, 20);
            this.txtMANV.TabIndex = 1;
            // 
            // bdsDH
            // 
            this.bdsDH.DataMember = "FK_DatHang_NhanVien";
            this.bdsDH.DataSource = this.bdsNV;
            // 
            // datHangTableAdapter
            // 
            this.datHangTableAdapter.ClearBeforeFill = true;
            // 
            // bdsPN
            // 
            this.bdsPN.DataMember = "FK_PhieuNhap_NhanVien";
            this.bdsPN.DataSource = this.bdsNV;
            // 
            // phieuNhapTableAdapter
            // 
            this.phieuNhapTableAdapter.ClearBeforeFill = true;
            // 
            // bdsPX
            // 
            this.bdsPX.DataMember = "FK_PX_NhanVien";
            this.bdsPX.DataSource = this.bdsNV;
            // 
            // phieuXuatTableAdapter
            // 
            this.phieuXuatTableAdapter.ClearBeforeFill = true;
            // 
            // FormNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 756);
            this.Controls.Add(this.panelNHAPLIEU);
            this.Controls.Add(this.gcNhanVien);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormNhanVien";
            this.Text = "FormNhanVien";
            this.Load += new System.EventHandler(this.FormNhanVien1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelNHAPLIEU)).EndInit();
            this.panelNHAPLIEU.ResumeLayout(false);
            this.panelNHAPLIEU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMACN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLUONG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYSINH.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYSINH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIACHI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMANV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPX)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnChuyenCN;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource bdsNV;
        private DS DS;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox chinhanhCB;
        private DSTableAdapters.NhanVienTableAdapter NhanVienTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colHO;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYSINH;
        private DevExpress.XtraGrid.Columns.GridColumn colLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn colMACN;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThaiXoa;
        private DevExpress.XtraEditors.PanelControl panelNHAPLIEU;
        private DevExpress.XtraEditors.SpinEdit txtLUONG;
        private DevExpress.XtraEditors.DateEdit dteNGAYSINH;
        private DevExpress.XtraEditors.TextEdit txtDIACHI;
        private DevExpress.XtraEditors.TextEdit txtTEN;
        private DevExpress.XtraEditors.TextEdit txtHO;
        private DevExpress.XtraEditors.TextEdit txtMANV;
        private System.Windows.Forms.CheckBox trangThaiXoaCB;
        private DevExpress.XtraEditors.TextEdit txtMACN;
        private System.Windows.Forms.BindingSource bdsDH;
        private DSTableAdapters.DatHangTableAdapter datHangTableAdapter;
        private System.Windows.Forms.BindingSource bdsPN;
        private DSTableAdapters.PhieuNhapTableAdapter phieuNhapTableAdapter;
        private System.Windows.Forms.BindingSource bdsPX;
        private DSTableAdapters.PhieuXuatTableAdapter phieuXuatTableAdapter;
    }
}