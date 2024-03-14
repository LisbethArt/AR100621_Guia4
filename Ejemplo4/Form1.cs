using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            Empleado miEmpleado = new Empleado();
            try
            {
                miEmpleado.Carnet = int.Parse(txtCarnet.Text);
                miEmpleado.Nombre = txtNombre.Text;
                miEmpleado.Edad = int.Parse(txtEdad.Text);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                txtCarnet.Text = "";
                txtNombre.Text = "";
                txtEdad.Text = "";
                txtCarnet.Focus();
                return;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}