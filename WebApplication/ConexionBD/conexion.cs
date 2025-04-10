using Microsoft.Data.SqlClient;

namespace WebApplication.ConexionBD
{
    public class conexion
    {
        public static SqlConnection conectate()
        {
            SqlConnection con = new SqlConnection("Server=ALMILCAR; DataBase=BDPROYECTORETO;Integrated Security=true; Encrypt=False");
            con.Open();
            return con;
        }
    }
}
