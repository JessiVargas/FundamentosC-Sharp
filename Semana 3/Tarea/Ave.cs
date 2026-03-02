using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioAnimales
{
    public class Ave : Animal
    {
        // Constructor
        public Ave(string nombre, int edad) : base(nombre, edad)
        {
        }

        // Implementación del sonido del ave
        public override void EmitirSonido()
        {
            Console.WriteLine("El ave dice: Pío Pío");
        }
    }
}
