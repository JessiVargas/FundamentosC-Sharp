using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioAnimales
{
    
    public class Perro : Animal
    {
        // Constructor
        public Perro(string nombre, int edad) : base(nombre, edad)
        {
        }

        // Implementación del sonido del perro
        public override void EmitirSonido()
        {
            Console.WriteLine("El perro dice: Guau Guau");
        }
    }
}
