using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyectov2.EnviarCorreo;

namespace Proyectov2.CarpetaNotificaciones
{
    class NotificacionMantenimiento
    {

        /*private double kilometraje;
        private string estado_banda;
        private string tiempo_uso;*/
        Correo c = new Correo();
        public void notificacionMantenimiento(string correo,string placa, double kilometraje,string estado_banda,string tiempo_uso)
        {
            c.enviarCorreoNotificacion(correo, "NotificacionMantenimiento", "Mantenimiento inmediato para el vehiculo con placa: " + placa + " tiene kilometraje: "+kilometraje+" , estado de banda: "+estado_banda+" y tiempo de uso: "+tiempo_uso);
        }
    }
}
