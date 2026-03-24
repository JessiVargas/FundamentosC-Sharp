using System;
using System.Collections.Generic;

namespace ProyectoFinal
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Lista para almacenar los clientes registrados
            List<Cliente> listaClientes = new List<Cliente>();

            int opcion = 0;

            // Menú principal del programa
            while (opcion != 3)
            {
                Console.WriteLine("===== GIMNASIO  =====");
                Console.WriteLine("1. Registrar cliente");
                Console.WriteLine("2. Mostrar clientes");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                // Se valida que el usuario ingrese un número válido
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese un número válido.\n");
                    continue;
                }

                // Validación de la opción ingresada
                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Edad: ");
                        int edad = int.Parse(Console.ReadLine());

                        Console.Write("Tipo de membresía: ");
                        string membresia = Console.ReadLine();

                        // Creación del objeto Cliente utilizando el constructor
                        Cliente nuevo = new Cliente(nombre, edad, membresia);

                        listaClientes.Add(nuevo);// Se agrega el cliente a la lista

                        Console.WriteLine("Cliente registrado.\n");
                        break;

                    case 2:
                        // Verifica si existen clientes antes de mostrarlos
                        if (listaClientes.Count == 0)
                        {
                            Console.WriteLine("No hay clientes registrados.\n");
                        }
                        else
                        {
                            // Recorre la lista y muestra cada cliente
                            foreach (Cliente c in listaClientes)
                            {
                                Console.WriteLine("-----");
                                c.MostrarInformacion();
                            }
                        }
                        break;
                    case 3:
                        // Finaliza la ejecución del programa
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida.\n");
                        break;
                }
                // Pausa para que el usuario pueda leer la información antes de limpiar pantalla
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
