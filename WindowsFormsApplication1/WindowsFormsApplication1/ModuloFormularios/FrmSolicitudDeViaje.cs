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
using WindowsFormsApplication1.ModuloFormularios;

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
            CSSolicitudDeViaje cssolicitud = new CSSolicitudDeViaje(txt_ciSolicitante.Text, txt_nombreSolicitante.Text, comboBoxDestinos.SelectedItem.ToString(), dtf_salida.Text, dth_salida.Text, dtf_llegada.Text, dth_llegada.Text, comboBoxDestinos.SelectedItem.ToString() , Int32.Parse(textBox1.Text));
            cssolicitud.guardarEnBase();
        }
    }
}
