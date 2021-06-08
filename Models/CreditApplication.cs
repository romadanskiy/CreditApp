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
        public decimal CreditAmount { get; set; }
        public string Goal { get; set; }
        public string Job { get; set; } // ?
        public string Deposit { get; set; }
        // другие кредиты ?
        
        public Result ValidationResult { get; set; }

        public CreditApplication(string operatorName, ClientFullName clientFullName, PassportData passportData, int age,
            decimal creditAmount, string goal, string job)
        {
            OperatorName = operatorName;
            ClientFullName = clientFullName;
            PassportData = passportData;
            Age = age;
            // HasCriminalRecord откуда-то достаем
            CreditAmount = creditAmount;
            Goal = goal;
            Job = job;
            
            var validator = new CreditApplicationValidator();
            ValidationResult = validator.Validate(this);
        }
    }
}