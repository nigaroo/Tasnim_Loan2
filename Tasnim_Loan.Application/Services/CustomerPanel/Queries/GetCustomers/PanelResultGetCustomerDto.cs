using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetCustomers
{
    public class PanelResultGetCustomerDto
    {
        public List<PanelGetCustomerDto> Users { get; set; }
        public int Rows { get; set; }
    }
}
