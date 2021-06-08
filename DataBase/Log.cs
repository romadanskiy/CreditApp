using System;

namespace DataBase
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Operator { get; set; }
        public bool CreditIsApproved { get; set; }
        public int CreditAmount { get; set; }
        public double InterestRate { get; set; }
    }
}