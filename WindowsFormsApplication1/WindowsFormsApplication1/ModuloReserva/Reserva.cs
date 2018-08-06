using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private int idSolicitante;
        ConexionSQL coneccion;
        Viaje viaje;

        public Reserva()
        {
            
            coneccion = new ConexionSQL();
            viaje = new Viaje();

        }


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

        public int IdSolicitante
        {
            get
            {
                return idSolicitante;
            }

            set
            {
                idSolicitante = value;
            }
        }

        public bool confirmarViaje()
        {
            
            viaje.asignarFecha(this.FechaInicio, this.FechaFin);
            viaje.asignarChofer(this.NumeroPersonas);
            viaje.asignarVehiculo(this.NumeroPersonas);


            if(viaje.validarChoferVehiculo(viaje.asignarChofer(this.NumeroPersonas), viaje.asignarVehiculo(this.NumeroPersonas)))
            {
                registrarReservaAprovada();
            }

            return viaje.validarChoferVehiculo(viaje.asignarChofer(this.NumeroPersonas), viaje.asignarVehiculo(this.NumeroPersonas));

        }

        public void registrarReservaAprovada()
        {
            this.estado = "aprobada2";
            coneccion.Conectar();
            SqlCommand cmd = new SqlCommand("INSERT INTO RESERVAAPROBADA ( IDCHOFER,IDVEHICULO,IDMOTIVOVIAJE,IDCATEGORIAUSUARIO,NUMEROPERSONAS,FECHASALIDA,FECHARETORNO,ESTADOSOLICITUD) VALUES (" + viaje.Chofer.IdChofer+ "," + viaje.Vehiculo.IdVehiculo + "," + this.idMotivoViaje +"," + this.idCategoriaUsuario + "," + this.numeroPersonas +",convert(datetime, '" + this.fechaInicio + "', 102),convert(datetime, '" + this.fechaFin + "', 102), '" + this.estado+ "') ", coneccion.getConnection());
            cmd.ExecuteNonQuery();
            coneccion.Desconectar();

        }
        


    }
}
