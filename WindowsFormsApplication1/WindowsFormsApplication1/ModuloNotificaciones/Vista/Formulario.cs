using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Proyectov2.LeerArchivos;
using Proyectov2.CarpetaSolicitud;
using System.Collections;
using Proyectov2.CarpetaNotificaciones;

namespace Proyectov2.Vista
{
    public partial class Formulario : Form
    {
        int index = 0; // con este indice se seleccionara una solicitud de la tabla, se la leerá, se la enviará a la autorización y se analizará si se aprueba o no.
        string idAnalizada = "";
        Leerfichero learch = new Leerfichero();
        LinkedList<string[]> lista = new LinkedList<string[]>();
        Autorizacion autorizacion = new Autorizacion();
        public String id,remitente,destino,noPasajeros,motivo,fechaSalida,horaSalida,fechaSolicitud;
        public bool enviar = false;
        int indexA = 0;
        
        public String ID
        {
            get { return id; }
            set { id = value; }
        }
        public String Remitente
        {
            get{ return remitente; }
            set{ remitente = value; }
        }

        public String Destino
        {
            get{ return destino;}
            set{ destino = value;}
        }

        public String NoPasajeros
        {
            get { return noPasajeros; }
            set { noPasajeros = value; }
        }
        public String Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }

        public String FechaSalida
        {
            get { return fechaSalida; }
            set { fechaSalida = value; }
        }
              

        public String HoraSalida
        {
            get { return horaSalida; }
            set { horaSalida = value; }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textid.Text = "";
            textRemitente.Text = "";
            textDestino.Text = "";
            textPasajeros.Text = "";
            textMotivo.Text = "";
            textFechaSalida.Text = "";
            textHoraSalida.Text = "";
            textFechaEmision.Text = "";
            enviar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList recha =learch.leerA2("Viaje.txt");
            
            string[] seleccionada;               
            seleccionada=learch.busqueda(idAnalizada);
            autorizacion.autorizacion(seleccionada);
            if (autorizacion.estado)
            {
                Console.WriteLine("he sido aprobadaaa"+"mi inde       ::"+ index);
                Solicitud sol = new Solicitud();
               


                MessageBox.Show(" CUMPLE LOS REQUISITOS DE APROBACION" , "My Application",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                Console.WriteLine("AHORA VOY A ACTUALIZAR LA LISTA DE PENDIENTES" + index);
                actualizar(recha);
                Console.WriteLine("YA ACABEEEEEEE" + index);
                sol.state.notificarEstado("andresbalcazar2020@gmail.com","NotificacionEstado","ESTADO SOLICITUD");

               

            }
            else
            {
                Console.WriteLine("he sido rechazada" + "mi inde       ::" + index);
                MessageBox.Show("NO CUMPLE LOS REQUISITOS DE APROBACION", "My Application",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
          
       
        }
        private void actualizar(ArrayList rech)
        {
          
            int cont = 0;
            if (System.IO.File.Exists(@"C:\Users\sofi-\OneDrive\Escritorio\ProyectoPropietarios\Unido\Proyectov2\Proyectov2\bin\Debug\Viaje.txt"))
            {
                Console.WriteLine("holkaaaaaaaaaaaaaaaaa voy a actualizaaaaaaaaaaaaaaaar");
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(@"C:\Users\sofi-\OneDrive\Escritorio\ProyectoPropietarios\Unido\Proyectov2\Proyectov2\bin\Debug\Viaje.txt");
                    foreach (string val in rech)
                    {
                        Console.WriteLine("index: "+ index+"\n cont:"+ cont);
                        if (cont != index)
                        {
                            Console.WriteLine("voy a escribir \n"+ val);
                            learch.escribirArchivo(val, "Viaje.txt");
                        }
                        cont++;
                        
                    }

                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            idAnalizada = "";
            limpiarTabla();
            cargarDatosTabla();
        }


        private void limpiarTabla()
        {
          
            vistaSolicitudes.Rows.Clear();
            vistaSolicitudes.Refresh();
        }

        public String FechaSolicitud
        {
            get { return fechaSolicitud; }
            set { fechaSolicitud = value; }
        }

        private void Formulario_Load(object sender, EventArgs e)
        {

        }

        private void vistaAprobadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexA = e.RowIndex;
            

        }

        private void notificacionUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = true;
            panel3.Visible = true;
            label13.Visible = false;
        }

        private void botonNotificacionUsuario_Click(object sender, EventArgs e)
        {
            NotificacionUsuario nu = new NotificacionUsuario();
            NotificacionUsuario nuser = new NotificacionUsuario();
            DateTime thisDay = DateTime.Today;
            nu.destinatario = vistaAprobadas.Rows[indexA].Cells[1].Value.ToString();
            nu.fecha_envio = thisDay.ToString("dd/MM/yyyy");

            MessageBox.Show(nu.enviarNotificacion());

            nuser.NotificacionSolicitudAprobada("sofig.0106@gmail.com", "Solcitud", "Su solicitud fue aprobada.");
        }

        public bool Enviar
        {
            get { return enviar; }
            set { enviar= value; }
        }

        private void vistaAprobadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void botonEnviar_Click(object sender, EventArgs e)
        {
            id = textid.Text;
            remitente = textRemitente.Text;
            destino = textDestino.Text;
            noPasajeros = textPasajeros.Text;
            motivo = textMotivo.Text;
            fechaSalida = textFechaSalida.Text;
            horaSalida = textHoraSalida.Text;
            fechaSolicitud = textFechaEmision.Text;
            enviar = true;
            Solicitud sol = new Solicitud();
            sol.escribirSolicitd(id, remitente,destino,noPasajeros,motivo,fechaSalida,horaSalida,fechaSolicitud);
           

        }

      
         private void vistaSolicitudes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index != -1)
            {
                idAnalizada = vistaSolicitudes.Rows[index].Cells[0].Value.ToString();
            }

          
        }

        public Formulario()
        {
            InitializeComponent();
            cargarDatosTabla();
            cargarDatosTabla2();
            
        }



        private void cargarDatosTabla()
        { ConsultasSolicitud vr = new ConsultasSolicitud();
            /*lista=learch.ioArchivos("Viaje.txt");
            int n;
            foreach(string[] a in lista)
            {
                n = vistaSolicitudes.Rows.Add();
                for (int i = 0; i <=9; i++)
                {
                    //Console.WriteLine(a[i]);
                    vistaSolicitudes.Rows[n].Cells[i].Value = a[i];
                }
            }*/
            vistaSolicitudes.DataSource = vr.tblSolicitudVr();
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
            ConsultasSolicitud auth = new ConsultasSolicitud();
            vistaAprobadas.DataSource = auth.tblSolicitudApr();

        }

        private void formularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
            label13.Visible = false;
        }

        private void verNotificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
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
