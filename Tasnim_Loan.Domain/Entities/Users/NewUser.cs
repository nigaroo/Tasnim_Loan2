using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Domain.Entities.Commons;

namespace Tasnim_Loan.Domain.Entities.Users
{
    public class NewUser:BaseEntity
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string National_Number { get; set; }
        public int Unique_Payment_Identifier { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }




        public ICollection<UserInRole> UserInRoles { get; set; }
        public ICollection<Loan> Loan { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }
}
