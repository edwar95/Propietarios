using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ModuloFormularios
{
    class ReporteConductor
    {
        private string idConductor;
        private string nombreCompletoConductor;
        private bool inconvenientesViaje;
        private string descripcionInconveniente;
        private string dineroGastadoEnGasolina;
        private string comportamientoPasajeros;
        private Conexion cnx = new Conexion();
        private SqlConnection conn;

        public ReporteConductor(string idConductor, string nombreCompletoConductor, bool inconvenientesViaje, string descripcionInconveniente, string dineroGastadoEnGasolina, string comportamientoPasajeros)
        {
            this.idConductor = idConductor;
            this.nombreCompletoConductor = nombreCompletoConductor;
            this.inconvenientesViaje = inconvenientesViaje;
            this.descripcionInconveniente = descripcionInconveniente;
            this.dineroGastadoEnGasolina = dineroGastadoEnGasolina;
            this.comportamientoPasajeros = comportamientoPasajeros;
        }
        public ReporteConductor()
        {

        }
        public string getCedulaConductor()
        {
            return this.idConductor;
        }

        public void setIdConductor(string idConductor)
        {
        this.idConductor = idConductor;

        }

        public string getNombreCompletoConductor()
        {
            try
            {
                cnx = new Conexion();
                conn = new SqlConnection(cnx.stringConexion);
                SqlDataReader reader = null;
                String sql = "select NOMBRECHOFER, APELLIDOCHOFER from chofer where cedulachofer like'" +idConductor + "'";
                conn.Open();
                SqlCommand comando = new SqlCommand(sql, conn);
                reader = comando.ExecuteReader();
                int i = 0;
                nombreCompletoConductor = "";
                while (reader.Read())
                {

                    if (i == 0)
                    {
                        nombreCompletoConductor = "" + reader[i];
                    }
                    else
                    {
                        nombreCompletoConductor = nombreCompletoConductor + " " + reader[i];
                    }
                    i++;
                }
                conn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error");
                Console.WriteLine(er.ToString());
            }
            return nombreCompletoConductor;
        }

        public void setNombreCompletoConducto(string nombreCompletoConductor)
        {
            this.nombreCompletoConductor = nombreCompletoConductor;

        }

        public bool getInconvenientesViaje()
        {
            return this.inconvenientesViaje;
        }


        public void setInconvenientesViaje(bool inconvenientesViaje)
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
            return this.comportamientoPasajeros;
        }

        public void setComportameientoPasajeros(string comportameientoPasajeros)
        {
            this.comportamientoPasajeros = comportameientoPasajeros;

        }

        public string getDineroGastadoEnGasolina()
        {
            return this.dineroGastadoEnGasolina;
        }

        public void setDineroGastadoEnGasolina(string dineroGastadoEnGasolina)
        {
            this.dineroGastadoEnGasolina = dineroGastadoEnGasolina;

        }
        public void guardarEnBase()
        {
            if (!idConductor.Equals(null))
            {
                try
                {
                    cnx = new Conexion();
                    conn = new SqlConnection(cnx.stringConexion);
                    conn.Open();
                    String sql = "";

                    if (inconvenientesViaje.Equals("null"))
                    {

                        sql = "insert into ReporteConductor (idchofer, incoveniente,gasto_combustible,comportamiento_pasajeros) values(" + idConductor + ",null," + dineroGastadoEnGasolina + "," + comportamientoPasajeros + ")";
                    }
                    else
                    {
                        sql = "insert into ReporteConductor (idchofer, incoveniente,gasto_combustible,comportamiento_pasajeros) values(" + idConductor + "," + descripcionInconveniente + "," + dineroGastadoEnGasolina + "," + comportamientoPasajeros + ")";
                    }

                    SqlCommand comando = new SqlCommand(sql, conn);
                    int resultado = comando.ExecuteNonQuery();
                    // Comprobar resultado y mandar mensaje de confirmacion o de reintento
                    MessageBox.Show(resultado + "");
                    MessageBox.Show("" + sql);
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error");
                    Console.WriteLine(er.ToString());
                }
            }
            else
            {

                MessageBox.Show("ID DEL CONDUCTOR NO EXISTENTE");
            }
        }
    }
}

    

