using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ListaModelo
    {
        public int idModelo { get; set; }
        public string nombre { get; set; }
        public int? año { get; set; }
    }

    public class Modelo
    {
        public object msg { get; set; }
        public IList<ListaModelo> listaModelos { get; set; }
    }

}
