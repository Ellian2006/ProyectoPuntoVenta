using ProyectoPuntoVenta.CAPA_DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.CAPA_NEGOCIOS
{
    internal class Negocios_Rol
    {
        public static DataTable listar()
        {
            //generamos la instancia a la clase datos_articulo
            Datos_Rol dc = new Datos_Rol();
            return dc.Listar();

        }
    }
}
