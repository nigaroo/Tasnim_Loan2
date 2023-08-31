using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Application.Singletons;
using Tasnim_Loan.Common.Dto;

namespace Tasnim_Loan.Application.Services.Loans.Commands.EditLoan
{
    public class EditLoanService : IEditLoanService
    {
        private readonly IDataBaseContext _context;

        public EditLoanService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditloanDto request)
        {

            var loan = _context.Loans.Find(request.ID);
            if (loan == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            //فیلد های نیاز به ویرایش 
            loan.FullName = request.FullName;
            loan.Total_Amount = request.Total_Amount;
            loan.Loan_Num = request.Loan_Num;
            loan.Payment_Num = request.Payment_Num;
            loan.Payment_Amount = request.Payment_Amount;
            loan.Guaranty = request.Guaranty;
            loan.Introducer = request.Introducer;
            loan.Cleared = request.Cleared;
            loan.DateCleared = request.DateCleared;
            loan.InsertTime = request.InsertionTime;


            loan.UpdateTime = DateTime.Now;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ویرایش کاربر انجام شد"
            };

        }
    }
}
