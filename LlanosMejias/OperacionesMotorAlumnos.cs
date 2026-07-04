using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LlanosMejias.Configuracion;

namespace LlanosMejias
{
    public class OperacionesMotorAlumnos
    {
        public bool ComprobarExistenciaRut(string rut)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = "SELECT COUNT(1) FROM Alumnos WHERE Rut = @rut";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    int existe = Convert.ToInt32(cmd.ExecuteScalar());
                    return existe > 0;
                }
            }
        }
        public bool RegistrarNuevoAlumno(string rut, string nombre, double nota1, double nota2, double nota3, double promedio)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = "INSERT INTO Alumnos (Rut, Nombre, Nota1, Nota2, Nota3, Promedio) " +
                               "VALUES (@rut, @nombre, @nota1, @nota2, @nota3, @promedio)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@nota1", nota1);
                    cmd.Parameters.AddWithValue("@nota2", nota2);
                    cmd.Parameters.AddWithValue("@nota3", nota3);
                    cmd.Parameters.AddWithValue("@promedio", promedio);

                    int filas = cmd.ExecuteNonQuery();
                    return filas > 0;
                }
            }
        }
        public DataTable ObtenerColeccionAlumnos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = "SELECT Rut, Nombre, Nota1, Nota2, Nota3, Promedio FROM Alumnos ORDER BY Nombre ASC";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}