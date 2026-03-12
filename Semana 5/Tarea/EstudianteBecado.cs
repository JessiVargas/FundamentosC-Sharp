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
            Console.WriteLine($"{GetNombre(),-15} | {GetCedula(),-12} | {Edad,-5} | {Carrera,-15} | Beca: ₡ {MontoBeca}");
        }
    }
}
