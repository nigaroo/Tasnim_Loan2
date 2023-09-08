﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;

namespace Tasnim_Loan.Application.Services.Loans.Commands.PayLoan
{
    public class PayLoanService : IPayLoanService
    {
        private readonly IDataBaseContext _context;

        public PayLoanService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestPayLoanDto request)
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
            
            loan.Payment_Amount = request.Payment_Amount;


            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ثبت درخواست  کاربر انجام شد"
            };

        }
    }
}