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
                //cargarImagen(listaArticulo[0].ImagenUrl);
                List<string> imagenes = new List<string>();
                imagenes = negocio.vectorImagenes(listaArticulo[0].Id);
                cargarImagen(imagenes[listaArticulo[0].indiceImg]);

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
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<string> lista = new List<string>();
                lista = negocio.vectorImagenes(selecionado.Id);
                cargarImagen(lista[selecionado.indiceImg]);
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

        private void comboBoxCampo_SelectedIndexChanged(object sender, EventArgs e) // dependiendo de la opcion selecionada en el comboBoxCampo vamos a mostrar la lista en comboBoxCriterio
        {
            string opcion = comboBoxCampo.SelectedItem.ToString();

            if (opcion == "Precio")
            {
                comboBoxCriterio.Items.Clear();
                comboBoxCriterio.Items.Add("Mayor a");
                comboBoxCriterio.Items.Add("Menor a");
                comboBoxCriterio.Items.Add("Igual a");
            }
            else
            {
                comboBoxCriterio.Items.Clear();
                comboBoxCriterio.Items.Add("Comienza con");
                comboBoxCriterio.Items.Add("Termina con");
                comboBoxCriterio.Items.Add("Contiene");
            }
        }

        private bool soloNumeros(string cadena) 
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                {
                    return false;
                }
            }
            return true;
        }

        private bool validarFiltro() // Mensajes en caso de no filtrar correctamente
        {
            if (comboBoxCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione los campos para filtrar");
                return true;
            }
            if (comboBoxCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor seleccione los campos para filtrar");
                return true;
            }
            if (comboBoxCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(textBoxFiltro.Text))
                {
                    MessageBox.Show("Indicar el numero en el campo filtro");
                    return true;
                }
                if (!(soloNumeros(textBoxFiltro.Text)))
                {
                    MessageBox.Show("Por favor ingresar solo numeros al filtrar por un campo numerico");
                    return true;
                }
            }

            return false;
        }

        private void buttonBuscar_Click(object sender, EventArgs e) // Metodo para una vez colocado los filtros correctamente muestre los resultados
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                    return;

                string campo = comboBoxCampo.SelectedItem.ToString();
                string criterio = comboBoxCriterio.SelectedItem.ToString();
                string filtro = textBoxFiltro.Text;
                dataGridViewArticuloBD.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro que desea eliminar el registro", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dataGridViewArticuloBD.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.Id);
                    cargar();
                } 
  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            seleccionado = (Articulo)dataGridViewArticuloBD.CurrentRow.DataBoundItem;
            List<string> lista = new List<string>();
            lista = negocio.vectorImagenes(seleccionado.Id);
            int maximo = lista.Count;

            if (seleccionado.indiceImg < maximo - 1)
                seleccionado.indiceImg++;
            else if (seleccionado.indiceImg == maximo - 1)
                seleccionado.indiceImg = 0;

            cargarImagen(lista[seleccionado.indiceImg]);
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            seleccionado = (Articulo)dataGridViewArticuloBD.CurrentRow.DataBoundItem;
            List<string> lista = new List<string>();
            lista = negocio.vectorImagenes(seleccionado.Id);
            int maximo = lista.Count;

            if (seleccionado.indiceImg == 0)
                seleccionado.indiceImg = maximo - 1;
            else 
                seleccionado.indiceImg --;

            cargarImagen(lista[seleccionado.indiceImg]);
        }
    }
}
