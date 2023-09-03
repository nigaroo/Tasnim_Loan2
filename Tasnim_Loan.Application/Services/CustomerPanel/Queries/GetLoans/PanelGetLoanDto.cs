using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetLoans
{
    public class PanelGetLoanDto
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Total_Amount { get; set; }
        public int Loan_Num { get; set; }
        public int Payment_Num { get; set; }
        public int Payment_Amount { get; set; }
        public string Guaranty { get; set; }
        public string Introducer { get; set; }
        public string Cleared { get; set; } 
        public DateTime? DateCleared { get; set; }
        public bool Accept { get; set; }
        public int User_ID { get; set; }
        public DateTime InsertTime { get; set; }


    }
}
