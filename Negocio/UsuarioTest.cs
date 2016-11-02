using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
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

    public class UsuarioTest
    {
        public string msg { get; set; }
        public Result result { get; set; }
        public string access_token { get; set; }
    }
}
