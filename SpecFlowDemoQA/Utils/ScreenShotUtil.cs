using OpenQA.Selenium;
using SpecFlowDemoQA.Helpers;
using System.Drawing;
using System.Drawing.Imaging;

namespace SpecFlowDemoQA.Utils
{
    public class ScreenShotUtil
    {
        public static byte[] TakesScreenshot(IWebDriver driver, IWebElement element, string step)
        {
            if (!Directory.Exists(DataHelper.GetCaminhoScreenshot()))
            {
                Directory.CreateDirectory(DataHelper.GetCaminhoScreenshot());
            }

            string fileName = DataHelper.GetCaminhoScreenshot() + DataHelper.GetDataAtual() + "-" + DataHelper.GetHoraAtual() +"_"+step.ToUpper()+".jpg";
            byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            Bitmap screenshot = new Bitmap(new MemoryStream(byteArray));
            screenshot.Save(string.Format(fileName, ImageFormat.Jpeg));
            return byteArray;
        }

        public static byte[] TakesScreenshot(IWebDriver driver, string step)
        {
            if (!Directory.Exists(DataHelper.GetCaminhoScreenshot()))
            {
                Directory.CreateDirectory(DataHelper.GetCaminhoScreenshot());
            }

            string fileName = DataHelper.GetCaminhoScreenshot() + DataHelper.GetDataAtual() + "-" + DataHelper.GetHoraAtual() + "_" + step.ToUpper() + ".jpg";
            byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            Bitmap screenshot = new Bitmap(new MemoryStream(byteArray));
            screenshot.Save(string.Format(fileName, ImageFormat.Jpeg));
            return byteArray;
        }
    }
}
