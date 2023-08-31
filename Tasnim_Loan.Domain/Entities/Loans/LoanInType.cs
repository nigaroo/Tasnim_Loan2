using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Domain.Entities.Commons;

namespace Tasnim_Loan.Domain.Entities.Loans
{
    public class LoanInType :BaseEntity

    {
       
        public virtual Loan Loan { get; set; }
        public int LoanId { get; set; }

        public virtual Typee Type { get; set; }
        public int TypeId { get; set; }
    }
}
