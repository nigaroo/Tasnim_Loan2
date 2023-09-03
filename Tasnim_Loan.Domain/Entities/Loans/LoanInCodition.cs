using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Domain.Entities.Commons;

namespace Tasnim_Loan.Domain.Entities.Loans
{
    public class LoanInCodition  :BaseEntity
    {
        public virtual Loan Loan { get; set; }
        public int LoanId { get; set; }

        public virtual Condition Condition { get; set; }
        public int ConditionId { get; set; }
    }
}
