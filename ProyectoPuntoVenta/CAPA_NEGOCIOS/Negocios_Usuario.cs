using ProyectoPuntoVenta.CAPA_DATOS;
using ProyectoPuntoVenta.CAPA_ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.CAPA_NEGOCIOS
{
    public class Negocios_Usuario
    {
        public static DataTable listar()
        {
            //generamos la instancia a la clase datos_usuario
            Datos_Usuario dc = new Datos_Usuario();
            return dc.Listar();

        }
        //metodo para buscar 
        public static DataTable Buscar(string valor)
        {
            //generamos la instancia a la clase datos_usuario
            Datos_Usuario dc = new Datos_Usuario();
            return dc.Buscar(valor);

        }

        //metodo para insertar 
        public static string Insertar(int idrol, string Nombre, string tipoducumento, string numdocumento,
            string Direccion, string telefono, string Email, string clave)
        {
            //generamos la instancia a la clase datos_ususario
            Datos_Usuario dc = new Datos_Usuario();
            string existe = dc.Existe(Email);
            if (existe.Equals("1"))
            {
                return "El usuario ya existe con este Email ya existe";
            }
            else
            {
                Usuario Obj = new Usuario();
                Obj.idRol = idrol;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = tipoducumento;
                Obj.numDocumento = numdocumento;
                Obj.Direccion = Direccion;
                Obj.telefono = telefono;
                Obj.Email = Email;
                Obj.clave = clave;
                return dc.Insertar(Obj);
            }



        }
        //metodo para acrualizar
        public static string Actualizar(int id, int idrol, string Nombre, string tipoducumento, string numdocumento,
            string Direccion, string telefono, string Emailant, string Email, string clave)
        {
            //generamos la instancia a la clase datos_ususario
            Datos_Usuario dc = new Datos_Usuario();
            if (Emailant.Equals("1"))
            {

                Usuario Obj = new Usuario();
                Obj.idUsuario = id;
                Obj.idRol = idrol;
                Obj.Nombre = Nombre;
                Obj.TipoDocumento = tipoducumento;
                Obj.numDocumento = numdocumento;
                Obj.Direccion = Direccion;
                Obj.telefono = telefono;
                Obj.Email = Email;
                Obj.clave = clave;
                return dc.actualizar(Obj);
            }
            else
            {
                string Existe = dc.Existe(Email);
                if (Existe.Equals("1"))
                {
                    return "EL USUARIO CON ESTE EMAIL YA EXISTE";
                }
                else
                {

                    Usuario Obj = new Usuario();
                    Obj.idUsuario = id;
                    Obj.idRol = idrol;
                    Obj.Nombre = Nombre;
                    Obj.TipoDocumento = tipoducumento;
                    Obj.numDocumento = numdocumento;
                    Obj.Direccion = Direccion;
                    Obj.telefono = telefono;
                    Obj.Email = Email;
                    Obj.clave = clave;
                    return dc.actualizar(Obj);
                }

            }



        }
        //metodo para eliminar
        public static string Eliminar(int Id)
        {
            //generamos la instancia a la clase datos_ususario
            Datos_Usuario dc = new Datos_Usuario();
            return dc.Eliminar(Id);
        }
        //metodo para activar
        public static string Activar(int Id)
        {
            //generamos la instancia a la clase datos_ususario
            Datos_Usuario dc = new Datos_Usuario();
            return dc.Activar(Id);
        }
        //metodo para desactivar
        public static string Desactivar(int Id)
        {
            //generamos la instancia a la clase datos_ususario
            Datos_Usuario dc = new Datos_Usuario();
            return dc.Desactivar(Id);
        }
    }
}
