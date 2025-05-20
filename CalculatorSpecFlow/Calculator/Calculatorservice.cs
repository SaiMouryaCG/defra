namespace CalculatorSpecFlow.Calculator
{
    public class CalculatorService
    {
        private readonly ICalculator _calculator;

        public CalculatorService(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public int Add(int a, int b) => _calculator.Add(a, b);
        public int Subtract(int a, int b) => _calculator.Subtract(a, b);
        public int Multiply(int a, int b) => _calculator.Multiply(a, b);
        public int Divide(int a, int b) => _calculator.Divide(a, b);
    }
}