using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.Customers.Queries.GetCustomers
{
    public interface IGetCustomersService 
    {
        ResultGetCustomerDto Execute(RequestGetCustomerDto request); 
    }
}
