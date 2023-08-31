using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;

namespace Tasnim_Loan.Application.Services.Loans.Commands.LoanStatusChange
{
    public interface ILoanStatusChangeService
    {
        ResultDto Execute(int ID);
    }
   
    public class LoanSatusChangeService : ILoanStatusChangeService
    {
        private readonly IDataBaseContext _context;


        public LoanSatusChangeService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(int ID)
        {
            var loan = _context.Loans.Find(ID);
            if (loan == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }


            loan.Accept = !loan.Accept;
            _context.SaveChanges();
            string loanstate = loan.Accept == true ? "تائید" : "رد ";
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $" درخواست وام کاربر با موفقیت {loanstate} شد!",
            };
        }
    }
}
