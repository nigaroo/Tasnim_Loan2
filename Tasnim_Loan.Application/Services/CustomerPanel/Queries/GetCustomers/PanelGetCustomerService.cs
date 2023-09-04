using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetCustomers
{
    public class PanelGetCustomerService : IPanelGetCustomerService
    {
        private readonly IDataBaseContext _context;
        public PanelGetCustomerService(IDataBaseContext context)
        {
            _context = context;
        }
        public PanelResultGetCustomerDto Execute(PanelRequestGetCustomerDto request, int customerId)
        {
            // var users = _context.Userss.AsQueryable();
            var users = _context.Userss.AsQueryable().Where(p => p.ID == customerId);
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey));

            }


            int rowscount = 0;
            var usersList = users.ToPaged(request.Page, 20, out rowscount).Select(p => new PanelGetCustomerDto
            {
                ID = p.ID,
                FullName = p.FullName,
                National_Number = p.National_Number,
                Unique_Payment_Identifier = p.Unique_Payment_Identifier,
                Description = p.Description,
                IsActive = p.IsActive,
                InsertTime = p.InsertTime,


            }).ToList();

            return new PanelResultGetCustomerDto
            {
                Rows = rowscount,
                Users = usersList,


            };


        }
    }
}
