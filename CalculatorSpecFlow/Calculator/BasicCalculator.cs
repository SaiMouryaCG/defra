using System;

namespace CalculatorSpecFlow.Calculator
{
    public class BasicCalculator : ICalculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b) => b != 0 ? a / b : throw new DivideByZeroException();
    }
}