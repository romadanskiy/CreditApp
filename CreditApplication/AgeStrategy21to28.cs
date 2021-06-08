namespace CreditApplication
{
    public class AgeStrategy21to28 : IAgeStrategy
    {
        public int DoAlgorithm(Models.CreditApplication data)
        {
            return data.CreditAmount switch
            {
                < 1000000 => 12,
                >= 1000000 and < 3000000 => 9,
                _ => 0
            };
        }
    }
}