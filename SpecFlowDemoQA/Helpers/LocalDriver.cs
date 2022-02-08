using System.Reflection;

namespace SpecFlowDemoQA.Helpers
{
    /// <summary>
    /// Classe representa o localização do driver
    /// </summary>
    public static class LocalDriver
    {
        private static string PastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);   


        /// <summary>
        /// Método static que retorna a localização do Driver
        /// </summary>
        /// <returns>Retorna um string representando o caminho do drive</returns>
        /// <exception cref="ArgumentException">Exceção lançada caso o drive não sejá encontrado</exception>
        public static string GetPastaDoExecutavel()
        {
            try
            {
               return PastaDoExecutavel;              
            }catch (ArgumentException ex)
            {
                throw new ArgumentException("Drive Chrome Drive não encontrado. "+ex.Message);
            }
        }
    }
}
