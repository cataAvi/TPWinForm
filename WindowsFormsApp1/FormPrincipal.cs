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
using WindowsFormsApp1;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class FormPrincipal : Form
    {
        private List<Articulo> listaArticulo;
        public FormPrincipal()
        {
            InitializeComponent();
        }


        private void FormPrincipal_Load(object sender, EventArgs e) // metodo para agregar las opciones de filtrado al momento de abrir el formluario
        {
            cargar();
            comboBoxCampo.Items.Add("Codigo Articulo");
            comboBoxCampo.Items.Add("Nombre");
            comboBoxCampo.Items.Add("Marca");
            comboBoxCampo.Items.Add("Categoria");
            comboBoxCampo.Items.Add("Precio");
        }

        private void cargar() // cargar la lista de articulos y "colocarlos" en el dataGridViewArticuloBD
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulo = negocio.listar();
                dataGridViewArticuloBD.DataSource = listaArticulo;
                ocultarColumnas();
                cargarImagen(listaArticulo[0].ImagenUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas() // Ocultamos las columnas que no tienen informacion relevante
        {
            dataGridViewArticuloBD.Columns["ImagenUrl"].Visible = false;
            dataGridViewArticuloBD.Columns["Id"].Visible = false;
        }

        private void cargarImagen(string imagen) //cargarmos la imagen y la mostramos en el pictureBoxArticulo
        {
            try
            {
                pictureBoxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la imagen: " + ex.Message);
                pictureBoxArticulo.Load("https://www.came-educativa.com.ar/wp-content/uploads/2022/03/placeholder-3.png");
            }
        }

        private void dataGridViewArticuloBD_SelectionChanged(object sender, EventArgs e) //metodo que cambia la imagen cada vez que se selecciona una fila
        {
            if (dataGridViewArticuloBD.CurrentRow != null)
            {
                Articulo selecionado = (Articulo)dataGridViewArticuloBD.CurrentRow.DataBoundItem;
                cargarImagen(selecionado.ImagenUrl);
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e) // evento para abrir el formulario de modificacion/alta
        {
            FormAltaBajaModificacion form2 = new FormAltaBajaModificacion();
            form2.ShowDialog();
            cargar();
        }

        private void buttonModificiar_Click(object sender, EventArgs e)
        {
            Articulo selecionado;
            selecionado = (Articulo)dataGridViewArticuloBD.CurrentRow.DataBoundItem;

            FormAltaBajaModificacion modificar = new FormAltaBajaModificacion(selecionado); // instancio el form de modificacion/alta pero usando el constructor donde tiene como parametro un objeto Articulo
            modificar.ShowDialog();
            cargar();
        }
    }
}
