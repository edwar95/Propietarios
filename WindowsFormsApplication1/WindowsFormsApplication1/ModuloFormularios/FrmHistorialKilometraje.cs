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

namespace ModulosG4
{
    public partial class FrmHistorialKilometraje : Form
    {
        public FrmHistorialKilometraje()
        {
            InitializeComponent();
        }

        private void FrmHistorialKilometraje_Load(object sender, EventArgs e)
        {
            DataSetKilometraje dsKilometraje = new DataSetKilometraje();
            string cs = @"data source = isaac-pc ; initial catalog = sistemaAAP ; integrated security = SSPI";
            SqlConnection cn = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HistorialKilometraje", cn);
            da.Fill(dsKilometraje, dsKilometraje.Tables[0].TableName);
            ReportDataSource rds = new ReportDataSource("HistorialKilometraje", dsKilometraje.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
