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
    public class Negocios_Categoria
    {
        public static DataTable listar()
        {
            //generamos la instancia a la clase datos_categoria
            Datos_Categoria dc = new Datos_Categoria();
            return dc.Listar();

        }
        //metodo para buscar 
        public static DataTable Buscar(string valor)
        {
            //generamos la instancia a la clase datos_categoria
            Datos_Categoria dc = new Datos_Categoria();
            return dc.Buscar(valor);

        }

        //metodo para insertar 
        public static string Insertar(string Nombre, string Descripcion)
        {
            //generamos la instancia a la clase datos_categoria
            Datos_Categoria dc = new Datos_Categoria();
            string existe = dc.Existe(Nombre);
            if (existe.Equals("1"))
            {
                return "La categoria ya existe";
            }
            else
            {
                Categoria Obj = new Categoria();
                Obj.Nombre = Nombre;
                Obj.Descripcion = Descripcion;
                return dc.Insertar(Obj);
            }



        }
        //metodo actualizar
        public static string Actualizar(int Id, string NombreAnt, string Nombre, string Descripcion)
        {
            //generamos la instancia a la clase datos_categoria
            Datos_Categoria dc = new Datos_Categoria();
            Categoria Obj = new Categoria();
            if (NombreAnt.Equals(Nombre))
            {
                Obj.Idcategoria = Id;
                Obj.Nombre = Nombre;
                Obj.Descripcion = Descripcion;
                return dc.Actualizar(Obj);
            }
            else
            {
                string existe = dc.Existe(Nombre);
                if (existe.Equals("1"))
                {
                    return "La categoria ya existe";
                }
                else
                {
                    Obj.Idcategoria = Id;
                    Obj.Nombre = Nombre;
                    Obj.Descripcion = Descripcion;
                    return dc.Actualizar(Obj);
                }
            }
        }
        //metodo para eliminar
        public static string Eliminar(int Id)
        {
            //generamos la instancia a la clase datos_categoria
            Datos_Categoria dc = new Datos_Categoria();
            return dc.Eliminar(Id);
        }
        //metodo para activar
        public static string Activar(int Id)
        {
            //generamos la instancia a la clase datos_categoria
            Datos_Categoria dc = new Datos_Categoria();
            return dc.Activar(Id);
        }
        //metodo para desactivar
        public static string Desactivar(int Id)
        {
            //generamos la instancia a la clase datos_categoria
            Datos_Categoria dc = new Datos_Categoria();
            return dc.Desactivar(Id);
        }
        //metodo para seleccionar la categoria 
        public static DataTable Seleccionar()
        {
            //generamos la instancia a la clase datos_categoria
            Datos_Categoria dt = new Datos_Categoria();
            return dt.Seleccionar();
        }
    }
}

