using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcial
{
    class Detalle
    {
        public string Fecha { get; set; }
        public string Tiempo { get; set; }
        public Recurso Recurso { get; set; }
        public Tarea Tarea { get; set; }
    }
}
