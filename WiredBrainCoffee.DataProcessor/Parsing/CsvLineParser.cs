using System.Globalization;
using WiredBrainCoffee.DataProcessor.Model;

namespace WiredBrainCoffee.DataProcessor.Parsing
{
    public class CsvLineParser
    {
        public static MachineDataItem[] Parse(string[] csvlines)
        {
            var machineDataItems = new List<MachineDataItem>();
            csvlines.ToList()
                .ForEach(line =>
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        machineDataItems.Add(Parse(line));
                }
               );
            return machineDataItems.ToArray();
        }

        private static MachineDataItem Parse(string csvLine)
        {
            var lineItems = csvLine.Split(';');

            return new MachineDataItem(lineItems[0], DateTime.Parse(lineItems[1], CultureInfo.InvariantCulture));
        }
    }
}
