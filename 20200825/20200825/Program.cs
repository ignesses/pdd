using System;

namespace _20200825
{
    class Program
    {
        static void Main(string[] args)
        {

            int numero = 0;
            // int numero = 10;
            // Si inicia en 10, nunca va a entrar al while.
            while (numero <10)
            {
                numero++;
                Console.WriteLine(numero);
            }

            // Se ejecuta 1 o n veces hasta que se cumpla la condición.
            // Entra al menos una vez.
            do
            {

            } while (numero < 10);

            int intentos = 1;
            string clave = "";
            Console.Write("Ingrese la contraseña: ");
            while (clave!="secreto" && intentos <4)
            {
                Console.Write("Ingrese la contraseña: ");
                clave = Console.ReadLine();
                intentos++;
            }

            Console.WriteLine("Hello World!");


            /* Armar un programa que le pida al usuario que adivine un numero que ustedes prefijaron, si adivina le muestran un mensaje de felicitacion, caso contrario que siga participando
            */


        }
    }
}
