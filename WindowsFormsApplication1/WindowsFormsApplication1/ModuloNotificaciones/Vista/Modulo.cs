using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyectov2.Vista
{
    public partial class Modulo : Form
    {
        public Modulo()
        {
            InitializeComponent();
        }

        private void notificaciónUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           panel2.Visible = false;
           panel3.Visible = false;
           panel1.Visible = true;
           
        }

        private void notificaciónMantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
                       
           panel3.Visible = false;

        }

        private void notifiaciónRutaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        /*private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }*/


    }
}
