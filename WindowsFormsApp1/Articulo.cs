using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Articulo
    {
        //ATRIBUTOS
        private string CodArt;
        private string Nombre;
        private string Descripción;
        private int Precio;
        private Marca Marca;
        private Categoria Categoria;
        private Imagen Imagen;

        //PROPIEDADES
        public string Nombre
        { 
            get { return Nombre; }
            set { Nombre = value; }
        
        }

        public string Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }

        }

        public int Precio
        {
            get { return Precio; }
            set { Precio = value; }

        }

        public Marca Marca
        {
            get { return Marca; }
            set { Marca = value; }

        }

        public Categoria Categoria
        {
            get { return Categoria; }
            set { Categoria = value; }

        }

        public string Imagen
        {
            get { return Imagen; }
            set { Imagen = value; }

        }

    }
}
