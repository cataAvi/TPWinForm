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


        private void dataGridView2_SelectionChanged_1(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dataGridView2.CurrentRow.DataBoundItem;
            dataGridView2.Columns["ImagenUrl"].Visible = false;
            dataGridView2.Columns["Id"].Visible = false;
            cargarImagen(seleccionado.ImagenUrl);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pcbximg.Load(imagen);
            }
            catch
            {
                pcbximg.Load("https://www.rivera.gub.uy/portal/wp-content/uploads/2017/02/imagen-no-disponible-820x513.jpg");
            }
            

        }
    }
}
