using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace _20200922
{
    public abstract class Vehiculo // No debo instanciar.
        // Puedo heredar solo de una clase.
        // Puedo implementar todas las interfaces que quiera.
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public Motor Motor { get; set; }

        protected abstract void Detener();

        public void Arrancar()
        {
            try
            {
                //this.Prueba();
                Console.WriteLine("El vehículo arrancó.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                throw;
                // Lo eleva al try catch del método que lo está utilizando. Elevo la excepción como la recibí.
                // También lo puedo elevar a otra excepción:
                throw new InvalidOperationException("No se qué pasó.", ex);
            }
        }

        public void Prueba(int valor)
        {
            if (valor == 0)
                throw new InvalidDataException("El parámetro valor no puede ser cero.");
            int.Parse("re");
        }
    }
}
