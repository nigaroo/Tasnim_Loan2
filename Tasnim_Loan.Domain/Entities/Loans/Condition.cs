using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Domain.Entities.Commons;

namespace Tasnim_Loan.Domain.Entities.Loans
{
    public class Condition : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<LoanInCodition> LoanInCodition { get; set; }
    }
}
