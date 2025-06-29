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

    }
}
