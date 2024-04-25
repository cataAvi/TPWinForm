using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Data.SqlClient;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setarConsulta("select A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Descripcion as Categoria, M.Descripcion as Marca,  I.ImagenUrl as ImagenUrl from ARTICULOS as A inner join MARCAS AS M on IdMarca = M.Id inner join CATEGORIAS AS C on IdCategoria = C.Id inner join IMAGENES AS I on C.Id = I.IdArticulo");
                datos.ejectuarLectura();


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    
                    aux.CodArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setarConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, ImagenUrl = @imagen, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio where Id = @id");
                datos.setearParametro("@id", art.Id);
                datos.setearParametro("@codigo", art.CodArticulo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("idMarca", art.Marca.Id);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
                datos.setearParametro("@imagen", art.ImagenUrl);
                datos.setearParametro("@precio", art.Precio);

                datos.ejectuarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Articulo nuevoArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setarConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria)values(@codigo, @nombre, @descripcion, @precio, @idMarca, @idCategoria, @imagen)");
                datos.setearParametro("@codigo", nuevoArticulo.CodArticulo);
                datos.setearParametro("@nombre", nuevoArticulo.Nombre);
                datos.setearParametro("@descripcion", nuevoArticulo.Descripcion);
                datos.setearParametro("@precio", nuevoArticulo.Precio);
                datos.setearParametro("@idMarca", nuevoArticulo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevoArticulo.Categoria.Id);
                datos.setearParametro("@imagen", nuevoArticulo.ImagenUrl);
                datos.ejectuarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setarConsulta("Delete from ARTICULOS Where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejectuarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Descripcion Categoria, M.Descripcion Marca, A.ImagenUrl, A.Id, A.IdMarca, A.IdCategoria from ARTICULOS A, CATEGORIAS C, MARCAS M where C.Id=A.IdCategoria and M.Id=A.IdMarca and ";
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "A.Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "A.Precio < " + filtro;
                            break;
                        case "Igual a":
                            consulta += "A.Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Codigo Articulo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Codigo like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Codigo like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "A.Codigo like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A.Nombre like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "A.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Categoria")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "C.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "C.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setarConsulta(consulta);
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
