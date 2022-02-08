using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace SpecFlowDemoQA.Helpers
{
    /// <summary>
    /// Classe para leitura e escrita de dados de arquivos com extensão .CSV
    /// </summary>
    public class CSVHelper
    {
        /// <summary>
        /// Método responsável pela leitura do arquivo .CSV
        /// </summary>
        /// <param name="path"> Representa o caminho onde o arquivo .CSV está localizado</param>
        /// <param name="row"> Representa o número da linha onde o dado será lido</param>
        /// <param name="column"> Representa o nome da coluna onde o dado será lido</param>
        /// <returns></returns>
        /// <exception cref="Exception"> Exceção lançada quando a linha ou coluna passada no parâmetro não foi localizada</exception>
        public string GetValueByRowAndColumn(string path, int row, string column)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                IgnoreBlankLines = false,
                HasHeaderRecord = true,
                DetectDelimiter = true    
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();

                int current_row = 1;

                while (csv.Read())
                {
                    if (current_row == row)
                    {
                        return csv.GetField(column);
                       
                    }

                    current_row++;
                    
                }
                
                throw new Exception($"Row {row} wasn't found in file {path}");
            }
            
        }
    }
}
