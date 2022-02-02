using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemoQA.Helpers
{
    internal class DataHelper
    {
        public static string GetDataAtual()
        {
            string data = DateTime.Now.ToString("dd-MM-yyyy");
            return data;
        }

        public static string GetHoraAtual()
        {
            string hora = DateTime.Now.ToString("HH-mm-ss-fff");
            return hora;
        }

        public static string GetCaminhoScreenshot()
        {
            string caminhoScreenshot = @"C:\\CSharpAlura\\SpecFlowDemoQA\\SpecFlowDemoQA\\Screenshoots\\" + GetDataAtual() + "\\";
            return caminhoScreenshot;
        }

        public static string GetCaminhoEvidencias()
        {
            string caminhoEvidencias = @"C:\\CSharpAlura\\SpecFlowDemoQA\\SpecFlowDemoQA\\Evidences\\" + GetDataAtual() + "\\";
            return caminhoEvidencias;
        }

        public static string GetCaminhoStatusPassed()
        {
            string caminhoStatusPassed = GetCaminhoEvidencias() + "Passed\\";
            return caminhoStatusPassed;
        }

        public static string GetCaminhoStatusFailed()
        {
            string caminhoStatusFailed = GetCaminhoEvidencias() + "Failed\\";
            return caminhoStatusFailed;
        }
    }
}
