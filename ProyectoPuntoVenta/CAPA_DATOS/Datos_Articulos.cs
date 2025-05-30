using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPuntoVenta.CAPA_ENTIDADES;

namespace ProyectoPuntoVenta.CAPA_DATOS
{
    public class Datos_Articulos
    {
        // metodo para listar 
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("articulo_listar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                Resultado = cmd.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }
        // metodo para buscar
        public DataTable Buscar(string valor)
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("articulo_buscar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                sqlCon.Open();
                Resultado = cmd.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
        }
        //metodo para verificar si existe la articulo
        public string Existe(string valor)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("articulo_existe", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                SqlParameter existe = new SqlParameter();
                existe.ParameterName = "@existe";
                existe.SqlDbType = SqlDbType.Int;
                existe.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(existe);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                respuesta = Convert.ToString(existe.Value);
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();

            }
            return respuesta;
        }
        //metodo para Insetar
        public string Insertar(Articulo Obj)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("articulo_insertar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = Obj.idCategoria;
                cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.codigo;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                cmd.Parameters.Add("@Precio_venta", SqlDbType.Decimal).Value = Obj.Precioventa;
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Obj.stock;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripccion;
                cmd.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = Obj.Imagen;

                sqlCon.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar al registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();

            }
            return respuesta;
        }
        //metodo para Actualizar
        public string Actualizar(Articulo Obj)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("articulo_actualizar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = Obj.idCategoria;
                cmd.Parameters.Add("@Codigo", SqlDbType.VarChar).Value = Obj.codigo;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                cmd.Parameters.Add("@Precio_venta", SqlDbType.Decimal).Value = Obj.Precioventa;
                cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Obj.stock;
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Obj.Descripccion;
                cmd.Parameters.Add("@Imagen", SqlDbType.VarChar).Value = Obj.Imagen;

                sqlCon.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();

            }
            return respuesta;
        }
        //metodo para eliminar
        public string Eliminar(int Id)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("articulo_eliminar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idarticulos", SqlDbType.Int).Value = Id;
                sqlCon.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();

            }
            return respuesta;
        }
        //metodo para activar
        public string Activar(int Id)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("articulo_activar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idarticulos", SqlDbType.Int).Value = Id;
                sqlCon.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();

            }
            return respuesta;
        }
        //metodo para desactivar
        public string Desactivar(int Id)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("articulo_desactivar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idarticulos", SqlDbType.Int).Value = Id;
                sqlCon.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();

            }
            return respuesta;
        }
    }
}
