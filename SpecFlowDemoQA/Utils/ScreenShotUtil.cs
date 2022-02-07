using OpenQA.Selenium;
using SpecFlowDemoQA.Helpers;
using System.Drawing;
using System.Drawing.Imaging;

namespace SpecFlowDemoQA.Utils
{
    /// <summary>
    /// Classe responsável por realizar os screenshoots da tela no momento da execução do teste
    /// </summary>
    public static class ScreenShotUtil
    {

        /// <summary>
        /// Método static responsável por realizar os screenshoots do elemento no momento da execução do teste
        /// </summary>
        /// <param name="driver"> Representa o drive instanciado na classe</param>
        /// <param name="element"> Representa o elemento no qual será realizado o screenshoot</param>
        /// <param name="step"> Representa um string contendo o nome do passo realizado no momento do teste</param>
        /// <returns>Retorna um array de bytes contendo todos os screenshots realizados no momento da execução do teste em formato JPEG no caminho específicado</returns>
        /// <exception cref="Exception">Exceção lançada caso não sejá possível realizar um screenshoot do elemento</exception>
        public static byte[] TakesScreenshot(this IWebDriver driver, IWebElement element, string step)
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


        /// <summary>
        /// Método static responsável por realizar os screenshoots da tela no momento da execução do teste
        /// </summary>
        /// <param name="driver">Representa o drive instanciado na classe</param>
        /// <param name="step">Representa um string contendo o nome do passo realizado no momento do teste</param>
        /// <returns>
        /// Retorna um array de bytes contendo todos os screenshots realizados no momento da execução do teste em formato JPEG no caminho específicado
        /// </returns>
        /// <exception cref="Exception">Exceção lançada caso não sejá possível realizar um screenshoot </exception>
        public static byte[] TakesScreenshot(this IWebDriver driver, string step)
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
