namespace WindowsFormsApplication1
{
    partial class Form1
    {

        

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numeroPersonas = new System.Windows.Forms.Label();
            this.tipoUsuario = new System.Windows.Forms.Label();
            this.fechaInicio = new System.Windows.Forms.Label();
            this.fechaFin = new System.Windows.Forms.Label();
            this.numPersonas = new System.Windows.Forms.NumericUpDown();
            this.fechaIni = new System.Windows.Forms.DateTimePicker();
            this.fechaFinaliza = new System.Windows.Forms.DateTimePicker();
            this.reservacion = new System.Windows.Forms.Button();
            this.numReserva = new System.Windows.Forms.Label();
            this.numReservaTxt = new System.Windows.Forms.TextBox();
            this.confirmarBtn = new System.Windows.Forms.Button();
            this.tipoUsr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.motivoViajeTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // numeroPersonas
            // 
            this.numeroPersonas.AutoSize = true;
            this.numeroPersonas.Location = new System.Drawing.Point(27, 68);
            this.numeroPersonas.Name = "numeroPersonas";
            this.numeroPersonas.Size = new System.Drawing.Size(106, 13);
            this.numeroPersonas.TabIndex = 0;
            this.numeroPersonas.Text = "Numero de Personas";
            this.numeroPersonas.Click += new System.EventHandler(this.label1_Click);
            // 
            // tipoUsuario
            // 
            this.tipoUsuario.AutoSize = true;
            this.tipoUsuario.Location = new System.Drawing.Point(29, 179);
            this.tipoUsuario.Name = "tipoUsuario";
            this.tipoUsuario.Size = new System.Drawing.Size(80, 13);
            this.tipoUsuario.TabIndex = 1;
            this.tipoUsuario.Text = "Tipo de usuario";
            this.tipoUsuario.Click += new System.EventHandler(this.tipoUsuario_Click);
            // 
            // fechaInicio
            // 
            this.fechaInicio.AutoSize = true;
            this.fechaInicio.Location = new System.Drawing.Point(29, 213);
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.Size = new System.Drawing.Size(80, 13);
            this.fechaInicio.TabIndex = 2;
            this.fechaInicio.Text = "Fecha de Inicio";
            // 
            // fechaFin
            // 
            this.fechaFin.AutoSize = true;
            this.fechaFin.Location = new System.Drawing.Point(29, 244);
            this.fechaFin.Name = "fechaFin";
            this.fechaFin.Size = new System.Drawing.Size(69, 13);
            this.fechaFin.TabIndex = 3;
            this.fechaFin.Text = "Fecha de Fin";
            // 
            // numPersonas
            // 
            this.numPersonas.Location = new System.Drawing.Point(150, 66);
            this.numPersonas.Name = "numPersonas";
            this.numPersonas.Size = new System.Drawing.Size(120, 20);
            this.numPersonas.TabIndex = 4;
            // 
            // fechaIni
            // 
            this.fechaIni.Location = new System.Drawing.Point(152, 213);
            this.fechaIni.Name = "fechaIni";
            this.fechaIni.Size = new System.Drawing.Size(121, 20);
            this.fechaIni.TabIndex = 6;
            // 
            // fechaFinaliza
            // 
            this.fechaFinaliza.Location = new System.Drawing.Point(152, 244);
            this.fechaFinaliza.Name = "fechaFinaliza";
            this.fechaFinaliza.Size = new System.Drawing.Size(120, 20);
            this.fechaFinaliza.TabIndex = 7;
            // 
            // reservacion
            // 
            this.reservacion.Location = new System.Drawing.Point(31, 295);
            this.reservacion.Name = "reservacion";
            this.reservacion.Size = new System.Drawing.Size(101, 21);
            this.reservacion.TabIndex = 8;
            this.reservacion.Text = "Consultar";
            this.reservacion.UseVisualStyleBackColor = true;
            this.reservacion.Click += new System.EventHandler(this.reservacion_Click);
            // 
            // numReserva
            // 
            this.numReserva.AutoSize = true;
            this.numReserva.Location = new System.Drawing.Point(29, 32);
            this.numReserva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numReserva.Name = "numReserva";
            this.numReserva.Size = new System.Drawing.Size(102, 13);
            this.numReserva.TabIndex = 9;
            this.numReserva.Text = "Numero de Reserva";
            // 
            // numReservaTxt
            // 
            this.numReservaTxt.Location = new System.Drawing.Point(150, 32);
            this.numReservaTxt.Margin = new System.Windows.Forms.Padding(2);
            this.numReservaTxt.Name = "numReservaTxt";
            this.numReservaTxt.Size = new System.Drawing.Size(120, 20);
            this.numReservaTxt.TabIndex = 10;
            // 
            // confirmarBtn
            // 
            this.confirmarBtn.Location = new System.Drawing.Point(161, 297);
            this.confirmarBtn.Margin = new System.Windows.Forms.Padding(2);
            this.confirmarBtn.Name = "confirmarBtn";
            this.confirmarBtn.Size = new System.Drawing.Size(92, 20);
            this.confirmarBtn.TabIndex = 11;
            this.confirmarBtn.Text = "Confirmar";
            this.confirmarBtn.UseVisualStyleBackColor = true;
            this.confirmarBtn.Click += new System.EventHandler(this.confirmarBtn_Click);
            // 
            // tipoUsr
            // 
            this.tipoUsr.Location = new System.Drawing.Point(152, 179);
            this.tipoUsr.Margin = new System.Windows.Forms.Padding(2);
            this.tipoUsr.Name = "tipoUsr";
            this.tipoUsr.Size = new System.Drawing.Size(120, 20);
            this.tipoUsr.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Motivo Viaje";
            // 
            // motivoViajeTxt
            // 
            this.motivoViajeTxt.Location = new System.Drawing.Point(150, 94);
            this.motivoViajeTxt.Name = "motivoViajeTxt";
            this.motivoViajeTxt.Size = new System.Drawing.Size(120, 20);
            this.motivoViajeTxt.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 319);
            this.Controls.Add(this.motivoViajeTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tipoUsr);
            this.Controls.Add(this.confirmarBtn);
            this.Controls.Add(this.numReservaTxt);
            this.Controls.Add(this.numReserva);
            this.Controls.Add(this.reservacion);
            this.Controls.Add(this.fechaFinaliza);
            this.Controls.Add(this.fechaIni);
            this.Controls.Add(this.numPersonas);
            this.Controls.Add(this.fechaFin);
            this.Controls.Add(this.fechaInicio);
            this.Controls.Add(this.tipoUsuario);
            this.Controls.Add(this.numeroPersonas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numeroPersonas;
        private System.Windows.Forms.Label tipoUsuario;
        private System.Windows.Forms.Label fechaInicio;
        private System.Windows.Forms.Label fechaFin;
        private System.Windows.Forms.NumericUpDown numPersonas;
        private System.Windows.Forms.DateTimePicker fechaIni;
        private System.Windows.Forms.DateTimePicker fechaFinaliza;
        private System.Windows.Forms.Button reservacion;
        private System.Windows.Forms.Label numReserva;
        private System.Windows.Forms.TextBox numReservaTxt;
        private System.Windows.Forms.Button confirmarBtn;
        private System.Windows.Forms.TextBox tipoUsr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox motivoViajeTxt;
    }
}

