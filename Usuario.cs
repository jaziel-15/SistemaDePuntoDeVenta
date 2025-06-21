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
    public partial class Usuario : FormBase
    {
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM Usuarios where id_usuario = " + Login.Codigo;
            DataSet Data = Biblioteca.Herramientas(consulta);

            LNombre.Text = Data.Tables[0].Rows[0]["username"].ToString();
            lUser.Text = Data.Tables[0].Rows[0]["account"].ToString();
            lCodigo.Text = Data.Tables[0].Rows[0]["id_usuario"].ToString();

            string imagen = Data.Tables[0].Rows[0]["imagen"].ToString();
            pictureBox1.Image = Image.FromFile(imagen);
        }
    }
}
