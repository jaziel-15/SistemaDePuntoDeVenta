using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema_Punto_de_Venta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=Sistema;Integrated Security=True");

            try
            {
                conexion.Open();
                MessageBox.Show("Conexion Exitosa");
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error, intente de nuevo" + error);
            }
            
        }
    }
}
