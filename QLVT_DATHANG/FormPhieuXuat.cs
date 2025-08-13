using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class FormPhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        /* vị trí của con trỏ trên grid view*/
        int viTri = 0;
        /********************************************
         * đang thêm mới -> true -> đang dùng btnThem
         *              -> false -> có thể là btnGhi( chỉnh sửa) hoặc btnXoa
         *              
         * Mục đích: dùng biến này để phân biệt giữa btnThem - thêm mới hoàn toàn
         * và việc chỉnh sửa nhân viên( do mình ko dùng thêm btnXoa )
         * Trạng thái true or false sẽ được sử dụng 
         * trong btnGhi - việc này để phục vụ cho btnPhucHoi
         ********************************************/
        bool dangThemMoi = false;
        public string makho = "";
        string maChiNhanh = "";
        /**********************************************************
         * undoList - phục vụ cho btnPhucHoi -  chứa các thông tin của đối tượng bị tác động 
         * 
         * nó là nơi lưu trữ các đối tượng cần thiết để hoàn tác các thao tác
         * 
         * nếu btnGhi sẽ ứng với INSERT
         * nếu btnXoa sẽ ứng với DELETE
         * nếu btnCHUYENCHINHANH sẽ ứng với CHANGEBRAND
         **********************************************************/
        Stack undoList = new Stack();



        /********************************************************
         * chứa những dữ liệu hiện tại đang làm việc
         * gc chứa grid view đang làm việc
         ********************************************************/
        BindingSource bds = null;
        GridControl gc = null;
        string type = "";
        public FormPhieuXuat()
        {
            InitializeComponent();
        }

        private void phieuXuatBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPX.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FormPhieuXuat_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLVT_DATHANGDS2.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);
            // TODO: This line of code loads data into the 'qLVT_DATHANGDS2.PhieuXuat' table. You can move, or remove it, as needed.
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

            /*Step 2*/
            chinhanhCB.DataSource = Program.bindingSource;/*sao chep bingding source tu form dang nhap*/
            chinhanhCB.DisplayMember = "TENCN";
            chinhanhCB.ValueMember = "TENSERVER";
            chinhanhCB.SelectedIndex = Program.brand;
        }

        private void phieuXuatBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPX.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        { 
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void btnPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 0*/
            btnMENU.Links[0].Caption = "Phiếu xuất";

            /*Step 1*/
            bds = bdsPX;
            gc = gcCTPX;


            /*Step 2*/
            /*Bat chuc nang cua phieu xuat*/
            txtMAPX.Enabled = false;
            dateNGAY.Enabled = false;

            txtHOTENKH.Enabled = true;
            txtMANV.Enabled = false;

            btnChonKho.Enabled = true;
            txtMAKHO.Enabled = false;


            /*Tat chuc nang cua chi tiet phieu nhap*/
            txtMAVT.Enabled = false;
            btnChonVT.Enabled = false;
            txtSOLUONG.Enabled = false;
            txtDONGIA.Enabled = false;

            /*Bat cac grid control len*/
            gcPX.Enabled = true;
            gcCTPX.Enabled = true;


            /*Step 3*/
            /*CONG TY chi xem du lieu*/
            if (Program.role == "CONGTY")
            {
                chinhanhCB.Enabled = true;

                this.btnThem.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnGhi.Enabled = false;

                this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnThoat.Enabled = true;

                this.groupBoxPX.Enabled = false;


            }

            /* CHI NHANH & USER co the xem - xoa - sua du lieu nhung khong the 
             chuyen sang chi nhanh khac*/
            if (Program.role == "CHINHANH" || Program.role == "USER")
            {
                chinhanhCB.Enabled = false;

                this.btnThem.Enabled = true;
                bool turnOn = (bdsPX.Count > 0) ? true : false;
                this.btnXoa.Enabled = turnOn;
                this.btnGhi.Enabled = true;

                this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnThoat.Enabled = true;

                //this.txtMaDonDatHang.Enabled = false;

            }
        }

        private void btnCTPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 0*/
            btnMENU.Links[0].Caption = "Chi tiết phiếu xuất";

            /*Step 1*/
            bds = bdsCTPX;
            //gc = gcCTPX;


            /*Step 2*/
            /*Tat het chuc nang cua phieu xuat*/
            txtMAPX.Enabled = false;
            dateNGAY.Enabled = false;

            txtHOTENKH.Enabled = false;
            txtMANV.Enabled = false;

            btnChonKho.Enabled = false;
            txtMAKHO.Enabled = false;


            /*Bat chuc nang cua chi tiet phieu nhap*/
            txtMAVT.Enabled = false;
            txtSOLUONG.Enabled = false;
            txtDONGIA.Enabled = false;

            /*Bat cac grid control len*/
            gcPX.Enabled = true;
            gcCTPX.Enabled = true;


            /*Step 3*/
            /*CONG TY chi xem du lieu*/
            if (Program.role == "CONGTY")
            {
                chinhanhCB.Enabled = true;

                this.btnThem.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnGhi.Enabled = false;

                this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnThoat.Enabled = true;

                this.groupBoxPX.Enabled = false;


            }

            /* CHI NHANH & USER co the xem - xoa - sua du lieu nhung khong the 
             chuyen sang chi nhanh khac*/
            if (Program.role == "CHINHANH" || Program.role == "USER")
            {
                chinhanhCB.Enabled = false;

                this.btnThem.Enabled = true;
                bool turnOn = (bdsPX.Count > 0) ? true : false;
                this.btnXoa.Enabled = false;
                this.btnGhi.Enabled = true;

                this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnThoat.Enabled = true;

                //this.txtMaDonDatHang.Enabled = false;
            }
        }

        private void chinhanhCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            /*Neu combobox khong co so lieu thi ket thuc luon*/
            if (chinhanhCB.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            Program.serverName = chinhanhCB.SelectedValue.ToString();

            /*Neu chon sang chi nhanh khac voi chi nhanh hien tai*/
            if (chinhanhCB.SelectedIndex != Program.brand)
            {
                Program.loginName = Program.remoteLogin;
                Program.loginPassword = Program.remotePassword;
            }
            /*Neu chon trung voi chi nhanh dang dang nhap o formDangNhap*/
            else
            {
                Program.loginName = Program.currentLogin;
                Program.loginPassword = Program.currentPassword;
            }

            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Xảy ra lỗi kết nối với chi nhánh hiện tại", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.DS.CTPX);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 1*/
            /*lấy vị trí hiện tại của con trỏ*/
            viTri = bds.Position;
            dangThemMoi = true;

            /*Step 2*/
            /*AddNew tự động nhảy xuống cuối thêm 1 dòng mới*/
            bds.AddNew();
            if (btnMENU.Links[0].Caption == "Phiếu xuất")
            {
                this.txtMAPX.Enabled = true;

                this.dateNGAY.EditValue = DateTime.Now;
                this.dateNGAY.Enabled = false;

                this.txtHOTENKH.Enabled = true;
                this.txtMANV.Text = Program.userName;

                this.btnChonKho.Enabled = true;
                this.txtMAKHO.Text = Program.maKhoDuocChon;

                this.txtMAVT.Enabled = false;
                this.btnChonVT.Enabled = false;
                this.txtSOLUONG.Enabled = false;
                this.txtDONGIA.Enabled = false;

                /*Gan tu dong may truong du lieu nay*/
                ((DataRowView)(bdsPX.Current))["NGAY"] = DateTime.Now;
                ((DataRowView)(bdsPX.Current))["MANV"] = Program.userName;
                ((DataRowView)(bdsPX.Current))["MAKHO"] =
                Program.maKhoDuocChon;

            }

            if (btnMENU.Links[0].Caption == "Chi tiết phiếu xuất")
            {

                DataRowView drv = ((DataRowView)bdsPX[bdsPX.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.userName != maNhanVien)
                {
                    MessageBox.Show("Không thể thêm Chi tiết phiếu xuất trên phiếu  không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

               /*Gan tu dong may truong du lieu nay*/
               ((DataRowView)(bdsCTPX.Current))["MAPX"] = ((DataRowView)(bdsPX.Current))["MAPX"];
                ((DataRowView)(bdsCTPX.Current))["MAVT"] =
                    Program.maVatTuDuocChon;




                this.txtMAVT.Enabled = false;
                this.btnChonVT.Enabled = true;

                this.txtSOLUONG.Enabled = true;
                this.txtSOLUONG.EditValue = 1;

                this.txtDONGIA.Enabled = true;
                this.txtDONGIA.EditValue = 1;
            }



            /*Step 3*/
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnGhi.Enabled = true;

            this.btnPhucHoi.Enabled = true;
            this.btnLamMoi.Enabled = false;
            this.btnMENU.Enabled = false;
            this.btnThoat.Enabled = false;

            gcPX.Enabled = false;
            gcCTPX.Enabled = false;
        }

        private void btnChonKho_Click(object sender, EventArgs e)
        {
            FormChonKhoHang form = new FormChonKhoHang();
            form.ShowDialog();

            this.txtMAKHO.Text = Program.maKhoDuocChon;
        }

        private void btnChonVT_Click(object sender, EventArgs e)
        {
            FormChonVatTu form = new FormChonVatTu();
            form.ShowDialog();
            this.txtMAVT.Text = Program.maVatTuDuocChon;
        }

        private bool kiemTraDuLieuDauVao(string cheDo)
        {
            if (cheDo == "Phiếu xuất")
            {
                DataRowView drv = ((DataRowView)bdsPX[bdsPX.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.userName != maNhanVien)
                {
                    MessageBox.Show("Không thể sửa Phiếu xuất do người khác tạo", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }

                if (txtMAPX.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã phiếu nhập !", "Thông báo", MessageBoxButtons.OK);
                    txtMAPX.Focus();
                    return false;
                }

                if (txtMAPX.Text.Length > 8)
                {
                    MessageBox.Show("Mã Phiếu xuất không thể quá 8 kí tự !", "Thông báo", MessageBoxButtons.OK);
                    txtMAPX.Focus();
                    return false;
                }

                if (txtHOTENKH.Text == "")
                {
                    MessageBox.Show("Không bỏ trống tên khách hàng !", "Thông báo", MessageBoxButtons.OK);
                    txtHOTENKH.Focus();
                    return false;
                }

                if (txtHOTENKH.Text.Length > 100)
                {
                    MessageBox.Show("Tên khách hàng không quá 100 kí tự !", "Thông báo", MessageBoxButtons.OK);
                    txtHOTENKH.Focus();
                    return false;
                }

                if (txtMAKHO.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã kho !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }

            }

            if (cheDo == "Chi tiết phiếu xuất")
            {
                DataRowView drv = ((DataRowView)bdsPX[bdsPX.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.userName != maNhanVien)
                {
                    MessageBox.Show("Không thể thêm Chi tiết phiếu xuất với Phiếu xuất do người khác tạo !", "Thông báo", MessageBoxButtons.OK);
                    bdsCTPX.RemoveCurrent();
                    return false;
                }

                if (txtMAPX.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã phiếu nhập !", "Thông báo", MessageBoxButtons.OK);
                    txtMAPX.Focus();
                    return false;
                }

                if (txtMAPX.Text.Length > 8)
                {
                    MessageBox.Show("Mã Phiếu xuất không thể quá 8 kí tự !", "Thông báo", MessageBoxButtons.OK);
                    txtMAPX.Focus();
                    return false;
                }

                if (txtMAVT.Text == "")
                {
                    MessageBox.Show("Thiếu mã vật tư !", "Thông báo", MessageBoxButtons.OK);
                    txtMAVT.Focus();
                    return false;
                }

                if (txtMAVT.Text.Length > 4)
                {
                    MessageBox.Show("Mã vật tư không quá 4 kí tự !", "Thông báo", MessageBoxButtons.OK);
                    txtMAVT.Focus();
                    return false;
                }

                if (txtSOLUONG.Value < 0 || txtSOLUONG.Value > Program.soLuongVatTu)
                {
                    MessageBox.Show("Số lượng vật tư không thể bé hơn 0 & lớn hơn số lượng vật tư đang có trong kho hàng !", "Thông báo", MessageBoxButtons.OK);
                    txtSOLUONG.Focus();
                    return false;
                }

                if (txtDONGIA.Value < 0)
                {
                    MessageBox.Show("Đơn giá không thể bé hơn 0 VND !", "Thông báo", MessageBoxButtons.OK);
                    txtDONGIA.Focus();
                    return false;
                }
            }

            return true;
        }

        private string taoCauTruyVanHoanTac(string cheDo)
        {
            String cauTruyVan = "";
            DataRowView drv;

            /*TH1: dang sua phieu xuat*/
            if (cheDo == "Phiếu xuất" && dangThemMoi == false)
            {
                drv = ((DataRowView)(bdsPX.Current));
                DateTime ngay = (DateTime)drv["NGAY"];


                cauTruyVan = "UPDATE DBO.PHIEUXUAT " +
                    "SET " +
                    "NGAY = CAST('" + ngay.ToString("yyyy-MM-dd") + "' AS DATETIME), " +
                    "HOTENKH = '" + drv["HOTENKH"].ToString().Trim() + "', " +
                    "MANV = '" + drv["MANV"].ToString().Trim() + "', " +
                    "MAKHO = '" + drv["MAKHO"].ToString().Trim() + "' " +
                    "WHERE MAPX = '" + drv["MAPX"].ToString().Trim() + "' ";
            }

            /*TH2: them moi phieu xuat*/
            if (cheDo == "Phiếu xuất" && dangThemMoi == true)
            {
                // tao trong btnGhi thi hon
            }

            /*TH3: them moi chi tiet phieu xuat*/
            if (cheDo == "Chi tiết phiếu xuất" && dangThemMoi == true)
            {
                // tao trong btnGhi thi hon
            }

            /*TH4: dang sua chi tiet phieu nhap*/
            if (cheDo == "Chi tiết phiếu xuất" && dangThemMoi == false)
            {
                drv = ((DataRowView)(bdsCTPX.Current));
                int soLuong = int.Parse(drv["SOLUONG"].ToString().Trim());
                float donGia = float.Parse(drv["DONGIA"].ToString().Trim());
                String maPhieuXuat = drv["MAPN"].ToString().Trim();
                String maVatTu = drv["MAVT"].ToString().Trim();

                cauTruyVan = "UPDATE DBO.CTPX " +
                    "SET " +
                    "SOLUONG = " + soLuong + " " +
                    "DOGIA = " + donGia + " " +
                    "WHERE MAPX = '" + maPhieuXuat + "' " +
                    "AND MAVT = '" + maVatTu + "' ";
            }

            return cauTruyVan;
        }

        private void capNhatSoLuongVatTu(string maVatTu, string soLuong)
        {
            string cauTruyVan = "EXEC sp_CapNhatSoLuongVatTu 'EXPORT','" + maVatTu + "', " + soLuong;


            int n = Program.ExecSqlNonQuery(cauTruyVan);
            //Console.WriteLine("Line 536");
            //Console.WriteLine(cauTruyVan);
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 1*/
            String cheDo = (btnMENU.Links[0].Caption == "Phiếu xuất") ? "Phiếu xuất" : "Chi tiết phiếu xuất";

            /*Step 2*/
            bool ketQua = kiemTraDuLieuDauVao(cheDo);
            if (ketQua == false) return;



            /*Step 3*/
            string cauTruyVanHoanTac = taoCauTruyVanHoanTac(cheDo);
            //Console.WriteLine("CAU TRUY VAN HOAN TAC");
            //Console.WriteLine(cauTruyVanHoanTac);


            /*Step 4*/
            String maPhieuXuat = txtMAPX.Text.Trim();
            //Console.WriteLine(maPhieuNhap);
            String cauTruyVan =
                    "DECLARE	@result int " +
                    "EXEC @result = sp_KiemTraMaPhieuXuat '" +
                    maPhieuXuat + "' " +
                    "SELECT 'Value' = @result";
            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
            try
            {
                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                /*khong co ket qua tra ve thi ket thuc luon*/
                if (Program.myReader == null)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return;
            }
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            Program.myReader.Close();

            /*Step 5*/
            int viTriConTro = bdsPX.Position;
            int viTriMaPhieuXuat = bdsPX.Find("MAPX", maPhieuXuat);

            /*Dang them moi phieu nhap*/
            if (result == 1 && cheDo == "Phiếu xuất" && viTriMaPhieuXuat != viTriConTro)
            {
                MessageBox.Show("Mã Phiếu xuất đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                txtMAPX.Focus();
                return;
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "Thông báo",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        /*TH1: them moi phieu nhap*/
                        if (cheDo == "Phiếu xuất" && dangThemMoi == true)
                        {
                            cauTruyVanHoanTac =
                                "DELETE FROM DBO.PHIEUXUAT " +
                                "WHERE MAPX = '" + maPhieuXuat + "'";
                        }

                        /*TH2: them moi chi tiet don hang*/
                        if (cheDo == "Chi tiết phiếu xuất" && dangThemMoi == true)
                        {
                            cauTruyVanHoanTac =
                                "DELETE FROM DBO.CTPN " +
                                "WHERE MAPN = '" + maPhieuXuat + "' " +
                                "AND MAVT = '" + Program.maVatTuDuocChon + "'";

                            string maVatTu = txtMAVT.Text.Trim();
                            string soLuong = txtSOLUONG.Text.Trim();

                            capNhatSoLuongVatTu(maVatTu, soLuong);
                        }

                        /*TH3: chinh sua phieu nhap -> chang co gi co the chinh sua
                         * duoc -> chang can xu ly*/
                        /*TH4: chinh sua chi tiet phieu nhap - > thi chi can may dong lenh duoi la xong*/
                        undoList.Push(cauTruyVanHoanTac);
                        Console.WriteLine("cau truy van hoan tac");
                        Console.WriteLine(cauTruyVanHoanTac);

                        this.bdsPX.EndEdit();
                        this.bdsCTPX.EndEdit();
                        this.phieuXuatTableAdapter.Update(this.DS.PhieuXuat);
                        this.cTPXTableAdapter.Update(this.DS.CTPX);

                        this.txtMAPX.Enabled = false;

                        this.btnThem.Enabled = true;
                        this.btnXoa.Enabled = true;
                        this.btnGhi.Enabled = true;

                        this.btnPhucHoi.Enabled = true;
                        this.btnLamMoi.Enabled = true;
                        this.btnMENU.Enabled = true;
                        this.btnThoat.Enabled = true;

                        this.gcPX.Enabled = true;
                        this.gcCTPX.Enabled = true;
                        /*cập nhật lại trạng thái thêm mới cho chắc*/
                        dangThemMoi = false;
                        MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        bds.RemoveCurrent();
                        MessageBox.Show("Da xay ra loi !\n\n" + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /* Step 0 */
            if (dangThemMoi == true && this.btnThem.Enabled == false)
            {
                dangThemMoi = false;

                /*dang o che do Phiếu Nhập*/
                if (btnMENU.Links[0].Caption == "Phiếu xuất")
                {
                    this.txtMAPX.Enabled = false;
                    this.dateNGAY.Enabled = false;
                    this.txtHOTENKH.Enabled = true;

                    this.txtMANV.Enabled = false;

                    this.txtMAKHO.Enabled = false;
                    this.btnChonKho.Enabled = true;
                }
                /*dang o che do Chi Tiết Phiếu Nhập*/
                if (btnMENU.Links[0].Caption == "Chi Tiết Phiếu Nhập")
                {
                    this.txtMAPX.Enabled = false;
                    this.txtMAVT.Enabled = false;
                    this.btnChonVT.Enabled = false;

                    this.txtSOLUONG.Enabled = true;
                    this.txtDONGIA.Enabled = true;
                }

                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnGhi.Enabled = true;

                //this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnThoat.Enabled = true;

                this.gcPX.Enabled = true;
                this.gcCTPX.Enabled = true;

                bds.CancelEdit();
                /*xoa dong hien tai*/
                bds.RemoveCurrent();
                /* trở về lúc đầu con trỏ đang đứng*/
                bds.Position = viTri;
                return;
            }

            /*Step 1*/
            if (undoList.Count == 0)
            {
                MessageBox.Show("Không còn thao tác nào để khôi phục", "Thông báo", MessageBoxButtons.OK);
                btnPhucHoi.Enabled = false;
                return;
            }

            /*Step 2*/
            bds.CancelEdit();
            String cauTruyVanHoanTac = undoList.Pop().ToString();

            Console.WriteLine(cauTruyVanHoanTac);
            int n = Program.ExecSqlNonQuery(cauTruyVanHoanTac);

            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
            this.cTPXTableAdapter.Fill(this.DS.CTPX);

            bdsPX.Position = viTri;
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
                this.cTPXTableAdapter.Fill(this.DS.CTPX);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi lam moi \n\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRowView drv;
            string cauTruyVanHoanTac = "";
            string cheDo = (btnMENU.Links[0].Caption == "Phiếu xuất") ? "Phiếu xuất" : "Chi tiết phiếu xuất";

            if (cheDo == "Phiếu xuất")
            {
                drv = ((DataRowView)bdsPX[bdsPX.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.userName != maNhanVien)
                {
                    MessageBox.Show("Không xóa Chi tiết phiếu xuất không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                if (bdsCTPX.Count > 0)
                {
                    MessageBox.Show("Không thể xóa vì có Chi tiết phiếu xuất", "Thông báo", MessageBoxButtons.OK);
                    return;
                }


                DateTime ngay = ((DateTime)drv["NGAY"]);

                cauTruyVanHoanTac = "INSERT INTO DBO.PHIEUXUAT(MAPX, NGAY, HOTENKH, MANV, MAKHO) " +
                    "VALUES( '" + drv["MAPX"].ToString().Trim() + "', '" +
                    ngay.ToString("yyyy-MM-dd") + "', '" +
                    drv["HOTENKH"].ToString() + "', '" +
                    drv["MANV"].ToString() + "', '" +
                    drv["MAKHO"].ToString() + "')";
            }

            if (cheDo == "Chi tiết phiếu xuất")
            {
                drv = ((DataRowView)bdsPX[bdsPX.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.userName != maNhanVien)
                {
                    MessageBox.Show("Bạn không xóa Chi tiết phiếu xuất không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    return;
                }


                drv = ((DataRowView)bdsCTPX[bdsCTPX.Position]);
                cauTruyVanHoanTac = "INSERT INTO DBO.CTPX(MAPX, MAVT, SOLUONG, DONGIA) " +
                    "VALUES('" + drv["MAPX"].ToString().Trim() + "', '" +
                    drv["MAVT"].ToString().Trim() + "', " +
                    drv["SOLUONG"].ToString().Trim() + ", " +
                    drv["DONGIA"].ToString().Trim() + ")";
            }

            undoList.Push(cauTruyVanHoanTac);
            //Console.WriteLine("Line 825");
            //Console.WriteLine(cauTruyVanHoanTac);


            /*Step 2*/
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    /*Step 3*/
                    viTri = bds.Position;
                    if (cheDo == "Phiếu xuất")
                    {
                        bdsPX.RemoveCurrent();
                    }
                    if (cheDo == "Chi Tiết Phiếu Nhập")
                    {
                        bdsCTPX.RemoveCurrent();
                    }


                    this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuXuatTableAdapter.Update(this.DS.PhieuXuat);

                    this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPXTableAdapter.Update(this.DS.CTPX);

                    //bdsPhieuNhap.Position = viTri;
                    /*Cap nhat lai do ben tren can tao cau truy van nen da dat dangThemMoi = true*/
                    dangThemMoi = false;
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK);
                    this.btnPhucHoi.Enabled = true;
                }
                catch (Exception ex)
                {
                    /*Step 4*/
                    MessageBox.Show("Lỗi xóa nhân viên. Hãy thử lại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuXuatTableAdapter.Update(this.DS.PhieuXuat);

                    this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPXTableAdapter.Update(this.DS.CTPX);
                    // tro ve vi tri cua nhan vien dang bi loi
                    bds.Position = viTri;
                    //bdsNhanVien.Position = bdsNhanVien.Find("MANV", manv);
                    return;
                }
            }
            else
            {
                // xoa cau truy van hoan tac di
                undoList.Pop();
            }
        }
    }
}