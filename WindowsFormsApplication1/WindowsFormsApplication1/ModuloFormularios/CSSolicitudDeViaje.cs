using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ModuloFormularios
{
    class CSSolicitudDeViaje
    {
        private string correoInstitucional;
        private string nombreCompletoSolicitante;
        private string destino;
        private string fechaSalida;
        private string horaSalida;
        private string fechaRetorno;
        private string horaRetorno;
        private string motivo;
        private int idmotivo;
        private int idUsuario;
        private int idLugar;
        private int numeroPersonas;
        private Conexion cnx = new Conexion();
        private SqlConnection conn;


        public CSSolicitudDeViaje(string correoInstitucional, string nombreCompletoSolicitante, string destino, string fechaSalida, string horaSalida, string fechaRetorno, string horaRetorno, string motivo, int numeroPersonas, int idmotivo)
        {
            this.correoInstitucional = correoInstitucional;
            this.nombreCompletoSolicitante = nombreCompletoSolicitante;
            this.destino = destino;
            this.fechaSalida = fechaSalida;
            this.horaSalida = horaSalida;
            this.fechaRetorno = fechaRetorno;
            this.horaRetorno = horaRetorno;
            this.motivo = motivo;
            this.numeroPersonas = numeroPersonas;
        }

        public int getNumeroPersonas()
        {
            return this.numeroPersonas;
        }

        public void setNumeroPersonas(int numeroPersonas)
        {
            this.numeroPersonas = numeroPersonas;

        }

        public string getMotivo()
        {
            return this.motivo;
        }

        public void setMotivo(string motivo)
        {
            this.motivo = motivo;

        }

        public string getHoraRetorno()
        {
            return this.horaRetorno;
        }

        public void setHoraRetorno(string horaRetorno)
        {
            this.horaRetorno = horaRetorno;

        }

        public string getFechaRetorno()
        {
            return this.fechaRetorno;
        }

        public void setFechaRetorno(string fechaRetorno)
        {
            this.fechaRetorno = fechaRetorno;

        }

        public string getHoraSalida()
        {
            return this.horaSalida;
        }

        public void setHoraSalida(string horaSalida)
        {
            this.horaSalida = horaSalida;

        }

        public string getFechaSalida()
        {
            return this.fechaSalida;
        }

        public void setFechaSalida(string fechaSalida)
        {
            this.fechaSalida = fechaSalida;

        }

        public string getDestino()
        {
            return this.destino;
        }

        public void setDestino(string destino)
        {
            this.destino = destino;

        }

        public string getNombreCompletoSolicitante()
        {
            return this.nombreCompletoSolicitante;
        }

        public void setNombreCompletoSolicitante(string nombreCompletoSolicitante)
        {
            this.nombreCompletoSolicitante = nombreCompletoSolicitante;

        }
        
        public string getCorreoInstitucional()
        {
            return this.correoInstitucional;
        }

        public void setCorreoInstitucional(string correoInstitucional)
        {
            this.correoInstitucional = correoInstitucional;

        }

        public void setIDs(int idmotivo,int idUsuario, int idLugar) {
            this.idmotivo = idmotivo;
            this.idUsuario = idUsuario;
            this.idLugar = idLugar;
        }

        public void guardarEnBase() {

            String idSolicitante;
            try
            {
                cnx = new Conexion();
                conn = new SqlConnection(cnx.stringConexion);
                SqlDataReader reader = null;
                String sql = "select idSolicitante from Solicitante where nombreSolicitante='" + nombreCompletoSolicitante + "'";
                conn.Open();
                SqlCommand comando = new SqlCommand(sql, conn);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    idSolicitante = "" + reader[0];
                }
                conn.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error");
                Console.WriteLine(er.ToString());
            }

            try
            {
                DateTime thisDay = DateTime.Today;
                cnx = new Conexion();
                conn = new SqlConnection(cnx.stringConexion);
                conn.Open();
                String sql = "insert into SolicitudReserva(idMotivoViaje,idSolicitante,idLugar,numeroPersonas,fechaSalida,fechaRetorno,estadoSolicitud,fechaReserva) " +
                    "values(" + idmotivo + "," + idUsuario + "," + idLugar + ",'" +  numeroPersonas + "," + fechaSalida +" "+horaSalida+"','" + fechaRetorno + " " + horaRetorno + "','en espera','" +thisDay.ToString() + "')";
                SqlCommand comando = new SqlCommand(sql, conn);
                int resultado = comando.ExecuteNonQuery();
                MessageBox.Show("" + sql);
            }
            catch (Exception er)
            {
                MessageBox.Show("Error");
                Console.WriteLine(er.ToString());
            }



        }
    }
}
