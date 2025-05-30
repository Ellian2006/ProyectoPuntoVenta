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
    public class Negocios_Articulo
    {
        public static DataTable listar()
        {
            //generamos la instancia a la clase datos_articulo
            Datos_Articulos dc = new Datos_Articulos();
            return dc.Listar();

        }
        //metodo para buscar 
        public static DataTable Buscar(string valor)
        {
            //generamos la instancia a la clase datos_articulo
            Datos_Articulos dc = new Datos_Articulos();
            return dc.Buscar(valor);

        }

        //metodo para insertar 
        public static string Insertar(int idCategoria, string codigo, string Nombre,
           decimal Precioventa, int stock, string Descripcion, string imagen)
        {
            //generamos la instancia a la clase datos_articulo
            Datos_Articulos dc = new Datos_Articulos();
            string existe = dc.Existe(Nombre);
            if (existe.Equals("1"))
            {
                return "La categoria ya existe";
            }
            else
            {
                Articulo Obj = new Articulo();
                Obj.idCategoria = idCategoria;
                Obj.codigo = codigo;
                Obj.Nombre = Nombre;
                Obj.Precioventa = Precioventa;
                Obj.stock = stock;
                Obj.Descripccion = Descripcion;
                Obj.Imagen = imagen;

                return dc.Insertar(Obj);
            }


        }
        //metodo para actualizar
        public static string Actualizar(int id, int idCategoria, string codigo, string nombreanterior, string Nombre,
           decimal Precioventa, int stock, string Descripcion, string imagen)
        {
            //generamos la instancia a la clase datos_articulo
            Datos_Articulos dc = new Datos_Articulos();
            string existe = dc.Existe(Nombre);
            if (nombreanterior.Equals(Nombre)) { }
            else
            {
                if (existe.Equals("1"))
                {
                    return "La categoria ya existe";
                }
            }

            if (existe.Equals("1"))
            {
                return "La categoria ya existe";
            }
            else
            {
                Articulo Obj = new Articulo();
                Obj.idCategoria = idCategoria;
                Obj.codigo = codigo;
                Obj.Nombre = Nombre;
                Obj.Precioventa = Precioventa;
                Obj.stock = stock;
                Obj.Descripccion = Descripcion;
                Obj.Imagen = imagen;

                return dc.Insertar(Obj);
            }



        }
        //metodo para eliminar
        public static string Eliminar(int Id)
        {
            //generamos la instancia a la clase datos_categoria
            Datos_Articulos dc = new Datos_Articulos();
            return dc.Eliminar(Id);
        }
        //metodo para activar
        public static string Activar(int Id)
        {
            //generamos la instancia a la clase datos_categoria
            Datos_Articulos dc = new Datos_Articulos();
            return dc.Activar(Id);
        }
        //metodo para desactivar
        public static string Desactivar(int Id)
        {
            //generamos la instancia a la clase datos_categoria
            Datos_Articulos dc = new Datos_Articulos();
            return dc.Desactivar(Id);
        }
        //metodo para seleccionar la categoria 
 
    }
}
