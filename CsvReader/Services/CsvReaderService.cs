using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvReader.Models;
using Microsoft.Extensions.Configuration;

namespace CsvReader.Services
{
    public class CsvReaderService : ICsvReaderService
    {
        private readonly IConfiguration _config;

        public CsvReaderService(IConfiguration config)
        {
            _config = config;
        }

        public List<Person> ReadPeople()
        {
            var path = _config["csvReaderSettings:CsvSettings:FilePath"];
            var delimiter = _config["csvReaderSettings:CsvSettings:Delimiter"];

            using var reader = new StreamReader(path);
            using var csv = new CsvHelper.CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = delimiter
            });

            return new List<Person>(csv.GetRecords<Person>());
        }
    }
}
