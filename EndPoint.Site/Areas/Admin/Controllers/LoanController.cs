﻿using Microsoft.AspNetCore.Mvc;
using Tasnim_Loan.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoanController : Controller
    {
        private readonly ILoanFacad _LoanFacad;
        public LoanController(ILoanFacad productFacad)
        {
            _LoanFacad = productFacad;
        }
        public IActionResult Index()
        {
            return View(_LoanFacad.GetLoansService.Execute());
        }

    }
}
