
using BLL;
using Entity;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly EstudianteBLL _estudianteBLL;
        private List<Estudiante> _estudiantesEnMemoria; // Lista que voy a usar para la carga masiva
        public Form1()
        {
            InitializeComponent();
            _estudianteBLL = new EstudianteBLL();
            _estudiantesEnMemoria = new List<Estudiante>();
            CargarCursos();
            CargarEstudiantesEnGrilla();
            txtPromedio.Text = "0";
        }

        private void CargarCursos()
        {
            List<Curso> cursos = _estudianteBLL.ObtenerCursos();
            cmbCurso.DataSource = cursos;
            cmbCurso.DisplayMember = "NombreCurso";
            cmbCurso.ValueMember = "IdCurso";

            cmbNuevoCurso.DataSource = cursos;
            cmbNuevoCurso.DisplayMember = "NombreCurso";
            cmbNuevoCurso.ValueMember = "IdCurso";
        }

        // Cargar estudiantes en el DataGridView
        private void CargarEstudiantesEnGrilla()
        {
            List<Estudiante> estudiantes = _estudianteBLL.ObtenerTodosLosEstudiantes();
            dgvEstudiantes.DataSource = estudiantes;

            // Configuración estética de las columnas
            dgvEstudiantes.Columns["FechaNacimiento"].HeaderText = "Fecha de Nacimiento";
            dgvEstudiantes.Columns["PromedioActual"].HeaderText = "Promedio";
            dgvEstudiantes.Columns["Curso"].Visible = false;

            // Agregar columna para la descripción del curso
            if (!dgvEstudiantes.Columns.Contains("NombreCurso"))
            {
                DataGridViewTextBoxColumn cursoColumn = new DataGridViewTextBoxColumn
                {
                    Name = "NombreCurso",
                    HeaderText = "Curso",
                    ReadOnly = true
                };
                dgvEstudiantes.Columns.Add(cursoColumn);
            }

            // Rellenar la columna con el nombre del curso
            foreach (DataGridViewRow row in dgvEstudiantes.Rows)
            {
                Estudiante estudiante = row.DataBoundItem as Estudiante;
                if (estudiante != null)
                {
                    row.Cells["NombreCurso"].Value = estudiante.Curso.NombreCurso;
                }
            }
        }

        // Limpiar campos de texto
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPromedio.Text="0";
            txtIdEstudiante.Clear();
            txtNuevoNombre.Clear();
            txtNuevoPromedio.Clear();
            txtEliminarEstudiante.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
        }

        // Cargar un solo estudiante
        private void btnCargarEstudiante_Click_1(object sender, EventArgs e)
        {
            try
            {
                var estudiante = CrearEstudianteDesdeFormulario();
                _estudianteBLL.AgregarEstudiante(estudiante);

                MessageBox.Show("Estudiante cargado exitosamente.");
                LimpiarCampos();
                CargarEstudiantesEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        // Agregar a la lista en memoria
        private void btnAgregarLista_Click_1(object sender, EventArgs e)
        {
            try
            {
                var estudiante = CrearEstudianteDesdeFormulario();
                _estudiantesEnMemoria.Add(estudiante);
                MessageBox.Show("Estudiante agregado a la lista en memoria.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        // cargar los estudiantes en memoria
        private void btnConfirmarLista_Click_1(object sender, EventArgs e)
        {
            try
            {
                _estudianteBLL.CargarEstudiantesMasivos(_estudiantesEnMemoria);
                MessageBox.Show("Carga masiva realizada con éxito.");
                _estudiantesEnMemoria.Clear();
                CargarEstudiantesEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga masiva: " + ex.Message);
                _estudiantesEnMemoria.Clear();
            }
        }

        private void btnModificarEstudiante_Click_1(object sender, EventArgs e)
        {
            try
            {
                int idEstudiante = int.Parse(txtIdEstudiante.Text);
                var estudiante = CrearEstudianteDesdeFormularioModificado(idEstudiante);
                _estudianteBLL.ActualizarEstudiante(estudiante);

                MessageBox.Show("Estudiante modificado exitosamente.");
                LimpiarCampos();
                CargarEstudiantesEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el estudiante: " + ex.Message);
            }
        }

        private void btnEliminarEstudiante_Click_1(object sender, EventArgs e)
        {
            try
            {
                int idEstudiante = int.Parse(txtEliminarEstudiante.Text);
                _estudianteBLL.EliminarEstudiante(idEstudiante);

                MessageBox.Show("Estudiante eliminado exitosamente.");
                LimpiarCampos();
                CargarEstudiantesEnGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el estudiante: " + ex.Message);
            }
        }


        // Crear un objeto Estudiante desde los campos del formulario
        private Estudiante CrearEstudianteDesdeFormulario()
        {
            Curso cursoSeleccionado = (Curso)cmbCurso.SelectedItem;
            return new Estudiante
            {
                Nombre = txtNombre.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                PromedioActual = decimal.Parse(txtPromedio.Text),
                Curso = cursoSeleccionado
            };
        }

        private Estudiante CrearEstudianteDesdeFormularioModificado(int idEstudiante)
        {
            // Obtener el estudiante actual desde la base de datos para recuperar su fecha de nacimiento
            Estudiante estudianteExistente = _estudianteBLL.ObtenerTodosLosEstudiantes().Find(e => e.IdEstudiante == idEstudiante);
            if (estudianteExistente == null)
            {
                throw new Exception("No se encontró el estudiante a modificar.");
            }

            Curso cursoSeleccionado = (Curso)cmbNuevoCurso.SelectedItem;
            return new Estudiante
            {
                IdEstudiante = idEstudiante,
                Nombre = txtNuevoNombre.Text,
                FechaNacimiento = estudianteExistente.FechaNacimiento, // Usar la fecha de nacimiento original
                PromedioActual = decimal.Parse(txtNuevoPromedio.Text),
                Curso = cursoSeleccionado
            };
        }

        // Cargar los datos del estudiante seleccionado en los campos de modificación
        // Mejora en la usabilidad de la aplicación
        private void dgvEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow filaSeleccionada = dgvEstudiantes.Rows[e.RowIndex];
                Estudiante estudianteSeleccionado = filaSeleccionada.DataBoundItem as Estudiante;

                if (estudianteSeleccionado != null)
                {
                    // Autocompletar campo de eliminación con el ID del estudiante
                    txtEliminarEstudiante.Text = estudianteSeleccionado.IdEstudiante.ToString();

                    // Autocompletar campos de modificación con los datos del estudiante seleccionado
                    txtIdEstudiante.Text = estudianteSeleccionado.IdEstudiante.ToString();
                    txtNuevoNombre.Text = estudianteSeleccionado.Nombre;
                    txtNuevoPromedio.Text = estudianteSeleccionado.PromedioActual.ToString();

                    // Seleccionar el curso correcto en el combo box de curso
                    cmbNuevoCurso.SelectedItem = estudianteSeleccionado.Curso;
                }
            }
        }
    }
}
