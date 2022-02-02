using OpenQA.Selenium;
using SpecFlowDemoQA.Helpers;
using System.Drawing;
using System.Drawing.Imaging;

namespace SpecFlowDemoQA.Utils
{
    public class ScreenShotUtil
    { 
        private ScenarioContext cenario;
        public ScreenShotUtil(ScenarioContext cenario)
        {
            this.cenario = cenario;
        }

        public byte[] TakesScreenshot(IWebDriver driver, IWebElement element)
        {
            if (!Directory.Exists(DataHelper.CaminhoScreenshot()))
            {
                Directory.CreateDirectory(DataHelper.CaminhoScreenshot());
            }
            string fileName = DataHelper.CaminhoScreenshot() + DataHelper.DataAtual() + "-" + DataHelper.HoraAtual() + ".jpg";
            byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            Bitmap screenshot = new Bitmap(new MemoryStream(byteArray));
            screenshot.Save(string.Format(fileName, ImageFormat.Jpeg));
            return byteArray;
        } 
    }
}
