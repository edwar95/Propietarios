﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class simuladorLogin : Form
    {
        public simuladorLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            Conexion cn = new Conexion();

            DataTable dtaux = cn.Buscar(id, "select  idsolicitante, facultad from solicitante where idsolicitante= '" + id + "'");
            if (dtaux.Rows.Count > 0)
            {
                MessageBox.Show("SOLICITANTE REGISTRADO EN BD");
                DataRow row = dtaux.Rows[0];
                string id2 = Convert.ToString(row["facultad"]);
                MessageBox.Show(id2);




            }
        }

        private void simuladorLogin_Load(object sender, EventArgs e)
        {

        }
    }
}