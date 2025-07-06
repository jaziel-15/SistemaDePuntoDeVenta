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
    public partial class ConsultarProductos : Consultas
    {
        public ConsultarProductos()
        {
            InitializeComponent();
        }

        private void ConsultarProductos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MostrarInfoDG("Articulos").Tables[0];
        }

        private void Btnbuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) == false)
            {
                try
                {
                    DataSet DS;
                    string Buscar = "SELECT * FROM Articulos WHERE Nombre_productos LIKE ('%" + textBox1.Text.Trim() + "%')";

                    DS = Biblioteca.Herramientas(Buscar);

                    dataGridView1.DataSource = DS.Tables[0];
                }
                catch(Exception error)
                {
                    MessageBox.Show("No se puede conectar, error", error.Message);
                }
            }
        }
    }
}
