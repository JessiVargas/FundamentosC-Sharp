using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooPracticaClase3
{
    public class EstudianteBecado : Estudiante
    {
        public double MontoBeca { get; set; }

        public EstudianteBecado(string carrera, double montoBeca) : base(carrera)
        {
            this.MontoBeca = montoBeca;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"Estudiante becado: {GetNombre()}, Edad: {Edad}, Carrera: {MontoBeca}");
        }
    }
}
