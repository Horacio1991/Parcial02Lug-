using System.Data.SqlClient;
using Entity;

namespace Mapper
{
    public static class EstudianteMapper
    {
        public static Estudiante Map(SqlDataReader reader, Curso curso)
        {
            return new Estudiante
            {
                IdEstudiante = Convert.ToInt32(reader["ID_ESTUDIANTE"]),
                Nombre = reader["NOMBRE"].ToString(),
                FechaNacimiento = Convert.ToDateTime(reader["FECHA_NACIMIENTO"]),
                PromedioActual = Convert.ToDecimal(reader["PROMEDIO_ACTUAL"]),
                Curso = curso 
            };
        }
    }
}
