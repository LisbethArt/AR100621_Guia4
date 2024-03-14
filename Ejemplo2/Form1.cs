using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool validarCampos()
        {
            //variable que verifica si algo ha sido validado
            bool validado = true;
            if (txtNombre.Text == "") //vefica que no quede vacío el campo
            {
                validado = false; //si está vacío validado es falso
                errorProvider1.SetError(txtNombre, "Ingresar nombre"); //por lo tanto manda a llamar a errorprovider
            //en los parámetros de setError se identifica a quién estoy validando y el mensaje que deseo mandar
        }
            //verifico la casilla de apellido
            if (txtApellido.Text == "")
            {
                validado = false;
                //digo que verifico a txtapellido y si no cumple mando ese mensaje
                errorProvider1.SetError(txtApellido, "Ingrese apellido");
            }
            return validado;
        }
        private void BorrarMesaje()
        {
            //borra los mensajes para que no se muestren y pueda limpiar
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtApellido, "");
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {
            //limpia cualquier mensaje de error de alguna corrida previa
            BorrarMesaje();
            //llamamos al método para validar campos, el de nombre y apellido
            if (validarCampos())
            {
                MessageBox.Show("Los datos se ingresaron correctamente");
            }
            //verificamos la fecha de nacimiento que nos den
            //DateTimePicker se llama dtpFechaNacimiento
            DateTime fechaNacimiento = dtpFechaNacimiento.Value;
            //verificamos la fecha del sistema (solo calculamos con los años
            int anios = System.DateTime.Now.Year - fechaNacimiento.Year;
            /*verificamos aparte del año si ya pasamos la fecha de nacimiento de este año o nos 
            faltan días*/
            if (System.DateTime.Now.Subtract(fechaNacimiento.AddYears(anios)).TotalDays < 0)
                //si nos faltan días para cumplir años al cálculo le resta uno
                txtEdad.Text = Convert.ToString(anios - 1);
            else
                //si ya pasó nuestra fecha de nacimiento manda el valor correspondiente
                txtEdad.Text = Convert.ToString(anios);
        }
    }
}