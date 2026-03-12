using System;
using System.Collections.Generic;
using System.Linq;           

namespace PooPracticaClase3
{
    public class Program
    {

        static List<Persona> personas = new List<Persona>();
        static Queue<Persona> colaAtencion = new Queue<Persona>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool salir = false;

            while (!salir)
            {
                Console.Clear(); // LIMPIA TODO ANTES DE MOSTRAR EL MENÚ
                Console.WriteLine("\n******************************************");
                Console.WriteLine("\n    ***    MENU DEL ESTUDIANTE    *** ");
                Console.WriteLine("\n******************************************");
                Console.WriteLine("\n1. Agregar un estudiante");
                Console.WriteLine("\n2. Listar los estudiantes actutales");
                Console.WriteLine("\n3. Buscar estudiantes por cedula");
                Console.WriteLine("\n4. Filtrar estudiantes por edad"); //Usar Link
                Console.WriteLine("\n5. Atender estudiante"); // Usar Queue
                Console.WriteLine("\n6. Registrar estudiante"); // Usar Stack
                Console.WriteLine("\n7. Salir  ");
                Console.WriteLine("\n8. Ingrese una opcion");
                Console.WriteLine("\n******************************************\n\n");
                

                string opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        AgregarEstudiante();
                        Console.WriteLine("\n  Presione cualquier tecla para volver al menú...  \n\n");
                        Console.ReadKey(); 
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n  *** LISTA DE ESTUDIANTES ACTUALES *** \n\n\n");

                        if (personas.Count == 0)
                        {
                            Console.WriteLine("La lista está vacía.");
                        }
                        else
                        {
                            // Títulos de las columnas 
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("NOMBRE          | CEDULA       | EDAD  | CARRERA         | BECA");
                            Console.WriteLine("-------------------------------------------------------------------------------------");

                            foreach (var p in personas)
                            {
                                p.MostrarInformacion();
                            }

                            Console.WriteLine("-------------------------------------------------------------------------------------");
                        }

                        Console.WriteLine("\n\n\nPresione cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Ingrese la cédula que desea buscar:");
                        string buscar = Console.ReadLine();

                        // Buscamos en la lista a alguien que tenga esa cédula
                        var encontrado = personas.FirstOrDefault(p => p.GetCedula() == buscar);

                        if (encontrado != null)
                        {
                            Console.WriteLine("¡Estudiante encontrado!");
                            encontrado.MostrarInformacion();
                        }
                        else
                        {
                            Console.WriteLine("No existe ningún estudiante con esa cédula.");
                        }

                        Console.WriteLine("\n  Presione cualquier tecla para volver al menú...  \n\n");
                        Console.ReadKey(); // Se detiene el programa hasta que se toque una tecla
                        break;
                    case "4":
                        Console.WriteLine("\n--- ESTUDIANTES MAYORES DE EDAD (18+) ---");

                        // Se usa LINQ para filtrar >= 18
                        var mayoresDeEdad = personas.Where(est => est.Edad >= 18).ToList();

                        if (mayoresDeEdad.Count == 0)
                        {
                            Console.WriteLine("No hay estudiantes mayores de 18 años en la lista.");
                        }
                        else
                        {
                            // Mostramos solo a los que pasaron el filtro
                            foreach (var estudiante in mayoresDeEdad)
        {
                                estudiante.MostrarInformacion();
                            }
                        }
                        Console.WriteLine("\n  Presione cualquier tecla para volver al menú...  \n\n");
                        Console.ReadKey(); // Se detiene el programa hasta que se toque una tecla
                        break;
                    case "5":
                        if (colaAtencion.Count > 0)
                        {
                            Persona atendido = colaAtencion.Dequeue();
                            Console.WriteLine($"Atendiendo a: {atendido.GetNombre()}");
                        }
                        else
                        {
                            Console.WriteLine("No hay estudiantes en la cola de atención.");
                        }
                        break;
                    case "7":
                        Console.WriteLine("\n******************************************");
                        Console.WriteLine("          Saliendo del programa...");
                        Console.WriteLine("\n******************************************");
                        Thread.Sleep(2000);
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opcion invalida. Por favor, ingrese una opcion valida.");
                        break;
                }
            }
        }

        public static void AgregarEstudiante()
        {
            Console.WriteLine("\n\nIngrese el nombre del estudiante");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la cédula del estudiante");
            string cedula = Console.ReadLine();

            Console.WriteLine("Ingrese la edad del estudiante");
            int edad = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la carrera del estudiante");
            string carrera = Console.ReadLine();

            string esBecado = "";

            // 1. Solo se acepta S o N
            while (esBecado != "s" && esBecado != "n")
            {
                Console.WriteLine("Ingrese si el estudiante es becado  S/N");
                esBecado = Console.ReadLine().ToLower().Trim();

                if (esBecado != "s" && esBecado != "n")
                {
                    Console.WriteLine("Dato incorrecto. Solo se acepta S o N.");
                }
            }

            if (esBecado == "s")
            {
                Console.WriteLine("Ingrese el monto de la beca");
                double monto = double.Parse(Console.ReadLine());

                // Se crea el estudiante becado
                EstudianteBecado nuevoBecado = new EstudianteBecado(carrera, monto);
                nuevoBecado.SetNombre(nombre);
                nuevoBecado.Edad = edad;
                nuevoBecado.SetCedula(cedula);
                personas.Add(nuevoBecado);

            }
            else
            {
                // Se crea al estudiante normal
                Estudiante nuevoEstudiante = new Estudiante(carrera);
                nuevoEstudiante.SetNombre(nombre);
                nuevoEstudiante.Edad = edad;
                nuevoEstudiante.SetCedula(cedula);
                personas.Add(nuevoEstudiante);
            }

            Console.WriteLine("\n\n  *****  ¡ESTUDIANTE AGREGADO CON EXITO!  *****\n\n");


         
        }

    }


}
