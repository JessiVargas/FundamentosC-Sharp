using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Cliente : Persona
    {
        private string tipoMembresia;

        // Constructor que reutiliza el de Persona y agrega membresía
        public Cliente(string nombre, int edad, string tipoMembresia)
            : base(nombre, edad)
        {
            this.tipoMembresia = tipoMembresia;
        }

        // Propiedad para tipo de membresía
        public string TipoMembresia
        {
            get { return tipoMembresia; }
            set { tipoMembresia = value; }
        }

        // Método que amplía la información del cliente
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine("Membresía: " + tipoMembresia);
        }
    }
}
