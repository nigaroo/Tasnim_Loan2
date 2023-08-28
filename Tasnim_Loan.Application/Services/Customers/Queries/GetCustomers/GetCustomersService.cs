using System;
using System.Collections.Generic;
using System.Linq;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common;

namespace Tasnim_Loan.Application.Services.Customers.Queries.GetCustomers
{
    //hala service ro bayad piade konim 
    public class GetCustomersService : IGetCustomersService
    {
        private readonly IDataBaseContext _context;
        public GetCustomersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetCustomerDto Execute(RequestGetCustomerDto request)
        {
            var users = _context.Userss.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey));

            }
            // this is about pageingation in  Commom
            int rowscount = 0;
            var usersList = users.ToPaged(request.Page, 20, out rowscount).Select(p => new GetCustomerDto
            {
                ID = p.ID,
                FullName = p.FullName,
                Password = p.Password,
                National_Number = p.National_Number,
                Unique_Payment_Identifier = p.Unique_Payment_Identifier,
                Description = p.Description,
                IsActive = p.IsActive,
                InsertTime = p.InsertTime,


            }).ToList();

            return new ResultGetCustomerDto
            {
                Rows = rowscount,
                Users = usersList,


            };


        }
    }
}
