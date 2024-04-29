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

        public List<string> vectorImagenes (int id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<string> lista = new List<string>();


            try
            {
                datos.setarConsulta("select Id, idArticulo, ImagenUrl from IMAGENES");
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    if (!((datos.Lector["ImagenUrl"] is DBNull)) && (id == (int)datos.Lector["IdArticulo"]))
                        lista.Add((string)datos.Lector["ImagenUrl"]);
                            

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

        public Articulo leerDatos(Articulo aux)
        {
            AccesoDatos datos = new AccesoDatos();

            datos.setarConsulta("SELECT Id, Codigo, Nombre, Descripcion, Precio from ARTICULOS");
            datos.ejectuarLectura();

            while (datos.Lector.Read())
            {
                if ((string)datos.Lector["Codigo"] == aux.CodArticulo)

                {
                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                }


            }

            return aux;

        }

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setarConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Descripcion AS Categoria, M.Descripcion AS Marca, (SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = A.Id) AS ImagenUrl, A.IdMarca, A.IdCategoria FROM ARTICULOS A INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria INNER JOIN MARCAS M ON M.Id = A.IdMarca");
                datos.ejectuarLectura();


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.CodArticulo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    
                   //if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca = new Marca();
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                   // if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria = new Categoria();
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    //Segun la base de datos, los campos que PUEDEN ser nulos son: Codigo, Nombre, Descripción, Marca, Categoria y Precio (basicamente todo menos la pk que es el id)

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
                datos.setarConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio where Id = @id");
                datos.setearParametro("@id", art.Id);
                datos.setearParametro("@codigo", art.CodArticulo);
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descripcion", art.Descripcion);
                datos.setearParametro("idMarca", art.Marca.Id);
                datos.setearParametro("@idCategoria", art.Categoria.Id);
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

            try
            {
                datos.setarConsulta("update IMAGENES set ImagenUrl = @imagen where IdArticulo = " + art.Id);
                datos.setearParametro("@imagen", art.ImagenUrl);

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

        public void agregarImagen(Articulo nuevoArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setarConsulta("INSERT INTO [CATALOGO_P3_DB].[dbo].[IMAGENES] ([IdArticulo], [ImagenUrl]) VALUES (@idArticulo, @imagenUrl)");
                datos.setearParametro("@idArticulo", nuevoArticulo.Id);
                datos.setearParametro("@imagenUrl", nuevoArticulo.ImagenUrl);
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
                datos.setarConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio, IdMarca, IdCategoria)values(@codigo, @nombre, @descripcion, @precio, @idMarca, @idCategoria)");
                datos.setearParametro("@codigo", nuevoArticulo.CodArticulo);
                datos.setearParametro("@nombre", nuevoArticulo.Nombre);
                datos.setearParametro("@descripcion", nuevoArticulo.Descripcion);
                datos.setearParametro("@precio", nuevoArticulo.Precio);
                datos.setearParametro("@idMarca", nuevoArticulo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevoArticulo.Categoria.Id);
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

            /*try
            {
                datos.setarConsulta("INSERT INTO [CATALOGO_P3_DB].[dbo].[IMAGENES] ([IdArticulo], [ImagenUrl]) VALUES (@idArticulo, @imagenUrl)");
                datos.setearParametro("@imagen", nuevoArticulo.ImagenUrl);
                datos.setearParametro("@idArticulo", nuevoArticulo.Id);

                datos.ejectuarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }*/
            
            //Acá pincha el agregar artículos
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setarConsulta("Delete from ARTICULOS Where Id = @id");
                datos.setearParametro("@id", id);
                datos.ejectuarAccion();

                //Agregar a este metodo borrar todos los registros de la tabla imagenes que correspondan al mismo artículo
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
                string consulta = "select A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Descripcion Categoria, M.Descripcion Marca, I.ImagenUrl, A.Id, A.IdMarca, A.IdCategoria from ARTICULOS A, CATEGORIAS C, MARCAS M, IMAGENES I where C.Id=A.IdCategoria and M.Id=A.IdMarca and A.Id=I.IdArticulo and ";
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
