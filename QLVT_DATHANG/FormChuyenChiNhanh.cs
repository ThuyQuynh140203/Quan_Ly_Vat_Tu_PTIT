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
    public partial class FormChuyenChiNhanh : DevExpress.XtraEditors.XtraForm
    {
        public FormChuyenChiNhanh()
        {
            InitializeComponent();
        }

        private void FormChuyenChiNhanh_Load(object sender, EventArgs e)
        {
            chinhanhCB.DataSource = Program.bindingSource.DataSource;
            /*sao chep bingding source tu form dang nhap*/
            chinhanhCB.DisplayMember = "tencn";
            chinhanhCB.ValueMember = "tenserver";
            chinhanhCB.SelectedIndex = Program.brand;
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        public delegate void MyDelegate(string chiNhanh);
        public MyDelegate branchTransfer;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (chinhanhCB.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng chọn chi nhánh", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            /*Step 2*/
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn chuyển nhân viên này đi ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.OK)
            {
                branchTransfer(chinhanhCB.SelectedValue.ToString());
            }

            this.Dispose();
        }
    }
}