using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetLoans;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetCustomersLoan
{
    public interface IGetCustomersLoan
    {
        List<CustomersLoanGetDto> Execute(int UserId);
    }
}
