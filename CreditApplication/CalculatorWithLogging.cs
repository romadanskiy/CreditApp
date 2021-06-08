namespace CreditApplication
{
    public class CalculatorWithLogging : CalculatorDecorator
    {
        public CalculatorWithLogging(Calculator calculator) : base(calculator)
        {
        }

        public override int CalculatePoints(Models.CreditApplication creditApplication)
        {
            var total = _calculator.CalculatePoints(creditApplication);
            // логируем
            return total;
        }

        public override double CalculateInterestRate(int total)
        {
            return _calculator.CalculateInterestRate(total);
        }
    }
}