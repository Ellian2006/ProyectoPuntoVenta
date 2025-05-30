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
    public class Datos_Usuario
    {
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("usuario_listar", sqlCon);
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
                SqlCommand cmd = new SqlCommand("usuario_buscar", sqlCon);
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
        //metodo para verificar si existe el correo del usuario 
        public string Existe(string valor)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("usuario_existe", sqlCon);
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
        public string Insertar(Usuario Obj)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("usuario_insertar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idrol", SqlDbType.Int).Value = Obj.idRol;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                cmd.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = Obj.TipoDocumento;
                cmd.Parameters.Add("@num_documento", SqlDbType.VarChar).Value = Obj.numDocumento;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Obj.telefono;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Obj.Email;
                cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = Obj.clave;
                sqlCon.Open();
                cmd.ExecuteNonQuery();
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
        public string actualizar(Usuario Obj)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.InstanciaConstructor().CrearConexion();
                SqlCommand cmd = new SqlCommand("usuario_actualizar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = Obj.idUsuario;
                cmd.Parameters.Add("@idrol", SqlDbType.Int).Value = Obj.idRol;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = Obj.Nombre;
                cmd.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = Obj.TipoDocumento;
                cmd.Parameters.Add("@numDocumento", SqlDbType.VarChar).Value = Obj.numDocumento;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = Obj.Direccion;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = Obj.telefono;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Obj.Email;
                cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = Obj.clave;
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
                SqlCommand cmd = new SqlCommand("usuario_eliminar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;
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
                SqlCommand cmd = new SqlCommand("usuario_activar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;
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
                SqlCommand cmd = new SqlCommand("usuario_desactivar", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                //Parametros del procedimiento almacenado
                cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = Id;
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
