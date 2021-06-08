namespace CreditApplication
{
    public class AgeStrategy61to72 : IAgeStrategy
    {
        public int DoAlgorithm(Models.CreditApplication data)
        {
            return string.IsNullOrEmpty(data.Deposit) ? 0 : 8;
        }
    }
}