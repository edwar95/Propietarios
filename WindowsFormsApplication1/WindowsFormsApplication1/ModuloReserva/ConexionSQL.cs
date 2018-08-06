using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ConexionSQL
    {
        private SqlConnection conexion;

        public void Conectar()
        {
            try
            {
                conexion = new SqlConnection("Data Source=172.31.101.33,1433;Initial Catalog=SistemaAAP;Persist Security Info=True;User ID=grupoAli;Password=grupoAli");
                conexion.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public SqlConnection getConnection()
        {
            return conexion;
        }

        public void Desconectar()
        {
            conexion.Close();
        }
    }
}