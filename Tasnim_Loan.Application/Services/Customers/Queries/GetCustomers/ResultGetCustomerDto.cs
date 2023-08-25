using System.Collections.Generic;

namespace Tasnim_Loan.Application.Services.Customers.Queries.GetCustomers
{
    public class ResultGetCustomerDto
    {
        public List<GetCustomerDto> Users { get; set; }
        public int Rows { get; set; }
    }
}
