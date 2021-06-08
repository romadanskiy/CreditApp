namespace CreditApplication
{
    public abstract class CalculatorDecorator : Calculator
    {
        protected Calculator _calculator;

        public CalculatorDecorator(Calculator calculator) : base()
        {
            _calculator = calculator;
        }
    }
}