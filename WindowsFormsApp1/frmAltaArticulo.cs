using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace WindowsFormsApp1
{
    public partial class frmAltaArticulo : Form
    {
        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Articulo art = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                art.Precio = decimal.Parse(tbPrecio.Text);
                art.Nombre = tbNombre.Text;
                art.ImagenUrl = tbURLImagen.Text;
                art.Descripcion = tbDescripcion.Text;
                art.CodArticulo = tbCodArt.Text;
                art.Marca = (Marca)cbMarca.SelectedItem;
                art.Categoria = (Categoria)cbCategoria.SelectedItem;

                negocio.agregar(art);
                MessageBox.Show("Agregado exitosamente");
                Close();
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            CategoriaNegocio catNeg = new CategoriaNegocio();
            MarcaNegocio marNeg = new MarcaNegocio();

            try
            {
                cbMarca.DataSource = marNeg.listar();
                cbCategoria.DataSource = catNeg.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tbURLImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(tbURLImagen.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbImagenArt.Load(imagen);
            }
            catch
            {
                pbImagenArt.Load("https://www.rivera.gub.uy/portal/wp-content/uploads/2017/02/imagen-no-disponible-820x513.jpg");
            }


        }

    }
}
