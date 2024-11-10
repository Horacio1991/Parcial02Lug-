
using System.Transactions;
using DAL;
using Entity;

namespace BLL
{
    public class EstudianteBLL
    {
        private readonly EstudianteDAL _estudianteDal;
        private readonly CursoDAL _cursoDal;

        public EstudianteBLL()
        {
            _estudianteDal = new EstudianteDAL();
            _cursoDal = new CursoDAL();
        }

        // Validaciones para todos los estudiantes
        private void ValidarEstudiante(Estudiante estudiante, bool esNuevo)
        {
            // Nombre
            if (string.IsNullOrWhiteSpace(estudiante.Nombre) || estudiante.Nombre.Length < 3)
            {
                throw new Exception("El nombre del estudiante debe tener al menos 3 caracteres.");
            }

            // Edad
            if (estudiante.Edad < 16 || estudiante.Edad > 60)
            {
                throw new Exception("La edad del estudiante debe ser mayor o igual a 16 y menor o igual a 60.");
            }

            // Promedio
            if (esNuevo && estudiante.PromedioActual != 0)
            {
                throw new Exception("El promedio inicial de un nuevo estudiante debe ser cero.");
            }
            else if (!esNuevo && (estudiante.PromedioActual < 0 || estudiante.PromedioActual > 10))
            {
                throw new Exception("El promedio debe estar entre 0 y 10.");
            }

            // Curso
            if (estudiante.Curso == null || _cursoDal.GetById(estudiante.Curso.IdCurso) == null)
            {
                throw new Exception("Debe seleccionar un curso válido.");
            }
        }

        // Agregar un solo estudiante
        public void AgregarEstudiante(Estudiante estudiante)
        {
            ValidarEstudiante(estudiante, esNuevo: true);

            using (TransactionScope scope = new TransactionScope())
            {
                
                try
                {
                    _estudianteDal.AgregarEstudiante(estudiante);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el estudiante en la capa de negocio: " + ex.Message);
                }
            }
        }

        // Carga masiva de estudiantes
        public void CargarEstudiantesMasivos(List<Estudiante> estudiantes)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    foreach (var estudiante in estudiantes)
                    {
                        ValidarEstudiante(estudiante, esNuevo: true);
                        _estudianteDal.AgregarEstudiante(estudiante);
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la carga masiva de estudiantes: " + ex.Message);
                }
            }
        }

        // Obtener todos los estudiantes
        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {
                return _estudianteDal.ObtenerTodosLosEstudiantes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al obtener los estudiantes: " + ex.Message);
            }
        }

        // Actualizar un estudiante
        public void ActualizarEstudiante(Estudiante estudiante)
        {
            // Validar que el estudiante exista en la base de datos
            if (_estudianteDal.ObtenerTodosLosEstudiantes().Find(e => e.IdEstudiante == estudiante.IdEstudiante) == null)
            {
                throw new Exception("El estudiante que intenta modificar no existe.");
            }

            ValidarEstudiante(estudiante, esNuevo: false);

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _estudianteDal.ActualizarEstudiante(estudiante);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el estudiante en la capa de negocio: " + ex.Message);
                }
            }
        }

        // Eliminar un estudiante
        public void EliminarEstudiante(int idEstudiante)
        {
            if (_estudianteDal.ObtenerTodosLosEstudiantes().Find(e => e.IdEstudiante == idEstudiante) == null)
            {
                throw new Exception("El estudiante que intenta eliminar no existe.");
            }

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _estudianteDal.EliminarEstudiante(idEstudiante);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el estudiante en la capa de negocio: " + ex.Message);
                }
            }
        }

        // Obtener todos los cursos, se usara para cargar el combo box
        public List<Curso> ObtenerCursos()
        {
            try
            {
                return _cursoDal.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa de negocio al obtener los cursos: " + ex.Message);
            }
        }
    }
}
