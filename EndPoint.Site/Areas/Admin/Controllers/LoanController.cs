using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using Tasnim_Loan.Application.Services.Loans.Commands.AcceptLoan;
using Tasnim_Loan.Application.Services.Loans.Commands.EditLoan;
using Tasnim_Loan.Application.Services.Loans.Commands.LoanStatusChange;
using Tasnim_Loan.Application.Services.Loans.Commands.RegisterLoan;
using Tasnim_Loan.Application.Services.Loans.Commands.RemoveLoan;
using Tasnim_Loan.Application.Services.Loans.Queries.GetLoans;
using Tasnim_Loan.Application.Services.Loans.Queries.GetTypes;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class LoanController : Controller
    {
        private readonly IGetLoanService _getLoanService;
        private readonly IGetTypesService _getTypesService;
        private readonly IRegisterLoanService _registerLoanService;
        private readonly IRemoveLoanService _removeLoanService;
        private readonly ILoanStatusChangeService _loanSatusChangeService;
        private readonly IEditLoanService _editLoanService;
        private readonly IAcceptLoanService _acceptLoanService;
        public LoanController(IGetLoanService getLoanService

           , IGetTypesService getTypesService
          
           , IRegisterLoanService registerLoanService
           , IRemoveLoanService removeLoanService
           , ILoanStatusChangeService loanSatusChangeService
           , IEditLoanService editLoanService
           , IAcceptLoanService acceptLoanService)
        {
            _getLoanService = getLoanService;
            _getTypesService = getTypesService;
            _registerLoanService = registerLoanService;
            _removeLoanService = removeLoanService;
            _loanSatusChangeService = loanSatusChangeService;
            _editLoanService = editLoanService;
            _acceptLoanService = acceptLoanService;
        }


        public IActionResult Index(string searchkey, int page = 1)
        {
            return View(_getLoanService.Execute(new RequestGetLoanDto
            {

                Page = page,
                SearchKey = searchkey,

            }));
        }
        //  action لازم برای اضافه کردن کاربر جدید
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Type = new SelectList(_getTypesService.Execute().Data, "ID", "Name");
            return View();
        }

        // دیتا رو به سرویس رجیستر یوزر ارسال میکنه و ثبت نام رو انجام میده

        [HttpPost]
        public IActionResult Create(string Fullname, int Total_Amount, int Loan_Num, int Payment_Num, int Payment_Amount, string Guaranty, string Introducer, int User_ID,  int typeId)
        {
            var result = _registerLoanService.Execute(new RequestRegisterLoanDto
            {
                FullName = Fullname,
                Total_Amount = Total_Amount,
                Loan_Num = Loan_Num,
                Payment_Num = Payment_Num,
                Payment_Amount = Payment_Amount,
                Guaranty = Guaranty,
                Introducer = Introducer,
             //   Cleared = Cleared,


                User_ID = User_ID,
               // DateCleared = DateCleared,
                types = new List<TypesInRegisterLoanDto>()
                   {
                       new TypesInRegisterLoanDto
                        {
                          Id= typeId
                        }
                   },


            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult Delete(int LoanId)
        {
            return Json(_removeLoanService.Execute(LoanId));
        }
        [HttpPost]
        public IActionResult LoanSatusChange(int LoanId)
        {

            return Json(_loanSatusChangeService.Execute(LoanId));
        }
        [HttpPost]
        public IActionResult Edit(int ID, string Fullname, int User_ID, int Total_Amount, int Loan_Num, int Payment_Num, int Payment_Amount, string Guaranty, string Introducer, bool Cleared, DateTime DateCleared, DateTime InsertionTime)
        {

            return Json(_editLoanService.Execute(new RequestEditloanDto
            {
                ID = ID,
                FullName = Fullname,
                User_ID = User_ID,
                Total_Amount = Total_Amount,
                Loan_Num = Loan_Num,
                Payment_Num = Payment_Num,
                Payment_Amount = Payment_Amount,
                Guaranty = Guaranty,
                Introducer = Introducer,
                Cleared = Cleared,
                DateCleared = DateCleared,
                InsertionTime = InsertionTime
            }));
        }


        [HttpPost]
        public IActionResult Accept(int ID, bool Cleared, DateTime DateCleared)
        {

            return Json(_acceptLoanService.Execute(new RequestAcceptLoanDto
            {
                ID = ID,
                Cleared = Cleared,
                DateCleared = DateCleared,

            }));
        }


    }
}
