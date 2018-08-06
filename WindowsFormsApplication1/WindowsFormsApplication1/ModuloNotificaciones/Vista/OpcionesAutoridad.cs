using System;
using ModuloFormularios;
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
    public partial class OpcionesAutoridad : Form
    {
        string idau;
        public OpcionesAutoridad(String id)
        {
            InitializeComponent();
            idau = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            solicitudesPendientes pendientes = new solicitudesPendientes(idau);
            pendientes.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSolicitudDeViaje sol = new FrmSolicitudDeViaje();
            sol.ShowDialog();
        }

        private void OpcionesAutoridad_Load(object sender, EventArgs e)
        {

        }
    }
}
