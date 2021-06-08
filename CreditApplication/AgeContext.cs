using System.Threading;

namespace CreditApplication
{
    public class AgeContext
    {
        private IAgeStrategy _strategy;

        public AgeContext()
        { }

        public AgeContext(IAgeStrategy strategy)
        {
            _strategy = strategy;
        }
        
        public void SetStrategy(IAgeStrategy strategy)
        {
            _strategy = strategy;
        }

        public int DoCalculation(Models.CreditApplication creditApplication)
        {
            var result = _strategy.DoAlgorithm(creditApplication);
            return result;
        }
    }
}