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
using System.Data;

namespace WindowsFormsApp1.ModuloDisponibilidad
{
    public partial class Calendario : Form
    {
        public Calendario()
        {
            InitializeComponent();
            // this.BackColor = Color.Black;
            int dis_a = 0;
            this.Size = new Size(1100, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Font = new System.Drawing.Font(label1.Font, FontStyle.Bold);
           // tableLayoutPanel1.MaximumSize = new Size(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel1.AutoScroll = true;
        }

        private void Calendario_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            tableLayoutPanel1.BackColor = Color.White;
            DateTime a = primerDiaSemana(monthCalendar1);
            llenarDias(a);
            textBox2.Text = "primer dia " + a;

            textBox1.Text = "Semana del:" + monthCalendar1.SelectionRange.Start;
            consultarReserva();

            //pruebas de manejo de la fecha





        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "Date Selected :" + (int)monthCalendar1.SelectionRange.Start.DayOfWeek;
            /*  monthCalendar1.SelectionStart.Date.AddDays(1 - (monthCalendar1.SelectionStart.Date.DayOfWeek));
              'Último día de la semana
               MonthCalendar.SelectionStart.Date.AddDays(7 - (MonthCalendar.SelectionStart.Date.DayOfWeek))*/
        }

        private void autosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autosToolStripMenuItem.BackColor = Color.Blue;
            busesToolStripMenuItem.BackColor = this.BackColor;
        }

        private void busesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            busesToolStripMenuItem.BackColor = Color.Blue;
            autosToolStripMenuItem.BackColor = this.BackColor;
        }


        private void label20_Click(object sender, EventArgs e)
        {

        }



        private void label25_Click(object sender, EventArgs e)
        {

        }
        public DateTime primerDiaSemana(MonthCalendar m) {
            DateTime f_select = m.SelectionRange.Start;
            int d_select = (int)m.SelectionRange.Start.DayOfWeek;


            if (d_select == 0)
            {
                DateTime a = f_select.AddDays(-6);
                return a;

            }
            else if (d_select != 0)
            {

                DateTime a = f_select.AddDays(1 - (int)f_select.DayOfWeek);
                return a;

            }

            return f_select;
        }

        public void llenarDias(DateTime dia) {
            // DateTime aux = dia.AddDays(1);

            lb_lunes.Text = "LUNES " + dia.Day;
            lb_martes.Text = "MARTES  " + dia.AddDays(1).Day;
            lb_miercoles.Text = "MIERCOLES " + dia.AddDays(2).Day;
            lb_jueves.Text = "JUEVES  " + dia.AddDays(3).Day;
            lb_viernes.Text = "VIERNES  " + dia.AddDays(4).Day;
            lb_sabado.Text = "SABADO  " + dia.AddDays(5).Day;
            lb_domingo.Text = "DOMINGO  " + dia.AddDays(6).Day;



        }

        public void consultarReserva()
        {
            // String aConsultar ="Select V.TIPOVEHICULO AS \"TIPO DE VEHICULO\", V.PLACAVEHICULO AS \"PLACA\", CH.NOMBRECHOFER+CH.APELLIDOCHOFER AS \"NOMBRES DEL CHOFER\", FECHASALIDA AS \"FECHA DE SALIDA\", FECHARETORNO AS \"FECHA DE REGRESO\" From RESERVAAPROBADA RA, CHOFER CH, VEHICULO V where CH.IDCHOFER = RA.IDCHOFER AND V.IDVEHICULO = RA.IDVEHICULO";
            String aConsultar ="Select * from RESERVAAPROBADA";//para pasar los datos al data grid view

            String fechasConsultadas = "select FECHASALIDA as f_i, FECHARETORNO as f_f FROM RESERVAAPROBADA";

            Consulta consulta = new Consulta();
            
           consulta.cargarDatos(aConsultar, dataGridView1);
            DataTable fechas = consulta.tablaConsulta(fechasConsultadas);
            DateTime f_i = new DateTime();
            DateTime f_f = new DateTime();

            for (int i = 0; i < fechas.Rows.Count; i++)
            {
                f_i = Convert.ToDateTime(fechas.Rows[i]["f_i"]);
                 f_f = Convert.ToDateTime(fechas.Rows[i]["f_f"]);
                
                pintar(f_i,f_f);
                }
           // textBox4.Text = Convert.ToString(f_i.TimeOfDay);
            
                
        }

        public void pintar(DateTime f_i, DateTime f_f) {
            DateTime aux = primerDiaSemana(monthCalendar1);
          
            int h_i = Convert.ToInt32(f_i.Hour);
            int h_f = Convert.ToInt32(f_f.Hour);
            textBox4.Text = Convert.ToString(f_i)+f_f;
            if (f_i.DayOfWeek == 0)//Valida si es domingo
            {
                if (f_i.Date == f_f.Date)
                 
                {//valida si la fecha de inicio es = a la de fin
                    for (int i = 0; i <= 6; i++)
                    {//contador para que auxiliar aumente
                        if (aux.AddDays(i) == f_i.Date)
                        {//valida que auxiliar sea igual a las fechas de inicio y fin(xq las dos son iguales)
                            textBox5.Text = "Si es igual zorreins ";
                            for (int j = h_i; j < h_f; j++)
                            {
                                tableLayoutPanel1.GetControlFromPosition(7, j - 7).BackColor = Color.Orange;
                            }
                        }
                        else if (aux.AddDays(i) == f_i && aux.AddDays(i) < f_f)
                        {//valida que la fecha de inicio sea menor que la final

                        }

                    }
                }
            }
            else
            {
                for (int i = 0; i <= 6; i++)
                {
                    if (f_i == aux.AddDays(i))
                    {
                    }

                }



            }

            /*
            
           












            DateTime aux = f_i;
             textBox4.Text = "detected"+aux;
             if (aux.DayOfWeek == 0)
             {
                 if(aux==f_i)
                 tableLayoutPanel1.GetControlFromPosition(7, hora - 7).BackColor = Color.Orange;
             }

                do
                {
                    if (f_i.DayOfWeek == 0)
                    {

                        tableLayoutPanel1.GetControlFromPosition(7, hora-7).BackColor = Color.Orange;
                    }
                    else if (f_i.DayOfWeek != 0) {

                        tableLayoutPanel1.GetControlFromPosition((int)f_i.DayOfWeek+1, hora).BackColor = Color.Orange;

                    }

                    aux= f_i.AddDays(1);


                } while (aux != f_f);
                if (f_f.DayOfWeek == 0)
                {
                    tableLayoutPanel1.GetControlFromPosition(7, hora-7).BackColor = Color.Orange;
                }
                else {

                    tableLayoutPanel1.GetControlFromPosition((int)f_f.DayOfWeek+1, hora-7).BackColor = Color.Orange;
                }
                */

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void p8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p32_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p36_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p50_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p52_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel54_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel58_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel55_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p54_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p47_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p40_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p33_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p19_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void p12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p51_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p39_Paint(object sender, PaintEventArgs e)
        {

        }


        private void p46_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p53_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p48_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p56_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p35_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p42_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p49_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel53_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel56_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel57_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p38_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel39_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel35_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel51_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel40_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel50_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel49_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel46_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel36_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel32_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel47_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel52_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel59_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel48_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel42_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel38_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel33_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    


