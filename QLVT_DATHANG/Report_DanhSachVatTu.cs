using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLVT_DATHANG
{
    public partial class Report_DanhSachVatTu : DevExpress.XtraReports.UI.XtraReport
    {
        public Report_DanhSachVatTu()
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
        }

    }
}
