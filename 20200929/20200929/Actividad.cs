using System;
using System.Collections.Generic;
using System.Text;

namespace _20200929
{
    public interface IActividad
    {
        string Nombre { get; set; }
    }

    public class Actividad : IActividad
    {
        public int Id { get; set }
        // public int ActividadId { get; set; }
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }

    }

    public class Tarea : IActividad
    {
        public string Nombre { get; set; }
        public string Nota { get; set; }
    }

    public class ActividadDto
    {
        public string Nombre { get; set; }
        public string Lugar { get; set; }
    }
}
