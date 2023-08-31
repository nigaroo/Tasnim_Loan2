using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.Loans.Queries.GetLoans
{
    public class ResultGetLoanDto
    {
        public List<GetLoanDto> Loans { get; set; }
        public int Rows { get; set; }
    }
}
