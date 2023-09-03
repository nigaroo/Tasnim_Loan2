using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetLoans
{
    public class PanelResultGetLoanDto
    {
        public PanelGetLoanDto Loans { get; set; }
        public int Rows { get; set; }
    }
}
