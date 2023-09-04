using Microsoft.AspNetCore.Mvc;
using Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetCustomerInfo;
using Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetCustomersLoan;
using Tasnim_Loan.Application.Services.Loans.Queries.GetLoans;

namespace EndPoint.Site.Controllers
{
    public class UserController : Controller
    {
        private readonly IGetCustomerInfo _getCustomerInfo;
        private readonly IGetCustomersLoan _getCustomersLoan;

        public UserController(IGetCustomerInfo getCustomerInfo , IGetCustomersLoan getCustomersLoan)
        {
            _getCustomerInfo = getCustomerInfo;
            _getCustomersLoan = getCustomersLoan;
        }

        [HttpGet]
        public IActionResult Index(int UserId)
        {
            return View(_getCustomerInfo.Execute(UserId));
        }

        [HttpGet]
        public IActionResult GetCustomersLoan(int UserId)
        {
            return View(_getCustomersLoan.Execute(UserId));
        }
    }
}
