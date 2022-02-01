
using AventStack.ExtentReports;
using Gherkin.Ast;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowDemoQA.Utils
{
    public class ScreenShotUtil
    {
        private ScenarioContext cenario;

        public ScreenShotUtil(ScenarioContext cenario)
        {
            this.cenario = cenario;
        }

        public void TakesScreenshot(IWebDriver driver, IWebElement element)
        {
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("HH-mm-ss-fff");
            string caminhoPadrao = @"C:\\CSharpAlura\\SpecFlowDemoQA\\SpecFlowDemoQA\\Screenshoots\\" + data + "\\";
            if (!Directory.Exists(caminhoPadrao))
            {
                Directory.CreateDirectory(caminhoPadrao);
            }

            string fileName = caminhoPadrao + data + "-" + hora + ".jpg";
            Byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            Bitmap screenshot = new Bitmap(new MemoryStream(byteArray));
            screenshot.Save(string.Format(fileName, ImageFormat.Jpeg));
        }
    }
}
