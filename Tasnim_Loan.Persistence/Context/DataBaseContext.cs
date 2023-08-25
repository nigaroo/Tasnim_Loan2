using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Domain.Entities;


namespace Tasnim_Loan.Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        //constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        //table haro bayad be entityframework beshnasonim
        public DbSet<Loan> Loans { get; set; }//harchi bad az <> benevisi db oon ro ba hamoon name sh
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //-- عدم نمایش اطلاعات حذف شده
            ApplyQueryFilter(modelBuilder);
        }
        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasQueryFilter(p => !p.IsRemoved);
            /*   modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
               modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
               modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
           */
        }


    }
}

