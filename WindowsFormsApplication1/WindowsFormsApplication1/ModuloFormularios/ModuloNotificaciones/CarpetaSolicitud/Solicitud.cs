using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Solicitud
    {
        

        public Estado state;
        public String idSolicitud;
        public String destinatario="Autoridad";
        public bool aprobada = false;

        public Solicitud()
        {
           
         
            
            this.state=new Pendiente();
            

            

        }
        public void listener()
        {
           
        }

        public Estado State
        {
            get { return state; }
            set { state = value; }
        }
        public String ID
        {
            get { return idSolicitud;}
            set { idSolicitud = value; }
        }

      
        public String Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }

        
        public bool Aprobada
        {
            get{return aprobada;}
            set{aprobada = value;}
        }


        public void escribirSolicitd(string id, string remitente, string destino, string pasajeros, string motivo, string fsalida, string hsalida, string fsolicitud)
        {
        }


        private String estadoSolicitud()
        {
            if (this.aprobada)
            {
                return "aprobada";
            }
            else
            {
                return "rechazada";
            }
        }








       // private HashSet<InterfazObservador> _observadores = new HashSet<InterfazObservador>();

        




        /*
        public void adjuntar(InterfazObservador obs)
        {
            _observadores.Add(obs);
        }

        public void des_adjuntar(InterfazObservador obs)
        {
            _observadores.Remove(obs);
        }

        public void informar()
        {
            
            _observadores.ToList().ForEach(o => o.confirmarAprobacion(aprobada));

        }*/
    }
}
