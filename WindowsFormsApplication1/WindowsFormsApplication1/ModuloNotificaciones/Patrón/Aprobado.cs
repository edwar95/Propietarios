using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyectov2.EnviarCorreo;

namespace Proyectov2.Patrón
{
    public class Aprobado : Estado
    {
        Correo c = new Correo();

        public void notificarEstado(string correoDestinatario, string asunto, string solicitud)
        {
            c.enviarCorreoNotificacion(correoDestinatario, asunto, "Estado APROBADO: " + solicitud);
        }
    }





}
