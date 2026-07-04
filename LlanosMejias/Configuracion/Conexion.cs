using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LlanosMejias.Configuracion
{
    public class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection conection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\vikll\\source\\repos\\LlanosMejias\\LlanosMejias\\App_Data\\PRUEBA4.mdf;Integrated Security=True");
            conection.Open();
            return conection;
        }
    }
}