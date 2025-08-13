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
    public partial class FormTaoTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public FormTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private string taiKhoan = "";
        private string matKhau = "";
        private string maNhanVien = "";
        private string vaiTro = "";

        private void FormTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            if (Program.role == "CONGTY")
            {
                vaiTro = "CONGTY";
                chinhanhRD.Enabled = false;
                userRD.Enabled = false;
            }
            else if (Program.role == "CHINHANH")
            {
                chinhanhRD.Enabled = true;
                userRD.Enabled = true;
            }
            else
            {
                chinhanhRD.Enabled = false;
                userRD.Enabled = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnChonNhanVien_Click(object sender, EventArgs e)
        {
            FormChonNhanVien form = new FormChonNhanVien();
            form.ShowDialog();
            txtMANV.Text = Program.maNhanVienDuocChon;
        }

        private bool kiemTraDuLieuDauVao()
        {
            if (txtMANV.Text == "")
            {
                MessageBox.Show("Thiếu mã nhân viên", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

            if (txtMATKHAU.Text == "")
            {
                MessageBox.Show("Thiếu mật khẩu", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

            if (txtXACNHAN.Text == "")
            {
                MessageBox.Show("Thiếu mật khẩu xác nhận", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

            if (txtMATKHAU.Text != txtXACNHAN.Text)
            {
                MessageBox.Show("Mật khẩu không khớp với mật khẩu xác nhận", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            bool ketQua = kiemTraDuLieuDauVao();
            if (ketQua == false) return;

            taiKhoan = Program.hoTen;
            matKhau = txtMATKHAU.Text;
            maNhanVien = Program.maNhanVienDuocChon;

            if (Program.role == "CHINHANH")
            {
                vaiTro = (chinhanhRD.Checked == true) ? "CHINHANH" : "USER";
            }


            Console.WriteLine(taiKhoan);
            Console.WriteLine(matKhau);
            Console.WriteLine(maNhanVien);
            Console.WriteLine(vaiTro);


            String cauTruyVan =
                    "EXEC sp_TaoTaiKhoan '" + taiKhoan + "' , '" + matKhau + "', '"
                    + maNhanVien + "', '" + vaiTro + "'";

            SqlCommand sqlCommand = new SqlCommand(cauTruyVan, Program.conn);
            try
            {


                Program.myReader = Program.ExecSqlDataReader(cauTruyVan);
                /*khong co ket qua tra ve thi ket thuc luon*/
                if (Program.myReader == null)
                {
                    return;
                }

                MessageBox.Show("Đăng kí tài khoản thành công\n\nTài khoản: " + taiKhoan + "\nMật khẩu: " + matKhau + "\n Mã Nhân Viên: " + maNhanVien + "\n Vai Trò: " + vaiTro, "Thông Báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thực thi database thất bại!\n\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}