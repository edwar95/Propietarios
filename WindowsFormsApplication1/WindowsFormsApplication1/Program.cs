using ModuloFormularios;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.ModuloReportesEstadisticos;

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

            //PRUEBAS UNITARIAS
            Application.Run(new FrmReporteHistorialKilometraje());
         
           


            //SIMULACION LOGIN

            /*
            Conexion conect = new Conexion();
            simuladorLogin log = new simuladorLogin();
            log.ShowDialog();
            */

            // conect.query("insert into NotificacionRuta values ('rut2','2-jun-2019');");
            //conect.abrir();
            // conect.query("insert into NotificacionRuta values ('rut5','3-jun-2019')");
        }
    }
}
