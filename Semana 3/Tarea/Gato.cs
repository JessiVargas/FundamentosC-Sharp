using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioAnimales
{
    
    public class Gato : Animal
    {
        // Constructor
        public Gato(string nombre, int edad) : base(nombre, edad)
        {
        }

        // Implementación del sonido del gato
        public override void EmitirSonido()
        {
            Console.WriteLine("El gato dice: Miau");
        }
    }
}
