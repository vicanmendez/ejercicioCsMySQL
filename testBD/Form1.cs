using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string email = txtEmail.Text;
            string sentencia = "INSERT INTO usuario (nombre, email) VALUES ('" + nombre + "', '" + email + "');";
            Conexion con = new Conexion();
            if (con.ejecutarInsert(sentencia))
            {
                MessageBox.Show("Usuario ingresado");
            }
            else
            {
                MessageBox.Show("Error en la comunicación con la base de datos");
            };
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
             listausuarios nuevalista = new listausuarios();
            nuevalista.Visible = true;
        }
    }
}
