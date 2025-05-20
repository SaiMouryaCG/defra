using System.Collections.Generic;
using TechTalk.SpecFlow;
using CsvReader.Models;
using CsvReader.Services;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace CsvReader.Steps
{
    [Binding]
    public class CsvReaderSteps
    {
        private List<Person> _people;
        private ICsvReaderService _csvReader;

        [Given(@"the CSV file is loaded")]
        public void GivenTheCSVFileIsLoaded()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _csvReader = new CsvReaderService(config);
        }

        [When(@"I read all records")]
        public void WhenIReadAllRecords()
        {
            _people = _csvReader.ReadPeople();
        }

        [Then(@"I should see (.*) records")]
        public void ThenIShouldSeeRecords(int count)
        {
            Assert.AreEqual(count, _people.Count);
        }
    }
}
