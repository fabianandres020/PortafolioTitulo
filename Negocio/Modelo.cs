﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ListaModelo
    {
        public int idModelo { get; set; }
        public string nombreModelo { get; set; }
        public int? anio { get; set; }
        public int idMarca { get; set; }
    }

    public class Modelo
    {
        public bool response { get; set; }
        public object msg { get; set; }
        public IList<ListaModelo> listaModelos { get; set; }
    }



}
