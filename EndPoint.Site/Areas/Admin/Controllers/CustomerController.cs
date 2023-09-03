using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Tasnim_Loan.Application.Services.CustomerPanel.Commands.RegisterLoan;
using Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetLoans;
using Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetTypes;
using Tasnim_Loan.Application.Services.Loans.Queries.GetLoans;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {

        private readonly IPanelGetLoanService _getLoanService;
        private readonly IPanelGetTypesService _getTypesService;
        private readonly IPanelRegisterLoanService _registerLoanService;
    
        public CustomerController(IPanelGetLoanService getLoanService

           , IPanelGetTypesService getTypesService

           , IPanelRegisterLoanService registerLoanService)
        {
            _getLoanService = getLoanService;
            _getTypesService = getTypesService;
            _registerLoanService = registerLoanService;

        }



        public IActionResult Index(string searchkey, int page = 1)
        {
            return View(_getLoanService.Execute(new PanelRequestGetLoanDto
            {

                Page = page,
                SearchKey = searchkey,

            }));
        }

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
      
       

    }
}
