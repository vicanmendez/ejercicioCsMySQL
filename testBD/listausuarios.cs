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
    public partial class listausuarios : Form
    {
        public listausuarios()
        {
            InitializeComponent();
            //Método para completar el dataGridView
            llenarTabla();
            
        }

        public void llenarTabla()
        {
            //Un DataTable nos sirve como origne de datos de un DataGridView (una tabla que podrá llenarse con una consulta)
            DataTable dt = new DataTable();
            Conexion con = new Conexion();
            //Ver método llenarTablaConConsulta en Conexion.cs
            con.llenarTablaConConsulta("SELECT * FROM usuario ORDER BY nombre ASC", dt);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string UsrVal = row.Cells[1].Value.ToString();
            string UsrMail = row.Cells[2].Value.ToString();
            lblUsuario.Text = "Usuario: "+UsrVal;
            lblMail.Text = "E-Mail: "+UsrMail;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mailSeleccionado = lblMail.Text.Substring(8);
            DialogResult dialogResult = MessageBox.Show("Seguro que desea eliminar el usuario con el mail: "+mailSeleccionado+"?", "CONFIRMAR", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Conexion con = new Conexion();
                con.ejecutarInsert("DELETE FROM usuario WHERE email='"+mailSeleccionado+"';");
                llenarTabla();
                lblUsuario.Text = "Eliminado";
                //lblMail.Text = "Eliminado";
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Mira bien, por poco lo vuelas de la BD");
            }
        }
    }
}
