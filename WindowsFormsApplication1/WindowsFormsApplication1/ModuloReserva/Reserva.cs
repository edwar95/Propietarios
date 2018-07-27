﻿using System;
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

        private int idReserva;
        private int idMotivoViaje;
        private int idCategoriaUsuario;//categoria usuario
        private int numeroPersonas;
        private string fechaInicio;
        private string fechaFin;
        private string estado;
        
        

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

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public int IdReserva
        {
            get
            {
                return idReserva;
            }

            set
            {
                idReserva = value;
            }
        }

        public int IdMotivoViaje
        {
            get
            {
                return idMotivoViaje;
            }

            set
            {
                idMotivoViaje = value;
            }
        }

        public int IdCategoriaUsuario
        {
            get
            {
                return idCategoriaUsuario;
            }

            set
            {
                idCategoriaUsuario = value;
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
