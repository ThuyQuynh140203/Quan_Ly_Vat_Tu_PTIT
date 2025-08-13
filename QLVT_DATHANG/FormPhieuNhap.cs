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
    public partial class FormPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        public FormPhieuNhap()
        {
            InitializeComponent();
        }

        /* vị trí của con trỏ trên grid view*/
        int viTri = 0;
        /********************************************
        * đang thêm mới -> true -> đang dùng btnTHEM
        *              -> false -> có thể là btnGHI( chỉnh sửa) hoặc btnXOA
        *              
        * Mục đích: dùng biến này để phân biệt giữa btnTHEM - thêm mới hoàn toàn
        * và việc chỉnh sửa nhân viên( do mình ko dùng thêm btnXOA )
        * Trạng thái true or false sẽ được sử dụng 
        * trong btnGHI - việc này để phục vụ cho btnHOANTAC
        ********************************************/
        bool dangThemMoi = false;
        public string makho = "";
        string maChiNhanh = "";
        /**********************************************************
      * undoList - phục vụ cho btnHOANTAC -  chứa các thông tin của đối tượng bị tác động 
      * 
      * nó là nơi lưu trữ các đối tượng cần thiết để hoàn tác các thao tác
      * 
      * nếu btnGHI sẽ ứng với INSERT
      * nếu btnXOA sẽ ứng với DELETE
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


        private void FormPhieuNhap_Load(object sender, EventArgs e)
        {
            /*Step 1*/
            /*không kiểm tra khóa ngoại nữa*/
            DS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'DS.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS.CTPN);
            // TODO: This line of code loads data into the 'dS.PhieuNhap' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

            /*Step 2*/
            chinhanhCB.DataSource = Program.bindingSource;/*sao chep bingding source tu form dang nhap*/
            chinhanhCB.DisplayMember = "TENCN";
            chinhanhCB.ValueMember = "TENSERVER";
            chinhanhCB.SelectedIndex = Program.brand;
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
                this.cTPNTableAdapter.Fill(this.DS.CTPN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi làm mời dữ liệu\n\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();
        }

        private void btnPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 0*/
            btnMENU.Links[0].Caption = "Phiếu nhập";

            /*Step 1*/
            bds = bdsPN;
            gc = gcPN;

            /*Step 2*/
            /*Bat chuc nang cua phieu nhap*/
            txtMAPN.Enabled = false;
            dateNGAY.Enabled = false;

            txtMADDH.Enabled = false;
            btnChonDH.Enabled = false;

            txtMANV.Enabled = false;
            txtMAKHO.Enabled = false;
            /*Tat chuc nang cua chi tiet phieu nhap*/
            btnChonCTDDH.Enabled = false;
            txtMAVT.Enabled = false;
            txtSOLUONG.Enabled = false;
            txtDONGIA.Enabled = false;

            /*Bat cac grid control len*/
            gcPN.Enabled = true;
            gcCTPN.Enabled = true;

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

                this.groupBoxPN.Enabled = false;
            }
            /* CHI NHANH & USER co the xem - xoa - sua du lieu nhung khong the 
            chuyen sang chi nhanh khac*/
            if (Program.role == "CHINHANH" || Program.role == "USER")
            {
                chinhanhCB.Enabled = false;

                this.btnThem.Enabled = true;
                bool turnOn = (bdsPN.Count > 0) ? true : false;
                this.btnXoa.Enabled = turnOn;
                this.btnGhi.Enabled = true;

                this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnThoat.Enabled = true;
            }
        }

        private void btnCTPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 0*/
            btnMENU.Links[0].Caption = "Chi tiết phiếu nhập";

            /*Step 1*/
            bds = bdsCTPN;
            gc = gcCTPN;

            /*Step 2*/
            /*Tat chuc nang cua chi tiet phieu nhap*/
            txtMAPN.Enabled = false;
            dateNGAY.Enabled = false;

            txtMADDH.Enabled = false;
            btnChonDH.Enabled = false;

            txtMANV.Enabled = false;
            txtMAKHO.Enabled = false;

            /*Bat chuc nang cua chi tiet don hang*/
            txtMAVT.Enabled = false;
            txtSOLUONG.Enabled = false;
            txtDONGIA.Enabled = false;

            btnChonCTDDH.Enabled = false;

            /*Bat cac grid control len*/
            gcPN.Enabled = true;
            gcCTPN.Enabled = true;

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
            }

            /* CHI NHANH & USER co the xem - xoa - sua du lieu nhung khong the 
            chuyen sang chi nhanh khac*/
            if (Program.role == "CHINHANH" || Program.role == "USER")
            {
                chinhanhCB.Enabled = false;

                this.btnThem.Enabled = true;
                bool turnOn = (bdsCTPN.Count > 0) ? true : false;
                this.btnXoa.Enabled = turnOn;
                this.btnGhi.Enabled = true;

                this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnThoat.Enabled = true;
            }
        }

        private void btnChonDH_Click(object sender, EventArgs e)
        {
            FormChonDonDatHang form = new FormChonDonDatHang();
            form.ShowDialog();

            this.txtMADDH.Text = Program.maDonDatHangDuocChon;
            this.txtMAKHO.Text = Program.maKhoDuocChon;
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
                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.DS.CTPN);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
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
            if (btnMENU.Links[0].Caption == "Phiếu nhập")
            {
                this.txtMAPN.Enabled = true;

                this.dateNGAY.EditValue = DateTime.Now;
                this.dateNGAY.Enabled = false;

                this.txtMADDH.Enabled = false;
                this.btnChonDH.Enabled = true;

                this.txtMANV.Text = Program.userName;
                this.txtMAKHO.Text = Program.maKhoDuocChon;


                /*Gan tu dong may truong du lieu nay*/
                ((DataRowView)(bdsPN.Current))["NGAY"] = DateTime.Now;
                ((DataRowView)(bdsPN.Current))["MasoDDH"] = Program.maDonDatHangDuocChon;
                ((DataRowView)(bdsPN.Current))["MANV"] = Program.userName;
                ((DataRowView)(bdsPN.Current))["MAKHO"] = Program.maKhoDuocChon;

            }
            if (btnMENU.Links[0].Caption == "Chi tiết phiếu nhập")
            {
                DataRowView drv = ((DataRowView)bdsPN[bdsPN.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.userName != maNhanVien)
                {
                    MessageBox.Show("Bạn không thêm Chi tiết phiếu nhập trên phiếu không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    bdsCTPN.RemoveCurrent();
                    return;
                }

               /*Gan tu dong may truong du lieu nay*/
               ((DataRowView)(bdsCTPN.Current))["MAPN"] = ((DataRowView)(bdsPN.Current))["MAPN"];
                ((DataRowView)(bdsCTPN.Current))["MAVT"] =
                    Program.maVatTuDuocChon;
                ((DataRowView)(bdsCTPN.Current))["SOLUONG"] =
                    Program.soLuongVatTu;
                ((DataRowView)(bdsCTPN.Current))["DONGIA"] =
                    Program.donGia;

                this.txtMAVT.Enabled = false;
                this.btnChonCTDDH.Enabled = true;

                this.txtSOLUONG.Enabled = true;
                this.txtSOLUONG.EditValue = 1;

                this.txtDONGIA.Enabled = true;
                this.txtDONGIA.EditValue = 1;

                this.txtSOLUONG.Enabled = true;
                this.txtDONGIA.Enabled = true;
            }
            /*Step 3*/
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnGhi.Enabled = true;

            this.btnPhucHoi.Enabled = true;
            this.btnLamMoi.Enabled = false;
            this.btnMENU.Enabled = false;
            this.btnThoat.Enabled = false;

            gcPN.Enabled = false;
            gcCTPN.Enabled = false;
        }

        private void btnChonCTDDH_Click(object sender, EventArgs e)
        {
            Program.maDonDatHangDuocChon = ((DataRowView)(bdsPN.Current))["MasoDDH"].ToString().Trim();
            Program.maPhieuNhapDuocChon = ((DataRowView)(bdsPN.Current))["MAPN"].ToString().Trim();
            FormChonChiTietDonHang form = new FormChonChiTietDonHang();
            form.ShowDialog();
            this.txtMAVT.Text = Program.maVatTuDuocChon;
            this.txtSOLUONG.Value = Program.soLuongVatTu;
            this.txtDONGIA.Value = Program.donGia;
        }

        /*
         * ta sử dụng maDonDatHangDuocChonChiTiet là vì nếu như ta thêm
         * Phiếu nhập cho đơn đặt hàng 1 nhưng Chi tiết phiếu nhập ta lại lập
         * bằng chi tiết đơn đặt hàng 2 thì sẽ dẫn tới mâu thuẫn.
         * 
         * đúng thì phải là lập phiếu bằng mã đơn đặt hàng 1 thì chi tiết 
         * Phiếu nhập cũng phải chọn chi tiết đơn đặt hàng 1 mới hợp lý
         * 
         * trong formLapPhieu có maDonHangDuocChon là mã đơn hàng của phiếu
         * nhập còn maDonDatHangDuocChonChiTiet là mã đơn hàng khi chọn chi 
         * tiết đơn hàng.
         * 
         * 2 mã này phải giống nhau thì mới cho phép ghi
         */
        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /* Step 0 */
            if (dangThemMoi == true && this.btnThem.Enabled == false)
            {
                dangThemMoi = false;

                /*dang o che do Phiếu nhập*/
                if (btnMENU.Links[0].Caption == "Phiếu nhập")
                {
                    this.txtMADDH.Enabled = false;
                    dateNGAY.Enabled = false;

                    txtMADDH.Enabled = false;
                    txtMAKHO.Enabled = false;

                    btnChonDH.Enabled = false;
                    txtMADDH.Enabled = false;
                }
                /*dang o che do Chi tiết phiếu nhập*/
                if (btnMENU.Links[0].Caption == "Chi tiết phiếu nhập")
                {
                    this.txtMADDH.Enabled = false;
                    this.btnChonCTDDH.Enabled = false;

                    this.txtMAVT.Enabled = false;
                    this.txtSOLUONG.Enabled = false;
                    this.txtDONGIA.Enabled = false;

                    this.btnXoa.Enabled = false;
                }

                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnGhi.Enabled = true;

                //this.btnHOANTAC.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnThoat.Enabled = true;

                this.gcPN.Enabled = true;
                this.gcCTPN.Enabled = true;

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

            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
            this.cTPNTableAdapter.Fill(this.DS.CTPN);

            bdsPN.Position = viTri;
        }
        private void capNhatSoLuongVatTu(string maVatTu, int soLuong)
        {
            string cauTruyVan = "EXEC sp_CapNhatSoLuongVatTu 'IMPORT','" + maVatTu + "', " + soLuong;


            int n = Program.ExecSqlNonQuery(cauTruyVan);
            Console.WriteLine(cauTruyVan);
        }

        private String taoCauTruyVanHoanTac(String cheDo)
        {
            String cauTruyVan = "";
            DataRowView drv;

            /*TH: dang sua phieu nhap - nhung ko co truong du lieu nao co the cho sua duoc ca*/
            if (cheDo == "Phiếu nhập" && dangThemMoi == false)
            {
                // khong co gi ca
            }



            /*TH4: dang sua chi tiet phieu nhap*/
            if (cheDo == "Chi tiết phiếu nhập" && dangThemMoi == false)
            {
                drv = ((DataRowView)(bdsCTPN.Current));
                int soLuong = int.Parse(drv["SOLUONG"].ToString().Trim());
                float donGia = float.Parse(drv["DONGIA"].ToString().Trim());
                String maPhieuNhap = drv["MAPN"].ToString().Trim();
                String maVatTu = drv["MAVT"].ToString().Trim();

                cauTruyVan = "UPDATE DBO.CTPN " +
                    "SET " +
                    "SOLUONG = " + soLuong + ", " +
                    "DONGIA = " + donGia + " " +
                    "WHERE MAPN = '" + maPhieuNhap + "' " +
                    "AND MAVT = '" + maVatTu + "' ";
            }

            return cauTruyVan;
        }

        private bool kiemTraDuLieuDauVao(String cheDo)
        {
            if (cheDo == "Phiếu nhập")
            {
                if (txtMAPN.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã Phiếu nhập !", "Thông báo", MessageBoxButtons.OK);
                    txtMAPN.Focus();
                    return false;
                }


                if (txtMANV.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã nhân viên !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }

                if (txtMAKHO.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã kho !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }

                if (txtMADDH.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã đơn đặt hàng !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
            }

            if (cheDo == "Chi tiết phiếu nhập")
            {
                /*Do chung khoa chinh cua no la MAPN + MAVT*/
                /* tạo 2 Phiếu nhập cùng mã đơn hàng thì bị lỗi do maDonHang trong phiếu 
                 * nhập chỉ được xuất hiện 1 lần duy nhất
                 */
                /*
                if (bdsChiTietPhieuNhap.Count > 1)
                {
                    MessageBox.Show("Không thể thêm Chi tiết phiếu nhập quá 1 lần", "Thông báo", MessageBoxButtons.OK);
                    bdsChiTietPhieuNhap.RemoveCurrent();
                    return false;
                }*/

                if (txtMAVT.Text == "")
                {
                    MessageBox.Show("Không bỏ trống mã vật tư !", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                /*Program.soLuongVatTu trong formChonChiTietDonHang*/
                if (txtSOLUONG.Value < 0 ||
                    txtSOLUONG.Value > Program.soLuongVatTu)
                {
                    MessageBox.Show("Số lượng vật tư không thể lớn hơn số lượng vật tư trong chi tiết đơn hàng !", "Thông báo", MessageBoxButtons.OK);
                    txtSOLUONG.Focus();
                    return false;
                }

                if (txtDONGIA.Value < 1)
                {
                    MessageBox.Show("Đơn giá không thể nhỏ hơn 1 VND", "Thông báo", MessageBoxButtons.OK);
                    txtDONGIA.Focus();
                    return false;
                }
            }

            return true;
        }

        /*
      *Step 1: xac dinh xem minh dang GHI o che do nao
      *Step 2: kiem tra du lieu dau vao
      *Step 3: tao cau truy van hoan tac
      *Step 4: dung stored procedure kiem tra xem phieu nhap da ton tai chua ?
      *Step 5: xu ly du lieu neu co
      */
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 1*/
            String cheDo = (btnMENU.Links[0].Caption == "Phiếu nhập") ? "Phiếu nhập" : "Chi tiết phiếu nhập";

            /*Step 2*/
            bool ketQua = kiemTraDuLieuDauVao(cheDo);
            if (ketQua == false) return;

            /*Step 3*/
            string cauTruyVanHoanTac = taoCauTruyVanHoanTac(cheDo);

            /*Step 4*/
            String maPhieuNhap = txtMAPN.Text.Trim();
            //Console.WriteLine(maPhieuNhap);
            String cauTruyVan =
                    "DECLARE	@result int " +
                    "EXEC @result = sp_KiemTraMaPhieuNhap '" +
                    maPhieuNhap + "' " +
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
            int viTriConTro = bdsPN.Position;
            int viTriMaPhieuNhap = bdsPN.Find("MAPN", maPhieuNhap);

            /*Dang them moi phieu nhap*/
            if (result == 1 && cheDo == "Phiếu nhập" && viTriMaPhieuNhap != viTriConTro)
            {
                MessageBox.Show("Mã Phiếu nhập đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                txtMAPN.Focus();
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
                        //Console.WriteLine(txtMaNhanVien.Text);
                        /*TH1: them moi phieu nhap*/
                        if (cheDo == "Phiếu nhập" && dangThemMoi == true)
                        {
                            cauTruyVanHoanTac =
                                "DELETE FROM DBO.PHIEUNHAP " +
                                "WHERE MAPN = '" + maPhieuNhap + "'";
                        }

                        /*TH2: them moi chi tiet don hang*/
                        if (cheDo == "Chi tiết phiếu nhập" && dangThemMoi == true)
                        {
                            cauTruyVanHoanTac =
                                "DELETE FROM DBO.CTPN " +
                                "WHERE MAPN = '" + maPhieuNhap + "' " +
                                "AND MAVT = '" + Program.maVatTuDuocChon + "'";

                            string maVatTu = txtMAVT.Text.Trim();
                            int soLuong = (int)txtSOLUONG.Value;

                            capNhatSoLuongVatTu(maVatTu, soLuong);
                        }

                        /*TH3: chinh sua phieu nhap -> chang co gi co the chinh sua
                         * duoc -> chang can xu ly*/
                        /*TH4: chinh sua chi tiet phieu nhap - > thi chi can may dong lenh duoi la xong*/
                        undoList.Push(cauTruyVanHoanTac);
                        Console.WriteLine("cau truy van hoan tac");
                        Console.WriteLine(cauTruyVanHoanTac);

                        this.bdsPN.EndEdit();
                        this.bdsCTPN.EndEdit();
                        this.phieuNhapTableAdapter.Update(this.DS.PhieuNhap);
                        this.cTPNTableAdapter.Update(this.DS.CTPN);

                        this.btnThem.Enabled = true;
                        this.btnXoa.Enabled = true;
                        this.btnGhi.Enabled = true;

                        this.btnPhucHoi.Enabled = true;
                        this.btnLamMoi.Enabled = true;
                        this.btnMENU.Enabled = true;
                        this.btnThoat.Enabled = true;

                        this.gcPN.Enabled = true;
                        this.gcCTPN.Enabled = true;

                        this.txtSOLUONG.Enabled = false;
                        this.txtDONGIA.Enabled = false;
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

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRowView drv;
            string cauTruyVanHoanTac = "";
            string cheDo = (btnMENU.Links[0].Caption == "Phiếu nhập") ? "Phiếu nhập" : "Chi tiết phiếu nhập";

            if (cheDo == "Phiếu nhập")
            {
                drv = ((DataRowView)bdsPN[bdsPN.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.userName != maNhanVien)
                {
                    MessageBox.Show("Không xóa Chi tiết phiếu nhập không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                if (bdsCTPN.Count > 0)
                {
                    MessageBox.Show("Không thể xóa Phiếu nhập vì có Chi tiết phiếu nhập", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                drv = ((DataRowView)bdsPN[bdsPN.Position]);
                DateTime ngay = ((DateTime)drv["NGAY"]);

                cauTruyVanHoanTac = "INSERT INTO DBO.PHIEUNHAP(MAPN, NGAY, MasoDDH, MANV, MAKHO) " +
                    "VALUES( '" + drv["MAPN"].ToString().Trim() + "', '" +
                    ngay.ToString("yyyy-MM-dd") + "', '" +
                    drv["MasoDDH"].ToString() + "', '" +
                    drv["MANV"].ToString() + "', '" +
                    drv["MAKHO"].ToString() + "')";

            }

            if (cheDo == "Chi tiết phiếu nhập")
            {
                drv = ((DataRowView)bdsPN[bdsPN.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.userName != maNhanVien)
                {
                    MessageBox.Show("Bạn không xóa Chi tiết phiếu nhập không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    return;
                }


                drv = ((DataRowView)bdsCTPN[bdsCTPN.Position]);
                cauTruyVanHoanTac = "INSERT INTO DBO.CTPN(MAPN, MAVT, SOLUONG, DONGIA) " +
                    "VALUES('" + drv["MAPN"].ToString().Trim() + "', '" +
                    drv["MAVT"].ToString().Trim() + "', " +
                    drv["SOLUONG"].ToString().Trim() + ", " +
                    drv["DONGIA"].ToString().Trim() + ")";
            }

            undoList.Push(cauTruyVanHoanTac);
            //Console.WriteLine("Line 842");
            //Console.WriteLine(cauTruyVanHoanTac);

            /*Step 2*/
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    /*Step 3*/
                    viTri = bds.Position;
                    if (cheDo == "Phiếu nhập")
                    {
                        bdsPN.RemoveCurrent();
                    }
                    if (cheDo == "Chi tiết phiếu nhập")
                    {
                        bdsCTPN.RemoveCurrent();
                    }


                    this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuNhapTableAdapter.Update(this.DS.PhieuNhap);

                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Update(this.DS.CTPN);

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
                    this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuNhapTableAdapter.Update(this.DS.PhieuNhap);

                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Update(this.DS.CTPN);
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