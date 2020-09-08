using System;

namespace _20200901_Ejercicio
{
    class Program
    {
        /*
        Armar un programa que le pida al usuario ingresar el año de la fecha de nacimiento y calcular si fue biciesto o no. 
        Encapsular en un método el ingreso de datos pasando el texto a mostrarle al usuario y en otro método el cálculo de si es biciesto devolviendo un valor booleano.
         */
        static void Main(string[] args)
        {
            int fecha = IngresoFecha();
            if (Bisiesto(fecha))
            {
                Console.WriteLine("Es año {0} fue bisiesto.", fecha);
            }
            else
            {
                Console.WriteLine("El año {0} no fue bisiesto.", fecha);
            }
        }
        static int IngresoFecha()
        {
            Console.WriteLine("Ingrese el año de nacimiento: ");
            string valor = Console.ReadLine();
            int fecha = int.Parse(valor);
            return fecha;
        }

        static Boolean Bisiesto(int fecha)
        {
            if (fecha % 4 == 0 && fecha % 100 != 0 || fecha % 400 == 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
