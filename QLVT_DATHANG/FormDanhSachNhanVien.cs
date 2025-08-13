using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class FormDanhSachNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public FormDanhSachNhanVien()
        {
            InitializeComponent();
        }

        private SqlConnection connPublisher = new SqlConnection();
        private string chiNhanh = "";

        private void layDanhSachPhanManh(String cmd)
        {
            if (connPublisher.State == ConnectionState.Closed)
            {
                connPublisher.Open();
            }
            DataTable dt = new DataTable();
            // adapter dùng để đưa dữ liệu từ view sang database
            SqlDataAdapter da = new SqlDataAdapter(cmd, connPublisher);
            // dùng adapter thì mới đổ vào data table được
            da.Fill(dt);


            connPublisher.Close();
            Program.bindingSource.DataSource = dt;


            chinhanhCB.DataSource = Program.bindingSource;
            chinhanhCB.DisplayMember = "TENCN";
            chinhanhCB.ValueMember = "TENSERVER";

        }
        private int KetNoiDatabaseGoc()
        {
            if (connPublisher != null && connPublisher.State == ConnectionState.Open)
                connPublisher.Close();
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

        private void FormDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            if (Program.role == "CONGTY")
            {
                this.chinhanhCB.Enabled = true;
            }
            DS.EnforceConstraints = false;

            if (KetNoiDatabaseGoc() == 0)
                return;

            layDanhSachPhanManh("SELECT TOP 2 * FROM view_DanhSachPhanManh");
            chinhanhCB.SelectedIndex = Program.brand;

            // TODO: This line of code loads data into the 'DS.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
        }

        private void chinhanhCB_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            chiNhanh = chinhanhCB.SelectedValue.ToString().Contains("1") ? "Chi nhánh 1" : "Chi nhánh 2";

            // TODO: This line of code loads data into the 'DS.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
        }

        private void btnXemTruoc_Click(object sender, EventArgs e)
        {
            Report_DanhSachNhanVien report = new Report_DanhSachNhanVien();
            /*GAN TEN CHI NHANH CHO BAO CAO*/
            report.txtChiNhanh.Text = chiNhanh.ToUpper();
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void btnInDSNV_Click(object sender, EventArgs e)
        {
            try
            {
                //ReportDanhSachNhanVien report = new ReportDanhSachNhanVien();
                Report_DanhSachNhanVien report = new Report_DanhSachNhanVien();
                /*GAN TEN CHI NHANH CHO BAO CAO*/
                report.txtChiNhanh.Text = chiNhanh.ToUpper();
                if (File.Exists(@"D:\ReportDanhSachNhanVien.pdf"))
                {
                    DialogResult dr = MessageBox.Show("File ReportDSNhanVien.pdf tại ổ D đã có!\nBạn có muốn tạo lại?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        report.ExportToPdf(@"D:\ReportDSNhanVien.pdf");
                        MessageBox.Show("File ReportDSNhanVien.pdf đã được ghi thành công tại ổ D",
                "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    report.ExportToPdf(@"D:\ReportDanhSachNhanVien.pdf");
                    MessageBox.Show("File ReportDSNhanVien.pdf đã được ghi thành công tại ổ D",
                "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Vui lòng đóng file ReportDSNhanVien.pdf",
                   "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}