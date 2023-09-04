using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetLoans
{
    public class PanelGetLoanService : IPanelGetLoanService
    {
        private readonly IDataBaseContext _context;

        public PanelGetLoanService(IDataBaseContext context)
        {
            _context = context;
        }
        public PanelResultGetLoanDto Execute(PanelRequestGetLoanDto request, int customerId)
        {
           // var customer = GetCustomerById(customerId);
            var loans = _context.Loans.AsQueryable().Where(p => p.User_ID == customerId);
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                loans = loans.Where(p => p.FullName.Contains(request.SearchKey));

            }
            // this is about pageingation in  Commom
            int rowscount = 0;
            var loansList = loans.ToPaged(request.Page, 10, out rowscount).Select(p => new PanelGetLoanDto
            {
                ID = p.ID,
                FullName = p.FullName,
                User_ID = p.User_ID,
                Total_Amount = p.Total_Amount,
                Loan_Num = p.Loan_Num,
                Payment_Num = p.Payment_Num,
                Payment_Amount = p.Payment_Amount,
                Guaranty = p.Guaranty,
                Introducer = p.Introducer,
              //  Cleared =p.Cleared,
                DateCleared = p.DateCleared,
                InsertTime = p.InsertTime,


            }).ToList();

            return new PanelResultGetLoanDto
            {
                Rows = rowscount,
                Loans = loansList,



            };


        }
    }
}
