using System;
using System.Collections.Generic;
using System.Text;

namespace _20200908
{
    class CalculadoraCientifica : Calculadora // Herencia
    {
        public double Potencia (int valor, int exponente)
        {
            return Math.Pow(valor, exponente);
        }

    }
}
