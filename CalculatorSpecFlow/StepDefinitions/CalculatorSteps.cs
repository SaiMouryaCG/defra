using TechTalk.SpecFlow;
using CalculatorSpecFlow.Calculator;
using SupportContext = CalculatorSpecFlow.Support.TestContext;
using Newtonsoft.Json.Linq;
using System.IO;
using NUnit.Framework;
using System;

namespace CalculatorSpecFlow.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        private readonly SupportContext _context;

        public CalculatorSteps(SupportContext context)
        {
            _context = context;
        }

        [Given(@"I have numbers from settings")]
        public void GivenIHaveNumbersFromSettings()
        {
            var json = JObject.Parse(File.ReadAllText("settings.json"));
            _context.Number1 = (int?)json["Input1"] ?? 0;
            _context.Number2 = (int?)json["Input2"] ?? 0;
            _context.CalculatorService = new CalculatorService(new BasicCalculator());
        }

        [When(@"I add them")]
        public void WhenIAddThem()
        {
            _context.Result = _context.CalculatorService.Add(_context.Number1, _context.Number2);
        }

        [When(@"I subtract them")]
        public void WhenISubtractThem()
        {
            _context.Result = _context.CalculatorService.Subtract(_context.Number1, _context.Number2);
        }

        [When(@"I multiply them")]
        public void WhenIMultiplyThem()
        {
            _context.Result = _context.CalculatorService.Multiply(_context.Number1, _context.Number2);
            Console.WriteLine($"Multiplying {_context.Number1}*{_context.Number2}={_context.Result}");
        }

        [When(@"I divide them")]
        public void WhenIDivideThem()
        {
            _context.Result = _context.CalculatorService.Divide(_context.Number1, _context.Number2);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            Console.WriteLine($"Expected Result:{expected}");
            Console.WriteLine($"Actual Result: {_context.Result}");
            Assert.AreEqual(expected, _context.Result);
        }
    }
}