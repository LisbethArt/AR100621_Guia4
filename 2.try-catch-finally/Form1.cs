using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    La diferencia clave entre try-catch y try-catch-finally es que el bloque finally se ejecutará siempre, 
    incluso si no se produce una excepción. Esto es útil para realizar tareas de limpieza o liberar 
    recursos, ya que garantiza que cierto código se ejecute, independientemente de si se produjo una 
    excepción o no.
*/

namespace _2.try_catch_finally
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(txtNumero1.Text);
                int num2 = Convert.ToInt32(txtNumero2.Text);
                int resultado = num1 / num2;
                MessageBox.Show("El resultado de la división es: " + resultado);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese números válidos.");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("No se puede dividir entre cero.");
            }
            finally
            {
                MessageBox.Show("Esta parte se ejecuta siempre, independientemente de si hay una excepción o no.");
            }
        }
    }
}