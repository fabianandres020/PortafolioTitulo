using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Rol
    {
        public object msg { get; set; }
        public IList<DetalleRol> result { get; set; }

    }
    public class DetalleRol
    {
        public int idRol { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }




}
