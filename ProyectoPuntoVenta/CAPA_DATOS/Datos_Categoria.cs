using ProyectoPuntoVenta.CAPA_ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoPuntoVenta.CAPA_DATOS
{
    public class Datos_Categoria
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
                SqlCommand cmd = new SqlCommand("categoria_listar", sqlCon);
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
                SqlCommand cmd = new SqlCommand("categoria_buscar", sqlCon);
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
        //metodo para verificar si existe la categoria 
        public string Existe(string valor)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("categoria_existe", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                SqlParameter existe = new SqlParameter();
                existe.ParameterName = "@existe";
                existe.SqlDbType = SqlDbType.Int;
                existe.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(existe);
                sqlCon.Open();
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
        public string Insertar(Categoria Obj)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("categoria_insertar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
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
        //metodo para actualizar 
        public string Actualizar(Categoria Obj)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("categoria_actualizar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Obj.Idcategoria;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = Obj.Descripcion;
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
                SqlCommand cmd = new SqlCommand("categoria_eliminar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;
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
                SqlCommand cmd = new SqlCommand("categoria_activar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;
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
                SqlCommand cmd = new SqlCommand("categoria_desactivar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idcategoria", SqlDbType.Int).Value = Id;
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
        //metodo para seleccionar la categoria 
        public DataTable Seleccionar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("categoria_seleccionar", sqlCon);
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
    }
}


