using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{

    
    class NotificacionUsuario : Notificacion
    {
                Correo c = new Correo();

        public void NotificacionSolicitudAprobada(string correo, string asunto, string cuerpo)
        {
            c.enviarCorreoNotificacion(correo, asunto, cuerpo);
        }
      }
}
