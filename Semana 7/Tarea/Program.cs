using PracticaSemana6;
using PracticaSemana6.Services;


namespace PracticaSemana6
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Sistema automático iniciado...\n");

            while (true)
            {
                try
                {
                    ExecutePipeline();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("\nEsperando próxima ejecución...\n");

                Thread.Sleep(120000); // 120 segundos/ 2min (valor por defecto)
            }
        }

        public static void ExecutePipeline()
        {
            // Instancia de la clase que se encarga de entrenar el modelo,
            // que recibe un parametro con el path del dataset 
            var trainer = new SentimentTrainer();
            var datasetPath = Path.Combine(AppContext.BaseDirectory, "Data", "sentiment.csv");
            var model = trainer.Train(datasetPath);
            //var model = trainer.Train("C:/Users/jekav/Desktop/Rocket Girls/Clase6_18-3-26/PracticaClase6/PracticaSemana6/Data/sentiment.csv");

            // Instancia que se encarga de hacer las predicciones,
            // al recibir como parametro un modelo entrenado
            var analyzer = new SentimentAnalyzer(model);

            analyzer.Predict("I love this product! It's amazing."); // Positivo
            analyzer.Predict("This is the worst experience I've ever had."); // Negativo

            RunInteractiveMode(analyzer);

            Console.WriteLine("\nPrograma finalizado.");
        }
        public static void RunInteractiveMode(SentimentAnalyzer analyzer)
        {
            Console.WriteLine("\n=== MODO INTERACTIVO ===");
            Console.WriteLine("Escribe 'salir' para terminar.\n");

            while (true)
            {
                Console.Write("Texto: ");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input.ToLower() == "salir")
                    break;

                analyzer.Predict(input);
            }

            Console.WriteLine("\nModo interactivo finalizado.");
        }
    }
}