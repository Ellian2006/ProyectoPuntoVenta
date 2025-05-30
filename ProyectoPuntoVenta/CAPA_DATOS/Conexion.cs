using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.CAPA_DATOS
{
    public class Conexion
    {
        // articulos privados de configuracion 
        private string NombreBase;
        private string NombreServidor;
        private string NombreUsuario;
        private string clave;
        private bool seguridad;
        // crear un objeto estatico para la conexion
        private static Conexion con = null;
        // crear un constructor 
        private Conexion()
        {
            // inicializar los valores de la conexion
            this.NombreBase = "ProyectoPuntoDeVenta";
            this.NombreServidor = "MSI\\MSSQLSERVER01";
            this.NombreUsuario = "sa";
            this.clave = "123456";
            seguridad = true;
        }
        // metodo publico para generar la cadena de conexion con la base de datos 
        public SqlConnection CrearConexion()
        {
            // cadena de conexion
            SqlConnection cadena = new SqlConnection();
            try
            {
                cadena.ConnectionString = "Server=" + this.NombreServidor + "; DataBase=" +
                    this.NombreBase + ";";
                if (this.seguridad == true)
                {
                    cadena.ConnectionString = cadena.ConnectionString + "Integrated Security = SSPI;";
                }
                else 
                {
                    cadena.ConnectionString = cadena.ConnectionString + "User Id=" +
                        this.NombreUsuario + "; Password=" + this.clave + ";";
                }
            }
            catch (Exception ex)
            {
                cadena = null;
                throw ex;
            }
            return cadena;
        }
        //metodo pra activar el constructor 
        public static Conexion InstanciaConstructor()
        {
            if (con == null)
            {
                con = new Conexion();
            }
            return con;
        }

    }
}
