using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tasnim_Loan.Domain.Entities;
using Tasnim_Loan.Domain.Entities.Loans;
using Tasnim_Loan.Domain.Entities.Users;

namespace Tasnim_Loan.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {

         DbSet<NewUser> Userss { get; set; }
         DbSet<Loan> Loans { get; set; }
         DbSet<Transaction> Transactions { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<UserInRole> UserInRoles { get; set; }
         DbSet<Typee> Types { get; set; }
         DbSet<Condition> Conditions { get; set; }
         DbSet<LoanInType> LoanInTypes { get; set; }
         DbSet<LoanInCodition> LoanInCoditions { get; set; }
 


        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
