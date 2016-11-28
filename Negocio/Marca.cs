using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ListaMarcaVehiculo
    {
        public int idMarca { get; set; }
        public string nombre { get; set; }
    }

    public class Marca
    {
        public bool response { get; set; }
        public object msg { get; set; }
        public IList<ListaMarcaVehiculo> listaMarcaVehiculo { get; set; }
    }
}
