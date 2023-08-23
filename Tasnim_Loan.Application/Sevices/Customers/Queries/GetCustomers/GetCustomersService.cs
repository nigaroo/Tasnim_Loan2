using System;
using System.Collections.Generic;
using System.Linq;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common;

namespace Tasnim_Loan.Application.Sevices.Customers.Queries.GetCustomers
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
            var customers = _context.Customers.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                customers = customers.Where(p =>
                   p.ID==request.SearchInt&&
                   p.Name.Contains(request.SearchKey) &&
                   p.Family.Contains(request.SearchKey) &&
                   p.National_Number.Contains(request.SearchKey) &&
                   p.Unique_Payment_Identifier == request.SearchInt &&
                   p.Description.Contains(request.SearchKey)

                );

            }
            // this is about pageingation in  Commom
            int rowscount = 0;
            var customerList = customers.ToPaged(request.Page, 20, out rowscount).Select(p => new GetCustomerDto
            {
                ID = p.ID,
                Name = p.Name,
                Family = p.Family,
                National_Number = p.National_Number,
                Unique_Payment_Identifier = p.Unique_Payment_Identifier,
                Description = p.Description,
                IsActive = p.IsActive,
                InsertTime = p.InsertTime,


            }).ToList();

            return new ResultGetCustomerDto
            {
                Rows = rowscount,
                Customers = customerList,


            };


        }
    }
}
