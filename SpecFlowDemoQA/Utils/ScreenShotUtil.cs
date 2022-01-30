
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

        public ScreenShotUtil()
        {
            
        }

        public void TakesScreenshot(IWebDriver driver, IWebElement element)
        {
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("HH-mm-ss-fff");

            string nomePasta = @"C:\\CSharpAlura\\SpecFlowDemoQA\\SpecFlowDemoQA\\Screenshoots\\"+data+"\\";
            if (!Directory.Exists(nomePasta))
            {
                Directory.CreateDirectory(nomePasta);
            }
          
            string fileName = nomePasta + data +"-"+ hora+".jpg";
            Byte[] byteArray = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            Bitmap screenshot = new Bitmap(new MemoryStream(byteArray));
            //Rectangle croppedImage = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
            //screenshot = screenshot.Clone(croppedImage, screenshot.PixelFormat);
            screenshot.Save(string.Format(fileName, ImageFormat.Jpeg));
        }

    }
}
