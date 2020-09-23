using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace _20200922
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void Listas()
        {
            int[] numeros = new int [3];
            numeros[0] = 1;

            ArrayList lista = new ArrayList();
            // El array es dinámico, nunca me voy a quedar corto.
            // Todo se guarda como objeto ("boxing"): se guarda el objeto en la memoria.
            lista.Add(1);
            lista.Add("");
            lista.Add(new Auto());

            // Lista fuertemente tipada:
            List<int> listadoDeNumeros = new List<int>();
            listadoDeNumeros.Add(1);
            listadoDeNumeros.Add(1);
            listadoDeNumeros.Add(1);
            // No tengo el problema de boxing - unboxing.
            // Todos los datos van a ser del tipo que yo quiera, no va a parecer otro.
            // Permite valores duplicados.

            List<Repuesto> repuestos = new List<Repuesto>();

            HashSet<int> numerosUnicos = new HashSet<int>();
            numerosUnicos.Add(1);
            numerosUnicos.Add(1);
            numerosUnicos.Add(1);

            // El Diccionario me permite gestionar dos tipo de datos, uno para la clave y otro para el valor.
            Dictionary<int, string> personas = new Dictionary<int, string>();
            personas.Add(26994130, "Gabriel");
            personas.Add(36400322, "Ignacio");
            personas.GetValueOrDefault(26994130);
            // Me permite buscar valores a través de una clave.

            Dictionary<string, Vehiculo> Autos = new Dictionary<string, Vehiculo>();
            Autos.Add("AA123AA", new Auto());
            Autos.Add("AB123AB", new Auto());
            Autos.Add("AB456AB", new Auto());

            Autos.GetValueOrDefault("AB123AB");
            //Autos.TryGetValue();
            // Le tengo que pasar una variable.

        }

        public static void Errores()
        {
            Vehiculo miauto = new Auto();
            Auto otroauto = new Auto();
            Vehiculo camion = new Camion();

            try
            {
                miauto.Marca = "Honda";
                miauto.Modelo = "Civic";
                miauto.Motor = new CuatroCilindros();
                ((Auto)camion).Puertas = 10;
                miauto.Arrancar(); // Esto va a dar error porque no puede parsear un string a int y no está encerrado dentro de un bloque try.
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("El valor no es del tipo auto.");
            }
            catch (NullReferenceException ex)
            // Cuando quiero acceder a una variable que no está inicializada.
            {
                Console.WriteLine("El valor no es del tipo auto.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(miauto.Marca);
            }

            Console.WriteLine(miauto.Marca);
            Console.ReadLine();
            if (camion is Auto)
            {

            }
        }
    }
}
