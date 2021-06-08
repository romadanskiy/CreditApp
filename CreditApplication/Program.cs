using System;
using System.Configuration;
using Models;

namespace CreditApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            GetProgramHeader();
            var creditApplication = GetInput();
            var isValid = ValidateInput(creditApplication);
            
            if (!isValid) return;

            var calculator = new Calculator();
            var total = calculator.CalculatePoints(creditApplication);
        }

        private static void GetProgramHeader()
        {
            Console.WriteLine("\n\t<--- Мгновенный кредит --->\n");
            var operatorName = ConfigurationManager.AppSettings["OperatorName"];
            Console.WriteLine($"Оператор: {operatorName}\n");
        }

        private static Models.CreditApplication GetInput()
        {
            Console.WriteLine("\tФИО клиента:");
            Console.Write("Фамилия: ");
            var surname = Console.ReadLine();
            Console.Write("Имя: ");
            var name = Console.ReadLine();
            Console.Write("Отчество: ");
            var patronymic = Console.ReadLine();

            var client = new ClientFullName(surname, name, patronymic);
            
            Console.WriteLine("\tПаспортные данные:");
            Console.Write("Серия: ");
            var series = Console.ReadLine();
            Console.Write("Номер: ");
            var number = Console.ReadLine();
            Console.Write("Кем выдан: ");
            var issuedBy = Console.ReadLine();
            Console.Write("Когда выдан: ");
            var issuedOn = Console.ReadLine();
            Console.Write("Прописка: ");
            var registration = Console.ReadLine();

            var passport = new PassportData(series, number, issuedBy, issuedOn, registration);
            
            Console.WriteLine("\tОстальная информация:");
            Console.Write("Возраст: ");
            var age = Console.ReadLine();
            Console.Write("Сумма кредита: ");
            var creditAmount = Console.ReadLine();
            Console.Write("Цель: ");
            var goal = Console.ReadLine();
            Console.Write("Трудоустройство: ");
            var job = Console.ReadLine();
            Console.Write("Залог: ");
            var deposit = Console.ReadLine();
            string carAge;
            if (deposit.ToLower() == "автомобиль")
            {
                Console.Write("Возраст автомобиля: ");
                carAge = Console.ReadLine();
            }
            else
            {
                carAge = "0";
            }

            var operatorName = ConfigurationManager.AppSettings["OperatorName"];
            
            var creditApplication = new Models.CreditApplication(operatorName, client, passport,
                Convert.ToInt32(age), Convert.ToInt32(creditAmount), goal, job, 
                deposit, Convert.ToInt32(carAge));

            return creditApplication;
        }

        private static bool ValidateInput(Models.CreditApplication credit)
        {
            if (!credit.ValidationResult.IsValid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nОшибки:");
                foreach (var error in credit.ValidationResult.GetErrorList)
                {
                    Console.WriteLine(error);
                }
                Console.ResetColor();
                return false;
            }

            Console.WriteLine("\nВведенные данные успешно прошли проверку.");
            return true;
        }
    }
}