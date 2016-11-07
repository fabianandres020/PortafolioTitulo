using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Vehiculo
    {
        public int ID_VEHICULO { get; set; }
        public string patente  { get; set; }
        public string rut_usuario { get; set; }
        public string rut_propietario { get; set; }
        public int id_tipo_marca { get; set; }
        public int id_marca { get; set; }
    }
}
