using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tasnim_Loan.Domain.Entities;

namespace Tasnim_Loan.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
         DbSet<Loan> Loans { get; set; }
         DbSet<Customer> Customers { get; set; }
         DbSet<Transaction> Transactions { get; set; }
         DbSet<User> Users { get; set; }





        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
