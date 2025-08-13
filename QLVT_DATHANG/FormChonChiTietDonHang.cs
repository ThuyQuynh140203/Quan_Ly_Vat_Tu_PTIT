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
    public partial class FormChonChiTietDonHang : DevExpress.XtraEditors.XtraForm
    {
        public FormChonChiTietDonHang()
        {
            InitializeComponent();
        }

        private void cTDDHBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsCTDDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FormChonChiTietDonHang_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'dS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.DS.CTDDH);

        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            DataRowView drv = ((DataRowView)(bdsCTDDH.Current));
            string maDonHang = drv["MasoDDH"].ToString().Trim();
            string maVatTu = drv["MaVT"].ToString().Trim();
            int soLuong = int.Parse(drv["SOLUONG"].ToString().Trim());
            int donGia = int.Parse(drv["DONGIA"].ToString().Trim());
            String maPhieuNhap = Program.maPhieuNhapDuocChon;

            /*Kiem tra xem ma don hang cua gcPhieuNhap co trung voi ma don hang duoc chon hay khong ?*/
            Program.maDonDatHangDuocChonChiTiet = maDonHang;
            if (Program.maDonDatHangDuocChon != Program.maDonDatHangDuocChonChiTiet)
            {
                MessageBox.Show("Bạn phải chọn chi tiết đơn hàng có mã đơn hàng là " + Program.maDonDatHangDuocChon, "Thông báo", MessageBoxButtons.OK);
                return;
            }

            String cauTruyVan =
                   "DECLARE	@result int " +
                   "EXEC @result = [dbo].[sp_KiemTraMaPhieuNhapVaMaVatTuTonTaiChua] '" +
                   maPhieuNhap + "','" + maVatTu + "'" +
                   "SELECT 'Value' = @result"; ;
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
            if (result == 1)
            {
                MessageBox.Show("Mã phiếu nhập và mã vật tư này đã được sử dụng", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            Program.maVatTuDuocChon = maVatTu;
            Program.soLuongVatTu = soLuong;
            Program.donGia = donGia;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}