using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Reserva reservaAux = new Reserva();   
        bool exiteReserva = false;
        String[] reservaTemp = null;
        
        public Form1()
        {
            InitializeComponent();
            confirmarBtn.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tipoUsuario_Click(object sender, EventArgs e)
        {

        }

        private void reservacion_Click(object sender, EventArgs e)
        {

            Reserva reserva = new Reserva();
            foreach (string line in File.ReadLines(@"reservas.txt"))
            {
                Char delimiter =';';
                String[] substrings = line.Split(delimiter);
                if (numReservaTxt.Text== substrings[0])
                {
                    exiteReserva = true;
                    reservaTemp = substrings;
                }
            }

            if (exiteReserva==true)
            {
                numPersonas.Value = Int32.Parse(reservaTemp[1]);
                tipoUsr.Text = reservaTemp[2];
                fechaIni.Value = Convert.ToDateTime(reservaTemp[3]);
                fechaFinaliza.Value= Convert.ToDateTime(reservaTemp[4]);

                confirmarBtn.Enabled = true;
                reservaAux = reserva;
                
            }
            else
            {

                MessageBox.Show("No existe reserva", "Error Reserva",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                numPersonas.Value = 0;

                confirmarBtn.Enabled = false;
            }

        }

        private void confirmarBtn_Click(object sender, EventArgs e)
        {
            Reserva reserva = new Reserva();
            reserva = reservaAux;
            reserva.NumeroPersonas = Decimal.ToInt32(numPersonas.Value);
            if (tipoUsr.Text == "Usuario Comun")
            {
                reserva.Prioridad = "1";
            }
            else
            {
                reserva.Prioridad = "2";
            }
            reserva.FechaInicio = fechaIni.Value.ToString("yyyy-MM-dd");
            reserva.FechaFin = fechaFinaliza.Value.ToString("yyyy-MM-dd");
            reserva.confirmarViaje();
              
        }
    }
}
