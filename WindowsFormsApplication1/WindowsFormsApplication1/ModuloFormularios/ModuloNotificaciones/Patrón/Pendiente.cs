using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    class Pendiente : Estado
    {
        Correo c = new Correo();

        public void notificarEstado(string correoDestinatario, string asunto, string solicitud)
        {
            //Console.Write("ESTADO PENDIENT"+ solicitud);
            c.enviarCorreoNotificacion(correoDestinatario, asunto, "Estado PENDIENTE:  " + solicitud);
           
        }
    }
}
