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
    public partial class FormChiTietSoLuongTriGiaNhapXuat : DevExpress.XtraEditors.XtraForm
    {
        public FormChiTietSoLuongTriGiaNhapXuat()
        {
            InitializeComponent();
        }

        private void FormChiTietSoLuongTriGiaNhapXuat_Load(object sender, EventArgs e)
        {
            this.loaiPhieuCB.SelectedIndex = 1;
            this.dateTuNgay.EditValue = "01-01-2014";
            this.dateDenNgay.EditValue = "01-09-2025";
        }

        private void xemtruocBTN_Click(object sender, EventArgs e)
        {
            string role = Program.role;
            string loaiPhieu = (loaiPhieuCB.SelectedItem.ToString() == "NHAP") ? "NHAP" : "XUAT";
            DateTime fromDate = dateTuNgay.DateTime;
            DateTime toDate = dateDenNgay.DateTime;

            Report_ChiTietSoLuongTriGiaHangHoaNhapXuat report = new Report_ChiTietSoLuongTriGiaHangHoaNhapXuat(role, loaiPhieu, fromDate, toDate);
            report.txtLoaiPhieu.Text = loaiPhieuCB.SelectedItem.ToString().ToUpper();
            report.txtTuNgay.Text = fromDate.ToString("dd-MM-yyyy");
            report.txtDenNgay.Text = toDate.ToString("dd-MM-yyyy");
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }

        private void inbaocaoBTN_Click(object sender, EventArgs e)
        {
            try
            {
                string role = Program.role;
                string loaiPhieu = (loaiPhieuCB.SelectedItem.ToString() == "NHAP") ? "NHAP" : "XUAT";
                DateTime fromDate = dateTuNgay.DateTime;
                DateTime toDate = dateDenNgay.DateTime;

                Report_ChiTietSoLuongTriGiaHangHoaNhapXuat report = new Report_ChiTietSoLuongTriGiaHangHoaNhapXuat(role, loaiPhieu, fromDate, toDate);
                report.txtLoaiPhieu.Text = loaiPhieu;
                report.txtTuNgay.Text = fromDate.ToString("dd-MM-yyyy");
                report.txtDenNgay.Text = toDate.ToString("dd-MM-yyyy");

                if (File.Exists(@"D:\Report_ChiTietSoLuongTriGiaHangHoaNhapXuat.pdf"))
                {
                    DialogResult dr = MessageBox.Show("File Report_ChiTietSoLuongTriGiaHangHoaNhapXuat.pdf tại ổ D đã có!\nBạn có muốn tạo lại?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        report.ExportToPdf(@"D:\Report_ChiTietSoLuongTriGiaHangHoaNhapXuat.pdf");
                        MessageBox.Show("File Report_ChiTietSoLuongTriGiaHangHoaNhapXuat.pdf đã được ghi thành công tại ổ D",
                        "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    report.ExportToPdf(@"D:\Report_ChiTietSoLuongTriGiaHangHoaNhapXuat.pdf");
                    MessageBox.Show("File Report_ChiTietSoLuongTriGiaHangHoaNhapXuat.pdf đã được ghi thành công tại ổ D",
                "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (IOException)
            {

            }
        }
    }
}