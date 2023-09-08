
using Tasnim_Loan.Domain.Entities.Commons;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tasnim_Loan.Domain.Entities.Users;
using Tasnim_Loan.Domain.Entities.Loans;

namespace Tasnim_Loan.Domain.Entities
{
    public class Transaction : BaseEntity
    {

        public int User_ID { get; set; }

        [ForeignKey("User_ID")]
        public virtual NewUser User { get; set; }

        public virtual Loan Total_Amount { get; set; }
     //   public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }

       

    }
}
