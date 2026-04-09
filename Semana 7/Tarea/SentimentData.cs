using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaSemana6.Models
{
    public class SentimentData
    {
        [LoadColumn(0)] // Carga la primera columna del CSV (0)
        public float Label { get; set; } // 0 para negativo, 1 para positivo

        [LoadColumn(5)] // Carga la segunda columna del CSV (1)
        public string Text { get; set; } // El texto que se va a analizar

    }
}
