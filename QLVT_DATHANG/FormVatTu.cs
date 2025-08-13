using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class FormVatTu : DevExpress.XtraEditors.XtraForm
    {
        public FormVatTu()
        {
            InitializeComponent();
        }

        /* vị trí của con trỏ trên grid view*/
        int viTri = 0;

        bool dangThemMoi = false;

        String maChiNhanh = "";

        Stack undoList = new Stack();

        private void FormVatTu_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'DS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);
            // TODO: This line of code loads data into the 'DS.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.DS.CTPN);
            // TODO: This line of code loads data into the 'DS.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPXTableAdapter.Fill(this.DS.CTPX);
            // TODO: This line of code loads data into the 'qLVT_DATHANGDS2.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);

            /*Step 2*/
            chinhanhCB.DataSource = Program.bindingSource;/*sao chep bingding source tu form dang nhap*/
            chinhanhCB.DisplayMember = "TENCN";
            chinhanhCB.ValueMember = "TENSERVER";
            chinhanhCB.SelectedIndex = Program.brand;

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
                this.btnThoat.Enabled = true;

                this.panelNHAPLIEU.Enabled = false;
            }

            /* CHI NHANH & USER co the xem - xoa - sua du lieu nhung khong the 
            chuyen sang chi nhanh khac*/
            if (Program.role == "CHINHANH" || Program.role == "USER")
            {
                chinhanhCB.Enabled = false;

                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnGhi.Enabled = true;

                this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnThoat.Enabled = true;

                this.panelNHAPLIEU.Enabled = true;
                this.txtMAVT.Enabled = false;
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
                /*Do du lieu tu DS vao grid Control*/
                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.DS.CTPN);

                this.cTPXTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPXTableAdapter.Fill(this.DS.CTPX);

                this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vattuTableAdapter.Fill(this.DS.Vattu);
                /*Tu dong lay maChiNhanh hien tai - phuc vu cho phan btnThem*/

            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 1*/
            /*lấy vị trí hiện tại của con trỏ*/
            viTri = bdsVT.Position;
            this.panelNHAPLIEU.Enabled = true;
            dangThemMoi = true;

            /*Step 2*/
            /*AddNew tự động nhảy xuống cuối thêm 1 dòng mới*/
            bdsVT.AddNew();
            txtSLTON.Value = 1;

            /*Step 3*/
            this.txtMAVT.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnGhi.Enabled = true;

            this.btnPhucHoi.Enabled = true;
            this.btnLamMoi.Enabled = false;
            this.btnThoat.Enabled = false;


            this.gcVATTU.Enabled = false;
            this.panelNHAPLIEU.Enabled = true;
        }

        private bool kiemTraDuLieuDauVao()
        {
            /*Kiem tra txtMAVT*/
            if (txtMAVT.Text == "")
            {
                MessageBox.Show("Không bỏ trống mã vật tư", "Thông báo", MessageBoxButtons.OK);
                txtMAVT.Focus();
                return false;
            }

            if (Regex.IsMatch(txtMAVT.Text, @"^[a-zA-Z0-9]+$") == false)
            {
                MessageBox.Show("Mã vật tư chỉ có chữ cái và số", "Thông báo", MessageBoxButtons.OK);
                txtMAVT.Focus();
                return false;
            }

            if (txtMAVT.Text.Length > 4)
            {
                MessageBox.Show("Mã vật tư không quá 4 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtMAVT.Focus();
                return false;
            }
            /*Kiem tra txtTENVT*/
            if (txtTENVT.Text == "")
            {
                MessageBox.Show("Không bỏ trống tên vật tư", "Thông báo", MessageBoxButtons.OK);
                txtTENVT.Focus();
                return false;
            }

            if (Regex.IsMatch(txtTENVT.Text, @"^[a-zA-Z0-9 ]+$") == false)
            {
                MessageBox.Show("Tên vật tư chỉ chấp nhận chữ, số và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtTENVT.Focus();
                return false;
            }

            if (txtTENVT.Text.Length > 30)
            {
                MessageBox.Show("Tên vật tư không quá 30 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtTENVT.Focus();
                return false;
            }
            /*Kiem tra txtDVT*/
            if (txtDVT.Text == "")
            {
                MessageBox.Show("Không bỏ trống đơn vị tính", "Thông báo", MessageBoxButtons.OK);
                txtDVT.Focus();
                return false;
            }

            if (Regex.IsMatch(txtDVT.Text, @"^[a-zA-Z ]+$") == false)
            {
                MessageBox.Show("Đơn vị vật tư chỉ có chữ cái", "Thông báo", MessageBoxButtons.OK);
                txtDVT.Focus();
                return false;
            }

            if (txtDVT.Text.Length > 15)
            {
                MessageBox.Show("Đơn vị vật tự không quá 15 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtDVT.Focus();
                return false;
            }
            /*Kiem tra txtSLTON*/
            if (txtSLTON.Value < 0)
            {
                MessageBox.Show("Sô lượng tồn phải ít nhất bằng 0", "Thông báo", MessageBoxButtons.OK);
                txtSLTON.Focus();
                return false;
            }

            return true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /* Step 0 */
            bool ketQua = kiemTraDuLieuDauVao();
            if (ketQua == false)
                return;


            /*Step 1*/
            /*Lay du lieu truoc khi chon btnGhi - phuc vu btnPhucHoi*/
            String maVatTu = txtMAVT.Text.Trim();// Trim() de loai bo khoang trang thua
            DataRowView drv = ((DataRowView)bdsVT[bdsVT.Position]);
            String tenVatTu = drv["TENVT"].ToString();
            String donViTinh = drv["DVT"].ToString();
            String soLuongTon = (drv["SOLUONGTON"].ToString());


            /*declare @returnedResult int
              exec @returnedResult = sp_KiemTraMaVatTu '20'
              select @returnedResult*/
            String cauTruyVan =
                    "DECLARE	@result int " +
                    "EXEC @result = sp_KiemTraMaVatTu '" +
                    maVatTu + "' " +
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
            //Console.WriteLine(result);
            Program.myReader.Close();



            /*Step 2*/
            int viTriConTro = bdsVT.Position;
            int viTriMaVatTu = bdsVT.Find("MAVT", txtMAVT.Text);

            if (result == 1 && viTriConTro != viTriMaVatTu)
            {
                MessageBox.Show("Mã vật tư này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
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
                        /*bật các nút về ban đầu*/
                        btnThem.Enabled = true;
                        btnXoa.Enabled = true;
                        btnGhi.Enabled = true;
                        btnPhucHoi.Enabled = true;

                        btnLamMoi.Enabled = true;
                        btnThoat.Enabled = true;

                        this.txtMAVT.Enabled = false;
                        this.gcVATTU.Enabled = true;

                        /*lưu 1 câu truy vấn để hoàn tác yêu cầu*/
                        String cauTruyVanHoanTac = "";
                        /*trước khi ấn btnGhi là btnThem*/
                        if (dangThemMoi == true)
                        {
                            cauTruyVanHoanTac = "" +
                                "DELETE DBO.VATTU " +
                                "WHERE MAVT = '" + txtMAVT.Text.Trim() + "'";
                        }
                        /*trước khi ấn btnGhi là sửa thông tin nhân viên*/
                        else
                        {
                            cauTruyVanHoanTac =
                                "UPDATE DBO.VATTU " +
                                "SET " +
                                "TENVT = '" + tenVatTu + "'," +
                                "DVT = '" + donViTinh + "'," +
                                "SOLUONGTON = " + soLuongTon + " " +
                                "WHERE MAVT = '" + maVatTu + "'";
                        }
                        //Console.WriteLine("CAU TRUY VAN HOAN TAC");
                        //Console.WriteLine(cauTruyVanHoanTac);

                        /*Đưa câu truy vấn hoàn tác vào undoList 
                         * để nếu chẳng may người dùng ấn hoàn tác thì quất luôn*/
                        undoList.Push(cauTruyVanHoanTac);

                        this.bdsVT.EndEdit();
                        this.vattuTableAdapter.Update(this.DS.Vattu);
                        /*cập nhật lại trạng thái thêm mới cho chắc*/
                        dangThemMoi = false;
                        MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        bdsVT.RemoveCurrent();
                        MessageBox.Show("Tên vật tư có thể đã được dùng !\n\n" + ex.Message, "Lỗi",
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

                this.txtMAVT.Enabled = false;
                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnGhi.Enabled = true;

                this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnThoat.Enabled = true;


                this.gcVATTU.Enabled = true;
                this.panelNHAPLIEU.Enabled = true;

                bdsVT.CancelEdit();
                /*xoa dong hien tai*/
                bdsVT.RemoveCurrent();
                /* trở về lúc đầu con trỏ đang đứng*/
                bdsVT.Position = viTri;
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
            bdsVT.CancelEdit();
            String cauTruyVanHoanTac = undoList.Pop().ToString();
            Console.WriteLine(cauTruyVanHoanTac);
            int n = Program.ExecSqlNonQuery(cauTruyVanHoanTac);
            this.vattuTableAdapter.Fill(this.DS.Vattu);
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // do du lieu moi tu DS vao gridControl NHANVIEN
                this.vattuTableAdapter.Fill(this.DS.Vattu);
                this.gcVATTU.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Làm mới" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }
        /***************************************************************************
         * có thể ở chi nhánh này vật tư X không được sử dụng trong phiếu nhập | xuất nào
         * cả. Nhưng ở chi nhánh khác vật tư X được sử dụng trong phiếu nhập hoặc xuất
         * nếu xóa thì gây mâu thuẫn dữ liệu.
         * 
         * Nếu vật tư được sử dụng ở chi nhánh khác thì không được xóa
         * 
         * Trả về 1 nếu tồn tại. Trả về 0 nếu chưa tham gia vào phiếu nhập | xuất nào
         ***************************************************************************/
        private int kiemTraVatTuCoSuDungTaiChiNhanhKhac(String maVatTu)
        {
            String cauTruyVan =
                    "DECLARE	@result int " +
                    "EXEC @result = sp_KiemTraMaVatTuChiNhanhConLai '" +
                    maVatTu + "' " +
                    "SELECT 'Value' = @result";
            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
            try
            {
                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                /*khong co ket qua tra ve thi ket thuc luon*/
                if (Program.myReader == null)
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return 1;
            }
            Program.myReader.Read();
            int result = int.Parse(Program.myReader.GetValue(0).ToString());
            //Console.WriteLine("line 535");
            //Console.WriteLine(result);
            Program.myReader.Close();

            /*result = 1 nghia la vat tu nay dang duoc su dung o chi nhanh con lai*/
            int ketQua = (result == 1) ? 1 : 0;

            return ketQua;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 1*/
            if (bdsVT.Count == 0)
            {
                btnXoa.Enabled = false;
            }

            if (bdsCTDDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập đơn đặt hàng", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập phiếu nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsCTPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đã lập phiếu xuất", "Thông báo", MessageBoxButtons.OK);
                return;
            }



            /*kiem tra xem no co dang duoc su dung tai chi nhanh khac hay khong ?*/
            String maVatTu = txtMAVT.Text.Trim();// Trim() de loai bo khoang trang thua
            int ketQua = kiemTraVatTuCoSuDungTaiChiNhanhKhac(maVatTu);

            if (ketQua == 1)
            {
                MessageBox.Show("Không thể xóa vật tư này vì đang được sử dụng ở chi nhánh khác", "Thông báo", MessageBoxButtons.OK);
                return;
            }



            /* Phần này phục vụ tính năng hoàn tác
            * Đưa câu truy vấn hoàn tác vào undoList 
            * để nếu chẳng may người dùng ấn hoàn tác thì quất luôn*/


            string cauTruyVanHoanTac =
            "INSERT INTO DBO.VATTU( MAVT,TENVT,DVT,SOLUONGTON) " +
            " VALUES( '" + txtMAVT.Text + "','" +
                        txtTENVT.Text + "','" +
                        txtDVT.Text + "', " +
                        txtSLTON.Value + " ) ";

            Console.WriteLine(cauTruyVanHoanTac);
            undoList.Push(cauTruyVanHoanTac);

            /*Step 2*/
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Thông báo",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    /*Step 3*/
                    viTri = bdsVT.Position;
                    bdsVT.RemoveCurrent();

                    this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.vattuTableAdapter.Update(this.DS.Vattu);

                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK);
                    this.btnPhucHoi.Enabled = true;
                }
                catch (Exception ex)
                {
                    /*Step 4*/
                    MessageBox.Show("Lỗi xóa nhân viên. Hãy thử lại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    this.vattuTableAdapter.Fill(this.DS.Vattu);
                    // tro ve vi tri cua nhan vien dang bi loi
                    bdsVT.Position = viTri;
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

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Dispose();

        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }
    }
}