using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DALConexion
    {
        
        /// <summary>
        /// Cadena de conexión para el acceso a la base de datos SQL Server
        /// </summary>
        private SqlConnection Conexion = new SqlConnection("Data Source= DESKTOP-GJDFMRJ\\SQLEXPRESS01;Initial Catalog=BD_TEST;Integrated Security=True;Encrypt=False;");

        /// <summary>
        /// Abrir la conexión hacia la base de datos
        /// </summary>
        /// <returns></returns>
        public SqlConnection OpenConnection()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }

        /// <summary>
        /// Cerrar la conexión hacia la base de datos
        /// </summary>
        /// <returns></returns>
        public SqlConnection CloseConnection()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
                Conexion.Close();
            return Conexion;
        }
    }
}
