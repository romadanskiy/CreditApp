using System;
using System.Configuration;

namespace CreditApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            GetProgramHeader();
            
        }

        private static void GetProgramHeader()
        {
            Console.WriteLine("\n\t<--- Мгновенный кредит --->\n");
            var operatorName = ConfigurationManager.AppSettings["OperatorName"];
            Console.WriteLine($"Оператор: {operatorName}\n");
        }
    }
}