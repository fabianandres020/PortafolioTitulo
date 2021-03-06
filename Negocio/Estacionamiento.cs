﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ListaEsta
    {
        public int idEstacionamiento { get; set; }
        public int altura { get; set; }
        public double largo { get; set; }
        public double ancho { get; set; }
        public int pisoUbicacion { get; set; }
        public int? numeroEst { get; set; }
        public string idEstado { get; set; }
        public int camaraVigilancia { get; set; }
        public string tipoEstacionamiento { get; set; }
        public string direccionEstacionamiento { get; set; }
        public string idComuna { get; set; }
        public int costoHora { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string rutUsuario { get; set; }
    }

    public class Estacionamiento
    {
        public string msg { get; set; }
        public int code { get; set; }
        public IList<ListaEsta> result { get; set; }
    }


}
