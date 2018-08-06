using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class solicitudesPendientes : Form
    {
        string idautoridad;
        public solicitudesPendientes(string idauto)
        {
            idautoridad = idauto;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String x = dataGridView1.CurrentCell.Value.ToString();
            MessageBox.Show(x);
            Conexion cn = new Conexion();
            cn.query("update solicitudreserva set estadosolicitud='aprobada1' where idsolicitudreserva='" + x + "'");
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();

            DataTable dtaux = cn.Buscar(idautoridad, "select  idsolicitante, facultad, tipo from solicitante where idsolicitante= '" + idautoridad + "'");
            DataRow row = dtaux.Rows[0];
            string x;
            string tipo = Convert.ToString(row["tipo"]);
            string facultad = Convert.ToString(row["facultad"]);
           // MessageBox.Show("  select *from SolicitudReserva where idSolicitante in (select idSolicitante from Solicitante where facultad ='" + facultad + "'");
            cn.CargarDatos("  select *from SolicitudReserva where estadosolicitud = 'en espera' AND idSolicitante in (select idSolicitante from Solicitante where facultad ='" + facultad + "') ", dataGridView1);
        }
    }
}
