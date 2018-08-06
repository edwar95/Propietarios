using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.ModuloFormularios;

namespace ModuloFormularios
{
    public partial class Form2 : Form
    {
        private ReporteConductor reporteConductor;
        public Form2(String idConductor)
        {
            InitializeComponent();
            reporteConductor = new ReporteConductor();
            reporteConductor.setIdConductor(idConductor);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reporteConductor = new ReporteConductor();
            try
            {
                reporteConductor.setDineroGastadoEnGasolina(textBox4.Text);

                if (radioButton1.Checked)
                {
                                     reporteConductor.setDescripcionInconveniente(textBox3.Text);

                }
                else
                {
                                     reporteConductor.setDescripcionInconveniente("null");

                }

                if (radioButton3 .Checked)
                {
                    reporteConductor.setComportameientoPasajeros("0");
                }
                else if (radioButton4.Checked)
                {
                    reporteConductor.setComportameientoPasajeros("25");
                }
                else if (radioButton5.Checked)
                {
                    reporteConductor.setComportameientoPasajeros("50");
                }
                else if (radioButton6.Checked)
                {
                    reporteConductor.setComportameientoPasajeros("75");
                }
                else
                {
                    reporteConductor.setComportameientoPasajeros("100");
                }
                reporteConductor.setCedulaConductor(textBox1.Text);
                reporteConductor.guardarEnBase();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error al ingresar los datos");
                Console.WriteLine(er.ToString());
            }
        }
    }
}



