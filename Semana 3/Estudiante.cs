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
        private string Carrera;

        public Estudiante(string carrera) : base()
        {
            this.Carrera = carrera;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"Estudiante:  {this.GetNombre()}, Edad: {this.Edad}, Carrera: {this.Carrera}");
        }
    }
}
