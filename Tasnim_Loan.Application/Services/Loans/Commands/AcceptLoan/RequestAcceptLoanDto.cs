using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.Loans.Commands.AcceptLoan
{
    public class RequestAcceptLoanDto
    {
        public int ID { get; set; }
        public bool Cleared { get; set; }
        public DateTime DateCleared { get; set; }

    }
}
