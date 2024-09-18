using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Configuration;

namespace negocio
{
    public class ArticulosNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        List<Articulo> lista = new List<Articulo>();
        string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio, M.Id IdMarca, C.Id IdCategoria from ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca AND C.Id = A.IdCategoria ";

        public List<Articulo> listar()
        {
            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.urlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector.GetDecimal(7);
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
        public List<Articulo> listarDeshabilitados()
        {
            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio, M.Id IdMarca, C.Id IdCategoria from ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca AND C.Id = A.IdCategoria AND A.Codigo = '-1' ");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.urlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector.GetDecimal(7);
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
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            if (campo == "Precio")
            {
                switch (criterio)
                {
                    case "Mayor a":
                        consulta += "AND A.Precio > '" + filtro + "'";
                        break;
                    case "Menor a":
                        consulta += "AND A.Precio < '" + filtro + "'";
                        break;
                    default:
                        consulta += "AND a.Precio = '" + filtro + "'";
                        break;
                }
            }
            else if (campo == "Nombre")
            {
                switch (criterio)
                {
                    case "Comienza con":
                        consulta += "AND A.Nombre like '" + filtro + "%'";
                        break;
                    case "Termina con":
                        consulta += "AND A.Nombre like '%" + filtro + "'";
                        break;
                    default:
                        consulta += "AND A.Nombre like '%" + filtro + "%'";
                        break;
                }
            }            
            if (campo == "Marca")            
                consulta += "AND M.Descripcion = '" + criterio + "'";            
            if (campo == "Categoría")
                consulta += "AND C.Descripcion = '" + criterio + "'";
            listar();
            return lista;
        }

        public void eliminarLogico(int id)
        {
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS set Codigo = '-1' where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
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

        public void eliminarFisico(int id)
        {
            try
            {
                datos.setearConsulta("DELETE from ARTICULOS where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
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
        public void agregar(Articulo articulo)
        {
            try
            {
                datos.setearConsulta("INSERT into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", articulo.urlImagen);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.ejecutarAccion();
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

        public void modificar(Articulo articulo)
        {
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", articulo.urlImagen);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@Id", articulo.Id);
                datos.ejecutarAccion();
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
        public void habilitar(int id)
        {
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS set Codigo = '0' where Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
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
        public void agregarFavoritos(int usuario, int articulo)
        {
            try
            {
                datos.setearConsulta("INSERT into FAVORITOS (IdUser, IdArticulo) SELECT @IdUser, @IdArticulo WHERE NOT EXISTS (SELECT 1 FROM FAVORITOS F WHERE F.IdUser = @IdUser AND F.IdArticulo = @IdArticulo)");
                datos.setearParametro("@IdUser", usuario);
                datos.setearParametro("@IdArticulo", articulo);
                datos.ejecutarAccion();
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
        public void eliminarFavoritos(int idUser, int idArticulo)
        {
            try
            {
                datos.setearConsulta("DELETE from FAVORITOS where IdUser = @IdUser AND IdArticulo = @IdArticulo");
                datos.setearParametro("@IdUser", idUser);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.ejecutarAccion();
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
        public List<Articulo> listarFavoritos(int idUser)
        {
            consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio, M.Id IdMarca, C.Id IdCategoria from ARTICULOS A, CATEGORIAS C, MARCAS M, FAVORITOS F Where M.Id = A.IdMarca AND C.Id = A.IdCategoria AND F.IdArticulo = A.Id AND F.IdUser = @IdUser";            
            datos.setearParametro("@IdUser", idUser);
            listar();
            return lista;
        }
    }
}
