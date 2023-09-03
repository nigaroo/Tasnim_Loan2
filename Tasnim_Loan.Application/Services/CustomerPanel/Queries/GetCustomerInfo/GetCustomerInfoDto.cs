using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetCustomerInfo
{
    public class GetCustomerInfoDto
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string National_Number { get; set; }
        public int Unique_Payment_Identifier { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
