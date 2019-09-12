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

                    //MSF-20190420: acá manejamos un posible nulo desde la DB. Recuerdan que la otra vez nos falló?
                    //Era porque en la DB estaba nulo y acá lo queríamos tomar y no le gustaba.
                    //Ojo... en la tabla no todas las columnas van a ser nuleables... en nuestro caso porque no le dimos
                    //importancia casi al diseño de la misma. Pero si está bien armada la tabla, serán pocas las columnas
                    //que sean nulleables. Solo a esa deberían agregarles ésta validación. Que de hecho pueden meter en un método
                    //para no tener que escribirla completa cada vez, por ejemplo.
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

        //public void agregarArticulo(Articulo nuevo)
        //{
        //    SqlConnection conexion = new SqlConnection();
        //    SqlCommand comando = new SqlCommand();
        //    try
        //    {
        //        conexion.ConnectionString = AccesoDatosManager.cadenaConexion;
        //        comando.CommandType = System.Data.CommandType.Text;
        //        //MSF-20190420: le agregué todas las columnas. Teniendo en cuenta inclusive lo que elegimos en el combo de selección..
        //        comando.CommandText = "insert into PERSONAJES (Nombre, Debilidad, UsaCapa, Volador, IdUniverso) values";
        //        comando.CommandText += "('" + nuevo.Nombre + "', '" + nuevo.Debilidad + "', '" + nuevo.UsaCapa.ToString() + "', '" + nuevo.Volador.ToString() + "'," + nuevo.Universo.Id.ToString() + ")";
        //        comando.Connection = conexion;
        //        conexion.Open();

        //        comando.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conexion.Close();
        //    }
        //}

        //public void modificarHeroe(Heroe modificar)
        //{
        //    AccesoDatosManager accesoDatos = new AccesoDatosManager();
        //    try
        //    {
        //        accesoDatos.setearConsulta("update PERSONAJES Set Nombre=@Nombre, Debilidad=@Debilidad, UsaCapa=@UC, Volador=@Vol, IdUniverso=@IdUni Where Id=" + modificar.Id.ToString());
        //        accesoDatos.Comando.Parameters.Clear();
        //        accesoDatos.Comando.Parameters.AddWithValue("@Nombre", modificar.Nombre);
        //        accesoDatos.Comando.Parameters.AddWithValue("@Debilidad", modificar.Debilidad);
        //        accesoDatos.Comando.Parameters.AddWithValue("@UC", modificar.UsaCapa);
        //        accesoDatos.Comando.Parameters.AddWithValue("@Vol", modificar.Volador);
        //        accesoDatos.Comando.Parameters.AddWithValue("@IdUni", modificar.Universo.Id);
        //        accesoDatos.abrirConexion();
        //        accesoDatos.ejecutarAccion();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        accesoDatos.cerrarConexion();
        //    }
        //}
    }
}
