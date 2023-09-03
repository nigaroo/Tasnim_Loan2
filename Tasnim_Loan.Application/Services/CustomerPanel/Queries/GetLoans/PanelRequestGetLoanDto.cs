using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetLoans
{
    public class PanelRequestGetLoanDto
    {
        public string SearchKey { get; set; }
        public int SearchInt { get; set; }
        public int Page { get; set; }
    }
}
