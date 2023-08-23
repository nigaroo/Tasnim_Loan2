using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(long? parentId)
        {
            return View(_LoanFacad.GetCategoriesService.Execute(parentId).Data);
        }
        [HttpGet]
        public IActionResult AddNewCategory(long? parentId)
        {
            ViewBag.parentId = parentId;
            return View();
        }
        [HttpPost]
        public IActionResult AddNewCategory(long? ParentId, string Name)
        {
            var result = _LoanFacad.AddNewCategoryService.Execute(ParentId, Name);
            return Json(result);
        }
    }
}
