using System;


namespace PooPracticaClase3
{
    public abstract class Persona
    {
        // Atributos
        protected string Nombre;
        protected string Cedula;
        public int Edad { get; set; }

        // Constructores
        public Persona()
        {
            this.Nombre = "Karol";
        }

        public Persona(string nombre, int edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;
        }

        // Métodos Get y Set
        public void SetNombre(string nombre)
        {
            this.Nombre = nombre;
        }

        public string GetNombre()
        {
            return this.Nombre;
        }

        public void SetCedula(string cedula)
        {
            this.Cedula = cedula;
        }

        public string GetCedula()
        {
            return this.Cedula;
        }

        // Método abstracto
        public abstract void MostrarInformacion();
    }
}
