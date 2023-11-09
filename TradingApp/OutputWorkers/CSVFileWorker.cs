using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace TradingApp.OutputWorkers
{
    public class CSVFileWorker<T> : OutputWorker<T>
    {
        public override IEnumerable<T> Reader(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<T>();
                return records.ToList();
            }
        }

        public override void Writer(IEnumerable<T> data, string path)
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data);
            }
        }

        public override void Append(IEnumerable<T> data, string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            using (var stream = File.Open(path, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(data);
            }
        }
    }
}
