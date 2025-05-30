using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.CAPA_ENTIDADES
{
    public class Articulo
    {
        public int idArticulo { get; set; }
        public int idCategoria { get; set; }
        public string codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precioventa { get; set; }
        public int stock { get; set; }
        public string Descripccion { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }
    }
}
