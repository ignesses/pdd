using System;

namespace _20200908
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Calculadora calculadora = new Calculadora();
            Calculadora calculadora2 = new Calculadora(1, 2);
            
            Calculadora calculadora3; // Declaro la intención nada más.

            calculadora3 = new Calculadora(); // Se asigna el espacio de memoria y se ejecuta el contructor.

            Class1 clase = new Class1();
            
            // Get como hacía usualmente:
            Console.WriteLine(calculadora.GetNumero1());
            
            // Asigno un valor .net:
            calculadora.Numero1 = 10;
            Console.WriteLine(calculadora.Numero1);

            calculadora.Numero2 = 32;
            Console.WriteLine(calculadora.Numero2);

            calculadora.Metodo(1);
            calculadora.Metodo(1, 2);
            calculadora.Metodo("");
            calculadora3 = null; // Limpio la referencia al espacio de memoria. Libero el puntero. En este caso de la calculadora3.

            Console.WriteLine(calculadora.Sumar(10, 26));
            Console.WriteLine(calculadora.RestarOriginal(10, 26));
            Console.WriteLine(calculadora.Multiplicar(10, 26));
            Console.WriteLine(calculadora.Dividir(15, 3));
            Console.WriteLine(calculadora.Dividir(10, 0));

            CalculadoraCientifica cientifica = new CalculadoraCientifica();
            cientifica.Sumar(43, 12);

            // No puedo instanciar objetos de clases abstractas. Me sirve entonces para heredar de otras.
            // CalculadoraBase calculadoraBase = new CalculadoraBase();

            // Uso de métodos de una clase estática (con propiedades estáticas --> sino rompe):
            Ayuda.Sumar(1, 2);

        }
    }
}
