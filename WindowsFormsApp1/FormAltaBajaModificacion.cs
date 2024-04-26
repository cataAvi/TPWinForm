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
    public partial class FormAltaBajaModificacion : Form
    {
        private Articulo articuloAux = null;

        // Como el "constructor" del formulario no recibe ningun parametro estamos seguros
        // que ingresamos a este articulo mediante el boton "Agregar".
        // Por ese motivo cambiamos el texto del formulario a "Agregar Articulo"
        public FormAltaBajaModificacion() 
        {
            InitializeComponent();
            Text = "Agregar Articulo";
        }

        // En cambio si el constructor del formulario recibe un articulo previamente seleccionado
        // podemos decir que nos encontramos ante una modificacion
        public FormAltaBajaModificacion(Articulo articulo)
        {
            InitializeComponent();
            articuloAux = articulo;
            Text = "Modificar Articulo";
        }

        private void FormAltaBajaModificacion_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                // agregar los valores predeterminados para los campos de Marca y Negocio
                comboBoxMarca.DataSource = marcaNegocio.listar();
                comboBoxMarca.ValueMember = "Id";
                comboBoxMarca.DisplayMember = "Descripcion";
                comboBoxCategoria.DataSource = categoriaNegocio.listar();
                comboBoxCategoria.ValueMember = "Id";
                comboBoxCategoria.DisplayMember = "Descripcion";


                // Bansandonos en la misma logica... si seleccionamos un articulo en el form principal e ingresamos
                // a este form mediante el boton modificar necesito mostrar los datos a modificar
                if (articuloAux != null)
                {
                    textBoxCodArticulo.Text = articuloAux.CodArticulo;
                    textBoxNombre.Text = articuloAux.Nombre;
                    textBoxDescripcion.Text = articuloAux.Descripcion;
                    textBoxUrlImagen.Text = articuloAux.ImagenUrl;
                    cargarImagen(articuloAux.ImagenUrl);
                    comboBoxMarca.SelectedValue = articuloAux.Marca.Id;
                    comboBoxCategoria.SelectedValue = articuloAux.Categoria.Id;
                    textBoxPrecio.Text = articuloAux.Precio.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                // Lo que se busca con este IF es saber si el objeto articuloAux esta vacio o no.
                // Si esta vacio significa que vamos a agregar un nuevo articulo a la BD
                // Caso contrario vamos a modificar un articulo.
                // Como sabemos que articulo vamos modificar? en la linea 33 guardamos el articulo previamente seleccionado
                // en el form principal
                if (articuloAux == null)
                {
                    articuloAux = new Articulo();
                }

                articuloAux.CodArticulo = textBoxCodArticulo.Text;
                articuloAux.Nombre = textBoxNombre.Text;
                articuloAux.Descripcion = textBoxDescripcion.Text;
                articuloAux.ImagenUrl = textBoxUrlImagen.Text;
                articuloAux.Marca = (Marca)comboBoxMarca.SelectedItem;
                articuloAux.Categoria = (Categoria)comboBoxCategoria.SelectedItem;
                articuloAux.Precio = decimal.Parse(textBoxPrecio.Text);


                // Si el Id del articulo es distinto de 0 eso significa que ya tenia un Id asigando
                // por ende vamos a modificar un articulo existente
                if (articuloAux.Id != 0)
                {
                    negocio.modificar(articuloAux);
                    MessageBox.Show("Articulo modificado en el inventario");
                }
                else
                {
                    negocio.agregar(articuloAux);
                    MessageBox.Show("Articulo agregado en el inventario");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void cargarImagen(string imagenUrl)
        {
            try
            {
                pictureBoxArticulo.Load(imagenUrl);
            }
            catch (Exception)
            {
                pictureBoxArticulo.Load("https://www.came-educativa.com.ar/wp-content/uploads/2022/03/placeholder-3.png");
            }
        }

        private void textBoxUrlImagen_Leave(object sender, EventArgs e)// Metodo para que cargue la imagen una vez se deja la celda y asi poder tener una "previsualizacion"
        {
            try
            {
                cargarImagen(textBoxUrlImagen.Text);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
