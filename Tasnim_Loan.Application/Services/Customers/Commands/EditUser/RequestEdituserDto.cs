using System;

namespace Tasnim_Loan.Application.Services.Customers.Commands.EditUser
{
    public class RequestEdituserDto
    {
        public int ID { get; set; }
        public string FullName { get; set; }
      //  public string Password { get; set; }
        public string National_Number { get; set; }
        public int Unique_Payment_Identifier { get; set; }
        public string Description { get; set; }
        public DateTime InsertionTime { get; set; }
    }


}
