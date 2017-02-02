using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing.Imaging;
using ExifLib;
using System.Data.SqlClient;

namespace ImagenesDisco
{
    public partial class Form1 : Form
    {

        List<FileInfo> listadoArchivos;

        delegate void ActualizarControl(Control pControl, string pPropiedad, string pValor);
        //barra.Invoke(new ActualizarControl(ActualizarControlSeguro), barra, "Value", porcentaje);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cargarImagenesDiferentes();    
            
        }

        private void cargarImagenesDiferentes() 
        {
            using (SqlConnection conexion = new SqlConnection("Data Source=(local);Initial Catalog=FotosYael;User ID=sa;password=123456"))
            {
                conexion.Open();

                string query2 = @"SELECT 
*,
convert(varchar(15),fecha_captura,103) AS FECHA_CAPTURA_FORMATO,
convert(varchar(15),fecha_modificacion,103) AS FECHA_MODIFICACION_FORMATO
FROM 
	FOTOS 
where
convert(varchar(15),fecha_captura,103)<>
convert(varchar(15),fecha_modificacion,103)
order by fecha_captura asc
";


                string query = @"SELECT 
RUTA,
convert(varchar(15),fecha_captura,103) AS FECHA_CAPTURA_FORMATO,
--convert(varchar(15),FECHA_CREACION,103) AS FECHA_CREACION_FORMATO,
convert(varchar(15),fecha_modificacion,103) AS FECHA_MODIFICACION_FORMATO,
EXIF

FROM 
	FOTOS 
where
convert(varchar(15),fecha_captura,103)<>
convert(varchar(15),fecha_modificacion,103)
order by fecha_captura DESC
";

                using (SqlCommand comando = new SqlCommand(query, conexion)) 
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataSet ds = new DataSet();
                    adaptador.Fill(ds);



                    dataGridView1.DataSource = ds.Tables[0];
                    
                    
                    
                    
                }

                conexion.Close();
            }
        }

        private void buscarImagenes() 
        {
            listadoArchivos = new List<FileInfo>();
            buscarImagenes(@"x:\", listadoArchivos);


            lblMensaje.Invoke(new ActualizarControl(ActualizarControlSeguro), lblMensaje, "Text", string.Format("{0} imagenes encontradas,preparando guardado", listadoArchivos.Count.ToString()));
        }
        
        private void buscarImagenes(string pRuta, List<FileInfo> listadoArchivos)
        {
            string[] carpetas = System.IO.Directory.GetDirectories(pRuta);

            if (carpetas.Count() == 0)
            {
                string[] imagenes = System.IO.Directory.GetFiles(pRuta);
                foreach (string rutaImagen in imagenes)
                {
                    FileInfo informacionArchivo = new FileInfo(rutaImagen);
                    listadoArchivos.Add(informacionArchivo);

                    lblMensaje.Invoke(new ActualizarControl(ActualizarControlSeguro),lblMensaje, "Text",string.Format("{0} imagenes encontradas", listadoArchivos.Count.ToString())   );
                }
            }
            else
            {
                for (int i = 0; i < carpetas.Length; i++)
                {
                    buscarImagenes(carpetas[i], listadoArchivos);
                }
            }
        }

        private void procesarImagenes() 
        {
            List<string> errores = new List<string>();
            int con = 0, sin = 0, pro = 0;

            while (lblMensaje.Text.IndexOf("preparando") == -1) 
            {
            
            }

            using (SqlConnection conexion = new SqlConnection("Data Source=(local);Initial Catalog=FotosYael;User ID=sa;password=123456"))
            {
                conexion.Open();

                
                foreach (FileInfo info in this.listadoArchivos)
                {


                    DateTime fechaCaptura = DateTime.Now;
                    bool datosEXIF = false;
                    try
                    {
                        pro++;
                        using (ExifReader reader = new ExifReader(info.FullName))
                        {
                            if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized, out fechaCaptura))
                            {
                                datosEXIF = true;
                                con++;
                            }
                            else
                            {
                                sin++;
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        //if(errores.Contains(error.Message)==false)
                        errores.Add(error.Message);
                    }


                    if (datosEXIF)
                    {
                        lblMensaje.Invoke(new ActualizarControl(ActualizarControlSeguro), lblMensaje, "Text", string.Format("Fecha de captura: {0} {1}", fechaCaptura.ToShortDateString(), fechaCaptura.ToShortTimeString()));
                    }
                    else
                    {
                        lblMensaje.Invoke(new ActualizarControl(ActualizarControlSeguro), lblMensaje, "Text", "Sin fecha de captura");
                    }



                    //string query=string.Format("INSERT INTO FOTOS VALUES(@RUTA,@FECHA_CAPTURA,@FECHA_CREACION,@FECHA_MODIFICACION,@EXIF)");
                    string query = string.Format("INSERT INTO FOTOS(RUTA,FECHA_CAPTURA,FECHA_CREACION,FECHA_MODIFICACION,EXIF) VALUES(@RUTA,@FECHA_CAPTURA,@FECHA_CREACION,@FECHA_MODIFICACION,@EXIF)");

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {




                        comando.Parameters.Add(new SqlParameter("@RUTA", info.FullName));

                        if (datosEXIF)
                        {

                            comando.Parameters.Add(new SqlParameter("@FECHA_CAPTURA", fechaCaptura));


                        }
                        else
                        {
                            comando.Parameters.Add(new SqlParameter("@FECHA_CAPTURA", DBNull.Value));


                        }

                        comando.Parameters.Add(new SqlParameter("@FECHA_CREACION", info.CreationTime));
                        comando.Parameters.Add(new SqlParameter("@FECHA_MODIFICACION", info.LastWriteTime));

                        if (datosEXIF)
                        {



                            comando.Parameters.Add(new SqlParameter("@EXIF", "SI"));
                        }
                        else
                        {

                            comando.Parameters.Add(new SqlParameter("@EXIF", "NO"));

                        }



                        comando.ExecuteNonQuery();
                    }

                }
            }
                
            

            lblMensaje.Invoke(new ActualizarControl(ActualizarControlSeguro), lblMensaje, "Text", string.Format( "FIN  pro={0},sin={1},con={2} ",pro,con,sin));
        }


        private void ActualizarControlSeguro(Control pControl, string pPropiedad, object pValor) 
        {
            if (pControl.GetType() == typeof(ProgressBar) )
            {
                switch (pPropiedad) 
                {
                    case "Value": ((ProgressBar)pControl).Value = Convert.ToInt32(pValor); break;
                }

            }
            else if (pControl.GetType() == typeof(Label))
            {
                switch (pPropiedad)
                {
                    case "Text": ((Label)pControl).Text= pValor.ToString(); break;
                }

            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            ThreadStart tsImagenes = new ThreadStart(this.buscarImagenes);
            Thread t = new Thread(tsImagenes);
            t.Start();

            ThreadStart tsProcesar = new ThreadStart(this.procesarImagenes);
            Thread tProcesar = new Thread(tsProcesar);
            tProcesar.Start();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) 
            {
                this.pictureBox1.Image = Image.FromFile(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                string archivoOrigen = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                FolderBrowserDialog seleccionarCarpeta = new FolderBrowserDialog();

                if (seleccionarCarpeta.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
                {
                    File.Copy(archivoOrigen, seleccionarCarpeta.SelectedPath);
                }
            }
        }

       

       
    }
}

