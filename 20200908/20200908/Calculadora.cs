using System;
using System.Collections.Generic;
using System.Text;

namespace _20200908
{
    /*
     * public
     * private
     * protected
     * internal
     * internal protected -> los que están en un proyecto o los que heredan
     * private protected -> solamente los que estén en el mismo proyecto y hereden la clase
     */
    public class Calculadora : CalculadoraBase // Heredo la función resta de mi CalculadoraBase (abstracta).
    {
        private int numero1;

        // Así lo hacíamos habitualmente:
        public void SetNumero1(int valor)
        {
            numero1 = valor;
        }

        public int GetNumero1()
        {
            return numero1;
        }

        // En .net:
        // Ctrol + k + c --> Comentar
        // Ctrol + k + u --> Descomentar
        // Ctrol + d --> Duplicar línea
        public int Numero1
        {
            get
            {
                return numero1;
            }
            set
            {
                numero1 = value;
            }
        }

        public int Numero2 { get; set; }
        public int Numero3 { private get; set; }

        // CONSTRUCTORES:

        public Calculadora()
        {

        }

        public Calculadora(int numero1, int numero2)
        {
            Numero1 = numero1;
            Numero2 = numero2;
        }

        // MÉTODOS:
        public int Metodo()
        {
            if(Numero1==Numero2)
            {
                return 0;
            }
            return 1;
        }

        // Puedo tener mismo nombre si los parámetros son distintos:
        public int Metodo(string valor)
        {
            return 0;
        }

        public int Metodo(int valor)
        {
            return 0;
        }

        /// <summary>
        /// Este método es de prueba.
        /// </summary>
        /// <param name="valor"> Parámetro 1</param>
        /// <param name="valor"> Parámetro 2</param>
        /// <returns>Devuelve un número.</returns>
        public int Metodo(int valor1, int valor2)
        {
            return 0;
        }

        public int Sumar(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        public int RestarOriginal(int numero1, int numero2)
        {
            return numero1 - numero2;
        }
        public int Multiplicar(int numero1, int numero2)
        {
            return numero1 * numero2;
        }

        public int Dividir(int numero1, int numero2)
        {
            if (numero2 == 0)
            {
                return 0;
            }
            return numero1 / numero2;
        }

        // Implemento el método heredado de Calculadora Base:
        public override int Division(int valor1, int valor2)
        {
            return valor1 / valor2;
        }

        // Cambio el comportamiento de ese método (override):
        public sealed override int Restar(int valor1, int valor2)
        {
            return valor2 - valor1;
        }
        // Con el sealed sobrescribo y nadie más lo puede sobrescribir.

        protected class Operacion
        {

        }

    }
}
