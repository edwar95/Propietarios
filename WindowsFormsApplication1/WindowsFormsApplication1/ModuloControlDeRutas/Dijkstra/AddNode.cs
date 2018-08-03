﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dijkstra
{
    public partial class AddNode : Form
    {
        public class GraphRowInfo
        {
            public bool Adj { get; set; }
            public string NName { get; set; }
            public string Weight { get; set; }
            public string Id { get; set; }

            public GraphRowInfo(bool adj, string name, string weight, string id)
            {
                this.Adj = adj;
                this.NName = name;
                this.Weight = weight;
                this.Id = id;
            }
        }
        public AddNode(Graph graph)
        {
            InitializeComponent();
            this.CurrentGraph = graph;
        }

        public Graph CurrentGraph { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {

                MessageBox.Show("El nombre del nodo está en blanco! ", " Error al añadir nodo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    int weight;
                    if (!int.TryParse(row.Cells[2].Value.ToString(), out weight))
                    {
                        MessageBox.Show("La distancia de arista del nodo \""+row.Cells[1].Value.ToString()+ "\" no es un valor numérico válido!",
                            "Error al añadir nodo", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    if (weight < 0)
                    {
                        MessageBox.Show("La distancia de arista del nodo \"" + row.Cells[1].Value.ToString() + "\" es negativo y no es soportado por el Algoritmo de Dijkstra!",
                            "Error al añadir nodo", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            var node = this.CurrentGraph.AddNode(this.textBox1.Text);

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    int weight = int.Parse(row.Cells[2].Value.ToString());
                    
                    var target = this.CurrentGraph.GetNodeById(int.Parse(row.Cells[3].Value.ToString()));

                    this.CurrentGraph.AddAdjacency(node, target, weight);

                    // AQUI AGREGAR INSERT A LA BASE DE DATOS
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddNode_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            var dl = new BindingList<GraphRowInfo>();
            foreach (var value in CurrentGraph.Nodes)
            {
                dl.Add(new GraphRowInfo(false, value.Value.Name, "", value.Key.ToString()));

            }
            //((DataGridViewCheckBoxColumn)this.dataGridView1.Columns[0])..CheckedChanged += new EventHandler(this.OnCheckChanged);
            this.dataGridView1.DataSource = dl;
        }
    }
}
