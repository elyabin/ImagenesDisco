namespace ImagenesDisco
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
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RUTA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_CAPTURA_FORMATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA_MODIFICACION_FORMATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXIF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Copiar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(21, 54);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(35, 13);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "label1";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(24, 12);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RUTA,
            this.FECHA_CAPTURA_FORMATO,
            this.FECHA_MODIFICACION_FORMATO,
            this.EXIF,
            this.Copiar});
            this.dataGridView1.Location = new System.Drawing.Point(24, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(732, 287);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(762, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // RUTA
            // 
            this.RUTA.DataPropertyName = "RUTA";
            this.RUTA.HeaderText = "RUTA";
            this.RUTA.Name = "RUTA";
            this.RUTA.ReadOnly = true;
            // 
            // FECHA_CAPTURA_FORMATO
            // 
            this.FECHA_CAPTURA_FORMATO.DataPropertyName = "FECHA_CAPTURA_FORMATO";
            this.FECHA_CAPTURA_FORMATO.HeaderText = "Fecha Captura";
            this.FECHA_CAPTURA_FORMATO.Name = "FECHA_CAPTURA_FORMATO";
            this.FECHA_CAPTURA_FORMATO.ReadOnly = true;
            // 
            // FECHA_MODIFICACION_FORMATO
            // 
            this.FECHA_MODIFICACION_FORMATO.DataPropertyName = "FECHA_MODIFICACION_FORMATO";
            this.FECHA_MODIFICACION_FORMATO.HeaderText = "Fecha Modificación";
            this.FECHA_MODIFICACION_FORMATO.Name = "FECHA_MODIFICACION_FORMATO";
            this.FECHA_MODIFICACION_FORMATO.ReadOnly = true;
            // 
            // EXIF
            // 
            this.EXIF.DataPropertyName = "EXIF";
            this.EXIF.HeaderText = "EXIF";
            this.EXIF.Name = "EXIF";
            this.EXIF.ReadOnly = true;
            // 
            // Copiar
            // 
            this.Copiar.HeaderText = "";
            this.Copiar.Name = "Copiar";
            this.Copiar.ReadOnly = true;
            this.Copiar.Text = "Copiar";
            this.Copiar.UseColumnTextForButtonValue = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 386);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.lblMensaje);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RUTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_CAPTURA_FORMATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA_MODIFICACION_FORMATO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXIF;
        private System.Windows.Forms.DataGridViewButtonColumn Copiar;
    }
}

