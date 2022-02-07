namespace SpecFlowDemoQA.Helpers
{
    /// <summary>
    /// Classe de auxilio responsável por localizar e criar o caminho das pastas de evidência do projeto 
    /// </summary>
    public class DataHelper
    {
        /// <summary> Método para retornar a data atual </summary>
        /// <returns>Retorna a data atual em formato string: dia(dd), mês(MM) e ano(yyyy)</returns>
        public static string GetDataAtual()
        {
            string data = DateTime.Now.ToString("dd-MM-yyyy");
            return data;
        }

        /// <summary> Método para retornar a hora atual</summary>
        /// <returns>Retorna a data atual em formato string: Hora(HH), minuto(mm), segundo(ss), milésimo(fff)</returns>
        public static string GetHoraAtual()
        {
             string hora = DateTime.Now.ToString("HH-mm-ss-fff");
             return hora;
        }

        /// <summary>Método representa o caminho para armazenar os Screenshoots do browser </summary>
        /// <returns>Retorna o caminho onde será armazenado os os Screenshoots do browser </returns>
        /// <exception cref="ArgumentException">Exceção lançada caso o caminho não sejá encontrado</exception>
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

        /// <summary>Método representa o caminho raíz para armazenar as evidências dos cenários</summary>
        /// <returns>Retorna um string do caminho da pasta raíz de evidências dos cenários</returns>
        /// <exception cref="ArgumentException">Exceção lançada caso o caminho não sejá encontrado</exception>
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

        /// <summary> Método representa o caminho raíz para armazenar as evidências dos cenários com Status de Sucesso</summary>
        /// <returns>Retorna um string do caminho da pasta raíz de evidências dos cenários de Sucesso </returns>
        /// <exception cref="ArgumentException">Exceção lançada caso o caminho não sejá encontrado</exception>
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

        /// <summary>Método representa o caminho raíz para armazenar as evidências dos cenários com Status de Falha </summary>
        /// <returns>Retorna um string do caminho da pasta raíz de evidências dos cenários de Falha</returns>
        /// <exception cref="ArgumentException">Exceção lançada caso o caminho não sejá encontrado</exception>
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

        /// <summary>Método representa o caminho do arquivo de dados de login .CSV </summary>
        /// <returns>Retorna um string representado o caminho do arquivo .CSV</returns>
        /// <exception cref="Exception">Exceção lançada caso o arquivo não sejá encontrado</exception>
        public static string GetFileCSVLogin()
        {
            try
            {
                string caminhoCSVLogin = @"cd..\\..\\..\\..\\..\\Dados\\login.csv";
                return caminhoCSVLogin;
            }catch( Exception e)
            {
                throw new Exception("Arquivo não encontrado. "+e.Message);
            }
        }

        /// <summary>Método representa o caminho do arquivo de dados de cadastro .CSV</summary>
        /// <returns>Retorna um string representado o caminho do arquivo .CSV</returns>
        /// <exception cref="Exception">Exceção lançada caso o arquivo não sejá encontrado</exception>
        public static string GetFileCSVCadastro()
        {
            try
            {
                string caminhoCSVCadastro = @"cd..\\..\\..\\..\\..\\Dados\\novoUsuario.csv";
                return caminhoCSVCadastro;

            }catch ( Exception e)
            {
                throw new Exception("Arquivo não encontrado. " + e.Message);
            }
        }
    }
}
