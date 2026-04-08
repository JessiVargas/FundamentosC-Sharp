using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProyectoFinal
{
    public class Program
    {
        // Lista principal donde se guardan todos los clientes registrados
        static List<Persona> personas = new List<Persona>();

        // Cola para simular el orden de atención (FIFO)
        static Queue<Persona> colaAtencion = new Queue<Persona>();

        // Pila para guardar historial de clientes atendidos (LIFO)
        static Stack<Persona> historial = new Stack<Persona>();

        // Dos entrenadores disponibles para atender a los clientes
        static Entrenador entrenador1 = new Entrenador("Entrenador 1", 3);
        static Entrenador entrenador2 = new Entrenador("Entrenador 2", 3);

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool salir = false;

            // Ciclo principal del sistema
            while (!salir)
            {
                Console.Clear(); // Limpia la pantalla antes de mostrar el menú

                Console.WriteLine("\n******************************************");
                Console.WriteLine("\n    ***    TITANES GYM    *** ");
                Console.WriteLine("\n******************************************");
                Console.WriteLine("\n1. Agregar cliente");
                Console.WriteLine("\n2. Listar clientes");
                Console.WriteLine("\n3. Buscar cliente por cédula");
                Console.WriteLine("\n4. Filtrar clientes por edad ");
                Console.WriteLine("\n5. Asignar cliente a entrenador");
                Console.WriteLine("\n6. Ver historial");
                Console.WriteLine("\n7. Salir");
                Console.WriteLine("\n******************************************\n");

                string opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        // Llama al método que se encarga de registrar clientes
                        AgregarCliente();
                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("\n  *** LISTA DE CLIENTES REGISTRADOS *** \n\n");

                        if (personas.Count == 0)
                        {
                            Console.WriteLine("No hay clientes registrados.");
                        }
                        else
                        {
                            // ENCABEZADO (esto es lo que te faltaba)
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("NOMBRE          | CEDULA       | EDAD  | MEMBRESIA      | DETALLE");
                            Console.WriteLine("-------------------------------------------------------------------------------------");

                            foreach (var p in personas)
                            {
                                p.MostrarInformacion(); // aquí ya imprime alineado
                            }

                            Console.WriteLine("-------------------------------------------------------------------------------------");
                        }

                        Console.WriteLine("\n\nPresione cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("Ingrese la cédula a buscar:");
                        string cedula = Console.ReadLine();

                        // Uso de LINQ para buscar por cédula
                        var encontrado = personas.FirstOrDefault(p => p.GetCedula() == cedula);

                        if (encontrado != null)
                        {
                            Console.WriteLine("\nCliente encontrado:\n");
                            encontrado.MostrarInformacion();
                        }
                        else
                        {
                            Console.WriteLine("No existe un cliente con esa cédula.");
                        }
                        Console.WriteLine("\n\nPresione cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.WriteLine("\n--- FILTRO DE CLIENTES POR EDAD ---\n");

                        Console.WriteLine("Seleccione una opción:");
                        Console.WriteLine("1. Menores de edad (-18)");
                        Console.WriteLine("2. Mayores de edad (18 - 59)");
                        Console.WriteLine("3. Adultos mayores (60+)");
                        string opcionFiltro = Console.ReadLine();

                        List<Persona> resultado = new List<Persona>();

                        if (opcionFiltro == "1")
                        {
                            resultado = personas.Where(p => p.Edad < 18).ToList();
                            Console.WriteLine("\n--- CLIENTES MENORES DE EDAD ---\n");
                        }
                        else if (opcionFiltro == "2")
                        {
                            resultado = personas.Where(p => p.Edad >= 18 && p.Edad < 60).ToList();
                            Console.WriteLine("\n--- CLIENTES MAYORES DE EDAD ---\n");
                        }
                        else if (opcionFiltro == "3")
                        {
                            resultado = personas.Where(p => p.Edad >= 60).ToList();
                            Console.WriteLine("\n--- CLIENTES ADULTOS MAYORES ---\n");
                        }
                        else
                        {
                            Console.WriteLine("Opción inválida.");
                            Console.ReadKey();
                            break;
                        }

                        // SIEMPRE muestra resultado (aunque esté vacío)
                        if (resultado.Count == 0)
                        {
                            Console.WriteLine("No hay clientes en esta categoría.");
                        }
                        else
                        {
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("NOMBRE          | CEDULA       | EDAD  | MEMBRESIA      | DETALLE");
                            Console.WriteLine("-------------------------------------------------------------------------------------");

                            foreach (var p in resultado)
                            {
                                p.MostrarInformacion();
                            }

                            Console.WriteLine("-------------------------------------------------------------------------------------");
                        }

                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.WriteLine("\n--- ASIGNACIÓN DE ENTRENADOR ---\n");

                        if (colaAtencion.Count == 0)
                        {
                            Console.WriteLine("No hay clientes en espera.");
                            Console.ReadKey();
                            break;
                        }

                        // Mostrar disponibilidad
                        Console.WriteLine($"{entrenador1.Nombre}: {entrenador1.ClientesAtendidos.Count}/{entrenador1.CapacidadMaxima}");
                        Console.WriteLine($"{entrenador2.Nombre}: {entrenador2.ClientesAtendidos.Count}/{entrenador2.CapacidadMaxima}");

                        Console.WriteLine("\nSeleccione entrenador:");


                        string opcionEntrenador = Console.ReadLine(); // 👈 nombre cambiado

                        Persona clienteEnEspera = colaAtencion.Peek(); // 👈 nombre cambiado

                        if (opcionEntrenador == "1")
                        {
                            if (entrenador1.TieneEspacio())
                            {
                                clienteEnEspera = colaAtencion.Dequeue();
                                entrenador1.AtenderCliente(clienteEnEspera);
                                Console.WriteLine($"{entrenador1.Nombre} atenderá a {clienteEnEspera.GetNombre()}");
                            }
                            else
                            {
                                Console.WriteLine("Entrenador 1 está lleno.");
                            }
                        }
                        else if (opcionEntrenador == "2")
                        {
                            if (entrenador2.TieneEspacio())
                            {
                                clienteEnEspera = colaAtencion.Dequeue();
                                entrenador2.AtenderCliente(clienteEnEspera);
                                Console.WriteLine($"{entrenador2.Nombre} atenderá a {clienteEnEspera.GetNombre()}");
                            }
                            else
                            {
                                Console.WriteLine("Entrenador 2 está lleno.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Opción inválida.");
                        }

                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.WriteLine("\n--- HISTORIAL DE ATENCIONES ---\n");

                        // ENTRENADOR 1
                        Console.WriteLine($"--- {entrenador1.Nombre} ---");

                        if (entrenador1.ClientesAtendidos.Count == 0)
                        {
                            Console.WriteLine("No ha atendido clientes.");
                        }
                        else
                        {
                            foreach (var cliente in entrenador1.ClientesAtendidos)
                            {
                                Console.WriteLine(cliente.GetNombre());
                            }
                        }

                        Console.WriteLine();

                        // ENTRENADOR 2
                        Console.WriteLine($"--- {entrenador2.Nombre} ---");

                        if (entrenador2.ClientesAtendidos.Count == 0)
                        {
                            Console.WriteLine("No ha atendido clientes.");
                        }
                        else
                        {
                            foreach (var cliente in entrenador2.ClientesAtendidos)
                            {
                                Console.WriteLine(cliente.GetNombre());
                            }
                        }

                        Console.WriteLine("\nPresione una tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "7":
                        Console.WriteLine("\nSaliendo del sistema...");
                        Thread.Sleep(1500);
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Método encargado de capturar datos y crear clientes
        static void AgregarCliente()
        {
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Cédula:");
            string cedula = Console.ReadLine();

            Console.WriteLine("Edad:");
            int edad = int.Parse(Console.ReadLine());

            // UNA SOLA DECISIÓN DE MEMBRESÍA
            Console.WriteLine("\nSeleccione tipo de membresía:");
            Console.WriteLine("1. Básica");
            Console.WriteLine("2. Premium");
            string opcion = Console.ReadLine();

            if (opcion == "2") // PREMIUM
            {
                Console.WriteLine("Costo mensual:");
                double costo = double.Parse(Console.ReadLine());

                ClientePremium nuevo = new ClientePremium("Premium", costo);
                nuevo.SetNombre(nombre);
                nuevo.SetCedula(cedula);
                nuevo.Edad = edad;

                personas.Add(nuevo);
                colaAtencion.Enqueue(nuevo);
            }
            else if (opcion == "1") // BÁSICA
            {
                Cliente nuevo = new Cliente("Básica");
                nuevo.SetNombre(nombre);
                nuevo.SetCedula(cedula);
                nuevo.Edad = edad;

                personas.Add(nuevo);
                colaAtencion.Enqueue(nuevo);
            }
            else
            {
                Console.WriteLine("Opción inválida.");
                return;
            }

            Console.WriteLine("\nCliente agregado correctamente.");
        }
    }
}