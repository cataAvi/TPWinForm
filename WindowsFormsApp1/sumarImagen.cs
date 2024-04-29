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
    public partial class sumarImagen : Form

       // Articulo seleccionado = new Articulo();

    {
        Articulo seleccionado = new Articulo();

        public sumarImagen(Articulo aux)
        {
            seleccionado = aux;
            InitializeComponent();
    
        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            //Articulo aux = new Articulo();

            seleccionado.ImagenUrl = tbURLImag.Text;
            negocio.agregarImagen(negocio.leerDatos(seleccionado));
            MessageBox.Show("Imagen agregada exitosamente");
                
        }


    }
}
