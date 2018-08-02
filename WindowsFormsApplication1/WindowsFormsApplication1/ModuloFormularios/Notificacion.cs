using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectov2.CarpetaNotificaciones
{
    class Notificacion
    {
        public String idNotificacion;
        public String destinatario;
        public String fecha_envio;

        public String IdNotificacion
        {
            get { return idNotificacion; }
            set { idNotificacion = value; }

        }

        public String Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }

        }

        public String Fecha
        {
            get { return fecha_envio; }
            set { fecha_envio = value; }

        }



        /*public string IdNotificacion { get => idNotificacion; set => idNotificacion = value; }
        public string Fecha_envio { get => fecha_envio; set => fecha_envio = value; }
        public string Destinatario { get => destinatario; set => destinatario = value; }*/
        /*
        public Notificacion(String idNotificacion, String destinatario, String fecha_envio)
        {
            this.idNotificacion = idNotificacion;
            this.destinatario = destinatario;
            this.fecha_envio = fecha_envio;
        }*/

        public String enviarNotificacion()
        {
            String notif =  this.destinatario + "-" + this.fecha_envio +"**Su solicitud fue aprobada**";
            return notif;
        }

    }
}
