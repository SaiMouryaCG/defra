using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;
using FluentAssertions;
[Binding]
public class StepDefinitions
{
   private readonly IConfiguration _config;
   private int _input1;
   private int _input2;
   private int _result;
   private string _csvFilePath;
   private string _connString;
   public StepDefinitions()
   {
       _config = new ConfigurationBuilder()
           .AddJsonFile("settings.json")
           .Build();
   }
   [Given(@"I have numbers from the configuration")]
   public void GivenIHaveNumbersFromConfiguration()
   {
       var calc = _config.GetSection("CalculatorSettings").Get<CalculatorSettings>();
       _input1 = calc.Input1;
       _input2 = calc.Input2;
   }
   [When(@"I add them")]
   public void WhenIAddThem() => _result = _input1 + _input2;
   [When(@"I subtract them")]
   public void WhenISubtractThem() => _result = _input1 - _input2;
   [When(@"I multiply them")]
   public void WhenIMultiplyThem() => _result = _input1 * _input2;
   [When(@"I divide them")]
   public void WhenIDivideThem() => _result = _input2 != 0 ? _input1 / _input2 : 0;
   [Then(@"the result should be (.*)")]
   public void ThenTheResultShouldBe(int expected) => _result.Should().Be(expected);
   [Given(@"the CSV file is configured")]
   public void GivenTheCsvFileIsConfigured()
   {
       _csvFilePath = _config.GetSection("CsvReaderSettings:FilePath").Value;
   }
   [When(@"I read all records")]
   public void WhenIReadAllRecords()
   {
       // Placeholder for CSV reading logic
   }
   [Then(@"I should see (.*) records")]
   public void ThenIShouldSeeRecords(int expectedCount)
   {
       // Assert CSV line count equals expectedCount
   }
   [Given(@"I have a SQL connection string from configuration")]
   public void GivenIHaveAConnectionStringFromConfiguration()
   {
       _connString = _config.GetSection("SqlSettings:ConnectionString").Value;
   }
   [When(@"I retrieve names from the database")]
   public void WhenIRetrieveNamesFromDatabase()
   {
       // Placeholder: Use _connString to query DB and fetch data
   }
   [Then(@"the result should not be empty")]
   public void ThenTheResultShouldNotBeEmpty()
   {
       // Assert DB result is not empty
   }
}
public class CalculatorSettings
{
   public int Input1 { get; set; }
   public int Input2 { get; set; }
}