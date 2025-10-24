namespace ActividadEnElAula10
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnResolverSolicitud = new Button();
            lbxColaSolicitudesAAtender = new ListBox();
            label2 = new Label();
            btnConfirmarAtencion = new Button();
            lbSolicitudSeleccionada = new Label();
            lbxVerSolicitudesImportadas = new ListBox();
            label1 = new Label();
            btnImportarSolicitudes = new Button();
            label3 = new Label();
            btnExportarResoluciones = new Button();
            label4 = new Label();
            lbxHistorialResoluciones = new ListBox();
            opfd = new OpenFileDialog();
            svfd = new SaveFileDialog();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnResolverSolicitud);
            groupBox1.Controls.Add(lbxColaSolicitudesAAtender);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnConfirmarAtencion);
            groupBox1.Controls.Add(lbSolicitudSeleccionada);
            groupBox1.Controls.Add(lbxVerSolicitudesImportadas);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnImportarSolicitudes);
            groupBox1.Font = new Font("Arial", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(763, 434);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Atención de Solicitudes";
            // 
            // btnResolverSolicitud
            // 
            btnResolverSolicitud.Location = new Point(644, 199);
            btnResolverSolicitud.Name = "btnResolverSolicitud";
            btnResolverSolicitud.Size = new Size(113, 63);
            btnResolverSolicitud.TabIndex = 7;
            btnResolverSolicitud.Text = "Resolver Solicitud";
            btnResolverSolicitud.UseVisualStyleBackColor = true;
            btnResolverSolicitud.Click += btnResolverSolicitud_Click;
            // 
            // lbxColaSolicitudesAAtender
            // 
            lbxColaSolicitudesAAtender.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbxColaSolicitudesAAtender.FormattingEnabled = true;
            lbxColaSolicitudesAAtender.ItemHeight = 19;
            lbxColaSolicitudesAAtender.Location = new Point(395, 194);
            lbxColaSolicitudesAAtender.Name = "lbxColaSolicitudesAAtender";
            lbxColaSolicitudesAAtender.Size = new Size(241, 232);
            lbxColaSolicitudesAAtender.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(395, 168);
            label2.Name = "label2";
            label2.Size = new Size(159, 23);
            label2.TabIndex = 5;
            label2.Text = "Cola de Atención";
            // 
            // btnConfirmarAtencion
            // 
            btnConfirmarAtencion.Location = new Point(250, 242);
            btnConfirmarAtencion.Name = "btnConfirmarAtencion";
            btnConfirmarAtencion.Size = new Size(139, 109);
            btnConfirmarAtencion.TabIndex = 4;
            btnConfirmarAtencion.Text = "Confirmar selección hacia cola de atención";
            btnConfirmarAtencion.UseVisualStyleBackColor = true;
            btnConfirmarAtencion.Click += btnConfirmarAtencion_Click;
            // 
            // lbSolicitudSeleccionada
            // 
            lbSolicitudSeleccionada.Location = new Point(253, 191);
            lbSolicitudSeleccionada.Name = "lbSolicitudSeleccionada";
            lbSolicitudSeleccionada.Size = new Size(136, 59);
            lbSolicitudSeleccionada.TabIndex = 3;
            lbSolicitudSeleccionada.Text = "Seleccione desde la lista";
            // 
            // lbxVerSolicitudesImportadas
            // 
            lbxVerSolicitudesImportadas.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbxVerSolicitudesImportadas.FormattingEnabled = true;
            lbxVerSolicitudesImportadas.ItemHeight = 19;
            lbxVerSolicitudesImportadas.Location = new Point(6, 191);
            lbxVerSolicitudesImportadas.Name = "lbxVerSolicitudesImportadas";
            lbxVerSolicitudesImportadas.Size = new Size(241, 232);
            lbxVerSolicitudesImportadas.TabIndex = 2;
            // 
            // label1
            // 
            label1.Location = new Point(6, 141);
            label1.Name = "label1";
            label1.Size = new Size(184, 50);
            label1.TabIndex = 1;
            label1.Text = "Lista de Solicitudes Entrantes";
            // 
            // btnImportarSolicitudes
            // 
            btnImportarSolicitudes.Location = new Point(6, 41);
            btnImportarSolicitudes.Name = "btnImportarSolicitudes";
            btnImportarSolicitudes.Size = new Size(166, 65);
            btnImportarSolicitudes.TabIndex = 0;
            btnImportarSolicitudes.Text = "Importar Solicitudes";
            btnImportarSolicitudes.UseVisualStyleBackColor = true;
            btnImportarSolicitudes.Click += btnImportarSolicitudes_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(781, 28);
            label3.Name = "label3";
            label3.Size = new Size(234, 23);
            label3.TabIndex = 1;
            label3.Text = "Historial de Resoluciones";
            // 
            // btnExportarResoluciones
            // 
            btnExportarResoluciones.Font = new Font("Arial", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnExportarResoluciones.Location = new Point(781, 64);
            btnExportarResoluciones.Name = "btnExportarResoluciones";
            btnExportarResoluciones.Size = new Size(160, 68);
            btnExportarResoluciones.TabIndex = 2;
            btnExportarResoluciones.Text = "Exportar Resoluciones";
            btnExportarResoluciones.UseVisualStyleBackColor = true;
            btnExportarResoluciones.Click += btnExportarResoluciones_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(781, 170);
            label4.Name = "label4";
            label4.Size = new Size(196, 23);
            label4.TabIndex = 3;
            label4.Text = "Pila de Resoluciones";
            // 
            // lbxHistorialResoluciones
            // 
            lbxHistorialResoluciones.Font = new Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lbxHistorialResoluciones.FormattingEnabled = true;
            lbxHistorialResoluciones.ItemHeight = 19;
            lbxHistorialResoluciones.Location = new Point(781, 197);
            lbxHistorialResoluciones.Name = "lbxHistorialResoluciones";
            lbxHistorialResoluciones.Size = new Size(243, 251);
            lbxHistorialResoluciones.TabIndex = 4;
            // 
            // opfd
            // 
            opfd.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1036, 450);
            Controls.Add(lbxHistorialResoluciones);
            Controls.Add(label4);
            Controls.Add(btnExportarResoluciones);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnImportarSolicitudes;
        private ListBox lbxVerSolicitudesImportadas;
        private Label label1;
        private Label lbSolicitudSeleccionada;
        private ListBox lbxColaSolicitudesAAtender;
        private Label label2;
        private Button btnConfirmarAtencion;
        private Button btnResolverSolicitud;
        private Label label3;
        private Button btnExportarResoluciones;
        private Label label4;
        private ListBox lbxHistorialResoluciones;
        private OpenFileDialog opfd;
        private SaveFileDialog svfd;
    }
}
