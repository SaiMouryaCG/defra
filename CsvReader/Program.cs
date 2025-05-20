using System;
using Microsoft.Extensions.Configuration;
using CsvReader.Services;

class Program
{
    static void Main()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        ICsvReaderService csvReader = new CsvReaderService(config);
        var people = csvReader.ReadPeople();

        foreach (var person in people)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }
}
