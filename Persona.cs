using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooPracticaClase3
{
    public abstract class Persona
    {
        // Atributo privado para el nombre
        private string Nombre;

        // Propiedad para el atributo Edad
        public int Edad { get; set; }

        // Constructor SIN parametros
        public Persona()
        {
            this.Nombre = "Karol";
        }

        // Constructor CON parametros   
        public Persona(string nombre, int edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;
        }

        // Metodo Set
        public void SetNombre(string nombre)
        {
            this.Nombre = nombre;
        }

        // Metodo Get
        public string GetNombre()
        {
            return this.Nombre;
        }

        // Metodo abstracto para mostrar informacion
        public abstract void MostrarInformacion();
    }
}
