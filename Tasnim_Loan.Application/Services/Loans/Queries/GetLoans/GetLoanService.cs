using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common;

namespace Tasnim_Loan.Application.Services.Loans.Queries.GetLoans
{
    public class GetLoanService : IGetLoanService
    {
        private readonly IDataBaseContext _context;
        public GetLoanService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetLoanDto Execute(RequestGetLoanDto request)
        {
            var loans = _context.Loans.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                loans = loans.Where(p => p.FullName.Contains(request.SearchKey));

            }
            // this is about pageingation in  Commom
            int rowscount = 0;
            var loansList = loans.ToPaged(request.Page, 10, out rowscount).Select(p => new GetLoanDto
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

            return new ResultGetLoanDto
            {
                Rows = rowscount,
                Loans = loansList,


            };


        }
    }
}
