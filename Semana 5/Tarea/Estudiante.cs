using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PooPracticaClase3;

namespace PooPracticaClase3
{
    public class Estudiante : Persona
    {
        // Propiedad específica de Estudiante
        public string Carrera { get; set; }

        // Constructor
        public Estudiante(string carrera) : base()
        {
            this.Carrera = carrera;
        }

        // Implementación del método abstracto de Persona
        public override void MostrarInformacion()
        {
            Console.WriteLine($"{GetNombre(),-15} | {GetCedula(),-12} | {Edad,-5} | {Carrera,-15} | No Becado");
        }
    }
}
