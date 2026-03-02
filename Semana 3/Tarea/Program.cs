namespace RefugioAnimales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creamos una lista de animales usando polimorfismo
            List<Animal> animales = new List<Animal>();

            // Agregamos diferentes tipos de animales al refugio
            animales.Add(new Perro("Titan", 8));
            animales.Add(new Gato("Jueves", 6));
            animales.Add(new Ave("Lala", 1));

            // Recorremos la lista y mostramos el sonido de cada animal
            foreach (Animal animal in animales)
            {
                Console.WriteLine($"Nombre: {animal.Nombre}, Edad: {animal.Edad}");
                animal.EmitirSonido();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
