using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DALUsuario
    {
        private DALConexion conexion = new DALConexion();

        SqlDataReader dataReader;
        DataTable table = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void CreateUsuario(string usuario, string contrasena, int intentos, double nivelSeg, DateTime fechaReg)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_INSERTAR_USUARIO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contrasena", contrasena);
            comando.Parameters.AddWithValue("@intentos", intentos);
            comando.Parameters.AddWithValue("@nivelSeg", nivelSeg);
            comando.Parameters.AddWithValue("@fechaReg", fechaReg);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable ReadAllUsuario()
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_SELECCIONAR_ALL_USUARIO";
            comando.CommandType = CommandType.StoredProcedure;
            dataReader = comando.ExecuteReader();
            table.Load(dataReader);
            conexion.CloseConnection();
            return table;
        }

        public void UpdateUsuario(string usuario, string contrasena, int intentos, double nivelSeg, DateTime fechaReg, int id)
        {

            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ACTUALIZAR_USUARIO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@contrasena", contrasena);
            comando.Parameters.AddWithValue("@intentos", intentos);
            comando.Parameters.AddWithValue("@nivelSeg", nivelSeg);
            comando.Parameters.AddWithValue("@fechaReg", fechaReg);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void DeleteUsuario(int id)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ELIMINAR_USUARIO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }


    }
}
