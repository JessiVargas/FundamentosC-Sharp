using Microsoft.ML;
using PracticaSemana6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PracticaSemana6.Services
{
    public class SentimentAnalyzer
    {
        private readonly MLContext _mLContext;
        private readonly PredictionEngine<SentimentData, SentimentPrediction> _predictor;

        public SentimentAnalyzer(ITransformer model)
        {
            _mLContext = new MLContext();
            _predictor = _mLContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
        }

        public void Predict(string text)
        {
            var result = _predictor.Predict(new SentimentData { Text = text });

            Console.WriteLine($"Texto: {text}");
            Console.WriteLine($"Predicción: {(result.Prediction ? "Positivo" : "Negativo")}");
            Console.WriteLine($"Probabilidad: {result.Probability:P2}");
        }
    }
}
