using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases_MT;

namespace Prueba_CargaDatos_LFA
{
    public partial class PruebaMaquina : Form
    {
        Class1 movimiento = new Class1();
        string alfabeto = "";
        int posicion = 0;
        int estadoactual = 0;
        string ultimatransicion = "";
        Dictionary<string, string> dicc;
        public PruebaMaquina(string cinta, Dictionary<string, string> dic)
        {
            alfabeto = cinta;
            dicc = dic;
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            movimiento.Movimiento(ref alfabeto, dicc, ref posicion, ref estadoactual, ref ultimatransicion);
            label1.Text = posicion.ToString();
            label2.Text = alfabeto.ToString();
            label3.Text = estadoactual.ToString();
            label4.Text = ultimatransicion.ToString();
        }

        private void PruebaMaquina_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label1.Text = posicion.ToString();
            label2.Text = alfabeto.ToString();
            label3.Text = estadoactual.ToString();
            label4.Text = ultimatransicion.ToString();
        }
    }
}
