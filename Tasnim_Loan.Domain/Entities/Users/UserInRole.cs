using Tasnim_Loan.Domain.Entities.Commons;

namespace Tasnim_Loan.Domain.Entities.Users
{
    public class UserInRole : BaseEntity
    {
        public long Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
