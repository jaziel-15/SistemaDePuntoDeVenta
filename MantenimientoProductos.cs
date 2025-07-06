using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaDLL;

namespace Sistema_Punto_de_Venta
{
    public partial class MantenimientoProductos : Mantenimiento
    {
        public MantenimientoProductos()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public override Boolean Guardar()
        {
            if (Biblioteca.ValidarFormulario(this, errorProvider1) == false)
            {
                try
                {
                    string insertar = string.Format("EXEC ActualizarClientes '{0}','{1}','{2}'", textID_Producto.Text.Trim(), textDescripcion.Text.Trim(), textPrecio.Text.Trim());
                    Biblioteca.Herramientas(insertar);
                    MessageBox.Show("Cliente Guaraddo correctamente");
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error" + error.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public override void Eliminar()
        {
            try
            {
                string eliminar = string.Format("EXEC ELiminarProductos {0}", textID_Producto.Text.Trim());
                Biblioteca.Herramientas(eliminar);
                MessageBox.Show("El producto se ha eliminado correctamente");
            }
            catch (Exception error) 

            {
                MessageBox.Show("Ha ocurrido un error" + error.Message);
            }

        }

        private void textID_Producto_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textID_Producto.Text.Trim()) == false && string.IsNullOrEmpty(textDescripcion.Text.Trim()) == false && string.IsNullOrEmpty(textPrecio.Text.Trim()) == false)
            {
                textID_Producto.Text = "";
                textDescripcion.Text = "";
                textPrecio.Text = "";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultarProductos ConsPro = new ConsultarProductos();
            ConsPro.Show();
        }
    }
}
