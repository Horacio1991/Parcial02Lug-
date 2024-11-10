using System.Data.SqlClient;
using Entity;

namespace Mapper
{
    public static class CursoMapper
    {
        public static Curso Map(SqlDataReader reader)
        {
            return new Curso
            {
                IdCurso = Convert.ToInt32(reader["ID_CURSO"]),
                NombreCurso = reader["NOMBRE_CURSO"].ToString(),
                Profesor = reader["PROFESOR"].ToString(),
                Horario = reader["HORARIO"].ToString()
            };
        }
    }
}
