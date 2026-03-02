namespace PooPracticaClase3
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            // Persona 1
            // Llamamos a persona 1
            Persona persona1 = new Persona();
            Console.WriteLine(persona1.GetNombre());
            // Modificamos el nombre de persona1
            persona1.SetNombre("Ka");
            Console.WriteLine("Modificando atributo nombre...");
            Console.WriteLine(persona1.GetNombre());

            // Persona 2
            Persona persona2 = new Persona();
            persona2.SetNombre("Cris");
            persona2.Edad = 25; 
            Console.WriteLine($"\n\nLa persona2 se llama {persona2.GetNombre()}, y tiene {persona2.Edad} anios \n\n");

            // Persona 3
            Persona persona3 = new Persona("Ana", 21);
            Console.WriteLine($"La persona3 se llama {persona3.GetNombre()}, y tiene {persona3.Edad} anios \n\n");
            */


             Estudiante estudiante1 = new Estudiante("Ingenieria Informatica");
                estudiante1.SetNombre("Karol");
                estudiante1.Edad = 22;
                estudiante1.MostrarInformacion();

            EstudianteBecado becado1 = new EstudianteBecado("Ingenieria Informatica", 150000);
            becado1.SetNombre("Laura");
            becado1.Edad = 20;
            becado1.MostrarInformacion();

        }
    }
}
