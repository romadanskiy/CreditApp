namespace CreditApplication
{
    public abstract class Calculator
    {
        public Calculator()
        {
        }
        
        public abstract int CalculatePoints(Models.CreditApplication creditApplication);
        public abstract double CalculateInterestRate(int total);
    }
}