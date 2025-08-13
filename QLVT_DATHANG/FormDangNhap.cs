using DevExpress.XtraEditors;
using System;
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
    public partial class FormDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection connPublisher = new SqlConnection();

        public FormDangNhap()
        {
            InitializeComponent();
        }

        /******************************************************************
         * Để tránh việc người dùng ấn vào 1 form đến 2 lần chúng ta 
         * cần sử dụng hàm này để kiểm tra xem cái form hiện tại đã 
         * có trong bộ nhớ chưa
         * Nếu có trả về "f"
         * Nếu không trả về "null"
         ******************************************************************/
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void layDanhSachPhanManh(String cmd)
        {
            if (connPublisher.State == ConnectionState.Closed)
            {
                connPublisher.Open();
            }
            DataTable dt = new DataTable();
            // apapter dùng để lấy dữ liệu từ database
            SqlDataAdapter da = new SqlDataAdapter(cmd, connPublisher);
            // dùnG dapter để đổ dữ liệu vào DataTable được
            da.Fill(dt);

            connPublisher.Close();
            Program.bindingSource.DataSource = dt;


            ChiNhanhCB.DataSource = Program.bindingSource;
            ChiNhanhCB.DisplayMember = "TENCN";
            ChiNhanhCB.ValueMember = "TENSERVER";
        }
        /******************************************************************
        * mở kết nối tới server 
        * @return trả về 1 nếu thành công
        *         trả về 0 nếu thất bại
        ******************************************************************/
        private int KetNoiDatabaseGoc()
        {
            if (connPublisher != null && connPublisher.State == ConnectionState.Open)
            {
                connPublisher.Close();
            }
            try
            {
                connPublisher.ConnectionString = Program.connstrPublisher;
                connPublisher.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }

        }
        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            // đặt sẵn mật khẩu để đỡ nhập lại nhiều lần
            TaiKhoanTB.Text = "TH";// Thái Hà - chi nhanh
            MatKhauTB.Text = "12345";
            if (KetNoiDatabaseGoc() == 0)
                return;
            //Lấy 2 cái đầu tiên của danh sách
            layDanhSachPhanManh("SELECT TOP 2 * FROM view_DanhSachPhanManh");
            ChiNhanhCB.SelectedIndex = 0;
            ChiNhanhCB.SelectedIndex = 1;
        }

        private void ChiNhanhCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.serverName = ChiNhanhCB.SelectedValue.ToString();
            //Console.WriteLine(cmbCHINHANH.SelectedValue.ToString());
        }

        private void dangNhapBTNClick_Click(object sender, EventArgs e)
        {
            /* Step 1*/
            if (TaiKhoanTB.Text.Trim() == "" || MatKhauTB.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản & mật khẩu không thể bỏ trống", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
            /* Step 2*/
            Program.loginName = TaiKhoanTB.Text.Trim();
            Program.loginPassword = MatKhauTB.Text.Trim();
            if (Program.KetNoi() == 0)
                return;
            /* Step 3*/
            Program.brand = ChiNhanhCB.SelectedIndex;
            Program.currentLogin = Program.loginName;
            Program.currentPassword = Program.loginPassword;


            /* Step 4*/
            String statement = "EXEC sp_DangNhap '" + Program.loginName + "'";// exec sp_DangNhap 'TP'
            Program.myReader = Program.ExecSqlDataReader(statement);
            if (Program.myReader == null)
                return;
            // đọc một dòng của myReader - điều này là hiển nhiên vì kết quả chỉ có 1 dùng duy nhất
            Program.myReader.Read();


            /* Step 5*/
            Program.userName = Program.myReader.GetString(0);// lấy userName
            if (Convert.IsDBNull(Program.userName))
            {
                MessageBox.Show("Tài khoản này không có quyền truy cập \n Hãy thử tài khoản khác", "Thông Báo", MessageBoxButtons.OK);
            }



            Program.staff = Program.myReader.GetString(1);
            Program.role = Program.myReader.GetString(2);

            Program.myReader.Close();
            Program.conn.Close();

            Program.formMain.MANV.Text = "MÃ NHÂN VIÊN: " + Program.userName;
            Program.formMain.HOTEN.Text = "HỌ TÊN: " + Program.staff;
            Program.formMain.NHOM.Text = "VAI TRÒ: " + Program.role;

            /* Step 6*/
            this.Visible = false;
            Program.formMain.enableButtons();
        }

        private void thoatBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.formMain.Close();
        }
    }
}