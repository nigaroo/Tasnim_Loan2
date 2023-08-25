using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Application.Interfaces.FacadPatterns;
using Tasnim_Loan.Application.Sevices.Loans.Commands.AddNewLoan;
using Tasnim_Loan.Application.Sevices.Loans.Queries.GetLoans;

namespace Tasnim_Loan.Application.Sevices.Loans.FacadPatterns
{
    public class LoanFacad : ILoanFacad
    {
        private readonly IDataBaseContext _context;
        public AddNewLoanService AddNewLoanService { get; }

        public LoanFacad(AddNewLoanService addNewLoanService)
        {
            AddNewLoanService = addNewLoanService;
        }

        private IGetLoansService _getLoansService;
        public IGetLoansService GetLoansService
        {
            get
            {
                return _getLoansService = _getLoansService ?? new GetLoansService(_context);
            }
        }
    }
}
