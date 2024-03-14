using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //tratará de realizar la acción solicitada
            try
            {
                float numera = float.Parse(txtDividendo.Text);
                float denomina = float.Parse(txtDivisor.Text);
                float resultado = numera / denomina;
                txtResultado.Text = Convert.ToString(resultado);
            }
            //si no pudiera hacerlo entonces verificará cual es el error y nos los mostrará
            catch (Exception error)
            {
                MessageBox.Show("El problema es: " + error.Message);
            }
        }

        private void btnReintentar_Click(object sender, EventArgs e)
        {
            txtDividendo.Clear();
            txtDivisor.Clear();
            txtDividendo.Focus();
        }
    }
}
