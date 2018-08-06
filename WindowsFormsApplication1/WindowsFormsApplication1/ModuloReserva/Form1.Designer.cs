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
            ((System.ComponentModel.ISupportInitialize)(this.numPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // numeroPersonas
            // 
            this.numeroPersonas.AutoSize = true;
            this.numeroPersonas.Location = new System.Drawing.Point(36, 84);
            this.numeroPersonas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numeroPersonas.Name = "numeroPersonas";
            this.numeroPersonas.Size = new System.Drawing.Size(142, 17);
            this.numeroPersonas.TabIndex = 0;
            this.numeroPersonas.Text = "Numero de Personas";
            this.numeroPersonas.Click += new System.EventHandler(this.label1_Click);
            // 
            // tipoUsuario
            // 
            this.tipoUsuario.AutoSize = true;
            this.tipoUsuario.Location = new System.Drawing.Point(36, 127);
            this.tipoUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tipoUsuario.Name = "tipoUsuario";
            this.tipoUsuario.Size = new System.Drawing.Size(107, 17);
            this.tipoUsuario.TabIndex = 1;
            this.tipoUsuario.Text = "Tipo de usuario";
            this.tipoUsuario.Click += new System.EventHandler(this.tipoUsuario_Click);
            // 
            // fechaInicio
            // 
            this.fechaInicio.AutoSize = true;
            this.fechaInicio.Location = new System.Drawing.Point(36, 169);
            this.fechaInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fechaInicio.Name = "fechaInicio";
            this.fechaInicio.Size = new System.Drawing.Size(103, 17);
            this.fechaInicio.TabIndex = 2;
            this.fechaInicio.Text = "Fecha de Inicio";
            // 
            // fechaFin
            // 
            this.fechaFin.AutoSize = true;
            this.fechaFin.Location = new System.Drawing.Point(36, 207);
            this.fechaFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fechaFin.Name = "fechaFin";
            this.fechaFin.Size = new System.Drawing.Size(90, 17);
            this.fechaFin.TabIndex = 3;
            this.fechaFin.Text = "Fecha de Fin";
            // 
            // numPersonas
            // 
            this.numPersonas.Location = new System.Drawing.Point(200, 81);
            this.numPersonas.Margin = new System.Windows.Forms.Padding(4);
            this.numPersonas.Name = "numPersonas";
            this.numPersonas.Size = new System.Drawing.Size(160, 22);
            this.numPersonas.TabIndex = 4;
            // 
            // fechaIni
            // 
            this.fechaIni.Location = new System.Drawing.Point(200, 169);
            this.fechaIni.Margin = new System.Windows.Forms.Padding(4);
            this.fechaIni.Name = "fechaIni";
            this.fechaIni.Size = new System.Drawing.Size(160, 22);
            this.fechaIni.TabIndex = 6;
            // 
            // fechaFinaliza
            // 
            this.fechaFinaliza.Location = new System.Drawing.Point(200, 207);
            this.fechaFinaliza.Margin = new System.Windows.Forms.Padding(4);
            this.fechaFinaliza.Name = "fechaFinaliza";
            this.fechaFinaliza.Size = new System.Drawing.Size(159, 22);
            this.fechaFinaliza.TabIndex = 7;
            // 
            // reservacion
            // 
            this.reservacion.Location = new System.Drawing.Point(39, 270);
            this.reservacion.Margin = new System.Windows.Forms.Padding(4);
            this.reservacion.Name = "reservacion";
            this.reservacion.Size = new System.Drawing.Size(135, 26);
            this.reservacion.TabIndex = 8;
            this.reservacion.Text = "Consultar";
            this.reservacion.UseVisualStyleBackColor = true;
            this.reservacion.Click += new System.EventHandler(this.reservacion_Click);
            // 
            // numReserva
            // 
            this.numReserva.AutoSize = true;
            this.numReserva.Location = new System.Drawing.Point(39, 40);
            this.numReserva.Name = "numReserva";
            this.numReserva.Size = new System.Drawing.Size(135, 17);
            this.numReserva.TabIndex = 9;
            this.numReserva.Text = "Numero de Reserva";
            // 
            // numReservaTxt
            // 
            this.numReservaTxt.Location = new System.Drawing.Point(200, 40);
            this.numReservaTxt.Name = "numReservaTxt";
            this.numReservaTxt.Size = new System.Drawing.Size(159, 22);
            this.numReservaTxt.TabIndex = 10;
            // 
            // confirmarBtn
            // 
            this.confirmarBtn.Location = new System.Drawing.Point(212, 272);
            this.confirmarBtn.Name = "confirmarBtn";
            this.confirmarBtn.Size = new System.Drawing.Size(122, 24);
            this.confirmarBtn.TabIndex = 11;
            this.confirmarBtn.Text = "Confirmar";
            this.confirmarBtn.UseVisualStyleBackColor = true;
            this.confirmarBtn.Click += new System.EventHandler(this.confirmarBtn_Click);
            // 
            // tipoUsr
            // 
            this.tipoUsr.Location = new System.Drawing.Point(200, 127);
            this.tipoUsr.Name = "tipoUsr";
            this.tipoUsr.Size = new System.Drawing.Size(159, 22);
            this.tipoUsr.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}

