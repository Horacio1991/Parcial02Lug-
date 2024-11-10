using System.Data.SqlClient;
using System.Transactions;
using Entity;
using Mapper;

namespace DAL
{
    public class EstudianteDAL
    {
        private readonly ConexionDB _conexionDB = new ConexionDB();
        private readonly CursoDAL _cursoDAL = new CursoDAL();

        public void AgregarEstudiante(Estudiante estudiante)
        {
            string query = "INSERT INTO ESTUDIANTE (NOMBRE, FECHA_NACIMIENTO, PROMEDIO_ACTUAL, ID_CURSO) " +
                           "VALUES (@NOMBRE, @FECHA_NACIMIENTO, @PROMEDIO_ACTUAL, @ID_CURSO)";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NOMBRE", estudiante.Nombre);
                        cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", estudiante.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@PROMEDIO_ACTUAL", estudiante.PromedioActual);
                        cmd.Parameters.AddWithValue("@ID_CURSO", estudiante.Curso.IdCurso);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al agregar el estudiante: " + ex.Message);
            }
        }

        // Obtener todos los estudiantes
        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            string query = "SELECT * FROM ESTUDIANTE";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idCurso = (int)reader["ID_CURSO"];
                                Curso curso = _cursoDAL.GetById(idCurso);
                                Estudiante estudiante = EstudianteMapper.Map(reader, curso);
                                estudiantes.Add(estudiante);
                            }
                        }
                    }
                }
                return estudiantes;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los estudiantes: " + ex.Message);
            }
        }

        public void EliminarEstudiante(int idEstudiante)
        {
            string query = "DELETE FROM ESTUDIANTE WHERE ID_ESTUDIANTE = @ID_ESTUDIANTE";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_ESTUDIANTE", idEstudiante);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar el estudiante: " + ex.Message);
            }
        }

        public void ActualizarEstudiante(Estudiante estudiante)
        {
            string query = "UPDATE ESTUDIANTE SET NOMBRE = @NOMBRE, PROMEDIO_ACTUAL = @PROMEDIO_ACTUAL, ID_CURSO = @ID_CURSO " +
                           "WHERE ID_ESTUDIANTE = @ID_ESTUDIANTE";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NOMBRE", estudiante.Nombre);
                        cmd.Parameters.AddWithValue("@PROMEDIO_ACTUAL", estudiante.PromedioActual);
                        cmd.Parameters.AddWithValue("@ID_CURSO", estudiante.Curso.IdCurso);
                        cmd.Parameters.AddWithValue("@ID_ESTUDIANTE", estudiante.IdEstudiante);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al actualizar el estudiante: " + ex.Message);
            }
        }

        // Cargar estudiantes masivamente
        public void CargarEstudiantesMasivos(List<Estudiante> estudiantes)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    foreach (var estudiante in estudiantes)
                    {
                        AgregarEstudiante(estudiante);
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la carga masiva de estudiantes: " + ex.Message);
                }
            }
        }
    }
}
