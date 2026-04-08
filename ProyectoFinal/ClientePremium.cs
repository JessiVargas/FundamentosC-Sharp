namespace ProyectoFinal
{
    public class ClientePremium : Cliente
    {
        public double CostoMensual { get; set; }

        public ClientePremium(string tipoMembresia, double costo)
            : base(tipoMembresia)
        {
            this.CostoMensual = costo;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine($"{GetNombre(),-15} | {GetCedula(),-12} | {Edad,-5} | {TipoMembresia,-15} | ₡ {CostoMensual}");
        }
    }
}