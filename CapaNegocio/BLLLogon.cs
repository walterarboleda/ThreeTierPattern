using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class BLLLogon
    {
        private DALLogon objetoCD = new DALLogon();

        public bool ValidarUsuario(string usuario, string contrasena)
        {
            DataTable tabla = objetoCD.FindUsuario(usuario, contrasena);
            return tabla.Rows.Count > 0;
        }



    }
}
