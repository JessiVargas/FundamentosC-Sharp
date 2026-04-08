using System;

namespace ProyectoFinal
{
    public abstract class Persona
    {
        protected string Nombre;
        protected string Cedula;
        public int Edad { get; set; }

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

        public abstract void MostrarInformacion();
    }
}