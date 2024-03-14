using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.ExpresionesRegulares
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtSitioWeb_Leave(object sender, EventArgs e)
        {
            // Expresión regular para validar URL de sitio web (con o sin http(s)://)
            string expresion = @"^(https?://)?(www\.)?[a-zA-Z0-9][a-zA-Z0-9-]*\.[a-z]{2,}(/.*)?$";
            if (!Regex.IsMatch(txtSitioWeb.Text, expresion))
            {
                MessageBox.Show("URL del sitio web no válida");
                txtSitioWeb.SelectAll();
                txtSitioWeb.Focus();
            }
        }

        private void txtNumeroTelefonico_Leave(object sender, EventArgs e)
        {
            // Expresión regular para validar número telefónico
            string expresion = @"^\d{4}-\d{4}$";
            if (!Regex.IsMatch(txtNumeroTelefonico.Text, expresion))
            {
                MessageBox.Show("Número telefónico no válido");
                txtNumeroTelefonico.SelectAll();
                txtNumeroTelefonico.Focus();
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            // Expresión regular para validar formato de correo electrónico
            string expresion = @"^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,})$";
            if (!Regex.IsMatch(txtCorreo.Text, expresion))
            {
                MessageBox.Show("Dirección de correo no válida");
                txtCorreo.SelectAll();
                txtCorreo.Focus();
            }
        }

        private void txtCarnet_Leave(object sender, EventArgs e)
        {
            // Expresión regular para validar formato de carnet de identidad (formato de El Salvador)
            string expresion = @"^[A-Z]{2}\d{6}$";
            if (!Regex.IsMatch(txtCarnet.Text, expresion))
            {
                MessageBox.Show("Número de carnet no válido");
                txtCarnet.SelectAll();
                txtCarnet.Focus();
            }
        }

        private void txtTarjeta_Leave(object sender, EventArgs e)
        {
            // Expresión regular para validar números de tarjeta de crédito en un formato genérico de 16 dígitos separados por guiones
            string expresion = @"^\d{4}-\d{4}-\d{4}-\d{4}$";
            if (!Regex.IsMatch(txtTarjeta.Text, expresion))
            {
                MessageBox.Show("Número de tarjeta de crédito no válido");
                txtTarjeta.SelectAll();
                txtTarjeta.Focus();
            }
        }

        private void txtDireccionesIP_Leave(object sender, EventArgs e)
        {
            // Expresión regular para validar direcciones IP en formato IPv4
            string expresion = @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            if (!Regex.IsMatch(txtDireccionesIP.Text, expresion))
            {
                MessageBox.Show("Dirección IP no válida");
                txtDireccionesIP.SelectAll();
                txtDireccionesIP.Focus();
            }
        }
    }
}