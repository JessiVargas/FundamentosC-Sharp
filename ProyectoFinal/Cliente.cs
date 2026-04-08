namespace ProyectoFinal
{
    public class Cliente : Persona
    {
        public string TipoMembresia { get; set; }

        public Cliente(string tipoMembresia)
        {
            this.TipoMembresia = tipoMembresia;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"{GetNombre(),-15} | {GetCedula(),-12} | {Edad,-5} | {TipoMembresia,-15} | Básico");
        }
    }
}
