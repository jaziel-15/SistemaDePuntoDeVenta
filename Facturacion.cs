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
    public partial class Facturacion : Procesos
    {
        public Facturacion()
        {
            InitializeComponent();
        }
        public static int contadorFila = 0;
        public static Double Total;

        private void button5_Click(object sender, EventArgs e)
        {
            if (Biblioteca.ValidarFormulario(this, errorProvider1) == false)
            {
                bool existe = false;
                int numeroFila = 0;

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == TxtCodigoProducto.Text)
                    {
                        existe = true;
                        numeroFila = fila.Index;
                        break;
                    }
                }

             
                if (existe)
                {
                    dataGridView1.Rows[numeroFila].Cells[3].Value =
                        (Convert.ToDouble(TxtCantidad.Text) +
                        Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[3].Value));

                    double importe = Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[2].Value) *
                                     Convert.ToDouble(dataGridView1.Rows[numeroFila].Cells[3].Value);

                    dataGridView1.Rows[numeroFila].Cells[4].Value = importe;
                }
                else
                {
                
                    dataGridView1.Rows.Add( TxtCodigoProducto.Text,TxtDescripcion.Text, TxtPrecio.Text,TxtCantidad.Text);

                    double importe = Convert.ToDouble(TxtPrecio.Text) * Convert.ToDouble(TxtCantidad.Text);
                    dataGridView1.Rows[contadorFila].Cells[4].Value = importe;
                    contadorFila++;
                }
            }

            Total = 0;
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                Total += Convert.ToDouble(fila.Cells[4].Value);
                
            }

            lbTotal.Text = "$" + Total.ToString() + "MX";

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

        private void btEliminar_Click(object sender, EventArgs e)
        {
            Total -= (Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value));
            lbTotal.Text = "$" + Total.ToString() + "MX";

            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            contadorFila--;
        }

        private void btClientes_Click(object sender, EventArgs e)
        {
            ConsultarCliente consultarClien = new ConsultarCliente();
            consultarClien.ShowDialog();

            if (consultarClien.DialogResult == DialogResult.OK)
            {
                TxtCodigoCliente.Text = consultarClien.dataGridView1.Rows[consultarClien.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                TxtCliente.Text = consultarClien.dataGridView1.Rows[consultarClien.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();

                TxtCodigoProducto.Focus();
            }
        }

        private void btProductos_Click(object sender, EventArgs e)
        {
            ConsultarProductos consultarProd = new ConsultarProductos();
            consultarProd.ShowDialog();
            if (consultarProd.DialogResult == DialogResult.OK)
            {
                TxtCodigoProducto.Text = consultarProd.dataGridView1.Rows[consultarProd.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                TxtDescripcion.Text = consultarProd.dataGridView1.Rows[consultarProd.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                TxtPrecio.Text = consultarProd.dataGridView1.Rows[consultarProd.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();

              TxtCantidad.Focus();

            }
        }

        private void btNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();

        }

        public override void Nuevo()
        {
            TxtCodigoCliente.Text = "";
            TxtCliente.Text = "";
            TxtCodigoProducto.Text = "";
            TxtDescripcion.Text = "";
            TxtPrecio.Text = "";
            TxtCantidad.Text = "";
            lbTotal.Text = "$";
            dataGridView1.Rows.Clear();

            contadorFila = 0;
            Total = 0;

            TxtCodigoCliente.Focus();
               
            
        }
    }
}
