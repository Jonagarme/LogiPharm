using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmVisorFactura : Form
    {
        private readonly DataTable _dtInfo;
        private readonly DataTable _dtDetalle;

        public FrmVisorFactura(DataTable dtInfo, DataTable dtDetalle)
        {
            InitializeComponent();
            _dtInfo = dtInfo;
            _dtDetalle = dtDetalle;
        }

        private void FrmVisorFactura_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            // 👇 Aquí estableces el RDLC embebido
            reportViewer1.LocalReport.ReportPath = "FacturaTicketP.rdlc";

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsInfo", _dtInfo));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsDetalle", _dtDetalle));

            this.reportViewer1.RefreshReport();
        }

    }
}
