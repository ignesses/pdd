using System;
using System.Collections.Generic;
using System.Text;

namespace _20200922
{
    public interface Acuatico
    {
        int Velocidad { get; set; }

        void Navegar(string destino);
    }
}
