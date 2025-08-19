using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace LogiPharm.Presentacion
{
    public partial class FrmVisorCierre : Form
    {
        // Variable privada para guardar la tabla con los datos del cierre
        private DataTable _dtInfo;

        // Constructor modificado para recibir los datos
        public FrmVisorCierre(DataTable dtInfo)
        {
            InitializeComponent();
            _dtInfo = dtInfo;
        }

        private void FrmVisorCierre_Load(object sender, EventArgs e)
        {
            // 1. Limpiamos cualquier dato anterior
            reportViewer1.LocalReport.DataSources.Clear();

            // 2. Le decimos al visor qué archivo de diseño (.rdlc) usar
            // IMPORTANTE: Asegúrate de que esta ruta coincida con el nombre de tu proyecto y la ubicación del archivo.
            reportViewer1.LocalReport.ReportEmbeddedResource = "LogiPharm.Presentacion.rptCierreCaja.rdlc";

            // 3. Creamos un origen de datos, conectando nuestros datos (_dtInfo) con el DataSet del reporte (dsInfo)
            ReportDataSource rds = new ReportDataSource("dsInfo", _dtInfo);

            // 4. Añadimos el origen de datos al reporte
            reportViewer1.LocalReport.DataSources.Add(rds);

            // 5. Actualizamos y mostramos el reporte
            reportViewer1.RefreshReport();
        }
    }
}