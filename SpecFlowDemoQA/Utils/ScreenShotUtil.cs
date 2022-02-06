using OpenQA.Selenium;
using SpecFlowDemoQA.Helpers;
using System.Drawing;
using System.Drawing.Imaging;

namespace SpecFlowDemoQA.Utils
{
    
    public static class ScreenShotUtil
    {
        //takescreenshot do elemento
        public static byte[] TakesScreenshot(IWebDriver driver, IWebElement element, string step)
        {
            try
            {
                if (!Directory.Exists(DataHelper.GetCaminhoScreenshot()))
                {
                    Directory.CreateDirectory(DataHelper.GetCaminhoScreenshot());
                }

                string fileName = DataHelper.GetCaminhoScreenshot() + DataHelper.GetDataAtual() + "-" + DataHelper.GetHoraAtual() + "_" + step + ".jpg";
                byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
                Bitmap screenshot = new Bitmap(new MemoryStream(byteArray));
                Rectangle croppedImage = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
                screenshot = screenshot.Clone(croppedImage, screenshot.PixelFormat);
                screenshot.Save(string.Format(fileName, ImageFormat.Jpeg));
                return byteArray;

            }catch (Exception ex)
            {
                throw new Exception($"Erro ao tirar foto da tela. {ex.Message}");
            }
        }

        //takescreenshot da tela
        public static byte[] TakesScreenshot(IWebDriver driver, string step)
        {
            try
            {
                if (!Directory.Exists(DataHelper.GetCaminhoScreenshot()))
                {
                    Directory.CreateDirectory(DataHelper.GetCaminhoScreenshot());
                }

                string fileName = DataHelper.GetCaminhoScreenshot() + DataHelper.GetDataAtual() + "-" + DataHelper.GetHoraAtual() + "_" + step + ".jpg";
                byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
                Bitmap screenshot = new Bitmap(new MemoryStream(byteArray));
                screenshot.Save(string.Format(fileName, ImageFormat.Jpeg));
                return byteArray;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tirar foto da tela. {ex.Message}");
            }
        }
    }
}
