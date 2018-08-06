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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(idautoridad);
            Conexion cn = new Conexion();
            cn.CargarDatos(dataGridView1);
        }
    }
}
