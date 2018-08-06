using Microsoft.Reporting.WinForms;
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

namespace WindowsFormsApplication1.ModuloReportesEstadisticos
{
    public partial class FrmReporteHistorialKilometraje : Form
    {
        public FrmReporteHistorialKilometraje()
        {
            InitializeComponent();
        }

        private void FrmReporteHistorialKilometraje_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSetHistorialKilometraje dsKilometraje = new DataSetHistorialKilometraje();
            SqlConnection cn = new SqlConnection(new Conexion().stringConexion);
            SqlDataAdapter da = new SqlDataAdapter("SELECT fecha, kilometraje, vehiculo.idVehiculo, placavehiculo FROM HistorialKilometraje join vehiculo on HistorialKilometraje.idVehiculo = vehiculo.idvehiculo order BY vehiculo.idVehiculo, kilometraje", cn);
            da.Fill(dsKilometraje, dsKilometraje.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("DataSetHistorialKilometraje", dsKilometraje.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
