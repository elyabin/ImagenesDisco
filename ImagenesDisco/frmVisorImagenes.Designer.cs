namespace ImagenesDisco
{
    partial class frmVisorImagenes
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("/");
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.barraStatus = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tvCarpetas = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirCarpetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.barraStatus.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRuta
            // 
            this.txtRuta.Enabled = false;
            this.txtRuta.Location = new System.Drawing.Point(12, 21);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(594, 20);
            this.txtRuta.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(621, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // barraStatus
            // 
            this.barraStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.barraStatus.Location = new System.Drawing.Point(0, 491);
            this.barraStatus.Name = "barraStatus";
            this.barraStatus.Size = new System.Drawing.Size(1105, 22);
            this.barraStatus.TabIndex = 2;
            this.barraStatus.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tvCarpetas
            // 
            this.tvCarpetas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tvCarpetas.CheckBoxes = true;
            this.tvCarpetas.ContextMenuStrip = this.contextMenuStrip1;
            this.tvCarpetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvCarpetas.Location = new System.Drawing.Point(12, 56);
            this.tvCarpetas.Name = "tvCarpetas";
            treeNode1.Name = "Node0";
            treeNode1.Text = "/";
            this.tvCarpetas.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvCarpetas.Size = new System.Drawing.Size(642, 407);
            this.tvCarpetas.TabIndex = 3;
            this.tvCarpetas.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvCarpetas_AfterCheck);
            this.tvCarpetas.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCarpetas_AfterSelect);
            this.tvCarpetas.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvCarpetas_NodeMouseClick_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirCarpetaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // abrirCarpetaToolStripMenuItem
            // 
            this.abrirCarpetaToolStripMenuItem.Name = "abrirCarpetaToolStripMenuItem";
            this.abrirCarpetaToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.abrirCarpetaToolStripMenuItem.Text = "&Abrir";
            this.abrirCarpetaToolStripMenuItem.Click += new System.EventHandler(this.abrirCarpetaToolStripMenuItem_Click);
            // 
            // pbFoto
            // 
            this.pbFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFoto.Location = new System.Drawing.Point(669, 56);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(424, 407);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 4;
            this.pbFoto.TabStop = false;
            // 
            // frmVisorImagenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 513);
            this.Controls.Add(this.pbFoto);
            this.Controls.Add(this.tvCarpetas);
            this.Controls.Add(this.barraStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRuta);
            this.Name = "frmVisorImagenes";
            this.Text = "frmVisorImagenes";
            this.Load += new System.EventHandler(this.frmVisorImagenes_Load);
            this.barraStatus.ResumeLayout(false);
            this.barraStatus.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip barraStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TreeView tvCarpetas;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirCarpetaToolStripMenuItem;
    }
}