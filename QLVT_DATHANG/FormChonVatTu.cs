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
    public partial class FormChonVatTu : DevExpress.XtraEditors.XtraForm
    {
        public FormChonVatTu()
        {
            InitializeComponent();
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsVT.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void FormChonVatTu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.Vattu' table. You can move, or remove it, as needed.
            DS.EnforceConstraints = false;
  
            this.vattuTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vattuTableAdapter.Fill(this.DS.Vattu);

        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            string maVatTu = ((DataRowView)bdsVT.Current)["MAVT"].ToString();
            int soLuongVatTu = int.Parse(((DataRowView)bdsVT.Current)["SOLUONGTON"].ToString());

            Program.maVatTuDuocChon = maVatTu;
            Program.soLuongVatTu = soLuongVatTu;

            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}