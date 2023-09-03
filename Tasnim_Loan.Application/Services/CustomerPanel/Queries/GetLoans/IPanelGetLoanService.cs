using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetLoans
{
    public interface IPanelGetLoanService
    {
        PanelResultGetLoanDto Execute(PanelRequestGetLoanDto request);
    }
}
