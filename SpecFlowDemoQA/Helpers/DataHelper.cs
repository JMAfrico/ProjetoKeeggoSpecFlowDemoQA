using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemoQA.Helpers
{
    internal class DataHelper
    {
        public static string DataAtual()
        {
            string data = DateTime.Now.ToString("dd-MM-yyyy");
            return data;
        }

        public static string HoraAtual()
        {
            string hora = DateTime.Now.ToString("HH-mm-ss-fff");
            return hora;
        }

        public static string CaminhoScreenshot()
        {
            string caminhoScreenshot = @"C:\\CSharpAlura\\SpecFlowDemoQA\\SpecFlowDemoQA\\Screenshoots\\" + DataAtual() + "\\";
            return caminhoScreenshot;
        }

        public static string CaminhoEvidencias()
        {
            string caminhoEvidencias = @"C:\\CSharpAlura\\SpecFlowDemoQA\\SpecFlowDemoQA\\Evidences\\" + DataAtual() + "\\";
            return caminhoEvidencias;
        }

        public static string CaminhoStatusPassed()
        {
            string caminhoStatusPassed = CaminhoEvidencias() + "Passed\\";
            return caminhoStatusPassed;
        }

        public static string CaminhoStatusFailed()
        {
            string caminhoStatusFailed = CaminhoEvidencias() + "Failed\\";
            return caminhoStatusFailed;
        }
    }
}
