using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using AccesoDatos;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarArticulos()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Articulo> listado = new List<Articulo>();
            Articulo articulo;
            //PoderSecundarioNegocio poderSecundarioNegocio = new PoderSecundarioNegocio();
            try
            {
                conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                comando.CommandType = System.Data.CommandType.Text;
                //MSF-20190420: agregué todos los datos del heroe. Incluso su universo, que lo traigo con join.
                comando.CommandText = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion as Marca, A.IdCategoria, C.Descripcion as Categoria, A.Imagen, A.Precio " +
                                        "From ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca = M.Id AND A.IdCategoria = C.Id";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    articulo = new Articulo();
                    articulo.Id = (int)lector["Id"];

                    if (!Convert.IsDBNull(lector["Codigo"]))
                        articulo.Codigo = (string)lector["Codigo"];

                    if (!Convert.IsDBNull(lector["Nombre"]))
                        articulo.Nombre = (string)lector["Nombre"];

                    if (!Convert.IsDBNull(lector["Descripcion"]))
                        articulo.Descripcion = (string)lector["Descripcion"];

                    if (!Convert.IsDBNull(lector["IdMarca"]))
                        articulo.Marca = new CodigoDescripcion();
                        articulo.Marca.Id = (int)lector["IdMarca"];
                        articulo.Marca.Descripcion = (string)lector["Marca"];

                    if (!Convert.IsDBNull(lector["IdCategoria"]))
                        articulo.Categoria = new CodigoDescripcion();
                        articulo.Categoria.Id = (int)lector["IdCategoria"];
                        articulo.Categoria.Descripcion = (string)lector["Categoria"];

                    if (!Convert.IsDBNull(lector["Precio"]))
                    {
                        articulo.Precio = decimal.Round((decimal)lector["Precio"],2);
                    }
                    
                    listado.Add(articulo);
                }

                return listado;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public void agregarArticulo(Articulo nuevo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                //conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
                //comando.CommandType = System.Data.CommandType.Text;
                ////MSF-20190420: le agregué todas las columnas. Teniendo en cuenta inclusive lo que elegimos en el combo de selección..
                //comando.CommandText = "insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values";
                //comando.CommandText += "('" + nuevo.Codigo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', " +
                //    nuevo.Marca.Id + "," + nuevo.Categoria.Id + ", @Precio)";
                //comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                //comando.Connection = conexion;
                //conexion.Open();

                accesoDatos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio, Imagen) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio, @Imagen)");
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                accesoDatos.Comando.Parameters.AddWithValue("@IdMarca", nuevo.Marca.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdCategoria", nuevo.Categoria.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                accesoDatos.Comando.Parameters.AddWithValue("@Imagen", nuevo.Imagen);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void modificarArticulo(Articulo articulo)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("update ARTICULOS Set Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, IdMarca=@IdMarca, IdCategoria=@IdCategoria, Precio=@Precio Where Id=" + articulo.Id.ToString());
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                accesoDatos.Comando.Parameters.AddWithValue("@IdMarca", articulo.Marca.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@IdCategoria", articulo.Categoria.Id);
                accesoDatos.Comando.Parameters.AddWithValue("@Precio", articulo.Precio);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
        
        public void eliminarArticulo (int id)
        {
            AccesoDatosManager datos = new AccesoDatosManager();
            try
            {
                datos.abrirConexion();
                datos.setearConsulta("delete from ARTICULOS where id =" + id);
                datos.ejecutarAccion();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
