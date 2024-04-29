﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setarConsulta("Select Id, Descripcion From CATEGORIAS");
                datos.ejectuarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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
    

    public void agregarCategoria(Categoria nuevaCategoria)
    {
        AccesoDatos datos = new AccesoDatos();

        try
        {
            datos.setarConsulta("Insert into CATEGORIAS (Descripcion)values(@descripcion)");
            datos.setearParametro("@descripcion", nuevaCategoria.Descripcion);
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

    }

}
