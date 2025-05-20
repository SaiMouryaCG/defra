namespace CalculatorSpecFlow.Support
{
    public class TestContext
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Result { get; set; }
        public CalculatorSpecFlow.Calculator.CalculatorService CalculatorService { get; set; }
    }
}