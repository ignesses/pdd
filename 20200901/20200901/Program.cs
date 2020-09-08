using System;

namespace Clase_20200901
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Armar un juego para adivinar un número utilizando una variable random.
             * Dar 3 chances al jugador para que acierte, si acierta salen del bucle y le dan un mensaje.
             * Si no aciertan imprimen un mensaje dando el número secreto.
             */

            /********** VERSIÓN 1.0
            int numeroSecreto, respuesta, maxIntentos = 3;
            Random random = new Random();
            numeroSecreto = random.Next(10);

            string mensaje = "";
            Console.WriteLine("Intenta adivinar el numero secreto: \n");

            for (int i = 0; i < maxIntentos; i++)
            {
                respuesta = int.Parse(Console.ReadLine());
                mensaje = respuesta == numeroSecreto ? "Has Ganado" : "El numero no es correcto. Vuelve a intentar.";

                if (respuesta == numeroSecreto)
                {
                    break;
                }

                if (i == maxIntentos - 1)
                {
                    mensaje = "Has perdido el numero era: " + numeroSecreto;
                    break;
                }
                Console.WriteLine(mensaje + "\n");
            }

            Console.WriteLine(mensaje + "\n");
            */

            /********** VERSIÓN 1.1
            Random random = new Random();
            int secreto = random.Next(10);
            int numero = 0;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Ingrese el número: ");
                string valor = Console.ReadLine();
                numero = int.Parse(valor);
                if (numero == secreto) break;
            }
            
            if(numero == secreto)
                {
                    Console.WriteLine("Ganaste");
                }
            else
            {
                Console.WriteLine("Perdiste, el número secreto era: " + secreto + ".");
            }
            */

            /********** VERSIÓN 2.0 */
            Random random = new Random();
            int secreto = random.Next(10);
            int numero = 0;

            for (int i = 0; i < 3; i++)
            {
                numero = IngresoNumero("Ingrese el número: ");
                if (numero == secreto) break;

                /********** VERSION 2.1:
                IngresoNumero("Ingrese el número: ", ref numero);
                if (numero == secreto) break;
                */

                /********** VERSIÓN 2.2:
                int inferior;
                int superior;
                IngresoNumero ("Ingrese el número: ", out inferior, out superior);
                */
            }
                
            if (numero == secreto)
            {
                Ganaste();
            }
            else
            {
                Perdiste(secreto);
            } 
        }
        static void Ganaste()
        {
            Console.WriteLine("Ganaste");
        }

        static void Perdiste(int valor)
        {
            Console.WriteLine("Perdiste, el número era " + valor + ".");
        }

        // Armar un método que reciba como parámetros el mensaje a mostrar al usuario y devuelva el número ingresado.
           
        //VERSIÓN 1.0
        static int IngresoNumero(string mensaje)
        {
            Console.Write(mensaje);
            string valor = Console.ReadLine();
            return int.Parse(valor);
        }
            
        // VERSIÓN 2.1:
        /*
        static void IngresoNumero(string mensaje, ref int numero)
        {
            Console.Write(mensaje);
            string valor = Console.ReadLine();
            numero = int.Parse(valor);
        }
        */

        // VERSIÓN 2.2:
        /*
        static int ingresoNumero(string mensaje, out int numero1, out int numero2)
        {
            Console.Write(mensaje);
            string valor = Console.ReadLine();
            numero1 = int.Parse(valor);
            numero2 = int.Parse(valor);
            //return int.Parse(valor);
        }
        */
    }
}
