using NUnit.Framework;
using SqlRetrieve.Core.Interfaces;
using SqlRetrieve.Core.Services;
using SqlRetrieve.Tests.Utils;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SqlRetrieve.Tests.Steps
{
    [Binding]
    public class SqlRetrievalSteps
    {
        private IDataService? _dataService;
        private List<string>? _results;

        [Given(@"I have a SQL connection string")]
        public void GivenIHaveASQLConnectionString()
        {
            string connStr = ConfigLoader.GetConnectionString();
            _dataService = new SqlDataService(connStr);
        }

        [When(@"I retrieve names from the database")]
        public void WhenIRetrieveNamesFromTheDatabase()
        {
            _results = _dataService!.GetNames();
            Console.WriteLine("Retrieved records:");
            foreach (var record in _results)
            {
                Console.WriteLine(record);
            }
        }

        [Then(@"the result should not be empty")]
        public void ThenTheResultShouldNotBeEmpty()
        {
            Assert.That(_results, Is.Not.Null);
            Assert.That(_results, Is.Not.Empty);
        }
    }
}
