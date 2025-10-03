using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DALProducto
    {
        private DALConexion conexion = new DALConexion();

        SqlDataReader dataReader;
        DataTable table = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void CreateProducto(string nombre, int cantidad)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_INSERTAR_PRODUCTO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable ReadAllProducto()
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_SELECCIONAR_ALL_PRODUCTO";
            comando.CommandType = CommandType.StoredProcedure;
            dataReader = comando.ExecuteReader();
            table.Load(dataReader);
            conexion.CloseConnection();
            return table;
        }

        public void UpdateProducto(string nombre,int cantidad,int id)
        {

            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ACTUALIZAR_PRODUCTO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void DeleteProducto(int id)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ELIMINAR_PRODUCTO";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
