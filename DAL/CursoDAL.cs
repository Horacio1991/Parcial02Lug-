using System.Data.SqlClient;
using Entity;
using Mapper;

namespace DAL
{
    public class CursoDAL
    {
        private readonly ConexionDB _conexionDB = new ConexionDB();

        // Obtener todos los cursos
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();
            string query = "SELECT * FROM CURSO";

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
                                cursos.Add(CursoMapper.Map(reader));
                            }
                        }
                    }
                }
                return cursos;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los cursos: " + ex.Message);
            }
        }

        // Obtener un curso por ID
        public Curso GetById(int idCurso)
        {
            string query = "SELECT * FROM CURSO WHERE ID_CURSO = @ID_CURSO";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID_CURSO", idCurso);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return CursoMapper.Map(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener el curso: " + ex.Message);
            }

            return null;
        }
    }
}
