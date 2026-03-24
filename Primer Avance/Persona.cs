using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Persona
    {
        // Encapsulación 
        private string nombre;
        private int edad;

        // Propiedades (get y set)
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        // Constructor
        public Persona(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        // Método para polimorfismo 
        public virtual void MostrarInformacion()
        {
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Edad: " + edad);
        }
    }
}
