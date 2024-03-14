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
    El control MaskedTextBox en C# se utiliza para restringir la entrada del usuario a un formato específico 
    mediante una "máscara" predefinida, esta máscara determina qué caracteres pueden ser introducidos por el 
    usuario, facilitando la entrada de datos con un formato específico, como números de teléfono, códigos 
    postales, fechas, entre otros.
    En mi ejemplo, he creado una instancia de MaskedTextBox llamada maskedTextBox1 y le he asignado la máscara 
    "0000-0000", que corresponde al formato de los números telefónicos en El Salvador.
    Cuando el formulario se carga, la máscara se aplica al MaskedTextBox, lo que significa que el usuario 
    solo podrá ingresar números siguiendo el formato especificado, luego, en el evento del botón btnMostrar, 
    al hacer clic, se muestra un MessageBox con el contenido del MaskedTextBox, que estará formateado de acuerdo 
    a la máscara.
*/

namespace _1.MaskedTextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "0000-0000"; // Máscara para números telefónicos salvadoreños
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Número telefónico: " + maskedTextBox1.Text);
        }
    }
}