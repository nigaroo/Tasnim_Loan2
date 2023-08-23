using Tasnim_Loan.Domain.Entities.Commons;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Domain.Entities
{
    public class User 

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Pass { get; set; }
        public ICollection<Loan> Loan { get; set; } //one to many for user and loan relationship
        public ICollection<Transaction> Transaction { get; set; }
    }
}
