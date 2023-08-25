
using Tasnim_Loan.Domain.Entities.Commons;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tasnim_Loan.Domain.Entities.Users;

namespace Tasnim_Loan.Domain.Entities
{
    public class Transaction : BaseEntity
    {

        [Required]
        public string Debtor { get; set; }
        [Required]
        public string Creditor { get; set; }
        [Required]
        public int Trans_Num { get; set; }

        [Required]
        public int User_ID { get; set; }
        [ForeignKey("User_ID")]
        public User User { get; set; }

    }
}
