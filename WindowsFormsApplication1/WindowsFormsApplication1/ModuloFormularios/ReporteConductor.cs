using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.ModuloFormularios
{
    class ReporteConductor
    {
        private string cedulaConductor;
        private string nombreCompletoConductor;
        private string inconvenientesViaje;
        private string descripcionInconveniente;
        private float dineroGastadoEnGasolina;
        private string comportameientoPasajeros;

        public ReporteConductor(string cedulaConductor, string nombreCompletoConductor, string inconvenientesViaje, string descripcionInconveniente, float dineroGastadoEnGasolina, string comportameientoPasajeros)
        {
            this.cedulaConductor = cedulaConductor;
            this.nombreCompletoConductor = nombreCompletoConductor;
            this.inconvenientesViaje = inconvenientesViaje;
            this.descripcionInconveniente = descripcionInconveniente;
            this.dineroGastadoEnGasolina = dineroGastadoEnGasolina;
            this.comportameientoPasajeros = comportameientoPasajeros;
        }

        public string getCedulaConductor()
        {
            return this.cedulaConductor;
        }

        public void setCedulaConductor(string cedulaConductor)
        {
            this.cedulaConductor = cedulaConductor;

        }

        public string getNombreCompletoConductor()
        {
            return this.nombreCompletoConductor;
        }

        public void setNombreCompletoConducto(string nombreCompletoConductor)
        {
            this.nombreCompletoConductor = nombreCompletoConductor;

        }

        public string getInconvenientesViaje()
        {
            return this.inconvenientesViaje;
        }


        public void setInconvenientesViaje(string inconvenientesViaje)
        {
            this.inconvenientesViaje = inconvenientesViaje;

        }

        public string getDescripcionInconveniente()
        {
            return this.descripcionInconveniente;
        }


        public void setDescripcionInconveniente(string descripcionInconveniente)
        {
            this.descripcionInconveniente = descripcionInconveniente;

        }

        public string getComportameientoPasajeros()
        {
            return this.comportameientoPasajeros;
        }

        public void setComportameientoPasajeros(string comportameientoPasajeros)
        {
            this.comportameientoPasajeros = comportameientoPasajeros;

        }

        public float getDineroGastadoEnGasolina()
        {
            return this.dineroGastadoEnGasolina;
        }

        public void setDineroGastadoEnGasolina(float dineroGastadoEnGasolina)
        {
            this.dineroGastadoEnGasolina = dineroGastadoEnGasolina;

        }

    }
}
