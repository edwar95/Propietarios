using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Reserva
    {
        private int numeroPersonas;
        private string prioridad;
        private string fechaInicio;
        private string fechaFin;
        
        

        public int NumeroPersonas
        {
            get
            {
                return numeroPersonas;
            }

            set
            {
                numeroPersonas = value;
            }
        }

        public string Prioridad
        {
            get
            {
                return prioridad;
            }

            set
            {
                prioridad = value;
            }
        }

        public string FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }

        public string FechaFin
        {
            get
            {
                return fechaFin;
            }

            set
            {
                fechaFin = value;
            }
        }

        public void confirmarViaje()
        {
            Viaje viaje = new Viaje();
            viaje.asignarChofer(this.NumeroPersonas);
            viaje.asignarVehiculo(this.NumeroPersonas);
            viaje.asignarFecha(this.FechaInicio, this.FechaFin);

            Notificacion notificacion = new Notificacion();
            notificacion.NotificacionReserva = "reserva realizada";
            MessageBox.Show("Reserva realizada", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

    }
}
