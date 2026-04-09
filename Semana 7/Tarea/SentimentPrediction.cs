using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaSemana6.Models
{
    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; } // Resultado de la predicción (true - false)
        public float Probability { get; set; } // Probabilidad de que la predicción sea correcta
        public float Score { get; set; } // Puntaje de la predicción (puede ser útil para entender la confianza del modelo)
    }
}
