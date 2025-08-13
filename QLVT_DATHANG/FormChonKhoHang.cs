using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class FormChonKhoHang : DevExpress.XtraEditors.XtraForm
    {
        public FormChonKhoHang()
        {
            InitializeComponent();
        }

        private void khoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKho.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FormChonKhoHang_Load(object sender, EventArgs e)
        {
            
            DS.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet2.Kho' table. You can move, or remove it, as needed.
            this.khoTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khoTableAdapter.Fill(this.DS.Kho);

        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            string maKhoHang = ((DataRowView)bdsKho.Current)["MAKHO"].ToString();
            Program.maKhoDuocChon = maKhoHang;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}