using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Proyectov2.Vista;
using System.IO;
using Proyectov2.LeerArchivos;
using System.Windows.Forms;
using Proyectov2.Patrón;

namespace Proyectov2.CarpetaSolicitud
{
    class Solicitud
    {

        Leerfichero learch = new Leerfichero();

        public Estado state;
        public String idSolicitud;
        public String destinatario="Autoridad";
        public bool aprobada = false;
        Formulario formulario; //= new Formulario();

        public Solicitud()
        {
           
         
            
            this.state=new Pendiente();
            

            

        }
        public void listener()
        {
            formulario = new Formulario();
            formulario.ShowDialog();
           
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
            learch.escribirArchivo(id+","+remitente + "," + destino+","+
               pasajeros+","+motivo+","+fsalida+","+
                hsalida+","+fsolicitud+","+"rechazada","Solicitud.txt");
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
