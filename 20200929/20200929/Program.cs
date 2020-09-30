using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _20200929
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Intro();
            Console.ReadLine();

        }

        public static void EF()
        {
            var ctx = new AppContext();

            var lista = ctx.Actividades.ToList();
            var lista2 = ctx.Actividades.Where(i => i.Fecha < DateTime.Now).ToList();

            // Modificar un registro:
            Actividad actividad = lista[0];
            actividad.Nombre = "nuevoNombre";
            
            // Borrar un registro:
            ctx.Actividades.Remove(lista[1]);

            // Para borrarlo primero lo tengo que traer, entonces sería:
            var actividad1 = ctx.Actividades.Where(i => i.Id == 15).First();
;
            ctx.Actividades.Add(new Actividad { Lugar = "CABA", Nombre = "Clase" }); // Estoy marcando la intención, pero no registrando los cambios.

            ctx.SaveChanges(); // Ahora si, guardo los cambios.

        }

        public static void Agregado (string orden)
        {
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine(numeros.Average());
            Console.WriteLine(numeros.Count());
            Console.WriteLine(numeros.Sum());
            Console.WriteLine(numeros.Max());
            Console.WriteLine(numeros.Min());
            Console.WriteLine(numeros.First());
            Console.WriteLine(numeros.Last());
        }

        // Armar un programa que dado una lista de números filtre los pares y los ordene de mayor a menor.

        public static void Ejercicio()
        {
            List<int> listaDeNumeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var numerosPar = listaDeNumeros.Where(n => n % 2 == 0).OrderByDescending(n => n);
            foreach (var n in numerosPar)
            {
                Console.WriteLine(n);
            }
        }

        public static void Todo(string orden)
        {
            List<Actividad> eventos = new List<Actividad>();
            eventos.Add(new Actividad { Lugar = "CABA", Nombre = "Ms Build", Fecha = new DateTime(2020, 11, 9) });
            eventos.Add(new Actividad { Lugar = "Online", Nombre = "Amazon Summit", Fecha = new DateTime(2020, 9, 29) });
            eventos.Add(new Actividad { Lugar = "Online", Nombre = "Ms Ignite", Fecha = new DateTime(2020, 9, 25) });

            var resultado = eventos
                .Where(i => i.Fecha < DateTime.Now)
                .OrderBy(i => i.Fecha)
                .Select(i => new ActividadDto { Nombre = i.Nombre, Lugar = i.Lugar });

            var resultado2 = eventos
                .Where(i => i.Fecha < DateTime.Now);

            if (orden == "fecha")
            {
                resultado2 = resultado2.OrderBy(i => i.Fecha);
            }
            else
            {
                resultado2 = resultado2.OrderBy(i => i.Fecha);
            }

            var resultado3 = resultado2
            .Select(i => new ActividadDto { Nombre = i.Nombre, Lugar = i.Lugar }); 

        }

        public static void Proyeccion()
        {
            List<Actividad> eventos = new List<Actividad>();
            eventos.Add(new Actividad { Lugar = "CABA", Nombre = "Ms Build", Fecha = new DateTime(2020, 11, 9) });
            eventos.Add(new Actividad { Lugar = "Online", Nombre = "Amazon Summit", Fecha = new DateTime(2020, 9, 29) });
            eventos.Add(new Actividad { Lugar = "Online", Nombre = "Ms Ignite", Fecha = new DateTime(2020, 9, 25) });

            var nombres = eventos.Select(i => i.Nombre);
            var nombres2 = eventos.Select(i => new { i.Nombre, i.Lugar});
            var nombres3 = eventos.Select(i => new ActividadDto { Nombre = i.Nombre, Lugar = i.Lugar });

        }

        public static void GroupBy()
        {
            List<Actividad> eventos = new List<Actividad>();
            eventos.Add(new Actividad { Lugar = "CABA", Nombre = "Ms Build", Fecha = new DateTime(2020, 11, 9) });
            eventos.Add(new Actividad { Lugar = "Online", Nombre = "Amazon Summit", Fecha = new DateTime(2020, 9, 29) });
            eventos.Add(new Actividad { Lugar = "Online", Nombre = "Ms Ignite", Fecha = new DateTime(2020, 9, 25) });

            // Agrupo por lugar:
            var grupos = eventos.GroupBy(i => i.Lugar);

            // Agrupo por lugar y fecha:
            var grupo2 = eventos.GroupBy(i => new { i.Lugar, i.Fecha });

            foreach (var item in grupos)
            {
                item.Count();
            }

            foreach (var item in grupo2)
            {
                //item.Key.Fecha;
            }

        }

        public static void Ordenar()
        {

            List<Actividad> eventos = new List<Actividad>();
            eventos.Add(new Actividad { Lugar = "CABA", Nombre = "Ms Build", Fecha = new DateTime(2020, 11, 9) });
            eventos.Add(new Actividad { Lugar = "Online", Nombre = "Amazon Summit", Fecha = new DateTime(2020, 9, 29) });
            eventos.Add(new Actividad { Lugar = "Online", Nombre = "Ms Ignite", Fecha = new DateTime(2020, 9, 25) });

            var ordenarFecha = eventos.OrderByDescending(i => i.Fecha);
            var ordenarNombre = eventos.OrderBy(i => i.Nombre);
            var odenarFechaNombre = eventos.OrderByDescending(i => i.Fecha).ThenBy(i => i.Nombre);

        }

        public static void PruebaOfType()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add("test");
            arrayList.Add("Ignacio");
            arrayList.Add(1);
            arrayList.Add(2);

            // Devuelve solo los números (int):
            var numeros = arrayList.OfType<int>();

            List<IActividad> eventos = new List<IActividad>();
            eventos.Add(new Actividad());
            eventos.Add(new Tarea());

            // Filtro aplicado sobre el tipo de dato:
            var tareas = eventos.OfType<Tarea>();

        }

        public static void Intro()
        {
            // "Link You"
            // Realizar consultas sobre colecciones que tengamos: arrays, listas, etc.

            string[] nombres = { "Gabriel", "Ignacio", "Facundo", "Federico", "Sofía", "Gabriel" };

            // Quiero filtrar los que comienzan con F. Usualmente lo haría con un for.

            // Sintaxis de consultas:
            IEnumerable<string> empiezanConF = from nombre in nombres where nombre.StartsWith("F") select nombre;

            // Sintaxis de métodos:
            IEnumerable<string> empiezanConI = nombres.Where(i => i.StartsWith("I"));

            foreach (var item in empiezanConF)
            {
                Console.WriteLine(item);
            }

            // Devuelvo solo los valores que no se repiten:
            IEnumerable<string> unicos = nombres.Distinct();

            List<Actividad> eventos = new List<Actividad>();
            eventos.Add(new Actividad { Lugar = "CABA", Nombre = "Ms Build", Fecha = new DateTime(2020, 11, 9) });
            eventos.Add(new Actividad { Lugar = "Online", Nombre = "Amazon Summit", Fecha = new DateTime(2020, 9, 29) });
            eventos.Add(new Actividad { Lugar = "Online", Nombre = "Ms Ignite", Fecha = new DateTime(2020, 9, 25) });
            // CREAR MÁS ACTIVIDADES PARA EL EJEMPLO.

            // IEnumerable:
            IEnumerable<string> pasados = eventos.Where(i => i.Fecha < DateTime.Now).Select(i => i.Nombre);
            // Lo mismo pero como List:
            List<string> pasados2 = eventos.Where(i => i.Fecha < DateTime.Now).Select(i => i.Nombre).ToList();

            // Funciones Lambda - Creo una función adentro de una variable:
            Func<int, bool> validarEdad = (edad) => edad > 18;

            // No necesariamente lo tengo que resolver todo en una misma línea - caso A:
            Func<int, string, bool> validarEdadSexo = (edad, genero) => (edad > 18 && genero == "M") || (edad > 19 && genero == "F");

            // Caso B:
            Func<int, string, bool> validarEdadSexoB = (edad, genero) =>
            {
                if (genero == "M")
                {
                    return edad > 18;
                }
                else
                {
                    return edad > 19;
                }
            };

            // Las Action no devuelven ningún valor, es como si fueran un void. Simplemente ejecutan una acción:
            Action<int> imprimir = (valor) => Console.WriteLine(valor);


            validarEdad(20); // Devuelve true o false.
            validarEdadSexo(20, "");
        }

        public void ImprimirFull(int edad)
        {
            Console.WriteLine(edad);
        }

        public bool validadEdadFull(int edad)
        {
            return edad > 18;
        }
    }
}
