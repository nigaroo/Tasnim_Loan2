using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
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
        private readonly IDataBaseContext _context;


        private readonly IGetLoanService _getLoanService;
        private readonly IGetTypesService _getTypesService;
        private readonly IRegisterLoanService _registerLoanService;
        private readonly IRemoveLoanService _removeLoanService;
        private readonly ILoanStatusChangeService _loanSatusChangeService;
        private readonly IEditLoanService _editLoanService;
        private readonly IAcceptLoanService _acceptLoanService;
        public LoanController(IDataBaseContext context

           , IGetLoanService getLoanService
           , IGetTypesService getTypesService
           , IRegisterLoanService registerLoanService
           , IRemoveLoanService removeLoanService
           , ILoanStatusChangeService loanSatusChangeService
           , IEditLoanService editLoanService
           , IAcceptLoanService acceptLoanService)
        {
            _context = context;
            _getLoanService = getLoanService;
            _getTypesService = getTypesService;
            _registerLoanService = registerLoanService;
            _removeLoanService = removeLoanService;
            _loanSatusChangeService = loanSatusChangeService;
            _editLoanService = editLoanService;
            _acceptLoanService = acceptLoanService;
        }

        [HttpGet]
        public async Task<FileResult> ExportLoansInExcel()
        {
            var resultDto = await _context.Loans
                .Select(loan => new GetLoanDto
                {
                    ID = loan.ID,
                    FullName = loan.FullName,
                    Total_Amount = loan.Total_Amount,
                    Loan_Num = loan.Loan_Num,
                    Payment_Num = loan.Payment_Num,
                    Payment_Amount = loan.Payment_Amount,
                    Guaranty = loan.Guaranty,
                    Introducer = loan.Introducer,
                  //  Cleared = loan.Cleared,
                    DateCleared = loan.DateCleared,
                    InsertTime = loan.InsertTime,
                    IsRemoved = loan.IsRemoved,
                    RemoveTime = loan.RemoveTime,
                    UpdateTime = loan.UpdateTime,

                })
                .ToListAsync();

            var fileName = "loans.xlsx";
            return GenerateExcel(fileName, resultDto);
        }

        private FileResult GenerateExcel(string fileName, List<GetLoanDto> loans)
        {
            DataTable dataTable = new DataTable("Loans");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID"),
                new DataColumn("FullName"),
                new DataColumn("Total_Amount"),
                new DataColumn("Loan_Num"),
                new DataColumn("Payment_Num"),
                new DataColumn("Payment_Amount"),
                new DataColumn("Guaranty"),
                new DataColumn("Introducer"),
                new DataColumn("DateCleared"),
                new DataColumn("InsertTime"),
                 new DataColumn("IsRemoved"),
                new DataColumn("RemoveTime"),
                new DataColumn("UpdateTime"),

            });

            foreach (var loan in loans)
            {
                dataTable.Rows.Add(
                    loan.ID,
                    loan.FullName,
                    loan.Total_Amount,
                    loan.Loan_Num,
                    loan.Payment_Num,
                    loan.Payment_Amount,
                    loan.Guaranty,
                    loan.Introducer,
                    loan.DateCleared,
                    loan.InsertTime,
                    loan.IsRemoved,
                    loan.RemoveTime,
                    loan.UpdateTime
                );

            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);

                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileName);
                }
            }
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
        public IActionResult Create(string Fullname, int Total_Amount, int Loan_Num, int Payment_Num, int Payment_Amount, string Guaranty, string Introducer, int User_ID, int typeId)
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
