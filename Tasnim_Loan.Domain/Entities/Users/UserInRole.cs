using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tasnim_Loan.Domain.Entities.Commons;

namespace Tasnim_Loan.Domain.Entities.Users
{
    public class UserInRole :BaseEntity

    {
        //  public int Idrole { get; set; }
        public virtual NewUser User { get; set; }
        public int UserId { get; set; }

        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
