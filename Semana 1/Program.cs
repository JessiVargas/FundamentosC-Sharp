namespace Tarea1_JessicaVargas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa tu nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingresa tu edad: ");
            int edad = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Hola " + nombre + ", tienes " + edad + " años.");

            int edadFutura = edad + 5;
            Console.WriteLine("En 5 años, tendrás " + edadFutura + " años.");

            if (edad >= 18)
            {
                Console.WriteLine("Eres mayor de edad.");
            }
            else
            {
                Console.WriteLine("Eres menor de edad.");
            }   




        }
    }
}
