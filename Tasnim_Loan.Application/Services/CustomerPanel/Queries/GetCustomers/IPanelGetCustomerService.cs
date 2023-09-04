using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetCustomers
{
    public interface IPanelGetCustomerService
    {
        PanelResultGetCustomerDto Execute(PanelRequestGetCustomerDto request, int customerId);
    }
}
