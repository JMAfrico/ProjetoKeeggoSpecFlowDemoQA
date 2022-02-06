using System.Reflection;

namespace SpecFlowDemoQA.Helpers
{
    public static class LocalDriver
    {
        private static string PastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);   

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
