using System.Collections.Generic;
using CsvReader.Models;

namespace CsvReader.Services
{
    public interface ICsvReaderService
    {
        List<Person> ReadPeople();
    }
}
