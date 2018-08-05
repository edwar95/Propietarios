using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Conexion
    {
        public readonly String stringConexion = "Data Source=localhost,2000;Initial Catalog=sistemaAAP;User ID=sistemaAAP;Password=sistemaAAP";
       // public SqlConnection conectarbd = new SqlConnection();
        
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;




        public Conexion()
        {
            try
            {
                cn = new SqlConnection(stringConexion);
                cn.Open();
                MessageBox.Show("CONECTADO");
            }catch(Exception ex){
                MessageBox.Show("no se conecto a la base");

            }



        }
        public void query(String consulta)
        {
            try
            {
                cmd = new SqlCommand("insert into NotificacionRuta values ('rut4','1-jun-2020')",cn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("no se conecto no hice la consulta");
            }
        }
        /*public void abrir()
        {
            try
            {
                conectarbd.Open();
                Console.WriteLine("conexion abierta");
            }catch(Exception ex)
            {
                Console.WriteLine("error al abrir la BD+");
            }
        }
        public void cerrar()
        {
            conectarbd.Close();


        }
        public void query(String query)
        {
            cmd = new SqlCommand(query);
            cmd.ExecuteNonQuery();


        }*/
    }
}
