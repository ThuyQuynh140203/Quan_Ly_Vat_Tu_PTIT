using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class FormDanhSachVatTu : DevExpress.XtraEditors.XtraForm
    {
        public FormDanhSachVatTu()
        {
            InitializeComponent();
        }

        private void FormDanhSachVatTu_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet2.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);

        }

        private void btnXemTruoc_Click(object sender, EventArgs e)
        {
            //ReportDanhSachVatTu report = new ReportDanhSachVatTu();
            Report_DanhSachVatTu report = new Report_DanhSachVatTu();
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void btnInDSVT_Click(object sender, EventArgs e)
        {
            Report_DanhSachVatTu report = new Report_DanhSachVatTu();
            try
            {
                if (File.Exists(@"D:\ReportDanhSachVatTu.pdf"))
                {
                    DialogResult dr = MessageBox.Show("File ReportDanhSachVatTu.pdf tại ổ D đã có!\nBạn có muốn tạo lại?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        report.ExportToPdf(@"D:\ReportDanhSachVatTu.pdf");
                        MessageBox.Show("File ReportDSNhanVien.pdf đã được ghi thành công tại ổ D",
                "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    report.ExportToPdf(@"D:\ReportDanhSachVatTu.pdf");
                    MessageBox.Show("File ReportDSNhanVien.pdf đã được ghi thành công tại ổ D",
                "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Vui lòng đóng file ReportDanhSachVatTu.pdf",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}