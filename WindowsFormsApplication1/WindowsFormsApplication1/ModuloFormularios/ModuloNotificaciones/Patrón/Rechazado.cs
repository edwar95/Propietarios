using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    public class Rechazado : Estado
    {

        Correo c = new Correo();

        public void notificarEstado(string correoDestinatario, string asunto, string solicitud)
        {
            c.enviarCorreoNotificacion(correoDestinatario, asunto, "Estado RECHAZADO:  "+solicitud);
        }
    }
}
