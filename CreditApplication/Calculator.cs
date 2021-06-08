using System;

namespace CreditApplication
{
    public class Calculator
    {
        public int CalculatePoints(Models.CreditApplication creditApplication)
        {
            var total = 0;
            
            // Возраст
            var ageContext = new AgeContext();
            switch (creditApplication.Age)
            {
                case >= 28 and <= 28:
                    ageContext.SetStrategy(new AgeStrategy21to28());
                    break;
                case >= 29 and <= 60:
                    ageContext.SetStrategy(new AgeStrategy29to60());
                    break;
                case >= 61 and <= 72:
                    ageContext.SetStrategy(new AgeStrategy61to72());
                    break;
                default:
                    ageContext.SetStrategy(new AgeStrategyAnother());
                    break;
            }
            total += ageContext.DoCalculation(creditApplication);
            
            // Сведения о судимости
            if (!creditApplication.HasCriminalRecord)
                total += 15;
            
            // Трудоустройство
            switch (creditApplication.Job.ToLower())
            {
                case "трудоустроен по трудовому договору":
                    total += 14;
                    break;
                case "собственное ип":
                    total += 12;
                    break;
                case "фрилансер":
                    total += 8;
                    break;
                case "пенсионер":
                {
                    if (creditApplication.Age < 70)
                        total += 5;
                    break;
                }
            }
            
            // Цель
            var goal = creditApplication.Goal.ToLower();
            if (goal == "потребительский кредит")
                total += 14;
            else if (goal == "недвижимость")
                total += 8;
            else if (goal == "перекредитование")
                total += 12;
            
            // Недвижимость
            var deposit = creditApplication.Deposit.ToLower();
            if (!string.IsNullOrEmpty(deposit))
            {
                if (deposit == "недвижимость")
                    total += 14;
                else if (deposit == "автомобиль")
                {
                    total += creditApplication.CarAge switch
                    {
                        < 3 => 8,
                        >= 3 => 3
                    };
                }
                else if (deposit == "поручительство")
                    total += 12;
            }
            
            // Наличие других кредитов
            if (creditApplication.HasAnotherCredits)
            {
                if (creditApplication.Goal.ToLower() != "перекредитование")
                    total += 15;
            }
            
            // Сумма
            var creditAmount = creditApplication.CreditAmount;
            switch (creditAmount)
            {
                case > 0 and < 1000000:
                    total += 12;
                    break;
                case >= 1000001 and <= 5000000:
                    total += 14;
                    break;
                case >= 5000001 and <= 10000000:
                    total += 8;
                    break;
            }

            return total;
        }

        public double CalculateInterestRate(int total)
        {
            var rate = total switch
            {
                < 84 => 30,
                < 88 => 26,
                < 92 => 22,
                < 96 => 19,
                < 100 => 15,
                100 => 12.5,
                _ => 0.0
            };

            return rate;
        }
    }
}