using System.Collections.Generic;

namespace Tasnim_Loan.Application.Sevices.Customers.Queries.GetCustomers
{
    public class ResultGetCustomerDto
    {
        public List<GetCustomerDto> Customers { get; set; }
        public int Rows { get; set; }
    }
}
