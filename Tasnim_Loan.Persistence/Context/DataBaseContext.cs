using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Condition;
using Tasnim_Loan.Common.Roles;
using Tasnim_Loan.Common.Type;
using Tasnim_Loan.Domain.Entities;
using Tasnim_Loan.Domain.Entities.Loans;
using Tasnim_Loan.Domain.Entities.Users;

namespace Tasnim_Loan.Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {

        //constructor
       public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
     
        //table haro bayad be entityframework beshnasonim
        public DbSet<Loan> Loans { get; set; }        //harchi bad az <> benevisi db oon ro ba hamoon name sh
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<NewUser> Userss { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Typee> Types { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<LoanInType> LoanInTypes { get; set; }
        public DbSet<LoanInCodition> LoanInCoditions { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //Seed Data
            SeedData(modelBuilder);


          



          
            //-- عدم نمایش اطلاعات حذف شده
            ApplyQueryFilter(modelBuilder);
        }

        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewUser>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Loan>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Typee>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<LoanInType>().HasQueryFilter(p => !p.IsRemoved);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { ID = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 3, Name = nameof(UserRoles.Customer) });


            modelBuilder.Entity<Typee>().HasData(new Typee { ID = 1, Name = nameof(LoanTypes.treatment) });
            modelBuilder.Entity<Typee>().HasData(new Typee { ID = 2, Name = nameof(LoanTypes.Housing) });
            modelBuilder.Entity<Typee>().HasData(new Typee { ID = 3, Name = nameof(LoanTypes.Others) });


            modelBuilder.Entity<Condition>().HasData(new Condition { ID = 1, Name = nameof(LoanCondition.Accept) });
            modelBuilder.Entity<Condition>().HasData(new Condition { ID = 2, Name = nameof(LoanCondition.Reject) });
            modelBuilder.Entity<Condition>().HasData(new Condition { ID = 3, Name = nameof(LoanCondition.Preview) });



        }
     

    }
}

