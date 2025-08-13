using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLVT_DATHANG
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FormDangNhap));
            if (frm != null) frm.Activate();
            else
            {
                FormDangNhap f = new FormDangNhap();
                //f.MdiParent = this;
                f.Show();
            }
        }

        public void enableButtons()
        {

            this.btnDangNhap.Enabled = false;
            this.btnDangXuat.Enabled = true;

            this.danhmuc.Visible = true;
            this.baocao.Visible = true;
            this.btnTaoTaiKhoan.Enabled = true;
            this.nghiepvu.Visible = true;

            if (Program.role == "USER")
            {
                this.btnTaoTaiKhoan.Enabled = false;
            }
        }

        private void logout()
        {
            foreach (Form f in this.MdiChildren)
                f.Dispose();
        }

        private void dangxuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            logout();
            btnDangNhap.Enabled = true;
            btnDangXuat.Enabled = false;

            danhmuc.Visible = false;
            baocao.Visible = false;
            nghiepvu.Visible = false;
            Form f = this.CheckExists(typeof(FormDangNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormDangNhap form = new FormDangNhap();
                form.MdiParent = this;
                form.Show();
            }

            Program.formMain.MANV.Text = "MÃ NHÂN VIÊN:";
            Program.formMain.HOTEN.Text = "HỌ TÊN:";
            Program.formMain.NHOM.Text = "VAI TRÒ:";
            //pageTaiKhoan.Visible = false;
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            logout();

            btnDangNhap.Enabled = true;
            btnDangXuat.Enabled = false;

            //pageNhapXuat.Visible = false;
            //pageBaoCao.Visible = false;
            //pageTaiKhoan.Visible = false;
            danhmuc.Visible = false;
            baocao.Visible = false;
            nghiepvu.Visible = false;

            Form f = this.CheckExists(typeof(FormDangNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormDangNhap form = new FormDangNhap();
                //form.MdiParent = this;
                form.Show();
            }

            Program.formMain.MANV.Text = "MÃ NHÂN VIÊN:";
            Program.formMain.HOTEN.Text = "HỌ TÊN:";
            Program.formMain.NHOM.Text = "VAI TRÒ:";
        }

        private void nhanvien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(FormNhanVien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormNhanVien form = new FormNhanVien();
                form.MdiParent = this;
                form.Show();

            }
        }

        private void vattu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(FormVatTu));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormVatTu form = new FormVatTu();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void khohang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(FormKhoHang));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormKhoHang form = new FormKhoHang();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(FormDonDatHang));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormDonDatHang form = new FormDonDatHang();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnLPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(FormPhieuNhap));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormPhieuNhap form = new FormPhieuNhap();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnLPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(FormPhieuXuat));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormPhieuXuat form = new FormPhieuXuat();
                form.MdiParent = this;
                form.Show();
            }
        }

        private void btnInDSNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(FormDanhSachNhanVien));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormDanhSachNhanVien form = new FormDanhSachNhanVien();
                form.Show();
            }
        }

        private void btnInDSVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(FormDanhSachVatTu));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormDanhSachVatTu form = new FormDanhSachVatTu();
                form.Show();
            }
        }

        private void btnChiTietTGNXHH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = this.CheckExists(typeof(FormChiTietSoLuongTriGiaNhapXuat));
            if (f != null)
            {
                f.Activate();
            }
            else
            {
                FormChiTietSoLuongTriGiaNhapXuat form = new FormChiTietSoLuongTriGiaNhapXuat();
                form.Show();
            }
        }
    }   
}
