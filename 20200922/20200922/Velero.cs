using System;
using System.Collections.Generic;
using System.Text;

namespace _20200922
{
    class Velero : Vehiculo, Acuatico
        // Primero la clase, luego la interfaz.
    {
        // Necesito implementar la función de la interfaz:
        public int Velocidad { get; set; }

        public void Navegar (string destino)
        {

        }
    }
}
