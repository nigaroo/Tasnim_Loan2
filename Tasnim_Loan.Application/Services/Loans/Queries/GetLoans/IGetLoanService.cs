using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.Loans.Queries.GetLoans
{
    public interface IGetLoanService
    {
        ResultGetLoanDto Execute(RequestGetLoanDto request);
    }
}
