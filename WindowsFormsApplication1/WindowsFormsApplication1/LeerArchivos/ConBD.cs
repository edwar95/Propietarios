using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Proyectov2.LeerArchivos
{
    class ConBD
    {
        string cadena = "Data Source=172.31.101.33;Initial Catalog=sistemaAAP; Integrated Security=False; User ID=grupo6; Password=grupo6Sofi";
        public SqlConnection con = new SqlConnection();

        public ConBD() {
            con.ConnectionString = cadena;
        }

        public void openCon() {
            try
            {
                con.Open();
                Console.WriteLine("Conexión abierta");
            }
            catch (Exception e) {
                Console.WriteLine("Error al abrir BD " + e);
            }
        }

        public void closeCon()
        {
            con.Close();
        }
    }
}
