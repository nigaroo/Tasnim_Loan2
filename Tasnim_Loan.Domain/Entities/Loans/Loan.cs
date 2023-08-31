
using Tasnim_Loan.Domain.Entities.Commons;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tasnim_Loan.Domain.Entities.Users;
using System.Collections.Generic;

namespace Tasnim_Loan.Domain.Entities.Loans
{
    public class Loan : BaseEntity
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public int Total_Amount { get; set; }

        [Required]
        public int Loan_Num { get; set; }

        [Required]
        public int Payment_Num { get; set; }

        [Required]
        public int Payment_Amount { get; set; }

        public string Guaranty { get; set; }
        public string Introducer { get; set; }

        [Required]
        public string Cleared { get; set; } 
        public DateTime? DateCleared { get; set; }
        public bool Accept { get; set; }

        public ICollection<LoanInType> LoanInType  { get; set; }



        public int User_ID { get; set; }

        [ForeignKey("User_ID")]
        public NewUser User { get; set; }  // Navigation property for the user associated with this loan


    }
}
