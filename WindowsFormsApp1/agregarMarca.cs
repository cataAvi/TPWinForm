using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace WindowsFormsApp1
{
    public partial class agregarMarca : Form

    {
        Marca seleccionado = new Marca();

        public agregarMarca()
        {
            InitializeComponent();
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
                  Marca nueva = new Marca();
                nueva.Descripcion = tbMarca.Text;
                MarcaNegocio negocio = new MarcaNegocio();
                negocio.agregarMarca(nueva);
                MessageBox.Show("Marca agregada correctamente");
             
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listar(List<string> lista)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }


    }
}
