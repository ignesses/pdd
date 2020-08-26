using System;

namespace Clase_20200818
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int dado = 1;
            string mensaje;
            string valor = Console.ReadLine();
            dado = int.Parse(valor);

            if (dado == 1)
                {
                    mensaje = "Te ganaste un auto.";
                }
            else if (dado == 2 || dado == 5)
                {
                    mensaje = "Te ganaste un perro.";
                }
            else
                {
                    mensaje = "Seguí participando.";
                }

            Console.Write("Hello "); // No hace el salto de línea.
            Console.Write("World!");

            // Concatenar:
            Console.Write("Tu dado fue " + valor + " y te ganaste " + mensaje);
            Console.Write(string.Format("Tu dado fue {0} y te ganaste {1}", dado, mensaje));
            // Este último es más eficiente porque no tiene que ir armando variables de la misma cadena.
            Console.Write($"Tu dado fue {dado} y te ganaste {mensaje}"); // Poniendo el $ delante.
            // Se llama interpolación de variables.

            // for (int i = 0; i < length; i++)
            for (int posicion = 10; posicion <20; posicion++) // Con posicion-- es descendente
            {
                break; // Sale del for sin seguir con el resto de los pasos.
            }

            /*
             * Ejercicio:
             * Pedirle al usuario que ingrese 10 números y los vaya sumando.
             * Si la suma llega a 50, salir del for.
             */

            // mensaje = dado == 1 ? "Te ganaste un auto" : dado == 3 ? "Te ganaste una moto." : "Seguí participando";
        }
    }
}
