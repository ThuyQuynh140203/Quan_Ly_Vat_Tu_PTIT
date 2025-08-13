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
    public partial class FormDonDatHang : DevExpress.XtraEditors.XtraForm
    {
        // Constructor for the FormDonDatHang class/* vị trí của con trỏ trên grid view*/
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



        /************************************************************
         * CheckExists:
         * Để tránh việc người dùng ấn vào 1 form đến 2 lần chúng ta 
         * cần sử dụng hàm này để kiểm tra xem cái form hiện tại đã 
         * có trong bộ nhớ chưa
         * Nếu có trả về "f"
         * Nếu không trả về "null"
         ************************************************************/

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        public FormDonDatHang()
        {
            InitializeComponent();
        }

        private void FormDonDatHang_Load(object sender, EventArgs e)
        {
            /*Step 1*/
            DS.EnforceConstraints = false;

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
            /*van con ton tai loi chua sua duoc*/
            //maChiNhanh = ((DataRowView)bdsVatTu[0])["MACN"].ToString();

            /*Step 2*/
            chinhanhCB.DataSource = Program.bindingSource;/*sao chep bingding source tu form dang nhap*/
            chinhanhCB.DisplayMember = "TENCN";
            chinhanhCB.ValueMember = "TENSERVER";
            chinhanhCB.SelectedIndex = Program.brand;


            bds = bdsDH;
            gc = gcDatHang;

        }


        private void btnDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 0*/
            btnMENU.Links[0].Caption = "Đơn đặt hàng";

            /*Step 1*/
            bds = bdsDH;
            gc = gcDatHang;

            /*Step 2*/
            /*Bat chuc nang cua don dat hang*/
            txtMADDH.Enabled = false;
            dteNGAY.Enabled = false;

            txtNCC.Enabled = true;
            txtMANV.Enabled = false;

            txtMAKHO.Enabled = false;
            btnChonMaKho.Enabled = true;


            /*Tat chuc nang cua chi tiet don hang*/
            txtMAVT.Enabled = false;
            btnChonVatTu.Enabled = false;
            txtSOLUONG.Enabled = false;
            txtDONGIA.Enabled = false;


            /*Bat cac grid control len*/
            gcDatHang.Enabled = true;
            gcCTDDH.Enabled = true;

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
                this.btnMENU.Enabled = false;
                this.btnThoat.Enabled = true;

                this.groupControlDDH.Enabled = false;

            }

            /* CHI NHANH & USER co the xem - xoa - sua du lieu nhung khong the 
             chuyen sang chi nhanh khac*/
            if (Program.role == "CHINHANH" || Program.role == "USER")
            {
                chinhanhCB.Enabled = false;

                this.btnThem.Enabled = true;
                bool turnOn = (bdsDH.Count > 0) ? true : false;
                this.btnXoa.Enabled = turnOn;
                this.btnGhi.Enabled = true;

                this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnThoat.Enabled = true;

                this.txtMADDH.Enabled = false;
            }
        }


        private void btnCTDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 0*/
            btnMENU.Links[0].Caption = "Chi tiết đơn đặt hàng";

            /*Step 1*/
            bds = bdsCTDDH;
            gc = gcCTDDH;
            //MessageBox.Show("Chế Độ Làm Việc Chi tiết đơn đặt hàng", "Thông báo", MessageBoxButtons.OK);

            /*Step 2*/
            /*Tat chuc nang don dat hang*/
            txtMADDH.Enabled = false;
            dteNGAY.Enabled = false;

            txtNCC.Enabled = false;
            txtMANV.Enabled = false;

            txtMAKHO.Enabled = false;
            btnChonMaKho.Enabled = false;

            /*Bat chuc nang cua chi tiet don hang*/
            txtMAVT.Enabled = false;
            btnChonVatTu.Enabled = false;
            txtSOLUONG.Enabled = true;
            txtDONGIA.Enabled = true;


            /*Bat cac grid control len*/
            gcDatHang.Enabled = true;
            gcCTDDH.Enabled = true;

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
                this.btnMENU.Enabled = false;
                this.btnThoat.Enabled = true;

                this.groupBoxDDH.Enabled = false;


            }

            /* CHI NHANH & USER co the xem - xoa - sua du lieu nhung khong the 
             chuyen sang chi nhanh khac*/
            if (Program.role == "CHINHANH" || Program.role == "USER")
            {
                chinhanhCB.Enabled = false;

                this.btnThem.Enabled = true;
                bool turnOn = (bdsCTDDH.Count > 0) ? true : false;
                this.btnXoa.Enabled = turnOn;
                this.btnGhi.Enabled = false;

                this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnThoat.Enabled = true;

                this.txtMADDH.Enabled = false;

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
            if (btnMENU.Links[0].Caption == "Đơn đặt hàng")
            {
                this.txtMADDH.Enabled = true;
                //this.txtMAKHO.Text = "";
                this.dteNGAY.EditValue = DateTime.Now;
                this.dteNGAY.Enabled = false;
                this.txtNCC.Enabled = true;
                this.txtMANV.Text = Program.userName;
                this.btnChonMaKho.Enabled = true;

                /*Gan tu dong may truong du lieu nay*/
                ((DataRowView)(bdsDH.Current))["MANV"] = Program.userName;
                ((DataRowView)(bdsDH.Current))["NGAY"] = DateTime.Now;
            }

            if (btnMENU.Links[0].Caption == "Chi tiết đơn đặt hàng")
            {
                DataRowView drv = ((DataRowView)bdsDH[bdsDH.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.userName != maNhanVien)
                {
                    MessageBox.Show("Bạn không thêm chi tiết đơn hàng trên phiếu không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    bdsCTDDH.RemoveCurrent();
                    return;
                }



                this.txtMAVT.Enabled = false;
                this.btnChonVatTu.Enabled = true;

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
        }

        /**************************************************
         * ham nay kiem tra du lieu dau vao
         * true là qua hết
         * false là thiếu một dữ liệu nào đó
         **************************************************/
        private bool kiemTraDuLieuDauVao(String cheDo)
        {
            if (cheDo == "Đơn đặt hàng")
            {
                if (txtMADDH.Text == "")
                {
                    MessageBox.Show("Không thể bỏ trống mã đơn hàng", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                if (txtMADDH.Text.Length > 8)
                {
                    MessageBox.Show("Mã Đơn đặt hàng không quá 8 kí tự", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                if (txtMANV.Text == "")
                {
                    MessageBox.Show("Không thể bỏ trống mã nhân viên", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                if (txtNCC.Text == "")
                {
                    MessageBox.Show("Không thể bỏ trống nhà cung cấp", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                if (txtNCC.Text.Length > 100)
                {
                    MessageBox.Show("Tên nhà cung cấp không quá 100 kí tự", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                if (txtMAKHO.Text == "")
                {
                    MessageBox.Show("Không thể bỏ trống mã kho", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
            }

            if (cheDo == "Chi tiết đơn đặt hàng")
            {
                if (txtMAVT.Text == "")
                {
                    MessageBox.Show("Không thể bỏ trống mã vật tư", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                if (txtSOLUONG.Value < 0 || txtDONGIA.Value < 0)
                {
                    MessageBox.Show("Không thể nhỏ hơn 1", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                /*
                if( txtSOLUONG.Value > Program.soLuongVatTu)
                {
                    MessageBox.Show("Sô lượng đặt mua lớn hơn số lượng vật tư hiện có", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }*/
            }
            return true;
        }

        /**************************************************
        * tra ve 1 cau truy van de phuc hoi du lieu
        * 
        * ket qua tra ve dua theo che do dang su dung
        **************************************************/
        private String taoCauTruyVanHoanTac(String cheDo)
        {
            String cauTruyVan = "";
            DataRowView drv;


            /*Dang chinh sua don dat hang*/
            if (cheDo == "Đơn đặt hàng" && dangThemMoi == false)
            {
                drv = ((DataRowView)bdsDH[bdsDH.Position]);
                /*Ngay can duoc xu ly dac biet hon*/
                DateTime ngay = ((DateTime)drv["NGAY"]);

                cauTruyVan = "UPDATE DBO.DATHANG " +
                    "SET " +
                    "NGAY = CAST('" + ngay.ToString("yyyy-MM-dd") + "' AS DATETIME), " +
                    "NhaCC = '" + drv["NhaCC"].ToString().Trim() + "', " +
                    "MANV = '" + drv["MANV"].ToString().Trim() + "', " +
                    "MAKHO = '" + drv["MAKHO"].ToString().Trim() + "' " +
                    "WHERE MasoDDH = '" + drv["MasoDDH"].ToString().Trim() + "'";
            }
            /*Dang xoa don dat hang*/
            if (cheDo == "Đơn đặt hàng" && dangThemMoi == true)
            {
                drv = ((DataRowView)bdsDH[bdsDH.Position]);
                DateTime ngay = ((DateTime)drv["NGAY"]);
                cauTruyVan = "INSERT INTO DBO.DATHANG(MasoDDH, NGAY, NhaCC, MaNV, MaKho) " +
                    "VALUES('" + drv["MasoDDH"] + "', '" +
                    ngay.ToString("yyyy-MM-dd") + "', '" +
                    drv["NhaCC"].ToString() + "', '" +
                    drv["MaNV"].ToString() + "', '" +
                    drv["MaKho"].ToString() + "' )";

            }

            /*Dang chinh sua chi tiet don dat hang*/
            if (cheDo == "Chi tiết đơn đặt hàng" && dangThemMoi == false)
            {
                drv = ((DataRowView)bdsCTDDH[bdsCTDDH.Position]);

                cauTruyVan = "UPDATE DBO.CTDDH " +
                    "SET " +
                    "SOLUONG = " + drv["SOLUONG"].ToString() + " , " +
                    "DONGIA = " + drv["DONGIA"].ToString() + " " +
                    "WHERE MasoDDH = '" + drv["MasoDDH"].ToString().Trim() + "'" +
                    " AND MAVT = '" + drv["MAVT"].ToString().Trim() + "'";

            }
            return cauTruyVan;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            viTri = bdsDH.Position;
            /*Step 1*/
            DataRowView drv = ((DataRowView)bdsDH[bdsDH.Position]);
            /*lay maNhanVien & maDonDatHang de phong truong hop them chi tiet don hang thi se co ngay*/
            String maNhanVien = drv["MANV"].ToString();
            String maDonDatHang = drv["MasoDDH"].ToString().Trim();

            if (Program.userName != maNhanVien && dangThemMoi == false)
            {
                MessageBox.Show("Bạn không thể sửa phiếu do người khác lập", "Thông báo", MessageBoxButtons.OK);
                return;
            }



            /*Step 2*/
            String cheDo = (btnMENU.Links[0].Caption == "Đơn đặt hàng") ? "Đơn đặt hàng" : "Chi tiết đơn đặt hàng";

            bool ketQua = kiemTraDuLieuDauVao(cheDo);
            if (ketQua == false) return;

            String cauTruyVanHoanTac = taoCauTruyVanHoanTac(cheDo);
            //Console.WriteLine(cauTruyVanHoanTac);


            /*Step 3*/
            String maDonDatHangMoi = txtMADDH.Text;
            String cauTruyVan =
                    "DECLARE	@result int " +
                    "EXEC @result = sp_KiemTraMaDonDatHang '" +
                    maDonDatHangMoi + "' " +
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



            /*Step 4*/
            //Console.WriteLine(txtMANV.Text);
            int viTriHienTai = bds.Position;
            int viTriMaDonDatHang = bdsDH.Find("MasoDDH", txtMADDH.Text);
            /******************************************************************
             * truong hop them moi don dat hang moi quan tam xem no ton tai hay
             * chua ?
             ******************************************************************/
            if (result == 1 && cheDo == "Đơn đặt hàng" && viTriHienTai != viTriMaDonDatHang)
            {
                MessageBox.Show("Mã đơn hàng này đã được sử dụng !\n\n", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*****************************************************************
             * tat ca cac truong hop khac ko can quan tam !!
             *****************************************************************/

            else
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu ?", "Thông báo",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        //Console.WriteLine(txtMANV.Text);
                        /*TH1: them moi don dat hang*/
                        if (cheDo == "Đơn đặt hàng" && dangThemMoi == true)
                        {
                            cauTruyVanHoanTac =
                                "DELETE FROM DBO.DATHANG " +
                                "WHERE MasoDDH = '" + maDonDatHang + "'";
                        }

                        /*TH2: them moi chi tiet don hang*/
                        if (cheDo == "Chi tiết đơn đặt hàng" && dangThemMoi == true)
                        {
                            /*Gan tu dong may truong du lieu nay*/
                            ((DataRowView)(bdsCTDDH.Current))["MasoDDH"] = ((DataRowView)(bdsDH.Current))["MasoDDH"];
                            ((DataRowView)(bdsCTDDH.Current))["MAVT"] = Program.maVatTuDuocChon;
                            ((DataRowView)(bdsCTDDH.Current))["SOLUONG"] =
                                txtSOLUONG.Value;
                            ((DataRowView)(bdsCTDDH.Current))["DONGIA"] =
                                (int)txtDONGIA.Value;

                            cauTruyVanHoanTac =
                                "DELETE FROM DBO.CTDDH " +
                                "WHERE MasoDDH = '" + maDonDatHang + "' " +
                                "AND MAVT = '" + txtMAVT.Text.Trim() + "'";
                        }

                        /*TH3: chinh sua don hang */
                        /*TH4: chinh sua chi tiet don hang - > thi chi can may dong lenh duoi la xong*/
                        undoList.Push(cauTruyVanHoanTac);
                        //Console.WriteLine("cau truy van hoan tac");
                        //Console.WriteLine(cauTruyVanHoanTac);

                        this.bdsDH.EndEdit();
                        this.bdsCTDDH.EndEdit();
                        this.datHangTableAdapter.Update(this.DS.DatHang);
                        this.cTDDHTableAdapter.Update(this.DS.CTDDH);

                        this.btnThem.Enabled = true;
                        this.btnXoa.Enabled = true;
                        this.btnGhi.Enabled = true;

                        this.btnPhucHoi.Enabled = true;
                        this.btnLamMoi.Enabled = true;
                        this.btnMENU.Enabled = true;
                        this.btnThoat.Enabled = true;

                        //this.groupBoxDDH.Enabled = false;

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

                /*dang o che do Don Dat Hang*/
                if (btnMENU.Links[0].Caption == "Đơn đặt hàng")
                {
                    this.txtMADDH.Enabled = false;

                    //this.dteNGAY.EditValue = DateTime.Now;
                    this.dteNGAY.Enabled = false;
                    this.txtNCC.Enabled = true;
                    //this.txtMANV.Text = Program.userName;
                    this.btnChonMaKho.Enabled = true;
                }
                /*dang o che do Chi Tiet Don Dat Hang*/
                if (btnMENU.Links[0].Caption == "Chi tiết đơn đặt hàng")
                {
                    this.txtMAVT.Enabled = false;
                    this.btnChonVatTu.Enabled = true;

                    this.txtSOLUONG.Enabled = true;
                    this.txtSOLUONG.EditValue = 1;

                    this.txtDONGIA.Enabled = true;
                    this.txtDONGIA.EditValue = 1;
                }

                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnGhi.Enabled = true;

                this.btnLamMoi.Enabled = true;
                this.btnMENU.Enabled = true;
                this.btnThoat.Enabled = true;


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

            this.datHangTableAdapter.Fill(this.DS.DatHang);
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

            bdsDH.Position = viTri;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // do du lieu moi tu DS vao gridControl NHANVIEN
                this.datHangTableAdapter.Fill(this.DS.DatHang);
                this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

                this.gcDatHang.Enabled = true;
                this.gcCTDDH.Enabled = true;

                bdsDH.Position = viTri;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Làm mới" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cauTruyVan = "";
            string cheDo = (btnMENU.Links[0].Caption == "Đơn đặt hàng") ? "Đơn đặt hàng" : "Chi tiết đơn đặt hàng";

            dangThemMoi = true;// bat cai nay len de ung voi dieu kien tao cau truy van

            if (cheDo == "Đơn đặt hàng")
            {
                /*Cái bdsChiTietDonHangHang là đại diện cho binding source riêng biệt của CTDDH
                 *Còn cTDDHBindingSource là lấy ngay từ trong data source DATHANG
                 */
                if (bdsCTDDH.Count > 0)
                {
                    MessageBox.Show("Không thể xóa Đơn đặt hàng này vì có Chi tiết đơn đặt hàng", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                if (bdsPN.Count > 0)
                {
                    MessageBox.Show("Không thể xóa Đơn đặt hàng này vì có phiếu nhập", "Thông báo", MessageBoxButtons.OK);
                    return;
                }


            }
            if (cheDo == "Chi tiết đơn đặt hàng")
            {
                DataRowView drv = ((DataRowView)bdsDH[bdsDH.Position]);
                String maNhanVien = drv["MANV"].ToString();
                if (Program.userName != maNhanVien)
                {
                    MessageBox.Show("Bạn không xóa chi tiết đơn hàng trên phiếu không phải do mình tạo", "Thông báo", MessageBoxButtons.OK);
                    //bdsCTDDH.RemoveCurrent();
                    return;
                }
            }

            cauTruyVan = taoCauTruyVanHoanTac(cheDo);
            //Console.WriteLine("Line 753");
            //Console.WriteLine(cauTruyVan);
            undoList.Push(cauTruyVan);

            /*Step 2*/
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    /*Step 3*/
                    viTri = bds.Position;
                    if (cheDo == "Đơn đặt hàng")
                    {
                        bdsDH.RemoveCurrent();
                    }
                    if (cheDo == "Chi tiết đơn đặt hàng")
                    {
                        bdsCTDDH.RemoveCurrent();
                    }


                    this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.datHangTableAdapter.Update(this.DS.DatHang);

                    this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTDDHTableAdapter.Update(this.DS.CTDDH);

                    /*Cap nhat lai do ben tren can tao cau truy van nen da dat dangThemMoi = true*/
                    dangThemMoi = false;
                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK);
                    this.btnPhucHoi.Enabled = true;
                }
                catch (Exception ex)
                {
                    /*Step 4*/
                    MessageBox.Show("Lỗi xóa nhân viên. Hãy thử lại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.datHangTableAdapter.Update(this.DS.DatHang);

                    this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTDDHTableAdapter.Update(this.DS.CTDDH);
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

        private void btnChonMaKho_Click_1(object sender, EventArgs e)
        {
            FormChonKhoHang form = new FormChonKhoHang();
            form.ShowDialog();


            this.txtMAKHO.Text = Program.maKhoDuocChon;
        }

        private void btnChonVatTu_Click(object sender, EventArgs e)
        {
            FormChonVatTu form = new FormChonVatTu();
            form.ShowDialog();
            this.txtMAVT.Text = Program.maVatTuDuocChon;
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
                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.DS.DatHang);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
            }
        }
    }
}