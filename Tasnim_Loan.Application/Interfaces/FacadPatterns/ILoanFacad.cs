using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Sevices.Loans.Commands.AddNewLoan;
using Tasnim_Loan.Application.Sevices.Loans.Queries.GetLoans;

namespace Tasnim_Loan.Application.Interfaces.FacadPatterns
{
    public interface ILoanFacad
    {
        AddNewLoanService AddNewLoanService { get; }
        IGetLoansService GetLoansService { get; }
    }
}
