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
    public partial class Producto : Form
    {
        BLLProducto objetoCN = new BLLProducto();
        private int id = 0;
        private bool Editar = false;
        
        public Producto()
        {
            InitializeComponent();
        }

        //
        private void ViewAllProducto()
        {

            BLLProducto objeto = new BLLProducto();
            dataGridView1.DataSource = objeto.View();
        }

        private void ClearControls()
        {
            txtNombre.Clear();
            txtCantidad.Clear();
            }





        private void Producto_Load(object sender, EventArgs e)
        {
            ViewAllProducto();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                objetoCN.Delete(id);
                MessageBox.Show("Registro eliminado correctamente");
                ViewAllProducto();
            }
            else
                MessageBox.Show("Debe seleccionar un registro en el DataGridView");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtCantidad.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            }
            else
                MessageBox.Show("Debe seleccionar un registro en el DataGridView");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    //Validación de controles

                    if (txtNombre.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNombre.Focus();
                        return;
                    }
                   
                    if (txtCantidad.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar la cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCantidad.Focus();
                        return;
                    }
                    

                    objetoCN.Create(txtNombre.Text, Convert.ToInt32(txtCantidad.Text));
                    MessageBox.Show("Se guardo correctamente");
                    ViewAllProducto();
                    ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos, se encontro el siguiente error : " + ex);
                }
            }

            if (Editar == true)
            {

                try
                {
                    objetoCN.Update(txtNombre.Text, Convert.ToInt32(txtCantidad.Text), id);
                    MessageBox.Show("Registro actualizado correctamente");
                    ViewAllProducto();
                    ClearControls();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos, se encontro el siguiente error : " + ex);
                }
            }
        }
    }
}
