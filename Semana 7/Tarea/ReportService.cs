using Microsoft.ML.Data;
using System;
using System.IO;

namespace PracticaSemana6.Services
{
    public class ReportService
    {
        
        public string REPORT_PATH = Path.Combine(AppContext.BaseDirectory, "Reports");
        public void GenerateReport(BinaryClassificationMetrics metrics)
        {
            string fileName = $"reporte_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            Directory.CreateDirectory(REPORT_PATH);
            var report = $@"
                ===== REPORTE DEL MODELO =====
                Fecha: {DateTime.Now}

                Accuracy: {metrics.Accuracy:P2}
                F1 Score: {metrics.F1Score:P2}
                Precision: {metrics.PositivePrecision:P2}
                Recall: {metrics.PositiveRecall:P2}
                AUC: {metrics.AreaUnderRocCurve:P2}

                ================================
                ";

            File.WriteAllText(Path.Combine(REPORT_PATH, fileName), report);

            Console.WriteLine($"Reporte generado en: {REPORT_PATH}");
        }
    }
}
