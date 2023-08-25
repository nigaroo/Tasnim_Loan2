using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.Customers.Queries.GetCustomers
{
    public interface IGetCustomersService // ye service omadi tarif kardi
    {
        ResultGetCustomerDto Execute(RequestGetCustomerDto request); //toie() vorodihamoone 
    }
}
