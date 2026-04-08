using System.Collections.Generic;

namespace ProyectoFinal
{
    public class Entrenador
    {
        // Nombre del entrenador
        public string Nombre { get; set; }

        // Capacidad máxima de clientes que puede atender
        public int CapacidadMaxima { get; set; }

        // Lista de clientes que ha atendido
        public List<Persona> ClientesAtendidos { get; set; }

        // Constructor
        public Entrenador(string nombre, int capacidad)
        {
            Nombre = nombre;
            CapacidadMaxima = capacidad;
            ClientesAtendidos = new List<Persona>();
        }

        // Guarda un cliente en su historial
        public void AtenderCliente(Persona cliente)
        {
            ClientesAtendidos.Add(cliente);
        }

        // Verifica si el entrenador tiene espacio para atender a más clientes
        public bool TieneEspacio()
        {
            return ClientesAtendidos.Count < CapacidadMaxima;
        }
    }
}