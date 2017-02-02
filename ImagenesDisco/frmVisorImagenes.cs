using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace ImagenesDisco
{
    public partial class frmVisorImagenes : Form
    {
        public frmVisorImagenes()
        {
            InitializeComponent();
        }

        private void frmVisorImagenes_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog seleccionCarpeta = new FolderBrowserDialog();

            if (seleccionCarpeta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRuta.Text = seleccionCarpeta.SelectedPath;






                ThreadStart tsCarpetas = new ThreadStart(this.encontrarCarpetas);
                Thread tCarpetas = new Thread(tsCarpetas);
                tCarpetas.Start();

                //encontrarCarpetas();

            }
        }

        private void encontrarCarpetas() 
        {
            string ruta = txtRuta.Text;


            AuxiliarUI auxiliarUI = new AuxiliarUI();

            barraStatus.Invoke(new ActualizarControl(auxiliarUI.ActualizarControlSeguro), barraStatus, "Text0", "Buscando carpetas...");
            string[] listadoCarpetas = Directory.GetDirectories(ruta);

            barraStatus.Invoke(new ActualizarControl(auxiliarUI.ActualizarControlSeguro), barraStatus, "Text0", string.Format("{0} carpetas en directorio seleccionado,buscando carpetas validas...",listadoCarpetas.Count()));

            List<DateTime> listadoCarpetasFecha = new List<DateTime>();
            foreach (string carpeta in listadoCarpetas) 
            {

                string nombreCarpeta = carpeta.Split('\\')[carpeta.Split('\\').Count() - 1];


                if (nombreCarpeta.Length >= 10)
                {
                    //02-10-2014
                    string dia = nombreCarpeta.Substring(0, 2);
                    string mes = nombreCarpeta.Substring(3, 2);
                    string añoa = nombreCarpeta.Substring(6, 4);

                    DateTime carpetaFecha = new DateTime(1983, 08, 21);

                    DateTime.TryParse(string.Format("{0}/{1}/{2}", dia, mes, añoa), out carpetaFecha);


                    if (carpetaFecha.ToShortDateString() != "01/01/0001") 
                    {
                        listadoCarpetasFecha.Add(carpetaFecha);
                    }
                }
            }


            if (listadoCarpetasFecha.Count != 0)
            {
                barraStatus.Invoke(new ActualizarControl(auxiliarUI.ActualizarControlSeguro), barraStatus, "Text0", "Ordenando carpetas...");
                listadoCarpetasFecha.Sort();
                

                tvCarpetas.Nodes[0].Nodes.Clear();

                int indiceNodo = 0;
                foreach (DateTime carpeta in listadoCarpetasFecha) 
                {

                    barraStatus.Invoke(new ActualizarControl(auxiliarUI.ActualizarControlSeguro), barraStatus, "Text0", string.Format("Agregando nodo {0}", carpeta.ToShortDateString()));


                    tvCarpetas.Invoke(new ActualizarControl(auxiliarUI.ActualizarControlSeguro), tvCarpetas, "RAIZ", carpeta.ToShortDateString());

                    TreeNode nodo = tvCarpetas.Nodes[0].Nodes[indiceNodo];
                    



                    string rutaFecha = string.Format(@"{0}\{1}-{2}-{3}", txtRuta.Text, carpeta.Day.ToString().PadLeft(2, '0'), carpeta.Month.ToString().PadLeft(2, '0'), carpeta.Year);
                    string[] archivos = Directory.GetFiles(rutaFecha);

                    int indiceArchivoNodo = 0;
                    foreach (string archivo in archivos)
                    {
                        tvCarpetas.Invoke(new ActualizarControl(auxiliarUI.ActualizarControlSeguro), nodo, "Add", archivo );
                        barraStatus.Invoke(new ActualizarControl(auxiliarUI.ActualizarControlSeguro), barraStatus, "Text0", string.Format("Agregando nodo {0}...Archivo {1} --> {2}", carpeta.ToShortDateString(), indiceArchivoNodo++, archivo));                     
                    }

                    

                    indiceNodo++;
                }





                barraStatus.Invoke(new ActualizarControl(auxiliarUI.ActualizarControlSeguro), barraStatus, "Text0", "");

            }
            else 
            {
                barraStatus.Invoke(new ActualizarControl(auxiliarUI.ActualizarControlSeguro), barraStatus, "Text0", "No se encontraron carpetas válidad en la ruta seleccionada");
            }

         
        }

        private void tvCarpetas_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
        }

        private void abrirCarpetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvCarpetas.SelectedNode != null) 
            {
                if (File.Exists(tvCarpetas.SelectedNode.Text))
                {
                    Process.Start(tvCarpetas.SelectedNode.Text);
                }
                else if(tvCarpetas.SelectedNode.Text.Equals(tvCarpetas.Nodes[0].Text)==false)
                {
                    DateTime nombreCarpeta = Convert.ToDateTime(tvCarpetas.SelectedNode.Text);

                    string ruta = string.Format(@"{0}\{1}-{2}-{3}", txtRuta.Text, nombreCarpeta.Day.ToString().PadLeft(2, '0'), nombreCarpeta.Month.ToString().PadLeft(2, '0'), nombreCarpeta.Year);

                    Process.Start(ruta);

                }
            }
        }

        private void tvCarpetas_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {

                if (File.Exists(e.Node.Text))
                {
                    pbFoto.Image = Image.FromFile(e.Node.Text);
                }
                else
                {
                    DateTime nombreCarpeta = Convert.ToDateTime(e.Node.Text);
                    string ruta = string.Format(@"{0}\{1}-{2}-{3}", txtRuta.Text, nombreCarpeta.Day.ToString().PadLeft(2, '0'), nombreCarpeta.Month.ToString().PadLeft(2, '0'), nombreCarpeta.Year);

                    string[] archivos = Directory.GetFiles(ruta);

                    foreach (string archivo in archivos)
                    {
                        e.Node.Nodes.Add(archivo);
                    }
                }
            }
        }

        private void tvCarpetas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {

                if (File.Exists(e.Node.Text))
                {
                    pbFoto.Image = Image.FromFile(e.Node.Text);
                }
                else
                {
                    DateTime nombreCarpeta = Convert.ToDateTime(e.Node.Text);
                    string ruta = string.Format(@"{0}\{1}-{2}-{3}", txtRuta.Text, nombreCarpeta.Day.ToString().PadLeft(2, '0'), nombreCarpeta.Month.ToString().PadLeft(2, '0'), nombreCarpeta.Year);

                    string[] archivos = Directory.GetFiles(ruta);

                    foreach (string archivo in archivos)
                    {
                        e.Node.Nodes.Add(archivo);
                    }
                }
            }
        }

        private void tvCarpetas_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked) 
            {
                string parar = "";
            }
        }

       
    }
}
