using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.ModuloFormularios
{
    class CalificacionDeServicio
    {
        //Holiii cariito :),  espero que funcione 

        ///dadadada
        private string puntualSalida;
        private string limpiezaVehiculo;
        private string puntualAlDestino;
        private string puntualAlRetorno;
        private string comentariosAdicionales;
        private Conexion cnx = new Conexion();

        public CalificacionDeServicio(string puntualSalida, string limpiezaVehiculo, string puntualAlDestino, string puntualAlRetorno, string comentariosAdicionales)
        {
            this.puntualSalida = puntualSalida;
            this.limpiezaVehiculo = limpiezaVehiculo;
            this.puntualAlDestino = puntualAlDestino;
            this.puntualAlRetorno = puntualAlRetorno;
            this.comentariosAdicionales = comentariosAdicionales;
        }

        public string getPuntualSalida()
        {
            return this.puntualSalida;
        }

        public void setPuntualSalida(string puntualSalida)
        {
            this.puntualSalida = puntualSalida;

        }

        public string getLimpiezaVehiculo()
        {
            return this.limpiezaVehiculo;
        }

        public void setLimpiezaVehiculo(string limpiezaVehiculo)
        {
            this.limpiezaVehiculo = limpiezaVehiculo;

        }

        public string getPuntualAlDestino()
        {
            return this.puntualAlDestino;
        }

        public void setPuntualAlDestino(string puntualAlDestino)
        {
            this.puntualAlDestino = puntualAlDestino;

        }

        public string getPuntualAlRetorno()
        {
            return this.puntualAlRetorno;
        }

        public void setPuntualAlRetorno(string puntualAlRetorno)
        {
            this.puntualAlRetorno = puntualAlRetorno;

        }

        public string getComentariosAdicionales()
        {
            return this.comentariosAdicionales;
        }

        public void setComentariosAdicionales(string comentariosAdicionales)
        {
            this.comentariosAdicionales = comentariosAdicionales;

        }







    }
}
