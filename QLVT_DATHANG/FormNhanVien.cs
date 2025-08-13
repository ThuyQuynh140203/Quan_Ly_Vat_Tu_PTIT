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
    public partial class FormNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        String maCN = "";
        int vitri = 0;
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
        /**********************************************************
        * undoList - phục vụ cho btnPhucHoi -  chứa các thông tin của đối tượng bị tác động 
        * 
        * nó là nơi lưu trữ các đối tượng cần thiết để hoàn tác các thao tác
        * 
        * nếu btnGhi sẽ ứng với INSERT
        * nếu btnXoa sẽ ứng với DELETE
        * nếu btnChuyenCN sẽ ứng với CHANGEBRAND
        **********************************************************/
        Stack undoList = new Stack();

        private Form CheckExists(Type fType)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == fType)
                {
                    return f;
                }
            }
            return null;
        }

        private void FormNhanVien1_Load(object sender, EventArgs e)
        {
            
            DS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'DS.NhanVien' table. You can move, or remove it, as needed.
            this.NhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.NhanVienTableAdapter.Fill(this.DS.NhanVien);
            // TODO: This line of code loads data into the 'DS.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.datHangTableAdapter.Fill(this.DS.DatHang);
            // TODO: This line of code loads data into the 'DS.PhieuNhap' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);
            // TODO: This line of code loads data into the 'DS.PhieuXuat' table. You can move, or remove it, as needed.
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);

            maCN = ((DataRowView)bdsNV[0])["MACN"].ToString();
            chinhanhCB.DataSource = Program.bindingSource; //sao chép từ bidingSource của Form dang nhập
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
                this.btnChuyenCN.Enabled = false;
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
                this.btnChuyenCN.Enabled = true;
                this.btnThoat.Enabled = true;

                this.panelNHAPLIEU.Enabled = true;
                this.txtMANV.Enabled = false;
            }
        }
        /*********************************************************************
       * bdsNV.Position - vitri phuc vu cho btnPhucHoi. Gia su, co 5 nhan vien, con tro chuot
       * dang dung o vi tri nhan vien thu 2 thi chung ta an nut THEM
       * nhung neu chon btnPhucHoi, con tro chuot phai quay lai vi 
       * tri nhan vien thu 2, thay vi o vi tri duoi cung - tuc nhan vien so 5
       * 
       * neu nhap chu cho txtMANV thi se khong chuyen sang cac o khac duoc nua - bat buoc ghi so
       * 
       * Step 1: Kich hoat panel Nhap lieu & lay vi tri cua nhan vien hien tai
       * dat dangThemMoi = true
       * Step 2: gui lenh them moi toi bdsNV - tu dong lay maChiNhanh - bo trong dteNGAYSINH
       * Step 3: vo hieu hoa cac nut chuc nang & gridControl - chi btnGhi & btnPhucHoi moi duoc hoat dong
       *********************************************************************/
        private void btnThem_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*Step 1*/
            /*lấy vị trí hiện tại của con trỏ*/
            vitri = bdsNV.Position;
            this.panelNHAPLIEU.Enabled = true;
            dangThemMoi = true;

            /*Step 2*/
            /*AddNew tự động nhảy xuống cuối thêm 1 dòng mới*/
            bdsNV.AddNew();
            txtMACN.Text = maCN;
            dteNGAYSINH.EditValue = "2003-14-02";
            txtLUONG.EditValue = 4000000;

            /*Step 3*/
            this.txtMANV.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnGhi.Enabled = true;

            this.btnPhucHoi.Enabled = true;
            this.btnLamMoi.Enabled = false;
            this.btnChuyenCN.Enabled = false;
            this.btnThoat.Enabled = false;
            this.trangThaiXoaCB.Checked = false;

            this.gcNhanVien.Enabled = false;
            this.panelNHAPLIEU.Enabled = true;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /* Step 0 - */
            if (dangThemMoi == true && this.btnThem.Enabled == false)
            {
                dangThemMoi = false;

                this.txtMANV.Enabled = false;
                this.btnThem.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnGhi.Enabled = true;

                this.btnPhucHoi.Enabled = false;
                this.btnLamMoi.Enabled = true;
                this.btnChuyenCN.Enabled = true;
                this.btnThoat.Enabled = true;
                this.trangThaiXoaCB.Checked = false;

                this.gcNhanVien.Enabled = true;
                this.panelNHAPLIEU.Enabled = true;

                bdsNV.CancelEdit();
                /*xoa dong hien tai*/
                bdsNV.RemoveCurrent();
                /* trở về lúc đầu con trỏ đang đứng*/
                bdsNV.Position = vitri;
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
            bdsNV.CancelEdit();
            String cauTruyVanHoanTac = undoList.Pop().ToString();
            //Console.WriteLine(cauTruyVanHoanTac);

            /*Step 2.1*/
            if (cauTruyVanHoanTac.Contains("sp_ChuyenChiNhanh"))
            {
                try
                {
                    String chiNhanhHienTai = Program.serverName;
                    String chiNhanhChuyenToi = Program.serverNameLeft;

                    Program.serverName = chiNhanhChuyenToi;
                    Program.loginName = Program.remoteLogin;
                    Program.loginPassword = Program.remotePassword;

                    if (Program.KetNoi() == 0)
                    {
                        return;
                    }


                    int n = Program.ExecSqlNonQuery(cauTruyVanHoanTac);

                    MessageBox.Show("Chuyển nhân viên trở lại thành công", "Thông báo", MessageBoxButtons.OK);
                    Program.serverName = chiNhanhHienTai;
                    Program.loginName = Program.currentLogin;
                    Program.loginPassword = Program.currentPassword;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chuyển nhân viên thất bại \n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    return;
                }

            }
            /*Step 2.2*/
            else
            {
                if (Program.KetNoi() == 0)
                {
                    return;
                }
                int n = Program.ExecSqlNonQuery(cauTruyVanHoanTac);

            }
            this.NhanVienTableAdapter.Fill(this.DS.NhanVien);




            /*
            bdsNV.CancelEdit();
            String cauTruyVanHoanTac = undoList.Pop().ToString();
            Console.WriteLine(cauTruyVanHoanTac);
            int n = Program.ExecSqlNonQuery(cauTruyVanHoanTac);
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
             */
        }

        private void btnLamMoi_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // do du lieu moi tu DS vao gridControl NhanVien
                this.NhanVienTableAdapter.Fill(this.DS.NhanVien);
                this.gcNhanVien.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi làm mới dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            {
                age = age - 1;
            }
            return age;
        }

        private bool kiemTraDuLieuDauVao()
        {
            /*kiem tra txtMANV*/
            if (txtMANV.Text == "")
            {
                MessageBox.Show("Không bỏ trống mã nhân viên", "Thông báo", MessageBoxButtons.OK);
                txtMANV.Focus();
                return false;
            }

            if (Regex.IsMatch(txtMANV.Text, @"^[a-zA-Z0-9]+$") == false)
            {
                MessageBox.Show("Mã nhân viên chỉ chấp nhận số", "Thông báo", MessageBoxButtons.OK);
                txtMANV.Focus();
                return false;
            }
            /*kiem tra txtHO*/
            if (txtHO.Text == "")
            {
                MessageBox.Show("Không bỏ trống họ và tên", "Thông báo", MessageBoxButtons.OK);
                txtHO.Focus();
                return false;
            }
            //"^[0-9A-Za-z ]+$"
            if (Regex.IsMatch(txtHO.Text, @"^[A-Za-z ]+$") == false)
            {
                MessageBox.Show("Họ của người chỉ có chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtHO.Focus();
                return false;
            }
            if (txtHO.Text.Length > 40)
            {
                MessageBox.Show("Họ không thể lớn hơn 40 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtHO.Focus();
                return false;
            }
            /*kiem tra txtTEN*/
            if (txtTEN.Text == "")
            {
                MessageBox.Show("Không bỏ trống họ và tên", "Thông báo", MessageBoxButtons.OK);
                txtTEN.Focus();
                return false;
            }

            if (Regex.IsMatch(txtTEN.Text, @"^[a-zA-Z]+$") == false)
            {
                MessageBox.Show("Tên người chỉ có chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtTEN.Focus();
                return false;
            }

            if (txtTEN.Text.Length > 10)
            {
                MessageBox.Show("Tên không thể lớn hơn 10 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtTEN.Focus();
                return false;
            }
            /*kiem tra txtDIACHI*/
            if (txtDIACHI.Text == "")
            {
                MessageBox.Show("Không bỏ trống địa chỉ", "Thông báo", MessageBoxButtons.OK);
                txtDIACHI.Focus();
                return false;
            }

            if (Regex.IsMatch(txtDIACHI.Text, @"^[a-zA-Z0-9, ]+$") == false)
            {
                MessageBox.Show("Địa chỉ chỉ chấp nhận chữ cái, số và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtDIACHI.Focus();
                return false;
            }

            if (txtDIACHI.Text.Length > 100)
            {
                MessageBox.Show("Không bỏ trống địa chỉ", "Thông báo", MessageBoxButtons.OK);
                txtDIACHI.Focus();
                return false;
            }
            /*kiem tra dteNGAYSINH va txtLUONG*/
            if (CalculateAge(dteNGAYSINH.DateTime) < 18)
            {
                MessageBox.Show("Nhân viên chưa đủ 18 tuổi", "Thông báo", MessageBoxButtons.OK);
                dteNGAYSINH.Focus();
                return false;
            }

            if (txtLUONG.Value < 4000000 || txtLUONG.Value == 0)
            {
                MessageBox.Show("Mức lương không thể bỏ trống & tối thiểu 4.000.000 đồng", "Thông báo", MessageBoxButtons.OK);
                txtLUONG.Focus();
                return false;
            }

            return true;

        }
        private void btnThoat_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXoa_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            String tenNV = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();
            /*Step 1*/

            // khong cho xoa nguoi dang dang nhap ke ca nguoi do khong co don hang - phieu nhap - phieu xuat
            if (tenNV == Program.userName)
            {
                MessageBox.Show("Không thể xóa chính tài khoản đang đăng nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsNV.Count == 0)
            {
                btnXoa.Enabled = false;
            }

            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập đơn đặt hàng", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu nhập", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (bdsPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu xuất", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            /* Phần này phục vụ tính năng hoàn tác
                    * Đưa câu truy vấn hoàn tác vào undoList 
                    * để nếu chẳng may người dùng ấn hoàn tác thì quất luôn*/
            int trangThai = (trangThaiXoaCB.Checked == true) ? 1 : 0;
            /*Lấy ngày sinh trong grid view*/
            DateTime NGAYSINH = (DateTime)((DataRowView)bdsNV[bdsNV.Position])["NGAYSINH"];


            string cauTruyVanHoanTac =
                string.Format("INSERT INTO DBO.NHANVIEN( MANV,HO,TEN,DIACHI,NGAYSINH,LUONG,MACN)" +
            "VALUES({0},'{1}','{2}','{3}',CAST({4} AS DATETIME), {5},'{6}')", txtMANV.Text, txtHO.Text, txtTEN.Text, txtDIACHI.Text, NGAYSINH.ToString("yyyy-MM-dd"), txtLUONG.Value, txtMACN.Text.Trim());

            Console.WriteLine(cauTruyVanHoanTac);
            undoList.Push(cauTruyVanHoanTac);


            /*Step 2*/
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không ?", "Thông báo",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    /*Step 3*/
                    vitri = bdsNV.Position;
                    bdsNV.RemoveCurrent();

                    this.NhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.NhanVienTableAdapter.Update(this.DS.NhanVien);

                    MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK);
                    this.btnPhucHoi.Enabled = true;
                }
                catch (Exception ex)
                {
                    /*Step 4*/
                    MessageBox.Show("Lỗi xóa nhân viên. Hãy thử lại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    this.NhanVienTableAdapter.Fill(this.DS.NhanVien);
                    // tro ve vi tri cua nhan vien dang bi loi
                    bdsNV.Position = vitri;
                    //bdsNV.Position = bdsNV.Find("MANV", manv);
                    return;
                }
            }
            else
            {
                undoList.Pop();
            }
        }

        private void chinhanhCB_SelectedIndexChanged_1(object sender, EventArgs e)
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
                this.NhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.NhanVienTableAdapter.Fill(this.DS.NhanVien);

                this.datHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.datHangTableAdapter.Fill(this.DS.DatHang);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.DS.PhieuNhap);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuXuatTableAdapter.Fill(this.DS.PhieuXuat);
                /*Tu dong lay maChiNhanh hien tai - phuc vu cho phan btnThem*/
                /*Cho dong nay chay thi bi loi*/
                //maChiNhanh = ((DataRowView)bdsNV[0])["MACN"].ToString().Trim();
            }
        }

        /**************************************************************
         * Step 1: kiêm tra xem có nằm trên cùng chi nhánh không
         * Step 2: chuẩn bị các biến để lưu tên chi nhánh hiện tại và chi nhánh chuyển tới, tên nhân viên được chuyển
         * Step 3: trước khi thực hiện, lưu sẵn câu lệnh hoàn tác vào undoList + tên chi nhánh tới
         * Step 4: thực hiện chuyển chi nhánh với sp_ChuyenChiNhanh
         **************************************************************/
        public void chuyenChiNhanh(String chiNhanh)
        {
            //Console.WriteLine("Chi nhánh được chọn là " + chiNhanh);

            /*Step 1*/
            if (Program.serverName == chiNhanh)
            {
                MessageBox.Show("Hãy chọn chi nhánh khác chi nhánh bạn đang đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*Step 2*/
            String maChiNhanhHienTai = "";
            String maChiNhanhMoi = "";
            int viTriHienTai = bdsNV.Position;
            String maNhanVien = ((DataRowView)bdsNV[viTriHienTai])["MANV"].ToString();

            if (chiNhanh.Contains("1"))
            {
                maChiNhanhHienTai = "CN2";
                maChiNhanhMoi = "CN1";
            }
            else if (chiNhanh.Contains("2"))
            {
                maChiNhanhHienTai = "CN1";
                maChiNhanhMoi = "CN2";
            }
            else
            {
                MessageBox.Show("Mã chi nhánh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Console.WriteLine("Ma chi nhanh hien tai : " + maChiNhanhHienTai);
            Console.WriteLine("Ma chi nhanh Moi : " + maChiNhanhMoi);

            /*Step 3*/
            String cauTruyVanHoanTac = "EXEC sp_ChuyenChiNhanh " + maNhanVien + ",'" + maChiNhanhHienTai + "'";
            undoList.Push(cauTruyVanHoanTac);

            Program.serverNameLeft = chiNhanh; /*Lấy tên chi nhánh tới để làm tính năng hoàn tác*/
            Console.WriteLine("Ten server con lai" + Program.serverNameLeft);

            /*Step 4*/
            String cauTruyVan = "EXEC sp_ChuyenChiNhanh " + maNhanVien + ",'" + maChiNhanhMoi + "'";
            Console.WriteLine("Cau Truy Van: " + cauTruyVan);
            Console.WriteLine("Cau Truy Van Hoan Tac: " + cauTruyVanHoanTac);

            SqlCommand sqlcommand = new SqlCommand(cauTruyVan, Program.conn);
            Console.WriteLine(cauTruyVan);
            try
            {
                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                MessageBox.Show("Chuyển chi nhánh thành công", "thông báo", MessageBoxButtons.OK);

                if (Program.myReader == null)
                {
                    return;/*khong co ket qua tra ve thi ket thuc luon*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("thực thi database thất bại!\n\n" + ex.Message, "thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return;
            }
            this.NhanVienTableAdapter.Update(this.DS.NhanVien);


        }


        private void btnChuyenCN_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int viTriHienTai = bdsNV.Position;
            int trangThaiXoa = int.Parse(((DataRowView)(bdsNV[viTriHienTai]))["TrangThaiXoa"].ToString());
            string maNhanVien = ((DataRowView)(bdsNV[viTriHienTai]))["MANV"].ToString();

            if (maNhanVien == Program.userName)
            {
                MessageBox.Show("Không thể chuyển chính người đang đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*Step 1 - Kiem tra trang thai xoa*/
            if (trangThaiXoa == 1)
            {
                MessageBox.Show("Nhân viên này không có ở chi nhánh này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            ///*Step 2 Kiem tra xem form da co trong bo nho chua*/
            Form f = this.CheckExists(typeof(FormChuyenChiNhanh));
            if (f != null)
            {
                f.Activate();
            }
            FormChuyenChiNhanh form = new FormChuyenChiNhanh();
            form.Show();

            /*Step 3*/
            /*đóng gói hàm chuyenChiNhanh từ formNHANVIEN đem về formChuyenChiNhanh để làm việc*/
            form.branchTransfer = new FormChuyenChiNhanh.MyDelegate(chuyenChiNhanh);

            /*Step 4*/
            this.btnPhucHoi.Enabled = true;
        }

        private void btnGhi_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /* Step 0: Kiểm tra dữ liệu đầu vào */
            bool ketQua = kiemTraDuLieuDauVao();
            if (ketQua == false)
            {
                return;
            }

            /* Step 1: Lấy dữ liệu trước khi Ghi - để phục vụ hoàn tác */
            DataRowView drv = (DataRowView)bdsNV.Current;
            String maNhanVien = txtMANV.Text.Trim();
            String ho = drv["HO"].ToString();
            String ten = drv["TEN"].ToString();
            String diaChi = drv["DIACHI"].ToString();
            DateTime ngaySinh = ((DateTime)drv["NGAYSINH"]);
            int luong = int.Parse(drv["LUONG"].ToString());
            int trangThai = (trangThaiXoaCB.Checked == true) ? 1 : 0;

            /* Logic kiểm tra trùng mã nhân viên chỉ chạy khi thêm mới */
            if (dangThemMoi)
            {
                String cauTruyVanKiemTra =
                    "DECLARE @result int " +
                    "EXEC @result = [dbo].[sp_TraCuu_KiemTraMaNhanVien] '" + maNhanVien + "' " +
                    "SELECT 'Value' = @result";

                try
                {
                    Program.myReader = Program.ExecSqlDataReader(cauTruyVanKiemTra);
                    if (Program.myReader == null) return;
                    Program.myReader.Read();
                    int result = int.Parse(Program.myReader.GetValue(0).ToString());
                    Program.myReader.Close();

                    if (result == 1)
                    {
                        MessageBox.Show("Mã nhân viên này đã được sử dụng !", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            /* Step 2: Xác nhận và ghi dữ liệu */
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn ghi dữ liệu vào cơ sở dữ liệu?", "Thông báo",
                                              MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                try
                {
                    bdsNV.EndEdit();
                    this.NhanVienTableAdapter.Update(this.DS.NhanVien);

                    /* LƯU CÂU TRUY VẤN HOÀN TÁC SAU KHI GHI THÀNH CÔNG */
                    String cauTruyVanHoanTac = "";
                    if (dangThemMoi == true)
                    {
                        cauTruyVanHoanTac = "DELETE DBO.NHANVIEN WHERE MANV = " + txtMANV.Text.Trim();
                    }
                    else
                    {
                        cauTruyVanHoanTac =
                            "UPDATE DBO.NhanVien SET " +
                            "HO = '" + ho + "', " +
                            "TEN = '" + ten + "', " +
                            "DIACHI = '" + diaChi + "', " +
                            "NGAYSINH = CAST('" + ngaySinh.ToString("yyyy-MM-dd") + "' AS DATETIME), " +
                            "LUONG = " + luong + ", " +
                            "TrangThaiXoa = " + trangThai + " " +
                            "WHERE MANV = '" + maNhanVien + "'";
                    }

                    undoList.Push(cauTruyVanHoanTac);
                    dangThemMoi = false;

                    MessageBox.Show("Ghi thành công", "Thông báo", MessageBoxButtons.OK);

                    // Cập nhật trạng thái các nút sau khi ghi
                    this.gcNhanVien.Enabled = true;
                    this.txtMANV.Enabled = false;
                    this.btnThem.Enabled = true;
                    this.btnXoa.Enabled = true;
                    this.btnGhi.Enabled = true;
                    this.btnPhucHoi.Enabled = (undoList.Count > 0);
                    this.btnLamMoi.Enabled = true;
                    this.btnChuyenCN.Enabled = true;
                    this.btnThoat.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thất bại. Vui lòng kiểm tra lại!\n" + ex.Message, "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Hủy bỏ chỉnh sửa và tải lại dữ liệu để đồng bộ với DB
                    bdsNV.CancelEdit();
                    this.NhanVienTableAdapter.Fill(this.DS.NhanVien);

                    // Nếu đang thêm mới mà bị lỗi, trở về vị trí cũ
                    if (dangThemMoi)
                    {
                        bdsNV.Position = vitri;
                    }
                }
            }
            else
            {
                // Nếu người dùng hủy, hủy bỏ thao tác chỉnh sửa
                bdsNV.CancelEdit();
                if (dangThemMoi)
                {
                    bdsNV.Position = vitri;
                }
            }
        }
    }
}