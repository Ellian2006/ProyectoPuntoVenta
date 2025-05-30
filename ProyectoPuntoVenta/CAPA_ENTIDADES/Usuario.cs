using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.CAPA_ENTIDADES
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string numDocumento { get; set; }
        public string Direccion { get; set; }
        public string telefono { get; set; }
        public string Email { get; set; }
        public string clave { get; set; }
        public bool estado { get; set; }
    }
}
