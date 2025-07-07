using LibreriaDLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Punto_de_Venta
{
    public partial class Facturacion : Procesos
    {
        public Facturacion()
        {
            InitializeComponent();
        }
        public static int contadorFila = 0;

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            string vendedor = " SELECT * FROM Usuarios WHERE id_usuario = " + Login.Codigo;

            DataSet ds;
            ds = Biblioteca.Herramientas(vendedor);

            lbVendedor.Text = ds.Tables[0].Rows[0]["username"].ToString().Trim();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtCodigoCliente.Text.Trim()) == false)
                {
                    string cmd = string.Format("SELECT Nombre_Clientes FROM Clientes WHERE id_Clientes = '{0}'", TxtCodigoCliente.Text.Trim());
                    DataSet ds;
                    ds = Biblioteca.Herramientas(cmd);

                    TxtCliente.Text = ds.Tables[0].Rows[0]["Nombre_Clientes"].ToString().Trim();

                    TxtCodigoProducto.Focus();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error",error.Message);
            }
        }
    }
}
