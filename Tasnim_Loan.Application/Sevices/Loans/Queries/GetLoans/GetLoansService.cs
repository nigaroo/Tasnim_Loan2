using System.Collections.Generic;
using System.Linq;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;
using Tasnim_Loan.Domain.Entities;

namespace Tasnim_Loan.Application.Sevices.Loans.Queries.GetLoans
{
    public class GetLoansService : IGetLoansService
    {
        private readonly IDataBaseContext _context;
        public GetLoansService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<LoansDto>> Execute()
        {
            var loans = _context.Loans.ToList();

            var results = new List<LoansDto>();

            foreach ( var loan in loans )
            {
                var result = new LoansDto
                {
                    ID = loan.ID,
                    Total_Amount = loan.Total_Amount,
                    Loan_Num = loan.Loan_Num,
                    Payment_Num = loan.Payment_Num,
                    Payment_Amount = loan.Payment_Amount,
                    Guaranty = loan.Guaranty,
                    Introducer = loan.Introducer,
                    Closed = loan.Closed,
                    Cleared = loan.Cleared,
                    Cleared_Date = loan.Cleared_Date,
              //      Customer_ID = loan.Customer_ID,
                };
                results.Add(result);
            }
           
            return new ResultDto<List<LoansDto>>()
            {
                Data = results,
                IsSuccess = true,
                Message = "لیست باموقیت برگشت داده شد"
            };
        }
    }
  
}
