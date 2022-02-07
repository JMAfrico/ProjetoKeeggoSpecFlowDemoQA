namespace SpecFlowDemoQA.Helpers
{
    public class DataHelper
    {
        public static string GetDataAtual()
        {
            try
            {
                string data = DateTime.Now.ToString("dd-MM-yyyy");
                return data;

            }catch(ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException(e.Message);
            }
        }

        public static string GetHoraAtual()
        {
            try
            {
                string hora = DateTime.Now.ToString("HH-mm-ss-fff");
                return hora;
            }
            catch(ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException(e.Message);

            }
        }

        public static string GetCaminhoScreenshot()
        {
            try
            {
                string caminhoScreenshot = @"cd..\\..\\..\\..\\..\\Screenshoots\\" + GetDataAtual() + "\\";
                return caminhoScreenshot;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Caminho da pasta Screenshots não encontrado. "+e.Message);
            }

        }

        public static string GetCaminhoEvidencias()
        {
            try
            {
                string caminhoEvidencias = @"cd..\\..\\..\\..\\..\\Evidences\\" + GetDataAtual() + "\\";
                return caminhoEvidencias;
            }catch (ArgumentException e)
            {
                throw new ArgumentException("Caminho da pasta Evidencias não encontrado. " + e.Message);
            }

        }

        public static string GetCaminhoStatusPassed()
        {
            try
            {
                string caminhoStatusPassed = GetCaminhoEvidencias() + "Passed\\";
                return caminhoStatusPassed;

            }catch(ArgumentException e)
            {
                throw new ArgumentException("Caminho da pasta Status Passed não encontrado. " + e.Message);
            }
        }

        public static string GetCaminhoStatusFailed()
        {
            try
            {
                string caminhoStatusFailed = GetCaminhoEvidencias() + "Failed\\";
                return caminhoStatusFailed;

            }catch( ArgumentException e)
            {
                throw new ArgumentException("Caminho da pasta Status Failed não encontrado. " + e.Message);
            }
        }

        public static string GetFileCSVLogin()
        {
            try
            {
                string caminhoCSVLogin = @"cd..\\..\\..\\..\\..\\Dados\\login.csv";
                return caminhoCSVLogin;
            }catch( Exception e)
            {
                throw new Exception("Dados de login não encontrado. "+e.Message);
            }
        }

        public static string GetFileCSVCadastro()
        {
            try
            {
                string caminhoCSVCadastro = @"cd..\\..\\..\\..\\..\\Dados\\novoUsuario.csv";
                return caminhoCSVCadastro;

            }catch ( Exception e)
            {
                throw new Exception("Dados de novo Usuario não encontrado. " + e.Message);
            }
        }
    }
}
