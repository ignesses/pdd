using System;
using System.Collections.Generic;
using System.Text;

namespace _20200908
{
    public abstract class CalculadoraBase // Es una clase de la cual yo no puedo crear una instancia.
                                          // Las clases estáticas tampoco las puedo instanciar.
                                          // Es para heredar una clase abstracta.
    {
        private int Indice { get; set; } // Sólo pueden acceder los métodos que tienen método dentro de la clase.
        protected int Indice2 { get; set; } // No puedo acceder por fuera de la clase, es como si fuese un private con herencia.

        public virtual int Restar(int valor1, int valor2)
        {
            return valor1 - valor2;
        }
        // Virtual para que se pueda sobrescribir.

        // Pido que implemente el método:
        public abstract int Division(int valor1, int valor2);
    }
}
