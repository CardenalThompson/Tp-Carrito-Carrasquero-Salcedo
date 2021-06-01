using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negosio
{
    public class ArticuloNegocio
    {
        public SqlCommand comando { set;get; }

        public List<Articulo> listar()
        {
           try
            { 

            List<Articulo> lista = new List<Articulo>();
            AccesoDatos conexion = new AccesoDatos();
            conexion.conectar();
            conexion.setearQuery( "select A.Id idarti,A.Codigo, A.Nombre,A.Descripcion,A.ImagenUrl,M.Id idmarca,M.Descripcion marca ,C.Id idcat,C.Descripcion cat,A.Precio precio from ARTICULOS A ,MARCAS M, CATEGORIAS C where A.idmarca=M.id AND	A.IdCategoria=C.id");
            SqlDataReader lector = conexion.leer();

            while (lector.Read())
            {
                Articulo aux = new Articulo();
                aux.id = (int)lector["idarti"];
                aux.codigo = lector.GetString(1);
                aux.nombre = lector.GetString(2);
                aux.descripcion = lector.GetString(3);
                aux.imagen = (string)lector["ImagenUrl"];
                aux.marca = new Marca();
                aux.marca.nombre = (string)lector["marca"];
                aux.marca.id = (int)lector["idmarca"];
                aux.categoria = new Categoria();
                aux.categoria.nombre = (string)lector["cat"];
                aux.categoria.id = (int)lector["idcat"];
                aux.precio = (decimal)lector["precio"];


                lista.Add(aux);
            }
            conexion.cerrarConexion();
            return lista;
             }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool agregar(Articulo nuevo)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();
                conexion.setearQuery("insert into ARTICULOS( Codigo,Nombre, Descripcion, IdMarca,IdCategoria,Precio, ImagenUrl)values(@cod, @nombre,@des,@marca,@cat,@precio,@imagen) ");
                conexion.agregarParametro("@cod", nuevo.codigo);
                conexion.agregarParametro("@nombre", nuevo.nombre);
                conexion.agregarParametro("@des", nuevo.descripcion);
                conexion.agregarParametro("@marca", nuevo.marca.id);
                conexion.agregarParametro("@cat", nuevo.categoria.id);
                conexion.agregarParametro("@precio", nuevo.precio);
                conexion.agregarParametro("@imagen", nuevo.imagen);
              
                conexion.ejecutarAccion();

                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool editar(Articulo arti)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();
                conexion.setearQuery("update ARTICULOS set codigo=@codigo,Nombre=@nombre,Descripcion=@des,idcategoria=@cat,idmarca=@marca,Precio=@precio, ImagenUrl=@imagen where Id=@id ");

                conexion.agregarParametro("@codigo", arti.codigo);
                conexion.agregarParametro("@nombre", arti.nombre);
                conexion.agregarParametro("@des", arti.descripcion);
                conexion.agregarParametro("@imagen", arti.imagen);
                conexion.agregarParametro("@marca", arti.marca.id);
                conexion.agregarParametro("@cat", arti.categoria.id);
                conexion.agregarParametro("@precio", arti.precio);
                conexion.agregarParametro("@id", arti.id);
                conexion.ejecutarAccion();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos conexion = new AccesoDatos();
                conexion.setearQuery("delete from articulos where Id=@id ");

                conexion.agregarParametro("@id", id);
                conexion.ejecutarAccion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
