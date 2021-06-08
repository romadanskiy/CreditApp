namespace Models
{
    public class CreditApplication
    {
        public int Id { get; set; }
        public string OperatorName { get; set; }
        public ClientFullName ClientFullName { get; set; }
        public PassportData PassportData { get; set; }
        public int Age { get; set; }
        public bool HasCriminalRecord { get; set; }
        public int CreditAmount { get; set; }
        public string Goal { get; set; }
        public string Job { get; set; }
        public string Deposit { get; set; }
        public int CarAge { get; set; }
        
        
        public bool HasAnotherCredits { get; set; }
        
        public Result ValidationResult { get; set; }

        public CreditApplication(string operatorName, ClientFullName clientFullName, PassportData passportData, int age,
            int creditAmount, string goal, string job, string deposit, int carAge)
        {
            OperatorName = operatorName;
            ClientFullName = clientFullName;
            PassportData = passportData;
            Age = age;
            // HasCriminalRecord достаем из бд (из мока)
            CreditAmount = creditAmount;
            Goal = goal;
            Job = job;
            Deposit = deposit;
            CarAge = carAge;
            // HasAnotherCredits проверяем в бд
            
            var validator = new CreditApplicationValidator();
            ValidationResult = validator.Validate(this);
        }
    }
}