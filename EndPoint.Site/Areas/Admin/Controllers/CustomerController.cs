using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Application.Services.CustomerPanel.Commands.RegisterLoan;
using Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetCustomers;
using Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetLoans;
using Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetTypes;
using Tasnim_Loan.Application.Services.Loans.Queries.GetLoans;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Customer")]
    public class CustomerController : Controller
    {
        private readonly IDataBaseContext _context;
        private readonly IPanelGetLoanService _getLoanService;
        private readonly IPanelGetCustomerService _getCustomerService;
        private readonly IPanelGetTypesService _getTypesService;
        private readonly IPanelRegisterLoanService _registerLoanService;

        public CustomerController(

             IDataBaseContext context
           , IPanelGetLoanService getLoanService
           , IPanelGetCustomerService getCustomerService
           , IPanelGetTypesService getTypesService
           , IPanelRegisterLoanService registerLoanService)

        {
            _context = context;
            _getLoanService = getLoanService;
            _getCustomerService = getCustomerService;
            _getTypesService = getTypesService;
            _registerLoanService = registerLoanService;

        }

        public IActionResult Index()
        {
            int? customerId = ClaimUtility.GetUserId(User);
            if (customerId.HasValue)
            {

                var loanResult = _getLoanService.Execute(new PanelRequestGetLoanDto(), customerId.Value);
                // Pass the result to the view
                return View(loanResult);
            }
            return RedirectToAction("Error");
        }

      
        [HttpGet]
        public IActionResult Create()
        {
            int? customerId = ClaimUtility.GetUserId(User);
            if (customerId.HasValue)
            {
                var loanResult = _getCustomerService.Execute(new PanelRequestGetCustomerDto(), customerId.Value);              
                return View(loanResult);
            }
            return RedirectToAction("Error");
        }

      

     
    }
}
