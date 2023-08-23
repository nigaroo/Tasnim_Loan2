using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tasnim_Loan.Domain.Entities.Commons;

namespace Tasnim_Loan.Domain.Entities
{
    public class Customer : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Family { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string National_Number { get; set; }


        [Required]
        public int Unique_Payment_Identifier { get; set; }


        public string Description { get; set; }



        public ICollection<Loan> Loan { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }
}
