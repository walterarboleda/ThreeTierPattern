using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Logon : Form
    {
        public Logon()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (usuario == "" || contrasena == "")
            {
                MessageBox.Show("Debe ingresar usuario y contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BLLLogon bllLogon = new BLLLogon();
            bool loginCorrecto = bllLogon.ValidarUsuario(usuario, contrasena);

            if (loginCorrecto)
            {
                this.Hide();
                Principal frmPrincipal = new Principal();
                frmPrincipal.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

