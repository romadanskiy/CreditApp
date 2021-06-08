using System;
using DataBase;

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
            var context = new ApplicationContext();
            var creditIsApproved = total > 80;
            var interestRate = creditIsApproved ? CalculateInterestRate(total) : 0.0;
            var log = new Log
            {
                DateTime = DateTime.Now,
                Surname = creditApplication.ClientFullName.Surname,
                Name = creditApplication.ClientFullName.Name,
                Operator = creditApplication.OperatorName,
                CreditIsApproved = creditIsApproved,
                CreditAmount = creditApplication.CreditAmount,
                InterestRate = interestRate
            };
            context.Logs.Add(log);
            context.SaveChanges();

            return total;
        }

        public override double CalculateInterestRate(int total)
        {
            return _calculator.CalculateInterestRate(total);
        }
    }
}