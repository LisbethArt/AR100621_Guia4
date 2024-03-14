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
using System.Drawing.Drawing2D;

namespace G4_Ejercicio_02
{
    public partial class Form2 : Form
    {
        private bool permitirEditar = true;
        private int indiceSeleccionado = -1;
        public Form2(ComboBox.ObjectCollection materias)
        {
            InitializeComponent();

            // Llenar cmbMateriaNotas con las mismas materias del ComboBox en Form1
            foreach (var materia in materias)
            {
                cmbMateriaNotas.Items.Add(materia);
            }

            // Mostrar los datos en el DataGridView al iniciar el programa
            MostrarDatosEnDataGridView();
        }

        private void cmbMateriaNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpiar cmbCarnet antes de agregar nuevos elementos
            cmbCarnet.Items.Clear();

            // Verificar si hay algún elemento seleccionado en el ComboBox
            if (cmbMateriaNotas.SelectedItem != null)
            {

                // Obtener la materia seleccionada
                string materiaSeleccionada = cmbMateriaNotas.SelectedItem.ToString();

                // Obtener la ruta del archivo de texto
                string rutaArchivo = Path.Combine(Environment.CurrentDirectory, "Alumnos.txt");

                // Verificar si el archivo existe
                if (File.Exists(rutaArchivo))
                {
                    // Leer todas las líneas del archivo de texto
                    string[] lineas = File.ReadAllLines(rutaArchivo);

                    // Iterar sobre cada línea para filtrar los carnets en base a la materia seleccionada
                    for (int i = 0; i < lineas.Length; i += 8) // 8 líneas por cada alumno
                    {
                        // Obtener la materia inscrita del alumno en la línea actual
                        string materiaInscrita = lineas[i + 6].Substring(lineas[i + 6].IndexOf(":") + 2);

                        // Si la materia inscrita coincide con la materia seleccionada, agregar el carné al cmbCarnet
                        if (materiaInscrita == materiaSeleccionada)
                        {
                            // Obtener el carné del alumno
                            string carnet = lineas[i + 2].Substring(lineas[i + 2].IndexOf(":") + 2);

                            // Agregar el carné al cmbCarnet
                            cmbCarnet.Items.Add(carnet);
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado una materia y un carnet
            if (cmbMateriaNotas.SelectedItem == null || cmbCarnet.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una materia y un carnet.");
                return;
            }

            // Validar que se hayan ingresado todas las notas
            if (string.IsNullOrWhiteSpace(txtNota1.Text) ||
                string.IsNullOrWhiteSpace(txtNota2.Text) ||
                string.IsNullOrWhiteSpace(txtNota3.Text) ||
                string.IsNullOrWhiteSpace(txtNota4.Text))
            {
                MessageBox.Show("Por favor, ingrese todas las notas.");
                return;
            }

            // Calcular el promedio de las notas
            decimal nota1 = decimal.Parse(txtNota1.Text);
            decimal nota2 = decimal.Parse(txtNota2.Text);
            decimal nota3 = decimal.Parse(txtNota3.Text);
            decimal nota4 = decimal.Parse(txtNota4.Text);
            decimal promedio = (nota1 + nota2 + nota3 + nota4) / 4;

            // Mostrar el promedio en el TextBox txtPromedio con máximo 2 decimales
            txtPromedio.Text = promedio.ToString("N2");

            // Obtener la materia seleccionada y el carnet
            string materiaSeleccionada = cmbMateriaNotas.SelectedItem.ToString();
            string carnetSeleccionado = cmbCarnet.SelectedItem.ToString();

            // Obtener la ruta del archivo de texto
            string rutaArchivo = Path.Combine(Environment.CurrentDirectory, "NotasAlumnos.txt");
            string[] lineas = File.ReadAllLines(rutaArchivo);
            bool encontrado = false;

            // Si se está permitiendo la edición y se ha seleccionado un índice válido
            if (permitirEditar && indiceSeleccionado != -1)
            {
                // Obtener el índice de inicio del registro seleccionado
                int indiceInicioRegistro = indiceSeleccionado * 8;

                // Actualizar las líneas correspondientes al registro seleccionado
                lineas[indiceInicioRegistro] = $"Materia a Ingresar Notas: {materiaSeleccionada}";
                lineas[indiceInicioRegistro + 1] = $"Carnet del Alumno: {carnetSeleccionado}";
                lineas[indiceInicioRegistro + 2] = $"Nota Periodo 1: {nota1}";
                lineas[indiceInicioRegistro + 3] = $"Nota Periodo 2: {nota2}";
                lineas[indiceInicioRegistro + 4] = $"Nota Periodo 3: {nota3}";
                lineas[indiceInicioRegistro + 5] = $"Nota Periodo 4: {nota4}";
                lineas[indiceInicioRegistro + 6] = $"Promedio: {promedio}";

                // Escribir de nuevo el archivo con el registro actualizado
                File.WriteAllLines(rutaArchivo, lineas);

                // Limpiar la selección de la fila
                dgvNotas.ClearSelection();

                // Limpiar los campos
                LimpiarCampos();

                // Reiniciar el índice seleccionado
                indiceSeleccionado = -1;

                // Reiniciar la variable de permitir edición
                permitirEditar = false;

                // Mostrar los datos actualizados en el DataGridView
                MostrarDatosEnDataGridView();

                return;
            }

            // Iterar sobre cada línea para buscar si ya existe un registro para el estudiante
            for (int i = 0; i < lineas.Length; i += 8)
            {
                if (lineas[i + 1].Contains(carnetSeleccionado) && lineas[i].Contains(materiaSeleccionada))
                {
                    MessageBox.Show("Ya existe una nota para este carnet en esta materia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    encontrado = true;
                    break;
                }
            }

            // Si no se encontró el registro y no se está permitiendo la edición, agregar uno nuevo
            if (!encontrado && !permitirEditar)
            {
                using (StreamWriter writer = File.AppendText(rutaArchivo))
                {
                    writer.WriteLine($"Materia a Ingresar Notas: {materiaSeleccionada}");
                    writer.WriteLine($"Carnet del Alumno: {carnetSeleccionado}");
                    writer.WriteLine($"Nota Periodo 1: {nota1}");
                    writer.WriteLine($"Nota Periodo 2: {nota2}");
                    writer.WriteLine($"Nota Periodo 3: {nota3}");
                    writer.WriteLine($"Nota Periodo 4: {nota4}");
                    writer.WriteLine($"Promedio: {promedio}");
                    writer.WriteLine(); // Agregar una línea en blanco para separar los datos de diferentes alumnos
                }
            }

            // Visualizar los datos en dgvNotas
            MostrarDatosEnDataGridView();

            // Deseleccionar todas las filas después de guardar
            dgvNotas.ClearSelection();
        }

        private void MostrarDatosEnDataGridView()
        {
            // Obtener la ruta del archivo de texto
            string rutaArchivo = Path.Combine(Environment.CurrentDirectory, "NotasAlumnos.txt");

            // Verificar si el archivo existe
            if (File.Exists(rutaArchivo))
            {
                // Limpiar los datos existentes en el DataGridView
                dgvNotas.Rows.Clear();
                dgvNotas.Columns.Clear(); // Limpiar las columnas antes de agregar nuevas

                // Agregar las columnas necesarias
                dgvNotas.Columns.Add("Materia", "Materia");
                dgvNotas.Columns.Add("Carnet", "Carnet");
                dgvNotas.Columns.Add("NotaPeriodo1", "Nota Periodo 1");
                dgvNotas.Columns.Add("NotaPeriodo2", "Nota Periodo 2");
                dgvNotas.Columns.Add("NotaPeriodo3", "Nota Periodo 3");
                dgvNotas.Columns.Add("NotaPeriodo4", "Nota Periodo 4");
                dgvNotas.Columns.Add("Promedio", "Promedio");

                // Leer todas las líneas del archivo de texto
                string[] lineas = File.ReadAllLines(rutaArchivo);

                // Iterar sobre cada línea para extraer los datos de las notas
                for (int i = 0; i < lineas.Length; i += 8) // 8 líneas por cada registro de notas
                {
                    // Crear un array con los datos de la fila
                    string[] datosNotas = new string[7];
                    for (int j = 0; j < 7; j++)
                    {
                        datosNotas[j] = lineas[i + j].Substring(lineas[i + j].IndexOf(":") + 2);
                    }

                    // Agregar la fila al DataGridView
                    dgvNotas.Rows.Add(datosNotas);
                }

                // Ajustar automáticamente el ancho de las columnas para llenar el espacio disponible
                dgvNotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila seleccionada
            if (dgvNotas.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgvNotas.SelectedRows[0];

                // Obtener el índice de la fila seleccionada
                int indice = dgvNotas.Rows.IndexOf(filaSeleccionada);

                // Verificar si el índice es válido
                if (indice >= 0 && indice < dgvNotas.Rows.Count)
                {
                    // Obtener la ruta del archivo de texto
                    string rutaArchivo = Path.Combine(Environment.CurrentDirectory, "NotasAlumnos.txt");

                    // Leer todas las líneas del archivo
                    List<string> lineas = File.ReadAllLines(rutaArchivo).ToList();

                    // Calcular el índice de inicio del registro seleccionado
                    int indiceInicioRegistro = indice * 8;

                    // Eliminar las 8 líneas correspondientes al registro seleccionado
                    lineas.RemoveRange(indiceInicioRegistro, 8);

                    // Escribir de nuevo el archivo sin el registro eliminado
                    File.WriteAllLines(rutaArchivo, lineas.ToArray());

                    // Actualizar el DataGridView
                    MostrarDatosEnDataGridView();

                    // Deseleccionar todas las filas después de eliminar
                    dgvNotas.ClearSelection();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            dgvNotas.ClearSelection();
        }

        private void LimpiarCampos()
        {
            cmbMateriaNotas.SelectedItem = null;
            cmbCarnet.SelectedItem = null;
            txtNota1.Clear();
            txtNota2.Clear();
            txtNota3.Clear();
            txtNota4.Clear();
            txtPromedio.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvNotas_DoubleClick(object sender, EventArgs e)
        {
            if (dgvNotas.SelectedRows.Count > 0)
            {
                DataGridViewRow seleccion = dgvNotas.SelectedRows[0];
                int indice = dgvNotas.Rows.IndexOf(seleccion);

                // Verificar si el índice es válido y si la fila no está vacía
                if (indice >= 0 && indice < dgvNotas.Rows.Count && dgvNotas.Rows[indice].Cells["Carnet"].Value != null)
                {
                    DataGridViewRow fila = dgvNotas.Rows[indice];
                    cmbMateriaNotas.SelectedItem = fila.Cells["Materia"].Value.ToString();
                    cmbCarnet.SelectedItem = fila.Cells["Carnet"].Value.ToString();
                    txtNota1.Text = fila.Cells["NotaPeriodo1"].Value.ToString();
                    txtNota2.Text = fila.Cells["NotaPeriodo2"].Value.ToString();
                    txtNota3.Text = fila.Cells["NotaPeriodo3"].Value.ToString();
                    txtNota4.Text = fila.Cells["NotaPeriodo4"].Value.ToString();

                    // Calcular el promedio de las notas y mostrarlo
                    decimal nota1 = decimal.Parse(txtNota1.Text);
                    decimal nota2 = decimal.Parse(txtNota2.Text);
                    decimal nota3 = decimal.Parse(txtNota3.Text);
                    decimal nota4 = decimal.Parse(txtNota4.Text);
                    decimal promedio = (nota1 + nota2 + nota3 + nota4) / 4;
                    txtPromedio.Text = promedio.ToString("N2");

                    // Permitir la edición y guardar el índice seleccionado
                    permitirEditar = true;
                    indiceSeleccionado = indice;
                }
            }
        }

        // Método para validar que una nota sea menor o igual a 10 pero no mayor
        private void ValidarNota(TextBox textBox)
        {
            if (!decimal.TryParse(textBox.Text, out decimal nota) || nota < 0 || nota > 10)
            {
                MessageBox.Show("Por favor, ingrese una nota válida entre 0 y 10.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.SelectAll(); // Selecciona todo el texto en el TextBox
                textBox.Focus(); // Pone el foco en el TextBox
            }
        }

        private void txtNota1_Leave(object sender, EventArgs e)
        {
            ValidarNota(txtNota1);
        }

        private void txtNota2_Leave(object sender, EventArgs e)
        {
            ValidarNota(txtNota2);
        }

        private void txtNota3_Leave(object sender, EventArgs e)
        {
            ValidarNota(txtNota3);
        }

        private void txtNota4_Leave(object sender, EventArgs e)
        {
            ValidarNota(txtNota4);
        }
    }
}