using System;

namespace Tasnim_Loan.Application.Sevices.Loans.Queries.GetLoans
{
    public class LoansDto
    {
        public int ID { get; set; }
        public int Total_Amount { get; set; }
        public int Loan_Num { get; set; }
        public int Payment_Num { get; set; }
        public int Payment_Amount { get; set; }
        public string Guaranty { get; set; }
        public string Introducer { get; set; }
        public string Closed { get; set; }
        public string Cleared { get; set; }
        public DateTime Cleared_Date { get; set; }
        public int Customer_ID { get; set; }
        public bool IsActive { get; set; }
    }
}
