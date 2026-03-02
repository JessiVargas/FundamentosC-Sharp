using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioAnimales
{
    public abstract class Animal
    {
        // Atributos privados
        private string nombre;
        private int edad;

        // Propiedad para el nombre
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        // Propiedad para la edad con validación
        public int Edad
        {
            get { return edad; }
            set
            {
                // Validamos que la edad sea mayor que 0
                if (value > 0)
                {
                    edad = value;
                }
                else
                {
                    edad = 1;
                }
            }
        }

        // Constructor con parámetros
        public Animal(string nombre, int edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;
        }

        // Método abstracto que cada animal debe implementar
        public abstract void EmitirSonido();
    }
}
