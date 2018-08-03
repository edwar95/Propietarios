﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using GraphVizWrapper;
using GraphVizWrapper.Commands;
using GraphVizWrapper.Queries;

namespace Dijkstra
{
    public partial class Form1 : Form, IMessageFilter
    {
        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            this.pictureBox1.MouseWheel += pictureBox1_MouseWheel;
            this.panel1.MouseWheel += pictureBox1_MouseWheel;
            this.Steps = new List<Graph>();
            this.Sizes = new Dictionary<Control, Rectangle>();
        }
        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pt);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        public Graph CurrentGraph { get; set; }
        public Graph BaseGraph { get; set; }
        public GraphGeneration Generator { get; set; }
        public Image OriginalBitmap { get; set; }
        public Image CurrentBitmap { get; set; }
        private int CurrentStep = 0;
        private List<Graph> Steps { get; set; }
        public string CurrentFileName { get; set; }
        public Etiqueta LegendForm { get; set; }
        public Dictionary<Control, Rectangle> Sizes { get; set; }
        public KeyValuePair<int, int> FormOriginalSize { get; set; }
        public float FontSize { get; set; }

        private const int scrollSpeed = 3;
        int _picWidth, _picHeight, _zoomInt = 100;
        private double _picRatio;
        private bool _isPanning = false;
        private Point _startPt;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x20a)
            {
                // WM_MOUSEWHEEL, find the control at screen position m.LParam
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                IntPtr hWnd = WindowFromPoint(pos);
                if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null)
                {
                    SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
                    return true;
                }
            }
            return false;
        }
        private void AddControlToList(Control control)
        {
            if (!Sizes.ContainsKey(control))
                Sizes.Add(control, control.Bounds);

            foreach (Control child in control.Controls)            
                AddControlToList(child);            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BaseGraph = new Graph(GraphType.Undirected);
            this.CurrentGraph = this.BaseGraph.Copy();

            var getStartProcessQuery = new GetStartProcessQuery();
            var getProcessStartInfoQuery = new GetProcessStartInfoQuery();
            var registerLayoutPluginCommand = new RegisterLayoutPluginCommand(getProcessStartInfoQuery, getStartProcessQuery);

            // GraphGeneration can be injected via the IGraphGeneration interface

            this.Generator = new GraphGeneration(getStartProcessQuery,
                                              getProcessStartInfoQuery,
                                              registerLayoutPluginCommand);

            this.FormOriginalSize = new KeyValuePair<int, int>(this.ClientSize.Width, this.ClientSize.Height);

            foreach(Control control in this.Controls)            
                AddControlToList(control);
            listView1.Columns[0].Width = (int)Math.Floor((listView1.Width - 10) * 0.33);
            listView1.Columns[1].Width = (int)Math.Floor((listView1.Width - 10) * 0.66);
            this.FontSize = this.Font.Size;
        }
        public void GetRatio()
        {
            _picRatio = ((double)_picHeight / (double)_picWidth);// needed for aspect ratio

        }
        public void ZoomPictureBox()
        {
            pictureBox1.Width = _picWidth;
            pictureBox1.Height = _picHeight;
           
            pictureBox1.Width = Convert.ToInt32(((double)pictureBox1.Width) * (_zoomInt * 0.01) );
            pictureBox1.Height = Convert.ToInt32(((double)pictureBox1.Width) * _picRatio);

            pictureBox1.Update();
        }
        private void ResizeControls()
        {
            try
            {
                var rateWidth = (double) this.ClientSize.Width/this.FormOriginalSize.Key;
                var rateHeight = (double) this.ClientSize.Height/this.FormOriginalSize.Value;

                foreach (Control ctr in this.Sizes.Keys)
                {
                    if (ctr == pictureBox1)
                        continue;

                    System.Drawing.Size _controlSize = new System.Drawing.Size
                        ((int) (Sizes[ctr].Width*rateWidth),
                            (int) (Sizes[ctr].Height*rateHeight)); //use for sizing

                    System.Drawing.Point _controlposition = new System.Drawing.Point((int)
                        (Sizes[ctr].X*rateWidth),
                        (int) (Sizes[ctr].Y*rateHeight)); //use for location

                    //set bounds
                    ctr.Bounds = new System.Drawing.Rectangle(_controlposition, _controlSize); //Put together

                    ctr.Font = new System.Drawing.Font(this.Font.FontFamily,
                        (float) (((Convert.ToDouble(FontSize)*rateWidth)/2) +
                                 ((Convert.ToDouble(FontSize)*rateHeight)/2)));
                }
            }
            catch (Exception)
            {
                
            }
        }        
        private void CenterImage()
        {
            int x = (panel1.Width - pictureBox1.Width)/2;
            int y = (panel1.Height - pictureBox1.Height)/2;

            pictureBox1.Location = new Point(x,y);
        }
        private void RefreshGraphDraw()
        {
            try
            {
                using (
                    MemoryStream ms =
                        new MemoryStream(
                            Generator.GenerateGraph(this.CurrentGraph.ToDotFormat(), Enums.GraphReturnType.Png)
                                .ToArray()))
                {
                    var img = Image.FromStream(ms);
                    this.pictureBox1.Image = img;
                    this.OriginalBitmap = this.pictureBox1.Image;
                    pictureBox1.Image = img;
                    pictureBox1.Width = img.Width;
                    pictureBox1.Height = img.Height;
                    _picWidth = pictureBox1.Width;
                    _picHeight = pictureBox1.Height;
                    GetRatio();
                    ZoomPictureBox();
                    this.CurrentBitmap = this.pictureBox1.Image;
                }
            }
            catch (Exception e)
            {
                var result = MessageBox.Show("No se pudo representar el grafo. ¿Quiere intentarlo de nuevo?\r\n\r\nMOTIVO: " + e.Message + "\r\n\r\nDetalles del error: " +
                    e.StackTrace, "Error al representar grafo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if(result == DialogResult.Yes)
                    RefreshGraphDraw();
            }
        }
        private void UpdateGraph()
        {
            this.listView1.Items.Clear();
            this.comboBox1.Items.Clear();
            this.comboBox2.Items.Clear();

            this.CurrentGraph = this.BaseGraph.Copy();
            
            Steps.Clear();
            CurrentStep = -1;


            foreach (var node in CurrentGraph.Nodes)
            {
                this.listView1.Items.Add(
                    new ListViewItem(new string[]
                    {node.Value.Name, string.Join(", ", node.Value.AdjacencyList.Select(e => e.Key.Name))}));
                comboBox1.Items.Add(node.Value.Name);
                comboBox2.Items.Add(node.Value.Name);
            }

            RefreshGraphDraw();
            CenterImage();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (new AddNode(this.BaseGraph).ShowDialog() == DialogResult.OK)
                UpdateGraph();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el nodo de inicio. ", " Error al ejecutar Algoritmo de Dijkstra",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el nodo de finalización. ", " Error al ejecutar Algoritmo de Dijkstra",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.CurrentGraph = this.BaseGraph.Copy();
            var start = this.CurrentGraph.Nodes[this.CurrentGraph.Nodes.Keys.ToArray()[comboBox1.SelectedIndex]];
            var end = this.CurrentGraph.Nodes[this.CurrentGraph.Nodes.Keys.ToArray()[comboBox2.SelectedIndex]];

            Steps = this.CurrentGraph.Dijkstra(start, end);

            if (Steps.Count == 0)
            {
                MessageBox.Show("Ninguna ruta de acceso mínima encontrada. ", " Error al ejecutar Algoritmo de Dijkstra",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CurrentStep = this.Steps.Count - 1;
            button5.Enabled = true;
            button6.Enabled = false;
            this.CurrentGraph = Steps[CurrentStep];
            RefreshGraphDraw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (new DeleteNode(this.BaseGraph).ShowDialog() == DialogResult.OK)
                UpdateGraph();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new EditNode(this.BaseGraph);

            if (form.ShowDialog() == DialogResult.OK)
            {
                this.BaseGraph = form.CurrentGraph;
                UpdateGraph();
            }
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                _zoomInt += scrollSpeed;
                if (_zoomInt > 500)
                {
                    _zoomInt = 500;
                    return;
                }
                ZoomPictureBox();
            }
            else if (e.Delta < 0)
            {
                _zoomInt -= scrollSpeed;
                if (_zoomInt <= 10)
                {
                    _zoomInt = 10;
                    return;
                }
                ZoomPictureBox();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _isPanning = true;
            _startPt = e.Location;
            Cursor = Cursors.SizeAll;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isPanning)
            {
                //Cursor = Cursors.Hand;
                Cursor = Cursors.SizeAll;
                Control c = (Control)sender;
                c.Left = (c.Left + e.X) - _startPt.X;
                c.Top = (c.Top + e.Y) - _startPt.Y;
                c.BringToFront();

            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isPanning = false;
            Cursor = Cursors.Default;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (CurrentStep == -1)
            {
                if (comboBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar el nodo de inicio. ", " Error al ejecutar Algoritmo de Dijkstra",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (comboBox2.SelectedIndex < 0)
                {
                    MessageBox.Show("Debe seleccionar el nodo de finalización. ", " Error al ejecutar Algoritmo de Dijkstra",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.CurrentGraph = this.BaseGraph.Copy();
                var start = this.CurrentGraph.Nodes[this.CurrentGraph.Nodes.Keys.ToArray()[comboBox1.SelectedIndex]];
                var end = this.CurrentGraph.Nodes[this.CurrentGraph.Nodes.Keys.ToArray()[comboBox2.SelectedIndex]];

                Steps = this.CurrentGraph.Dijkstra(start, end);

                if (Steps.Count == 0)
                {
                    MessageBox.Show("Ninguna ruta de acceso mínima encontrada. ", " Error al ejecutar Algoritmo de Dijkstra",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CurrentStep = 0;
            }
            else
            {
                if (CurrentStep >= Steps.Count - 1)
                {
                    button6.Enabled = false;
                    button5.Enabled = true;
                    return;
                }

                CurrentStep++;
                button5.Enabled = true;

                if (CurrentStep >= Steps.Count - 1)
                {
                    button6.Enabled = false;
                    button5.Enabled = true;
                }
                this.CurrentGraph = Steps[CurrentStep];
                RefreshGraphDraw();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (CurrentStep == 0)
            {
                button5.Enabled = false;
                button6.Enabled = true;
            }
            else
            {
                CurrentStep--;
                if (CurrentStep == 0)
                {
                    button5.Enabled = false;
                    button6.Enabled = true;
                }
                button6.Enabled = true;
                this.CurrentGraph = Steps[CurrentStep];
                RefreshGraphDraw();
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OldTitle = this.Text;
            if (string.IsNullOrEmpty(this.CurrentFileName))
            {
                if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                this.CurrentFileName = saveFileDialog1.FileName;
                this.Text = "Manejo de rutas - " + this.CurrentFileName;
            }

            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(this.CurrentFileName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, this.BaseGraph);
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el archivo del grafo.\r\n\r\nMOTIVO: " + ex.Message+"\r\n\r\nDetalles del error: "+ex.StackTrace,
                    "Error al guardar grafo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Text = OldTitle;
            }
            
        }


        private void carregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            var OldTitle = this.Text;

            this.CurrentFileName = openFileDialog1.FileName;
            this.Text = "Manejo de rutas - " + this.CurrentFileName;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                Graph obj = (Graph) formatter.Deserialize(stream);
                stream.Close();
                this.BaseGraph = obj;
                this.UpdateGraph();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "El archivo seleccionado está dañado o no está en el formato correcto de la aplicación. El formato debe ser .grf\r\n\r\nMOTIVO: " +
                    ex.Message + "\r\n\r\nDetalles del erroe: " + ex.StackTrace,
                    "Error al cargar grafo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Text = OldTitle;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentGraph = this.BaseGraph.Copy();

            Steps.Clear();
            CurrentStep = -1;
            button6.Enabled = true;
            button5.Enabled = false;
            
            RefreshGraphDraw();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CurrentGraph = this.BaseGraph.Copy();

            Steps.Clear();
            CurrentStep = -1;
            button6.Enabled = true;
            button5.Enabled = false;

            RefreshGraphDraw();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BaseGraph = new Graph(GraphType.Undirected);
            this.UpdateGraph();
            this.CurrentFileName = "";
            this.Text = "Manejo de rutas - Sin Título.grf";
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            this.CurrentFileName = saveFileDialog1.FileName;

            this.Text = "Manejo de rutas - " + this.CurrentFileName;
            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(this.CurrentFileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this.BaseGraph);
            stream.Close();
        
        }

        private void legendaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.LegendForm != null)
            {
               this.LegendForm.Focus();
            }
            else
            {
                this.LegendForm = new Etiqueta();
                this.LegendForm.Closed += LegendFormOnClosed;
                this.LegendForm.Show();
            }
            
        }

        private void LegendFormOnClosed(object sender, EventArgs eventArgs)
        {
            this.LegendForm = null;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                _zoomInt += scrollSpeed;
                if (_zoomInt > 500)
                {
                    _zoomInt = 500;
                    return;
                }
                ZoomPictureBox();
            }
            if (e.KeyCode == Keys.Subtract)
            {
                _zoomInt -= scrollSpeed;
                if (_zoomInt <= 10)
                {
                    _zoomInt = 10;
                    return;
                }
                ZoomPictureBox();
            }

        }    

        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeControls();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //RefreshGraphDraw();
            CenterImage();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new AboutBox().ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            Kilometraje.Text = (this.CurrentGraph.calcularKilometraje()).ToString();
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new Benchmark(this.BaseGraph).ShowDialog();
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
            listView1.Columns[0].Width = (int) Math.Floor((listView1.Width - 10)*0.33);
            listView1.Columns[1].Width = (int) Math.Floor((listView1.Width - 10)*0.66);
        }
    }
}
