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
using System.IO;

namespace G4_Ejercicio_02
{
    public partial class Form1 : Form
    {

        private bool permitirEditar = true;
        public Form1()
        {
            InitializeComponent();

            cmbMateriaInscrita.Items.Add("Implementación de Lenguajes de Programación para Negocios");
            cmbMateriaInscrita.Items.Add("Analizando Necesidades de Infraestructura de Servidores");
            cmbMateriaInscrita.Items.Add("Gestión Efectiva del Talento Humano");
            cmbMateriaInscrita.Items.Add("Gestión de Indicadores de Rendimiento, Calidad y Seguridad de Redes");
            cmbMateriaInscrita.Items.Add("Presentación Efectiva de Proyectos");

            // Llamar al método para mostrar los datos en el DataGridView
            MostrarDatosEnDataGridView();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(txtNombres.Text) ||
                string.IsNullOrEmpty(txtApellidos.Text) ||
                string.IsNullOrEmpty(txtCarnet.Text) ||
                dtpFechaNacimiento.Value == null ||
                string.IsNullOrEmpty(txtCorreo.Text) ||
                string.IsNullOrEmpty(txtResponsable.Text) ||
                cmbMateriaInscrita.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si el alumno ya está inscrito en la misma materia
            if (AlumnoMateriaExiste(txtCarnet.Text, cmbMateriaInscrita.SelectedItem.ToString()))
            {
                MessageBox.Show("El alumno ya está inscrito en la materia seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un nuevo objeto Alumno con los datos ingresados
            Alumno nuevoAlumno = new Alumno();
            nuevoAlumno.Nombres = txtNombres.Text;
            nuevoAlumno.Apellidos = txtApellidos.Text;
            nuevoAlumno.Carnet = txtCarnet.Text;
            nuevoAlumno.FechaNacimiento = dtpFechaNacimiento.Value.ToString("dd/MM/yyyy");
            nuevoAlumno.Correo = txtCorreo.Text;
            nuevoAlumno.Responsable = txtResponsable.Text;
            nuevoAlumno.MateriaInscrita = cmbMateriaInscrita.SelectedItem.ToString();

            // Guardar los datos en un archivo de texto
            GuardarDatosTexto(nuevoAlumno);

            // Mostrar mensaje de éxito
            MessageBox.Show("Los datos se han guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos del formulario
            LimpiarCampos();

            // Actualizar el DataGridView
            MostrarDatosEnDataGridView();
        }

        private bool AlumnoMateriaExiste(string carnet, string materia)
        {
            // Obtener la ruta del archivo de texto
            string rutaArchivo = Environment.CurrentDirectory + "\\Alumnos.txt";

            // Verificar si el archivo existe
            if (File.Exists(rutaArchivo))
            {
                // Leer todas las líneas del archivo de texto
                string[] lineas = File.ReadAllLines(rutaArchivo);

                // Iterar sobre cada línea para verificar si existe un alumno con el mismo carnet y la misma materia inscrita
                for (int i = 0; i < lineas.Length; i += 8) // 8 líneas por cada alumno
                {
                    string carnets = lineas[i + 2].Substring(lineas[i + 2].IndexOf(":") + 2);
                    string materiaInscrita = lineas[i + 6].Substring(lineas[i + 6].IndexOf(":") + 2);
                    if (carnets.Equals(carnet) && materiaInscrita.Equals(materia))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        private bool AlumnoExiste(string carnet)
        {
            // Obtener la ruta del archivo de texto
            string rutaArchivo = Environment.CurrentDirectory + "\\Alumnos.txt";

            // Verificar si el archivo existe
            if (File.Exists(rutaArchivo))
            {
                // Leer todas las líneas del archivo de texto
                string[] lineas = File.ReadAllLines(rutaArchivo);

                // Iterar sobre cada línea para verificar si existe un alumno con el mismo carné y la misma materia inscrita
                for (int i = 0; i < lineas.Length; i += 8) // 8 líneas por cada alumno
                {
                    string carnets = lineas[i + 2].Substring(lineas[i + 2].IndexOf(":") + 2);
                    if (carnets.Equals(carnet))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void GuardarDatosTexto(Alumno alumno)
        {
            // Obtener la ruta del archivo de texto
            string rutaArchivo = Environment.CurrentDirectory + "\\Alumnos.txt";

            // Verificar si el carné del alumno ya existe en el archivo
            if (AlumnoExiste(alumno.Carnet))
            {
                // Verificar si el alumno ya está inscrito en la misma materia
                if (AlumnoMateriaExiste(alumno.Carnet, alumno.MateriaInscrita))
                {
                    MessageBox.Show("El alumno ya está inscrito en la materia seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Agregar un nuevo registro al final del archivo
            using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            {
                writer.WriteLine("Nombres: " + alumno.Nombres);
                writer.WriteLine("Apellidos: " + alumno.Apellidos);
                writer.WriteLine("Carnet: " + alumno.Carnet);
                writer.WriteLine("Fecha de Nacimiento: " + alumno.FechaNacimiento);
                writer.WriteLine("Correo Electrónico: " + alumno.Correo);
                writer.WriteLine("Responsable: " + alumno.Responsable);
                writer.WriteLine("Materia Inscrita: " + alumno.MateriaInscrita);
                writer.WriteLine(); // Agregar una línea en blanco para separar los datos de diferentes alumnos
            }
        }

        private void MostrarDatosEnDataGridView()
        {
            // Obtener la ruta del archivo de texto
            string rutaArchivo = Environment.CurrentDirectory + "\\Alumnos.txt";

            // Verificar si el archivo existe
            if (File.Exists(rutaArchivo))
            {
                // Limpiar los datos existentes en el DataGridView
                dgvAlumnos.Rows.Clear();
                dgvAlumnos.Columns.Clear(); // Limpiar las columnas antes de agregar nuevas

                // Agregar las columnas necesarias
                dgvAlumnos.Columns.Add("Nombres", "Nombres");
                dgvAlumnos.Columns.Add("Apellidos", "Apellidos");
                dgvAlumnos.Columns.Add("Carnet", "Carnet");
                dgvAlumnos.Columns.Add("FechaNacimiento", "Fecha de Nacimiento");
                dgvAlumnos.Columns.Add("Correo", "Correo Electrónico");
                dgvAlumnos.Columns.Add("Responsable", "Responsable");
                dgvAlumnos.Columns.Add("MateriaInscrita", "Materia Inscrita");

                // Leer todas las líneas del archivo de texto
                string[] lineas = File.ReadAllLines(rutaArchivo);

                // Iterar sobre cada línea para extraer los datos de los alumnos
                for (int i = 0; i < lineas.Length; i += 8) // 8 líneas por cada alumno
                {
                    // Crear un array con los datos de la fila
                    string[] datosAlumno = new string[7];
                    for (int j = 0; j < 7; j++)
                    {
                        datosAlumno[j] = lineas[i + j].Substring(lineas[i + j].IndexOf(":") + 2);
                    }

                    // Agregar la fila al DataGridView
                    dgvAlumnos.Rows.Add(datosAlumno);
                }

                // Ajustar automáticamente el ancho de las columnas para llenar el espacio disponible
                dgvAlumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LimpiarCampos()
        {
            // Limpiar los campos del formulario
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtCarnet.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            txtCorreo.Text = "";
            txtResponsable.Text = "";
            cmbMateriaInscrita.SelectedIndex = -1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count > 0) // Verificar si hay alguna fila seleccionada
            {
                int indice = dgvAlumnos.SelectedRows[0].Index; // Obtener el índice de la fila seleccionada

                // Verificar si el índice es válido
                if (indice >= 0 && indice < dgvAlumnos.Rows.Count)
                {
                    // Obtener el carné del alumno a eliminar
                    string carnetEliminar = dgvAlumnos.Rows[indice].Cells["Carnet"].Value.ToString();

                    // Eliminar el alumno del archivo de texto
                    EliminarAlumno(carnetEliminar);

                    // Eliminar la fila del DataGridView
                    dgvAlumnos.Rows.RemoveAt(indice);

                    // Mostrar mensaje de éxito
                    MessageBox.Show("El alumno ha sido eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar todos los campos
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("El índice seleccionado no es válido.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un alumno primero.");
            }

            // Restablecer la variable permitirEditar a true después de eliminar
            permitirEditar = true;

            // Limpiar la selección después de eliminar
            dgvAlumnos.ClearSelection();
        }

        private void EliminarAlumno(string carnet)
        {
            // Obtener la ruta del archivo de texto
            string rutaArchivo = Environment.CurrentDirectory + "\\Alumnos.txt";

            // Leer todas las líneas del archivo de texto
            string[] lineas = File.ReadAllLines(rutaArchivo);

            // Crear un nuevo archivo temporal para guardar los datos sin el alumno a eliminar
            string archivoTemporal = Path.GetTempFileName();

            using (StreamWriter writer = new StreamWriter(archivoTemporal))
            {
                for (int i = 0; i < lineas.Length; i += 8) // 8 líneas por cada alumno
                {
                    // Obtener el carné del alumno en la línea actual
                    string carnets = lineas[i + 2].Substring(lineas[i + 2].IndexOf(":") + 2);

                    // Verificar si el carné coincide con el carné a eliminar
                    if (!carnets.Equals(carnet))
                    {
                        // Escribir las líneas del alumno en el archivo temporal
                        for (int j = 0; j < 8; j++)
                        {
                            writer.WriteLine(lineas[i + j]);
                        }
                    }
                }
            }

            // Reemplazar el archivo original con el archivo temporal
            File.Delete(rutaArchivo);
            File.Move(archivoTemporal, rutaArchivo);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar la selección en el DataGridView
            dgvAlumnos.ClearSelection();

            // Restablecer el estado para agregar un nuevo registro
            permitirEditar = true;

            // Limpiar los campos del formulario
            LimpiarCampos();
        }

        private void btnIngresarNotas_Click(object sender, EventArgs e)
        {
            // Crear una instancia del Form2
            Form2 formulario = new Form2(cmbMateriaInscrita.Items);
            formulario.Show();

            // Cerrar el Form1
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvAlumnos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count > 0)
            {
                DataGridViewRow seleccion = dgvAlumnos.SelectedRows[0];
                int indice = dgvAlumnos.Rows.IndexOf(seleccion);

                // Verificar si el índice es válido y si la fila no está vacía
                if (indice >= 0 && indice < dgvAlumnos.Rows.Count && dgvAlumnos.Rows[indice].Cells["Carnet"].Value != null)
                {
                    DataGridViewRow fila = dgvAlumnos.Rows[indice];
                    txtNombres.Text = fila.Cells["Nombres"].Value.ToString();
                    txtApellidos.Text = fila.Cells["Apellidos"].Value.ToString();
                    txtCarnet.Text = fila.Cells["Carnet"].Value.ToString();
                    dtpFechaNacimiento.Value = Convert.ToDateTime(fila.Cells["FechaNacimiento"].Value);
                    txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                    txtResponsable.Text = fila.Cells["Responsable"].Value.ToString();
                    cmbMateriaInscrita.SelectedItem = fila.Cells["MateriaInscrita"].Value.ToString();

                    // Deshabilitar la edición
                    permitirEditar = false;
                }
            }
        }

        // Método para validar un correo electrónico
        public static bool ValidarCorreo(string correo)
        {
            //cadena o expresion regular que verifica a un formato de correo electrónico
            string expresion = @"^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,})$";

            //verifica que el email ingresado corresponda con la expresion válida
            if (Regex.IsMatch(correo, expresion))
            {//verifica que la direccion corresponda y que la longitud de la cadena no esté vacía
                if (Regex.Replace(correo, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (ValidarCorreo(txtCorreo.Text))
            {
            }
            else
            {
                MessageBox.Show("Dirección de correo no válida, debe de ingresar el formato correcto y en minúsculas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.SelectAll(); // Selecciona todo el texto en el TextBox
                txtCorreo.Focus(); // Pone el foco en el TextBox
            }
        }

        // Método para validar el formato del carnet
        public static bool ValidarCarnet(string carnet)
        {
            // Expresión regular para validar el formato del carnet: 2 letras mayúsculas seguidas de 6 números
            string expresion = @"^[A-Z]{2}\d{6}$";

            // Verifica si el carnet ingresado corresponde con la expresión regular
            return Regex.IsMatch(carnet, expresion);
        }

        private void txtCarnet_Leave(object sender, EventArgs e)
        {
            if (!ValidarCarnet(txtCarnet.Text))
            {
                MessageBox.Show("Formato de carnet no válido. Debe tener el formato, por ejemplo: 'AR100621'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCarnet.SelectAll(); // Selecciona todo el texto en el TextBox
                txtCarnet.Focus(); // Pone el foco en el TextBox
            }
        }

        // Método para validar la fecha de nacimiento
        public static bool ValidarFechaNacimiento(DateTime fechaNacimiento)
        {
            // Compara la fecha de nacimiento con la fecha actual
            return fechaNacimiento <= DateTime.Today;
        }

        private void dtpFechaNacimiento_Leave(object sender, EventArgs e)
        {
            if (!ValidarFechaNacimiento(dtpFechaNacimiento.Value))
            {
                MessageBox.Show("La fecha de nacimiento no puede ser mayor que la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaNacimiento.Focus(); // Pone el foco en el DateTimePicker
            }
        }

        // Método para validar que un texto tenga al menos 5 letras y no contenga números
        public static bool ValidarTexto(string texto)
        {
            // Expresión regular para validar que el texto tenga al menos 5 letras, permitiendo espacios y mayúsculas pero excluyendo números
            string expresion = @"^[a-zA-Z\s]{5,}$";

            // Verifica si el texto ingresado corresponde con la expresión regular
            return Regex.IsMatch(texto, expresion);
        }

        private void txtNombres_Leave(object sender, EventArgs e)
        {
            if (!ValidarTexto(txtNombres.Text))
            {
                MessageBox.Show("El nombre debe tener al menos 5 letras y no puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombres.Focus(); // Pone el foco en el TextBox de nombres
            }
        }

        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            if (!ValidarTexto(txtApellidos.Text))
            {
                MessageBox.Show("El apellido debe tener al menos 5 letras y no puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtApellidos.Focus(); // Pone el foco en el TextBox de apellidos
            }
        }

        private void txtResponsable_Leave(object sender, EventArgs e)
        {
            if (!ValidarTexto(txtResponsable.Text))
            {
                MessageBox.Show("El nombre del responsable debe tener al menos 5 letras y no puede contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResponsable.Focus(); // Pone el foco en el TextBox de responsable
            }
        }
    }
}