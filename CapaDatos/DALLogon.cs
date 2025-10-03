using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DALLogon
    {

        private DALConexion conexion = new DALConexion();

        public DataTable FindUsuario(string usuario, string contrasena)
        {
            DataTable tabla = new DataTable();
            using (SqlCommand comando = new SqlCommand())
            {
               comando.Connection = conexion.OpenConnection();
               comando.CommandText = "SELECT * FROM USUARIO WHERE usuario = @usuario AND contrasena = @contrasena";
               comando.Parameters.AddWithValue("@usuario", usuario);
               comando.Parameters.AddWithValue("@contrasena", contrasena);
               SqlDataAdapter da = new SqlDataAdapter(comando);
               da.Fill(tabla);
               conexion.CloseConnection();
                        }
            return tabla;
        }

    }
}    


       