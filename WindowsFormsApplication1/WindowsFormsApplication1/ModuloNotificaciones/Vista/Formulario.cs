using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Formulario : Form
    {
        
        
       

        

        
        private void actualizar(ArrayList rech)
        {
          
           // ACTUALIZAR EN LA BD
        }


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiarTabla();
            cargarDatosTabla();
        }


        private void limpiarTabla()
        {
          
            vistaSolicitudes.Rows.Clear();
            vistaSolicitudes.Refresh();
        }

        
       

       

        private void notificacionUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            panel1.Visible = true;
            panel3.Visible = true;
            label13.Visible = false;
        }

        private void botonNotificacionUsuario_Click(object sender, EventArgs e)
        {
            NotificacionUsuario nu = new NotificacionUsuario();
            NotificacionUsuario nuser = new NotificacionUsuario();
            DateTime thisDay = DateTime.Today;
            //nu.fecha_envio = thisDay.ToString("dd/MM/yyyy");

            //MessageBox.Show(nu.enviarNotificacion());

            nuser.NotificacionSolicitudAprobada("sofig.0106@gmail.com", "Solcitud", "Su solicitud fue aprobada.");
        }

    

        private void vistaAprobadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

  
      
        

        public Formulario()
        {
            InitializeComponent();
            cargarDatosTabla();
            cargarDatosTabla2();
            
        }



        private void cargarDatosTabla()
        { 

            // CARGAR DATOS A TABLA
        }

        private void cargarDatosTabla2()
        {
            /*lista = learch.ioArchivos("Aprobadas.txt");
            int n;
            foreach (string[] a in lista)
            {
                n = vistaAprobadas.Rows.Add();
                for (int i = 0; i < 7; i++)
                {
                   
                    vistaAprobadas.Rows[n].Cells[i].Value = a[i];
                }
            }*/

        }

        private void formularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel3.Visible = false;
            label13.Visible = false;
        }

        private void verNotificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel3.Visible = false;
            label13.Visible = false;
        }

        /*Solicitud s = new Solicitud();
        public void escribirSolicitud()
        {
            s.escribirSolicitd();
        }*/
    }
}
