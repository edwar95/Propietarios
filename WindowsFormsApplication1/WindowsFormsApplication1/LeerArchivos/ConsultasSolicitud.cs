using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyectov2.LeerArchivos;

namespace Proyectov2.LeerArchivos
{
    class ConsultasSolicitud
    {
        string CnStr = @"Data Source=172.31.101.33;Initial Catalog=sistemaAAP; Integrated Security=False; User ID=grupo6; Password=grupo6Sofi";

        public ConsultasSolicitud() {
        }

        public DataTable tblSolicitudVr() {
            
            SqlDataAdapter adp = new SqlDataAdapter("select * from SolicitudReserva",CnStr);
            DataTable ds = new DataTable();
            adp.Fill(ds);

            return ds;
        }

        public DataTable tblSolicitudApr()
        {
            
            SqlDataAdapter adp = new SqlDataAdapter("select * from SolicitudReserva where estadoSolicitud='aprobado'", CnStr);
            DataTable ds = new DataTable();
            adp.Fill(ds);

            return ds;
        }

    }
}
