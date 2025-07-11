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
    public partial class MantenimientoClientes : Mantenimiento
    {
        public MantenimientoClientes()
        {
            InitializeComponent();
        }

        public override Boolean Guardar()
        {
            if (Biblioteca.ValidarFormulario(this, errorProvider1) == false)
            {
                try
                {
                    string insertar = string.Format("EXEC ActualizarClientes '{0}','{1}','{2}'", textID_Cliente.Text.Trim(), textNombre_Cliente.Text.Trim(), textApellido_Cliente.Text.Trim());
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
                string eliminar = string.Format("EXEC ELiminarClientes {0}", textID_Cliente.Text.Trim());
                Biblioteca.Herramientas(eliminar);
                MessageBox.Show("El cliente se ha eliminado correctamente");
            }
            catch (Exception error)

            {
                MessageBox.Show("Ha ocurrido un error" + error.Message);
            }

        }

        private void textID_Cliente_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textID_Cliente.Text.Trim()) == false && string.IsNullOrEmpty(textNombre_Cliente.Text.Trim()) == false && string.IsNullOrEmpty(textApellido_Cliente.Text.Trim()) == false)
            {
                textID_Cliente.Text = "";
                textNombre_Cliente.Text = "";
                textApellido_Cliente.Text = "";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultarCliente ConsClie = new ConsultarCliente();
            ConsClie.ShowDialog();

            if (ConsClie.DialogResult == DialogResult.OK)
            {
                textID_Cliente.Text = ConsClie.dataGridView1.Rows[ConsClie.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                textNombre_Cliente.Text = ConsClie.dataGridView1.Rows[ConsClie.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                textApellido_Cliente.Text = ConsClie.dataGridView1.Rows[ConsClie.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            }
        }
    }
}
