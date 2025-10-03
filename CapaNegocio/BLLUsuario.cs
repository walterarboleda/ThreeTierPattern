using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class BLLUsuario
    {

        private DALUsuario objetoCD = new DALUsuario();

        public DataTable View()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ReadAllUsuario();
            return tabla;
        }
        public void Create(string usuario, string contrasena, int intentos, double nivelSeg, DateTime fechaReg)
        {

            objetoCD.CreateUsuario(usuario, contrasena, Convert.ToInt32(intentos), Convert.ToDouble(nivelSeg), fechaReg);
        }

        public void Update(string usuario, string contrasena, int intentos, double nivelSeg, DateTime fechaReg, int id)
        {
            objetoCD.UpdateUsuario(usuario, contrasena, Convert.ToInt32(intentos), Convert.ToDouble(nivelSeg), fechaReg, Convert.ToInt32(id));
        }

        public void Delete(int id)
        {

            objetoCD.DeleteUsuario(id);
        }

    }
}
