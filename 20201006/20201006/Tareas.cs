using System;
using System.Collections.Generic;
using System.Text;

namespace _20201006
{
    class Tareas
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public int TipoId { get; set; }
        public TipoTarea Tipo { get; set; }
    }
}
