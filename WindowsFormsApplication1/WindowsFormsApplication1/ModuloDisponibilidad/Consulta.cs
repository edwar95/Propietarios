using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApp1.ModuloDisponibilidad
{
    class Consulta
    {
        Conexion conexion = new Conexion();
        public void cargarDatos(String consulta, DataGridView tabla  )
        {
            conexion.CargarDatos(consulta, tabla);
         
        }
        public void consultar(String consulta)
        {
            conexion.query(consulta);

        }
        public DataTable tablaConsulta(String consulta) {

            DataTable tabla = conexion.tablaConsulta(consulta);

            return tabla;
        }



    }

}
