using ModuloFormularios;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Correo cor = new Correo();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Console.WriteLine("yaaaaaaa");
           // Application.Run(new FrmSolicitudDeViaje());
            Conexion conect = new Conexion();
            // conect.query("insert into NotificacionRuta values ('rut2','2-jun-2019');");
            //conect.abrir();
           // conect.query("insert into NotificacionRuta values ('rut5','3-jun-2019')");
            simuladorLogin log = new simuladorLogin();
            log.ShowDialog();
            
                                                 
        }
    }
}
