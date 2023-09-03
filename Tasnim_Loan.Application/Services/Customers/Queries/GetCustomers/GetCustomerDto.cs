using System;

namespace Tasnim_Loan.Application.Services.Customers.Queries.GetCustomers
{
    public class GetCustomerDto
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string National_Number { get; set; }
        public DateTime InsertTime { get; set; }
        public int Unique_Payment_Identifier { get; set; }
 
        public string Description { get; set; }
        public bool IsActive { get; set; }



        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? RemoveTime { get; set; }

    }
}
