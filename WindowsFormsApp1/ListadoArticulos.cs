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



namespace WindowsFormsApp1
{
    public partial class ListadoArticulos : Form
    {
        public ListadoArticulos()
        {
            InitializeComponent();
        }



        private void ListadoArticulos_Load_1(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dataGridView2.DataSource = negocio.listar();
        }
    }
}
