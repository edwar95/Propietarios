using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyectov2.EnviarCorreo;


namespace Proyectov2.CarpetaNotificaciones
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
