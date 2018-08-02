﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyectov2.LeerArchivos;
namespace ModulosG4
{
    public partial class FrmSolicitudDeViaje : Form
    {
        // private EscribirArchivo esc_archivo;
        Leerfichero learch = new Leerfichero();
        private SolicitudDeViaje viaje;
        public FrmSolicitudDeViaje()
        {
            InitializeComponent();
            //esc_archivo = new EscribirArchivo();
        }

        public void obtenerDatos()
        {
            viaje = new SolicitudDeViaje(txt_ciSolicitante.Text, txt_nombreSolicitante.Text, cb_destino.SelectedItem.ToString(), cb_conductor.SelectedItem.ToString(), dtf_salida.Value.ToString("MM/dd/yyyy"), dth_salida.Value.ToString("hh:mm:ss"), dtf_llegada.Value.ToString("MM/dd/yyyy"), dth_llegada.Value.ToString("hh:mm:ss"), txt_motivo.Text);

        }


        private void dtf_salida_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            obtenerDatos();
            //esc_archivo.escribirViaje(viaje);
            learch.escribirArchivo(viaje.solicitud(), "Viaje.txt");
        }
    }
}
