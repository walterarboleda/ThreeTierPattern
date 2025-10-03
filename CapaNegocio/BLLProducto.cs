using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class BLLProducto
    {
        private DALProducto objetoCD = new DALProducto();

        public DataTable View()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ReadAllProducto();
            return tabla;
        }
        public void Create(string nombre, int cantidad)
        {

            objetoCD.CreateProducto(nombre, Convert.ToInt32(cantidad));
        }

        public void Update(string nombre, int cantidad, int id)
        {
            objetoCD.UpdateProducto(nombre, Convert.ToInt32(cantidad), Convert.ToInt32(id));
        }

       
        public void Delete(int id)
        {

            objetoCD.DeleteProducto(id);
        }
        
    }
}
