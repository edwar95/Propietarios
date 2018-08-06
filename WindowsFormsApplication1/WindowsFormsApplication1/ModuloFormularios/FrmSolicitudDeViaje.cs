using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;


namespace ModuloFormularios
{
    public partial class FrmSolicitudDeViaje : Form
    {
        private Conexion cnx = new Conexion();
        private SqlConnection conn;
        private ArrayList idDestino = new ArrayList();
        public FrmSolicitudDeViaje()
        {
            InitializeComponent();
            SqlDataReader reader = null;
            conn = new SqlConnection(cnx.stringConexion);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("SELECT idLugar, nombreLugar FROM dbo.Lugar", conn);
                reader = comando.ExecuteReader();
                comboBoxDestinos.DisplayMember = "Text";
                comboBoxDestinos.ValueMember = "Value";
                while (reader.Read())
                {
                    comboBoxDestinos.Items.Add(new { Text = reader[1], Value = reader[0] });
                    
                }
                comboBoxDestinos.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn = new SqlConnection(cnx.stringConexion);
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("SELECT idMotivoViaje, descripcion FROM dbo.MotivoViaje", conn);
                reader = comando.ExecuteReader();
                comboBoxMotivos.DisplayMember = "Text";
                comboBoxMotivos.ValueMember = "Value";
                while (reader.Read())
                {
                    comboBoxMotivos.Items.Add(new { Text = reader[1], Value = reader[0] });

                }
                comboBoxMotivos.SelectedIndex = 0;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        
        
        
        private void buttonGuardar_Click(object sender, EventArgs e)
        {

            //public CSSolicitudDeViaje( , string destino, string fechaSalida, string horaSalida, string fechaRetorno, string horaRetorno, string motivo, int numeroPersonas, int idmotivo)
            //CSSolicitudDeViaje cssolicitud = new CSSolicitudDeViaje(txt_ciSolicitante.Text, txt_nombreSolicitante, comboBoxDestinos.se);

            //idMotivoViaje,idCategoriaUsuario,idSolicitante,idLugar,numeroPersonas,fechaSalida,fechaRetorno,estadoSolicitud,fechaReserva) " +
            //        "values(" + (comboBoxMotivos.SelectedIndex + 1) + "," + 1 + "," + idSol + "," + (comboBoxMotivos.SelectedIndex + 1) + "," + 3 + ",'" +
            //        dtf_salida.Text + " " + dth_salida.Text + "','" + dtf_llegada.Text + " " + dth_llegada.Text + "','en espera','" + thisDay.ToString() +

            //String idSol = "";
            //DateTime thisDay = DateTime.Today;
            //try
            //{
            //    cnx = new Conexion();
            //    conn = new SqlConnection(cnx.stringConexion);
            //    SqlDataReader reader = null;
            //    String sql = "select idSolicitante from Solicitante where nombreSolicitante='" + txt_nombreSolicitante.Text + "'";
            //    conn.Open();
            //    SqlCommand comando = new SqlCommand(sql, conn);
            //    reader = comando.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        idSol = "" + reader[0];
            //    }
            //    conn.Close();
            //}
            //catch (Exception er)
            //{
            //    MessageBox.Show("Error");
            //    Console.WriteLine(er.ToString());
            //}
            //try
            //{
            //    cnx = new Conexion();
            //    conn = new SqlConnection(cnx.stringConexion);
            //    conn.Open();
            //    String sql = "insert into SolicitudReserva(idMotivoViaje,idCategoriaUsuario,idSolicitante,idLugar,numeroPersonas,fechaSalida,fechaRetorno,estadoSolicitud,fechaReserva) " +
            //        "values(" + (comboBoxMotivos.SelectedIndex + 1) + "," + 1 + "," + idSol + "," + (comboBoxMotivos.SelectedIndex + 1) + "," + 3 + ",'" +
            //        dtf_salida.Text + " " + dth_salida.Text + "','" + dtf_llegada.Text + " " + dth_llegada.Text + "','en espera','" + thisDay.ToString() + "')";
            //    SqlCommand comando = new SqlCommand(sql, conn);
            //    int resultado = comando.ExecuteNonQuery();
            //    MessageBox.Show("" + sql);
            //}
            //catch (Exception er)
            //{
            //    MessageBox.Show("Error");
            //    Console.WriteLine(er.ToString());
            //}
        }
    }
}
