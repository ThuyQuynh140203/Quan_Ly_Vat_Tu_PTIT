using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace QLVT_DATHANG
{
    public partial class Report_ChiTietSoLuongTriGiaHangHoaNhapXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public Report_ChiTietSoLuongTriGiaHangHoaNhapXuat(String role, String loaiPhieu, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.sqlDataSource1.Queries[0].Parameters[0].Value = role;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = loaiPhieu;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = fromDate;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = toDate;

            this.sqlDataSource1.Fill();
        }

    }
}
