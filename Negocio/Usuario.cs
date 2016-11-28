using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiEstacionamiento
{
    public class Result
    {
        public string rutUsuario { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string correoUsuario { get; set; }
        public string claveUsuario { get; set; }
        public int idEstado { get; set; }
        public string fonoUsuario { get; set; }
        public int idRol { get; set; }
    }

    public class Usuario
    {
        public bool response { get; set; }
        public object msg { get; set; }
        public IList<Result> result { get; set; }
    }
}
