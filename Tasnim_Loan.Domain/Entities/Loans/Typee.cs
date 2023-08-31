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
    public class Typee:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<LoanInType> LoanInType { get; set; }
    }
}
