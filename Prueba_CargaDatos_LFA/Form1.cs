using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Prueba_CargaDatos_LFA
{
    public partial class Form1 : Form
    {
        string alfabeto = "";
        Dictionary<string, string> dic;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnCargaArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                this.ofdCargarArchivo.InitialDirectory = @"C:\";
                this.ofdCargarArchivo.Title = "Carga de Archivo";
                this.ofdCargarArchivo.CheckFileExists = true;
                this.ofdCargarArchivo.CheckPathExists = true;
                this.ofdCargarArchivo.DefaultExt = ".txt";
                this.ofdCargarArchivo.Filter = "Archivos de Texto (*.txt)|*.txt"; //OJO
                this.ofdCargarArchivo.RestoreDirectory = true;
                this.ofdCargarArchivo.FilterIndex = 2;
                this.ofdCargarArchivo.ShowReadOnly = true;
                this.ofdCargarArchivo.ReadOnlyChecked = true;

                if (this.ofdCargarArchivo.ShowDialog() == DialogResult.OK)
                {
                    this.txtRutaArchivo.Text = this.ofdCargarArchivo.FileName;
                    this.ConvertTxtTabla(this.txtRutaArchivo.Text);
                }
            }
            catch (Exception ex)
            {
                string n = ex.Message;

                throw;
            }

        }
        private DataTable ConvertTxtTabla(string ruta)
        {
            DataTable dtDatos = new DataTable();
            ManejoData data = new ManejoData();

            string linea;
            try
            {
                FileInfo fiArchivo = new FileInfo(ruta);
                StreamReader srLeerArchivo = new StreamReader(ruta,System.Text.Encoding.UTF8);
                data.ObtenerValores(srLeerArchivo.ReadToEnd());
                alfabeto = data.alfabeto;
                dic = data.Transiciones;
                //this.ObtenerValores(Data);

                using (srLeerArchivo = fiArchivo.OpenText())
                {
                    linea = srLeerArchivo.ReadLine();
                    while (linea!= null)
                    {
                        richTextBox1.AppendText(linea+"\n");
                        linea = srLeerArchivo.ReadLine();
                    }
                }
                return dtDatos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form Prueba = new PruebaMaquina(alfabeto,dic);
            Prueba.Show();
        }
    }
}
