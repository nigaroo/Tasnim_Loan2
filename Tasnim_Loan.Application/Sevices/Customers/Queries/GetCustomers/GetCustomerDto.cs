using System;

namespace Tasnim_Loan.Application.Sevices.Customers.Queries.GetCustomers
{
    public class GetCustomerDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string National_Number { get; set; }
        public DateTime InsertTime { get; set; }
        public int Unique_Payment_Identifier { get; set; }
 
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
