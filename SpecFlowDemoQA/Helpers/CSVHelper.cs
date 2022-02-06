using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace SpecFlowDemoQA.Helpers
{
    public class CSVHelper
    {
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
