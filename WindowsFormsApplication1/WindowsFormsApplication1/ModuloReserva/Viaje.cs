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
    class Viaje
    {
        Fecha fecha;
        Vehiculo vehiculo;
        Chofer chofer;
        ConexionSQL coneccion;

        internal Chofer Chofer
        {
            get
            {
                return chofer;
            }

            set
            {
                chofer = value;
            }
        }

        internal Vehiculo Vehiculo
        {
            get
            {
                return vehiculo;
            }

            set
            {
                vehiculo = value;
            }
        }

        public Viaje()
        {
            fecha = new Fecha();
            Vehiculo = new Vehiculo();
            Chofer = new Chofer();
            coneccion = new ConexionSQL();

        }

        public bool asignarChofer(int NumeroPersonas)
        {

            coneccion.Conectar();

            if (NumeroPersonas <= 5)
            {
                SqlCommand cmd = new SqlCommand("select * from CHOFER where TIPOLICENCIA = 'B' and IDCHOFER not in (select IDCHOFER from RESERVAAPROBADA where (convert(datetime, '" + fecha.FechaInicio+ "', 102) between FECHASALIDA and FECHARETORNO) and(convert(datetime, '" + fecha.FechaFin + "', 102) between FECHASALIDA and FECHARETORNO) )", coneccion.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    Console.WriteLine("No hay choferes disponibles");
                }
                else
                {
                    Chofer.IdChofer = reader.GetInt32(0);
                    Chofer.NombreChofer = reader.GetString(3);
                    Chofer.ApellidoChofer = reader.GetString(2);
                    Chofer.CedulaChofer = reader.GetString(1);
                    return true;
                }
                coneccion.Desconectar();
            }
            else if (NumeroPersonas > 5)
            {
                SqlCommand cmd = new SqlCommand("select * from CHOFER where TIPOLICENCIA = 'C' and IDCHOFER not in (select IDCHOFER from RESERVAAPROBADA where (convert(datetime, '" + fecha.FechaInicio + "', 102)between FECHASALIDA and FECHARETORNO) and(convert(datetime, '" + fecha.FechaFin + "', 102)between FECHASALIDA and FECHARETORNO) )", coneccion.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    Console.WriteLine("No hay choferes disponibles");
                }
                else
                {
                    Chofer.IdChofer = reader.GetInt32(0);
                    Chofer.NombreChofer = reader.GetString(3);
                    Chofer.ApellidoChofer = reader.GetString(2);
                    Chofer.CedulaChofer = reader.GetString(1);
                    return true;
                }
                coneccion.Desconectar();

            }
            return false;

        }


        public bool asignarVehiculo(int NumeroPersonas)
        {
            coneccion.Conectar();

            if (NumeroPersonas <= 5)
            {
                SqlCommand cmd = new SqlCommand("select * from VEHICULO where TIPOVEHICULO = 'auto' and IDVEHICULO not in (select IDVEHICULO from RESERVAAPROBADA where (convert(datetime, '" + fecha.FechaInicio + "', 102)between FECHASALIDA and FECHARETORNO) and(convert(datetime, '" + fecha.FechaFin + "', 102)between FECHASALIDA and FECHARETORNO) )", coneccion.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    Console.WriteLine("No hay vehiculos disponibles");
                }
                else
                {
                    Vehiculo.IdVehiculo = reader.GetInt32(0);
                    Vehiculo.Tipo = reader.GetString(1);
                    Vehiculo.Placa = reader.GetString(2);
                    return true;
                }
                coneccion.Desconectar();

            }
            else if (NumeroPersonas > 5)
            {
                SqlCommand cmd = new SqlCommand("select * from VEHICULO where TIPOVEHICULO = 'bus' and IDVEHICULO not in (select IDVEHICULO from RESERVAAPROBADA where (convert(datetime, '" + fecha.FechaInicio + "', 102)between FECHASALIDA and FECHARETORNO) and(convert(datetime, '" + fecha.FechaFin + "', 102)between FECHASALIDA and FECHARETORNO) )", coneccion.getConnection());
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    Console.WriteLine("No hay vehiculos disponibles");
                }
                else
                {
                    Vehiculo.IdVehiculo = reader.GetInt32(0);
                    Vehiculo.Tipo = reader.GetString(1);
                    Vehiculo.Placa = reader.GetString(2);
                    return true;
                }
                coneccion.Desconectar();

            }

            Console.WriteLine(Vehiculo.Placa);
            return false;
        }
            

        public void asignarFecha(string fechaInicio, string fechaFin)
        {

            fecha.FechaInicio = fechaInicio;
            fecha.FechaFin = fechaFin;

        }

        public bool validarChoferVehiculo(bool chofer, bool vehiculo )
        {

            if (chofer && vehiculo)
            {
                return true;
            }

            return false;

        }

    }
}
