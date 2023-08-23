using  Tasnim_Loan.Application.Services.Customers.Commands.EditUser;
using  Tasnim_Loan.Application.Services.Customers.Commands.RemoveUser;
using  Tasnim_Loan.Application.Services.Customers.Commands.UserSatusChange;
using Microsoft.AspNetCore.Mvc;
using System;
using Tasnim_Loan.Application.Sevices.Customers.Commands.RegisterUser;
using Tasnim_Loan.Application.Sevices.Customers.Queries.GetCustomers;


namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetCustomersService _getCustomerService;
        private readonly IRegisterCustomerService _registerCustomerService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserSatusChangeService _userSatusChangeService;
        private readonly IEditUserService _editUserService;
        public UsersController(IGetCustomersService getCustomerService

           , IRegisterCustomerService registerCustomerService
           , IRemoveUserService removeUserService
           , IUserSatusChangeService userSatusChangeService
           , IEditUserService editUserService)
        {
            _getCustomerService = getCustomerService;
            _registerCustomerService = registerCustomerService;
            _removeUserService = removeUserService;
            _userSatusChangeService = userSatusChangeService;
            _editUserService = editUserService;
        }


        public IActionResult Index(string searchkey, int page = 1)
        {
            return View(_getCustomerService.Execute(new RequestGetCustomerDto
            {

                Page = page,
                SearchKey = searchkey,

            }));
        }
        //  action لازم برای اضافه کردن کاربر جدید
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // دیتا رو به سرویس رجیستر یوزر ارسال میکنه و ثبت نام رو انجام میده

        [HttpPost]
        public IActionResult Create(string Name, string Family, string National_Number, int Unique_Payment_Identifier, string Description)
        {
            var result = _registerCustomerService.Execute(new RequestRegisterCustomerDto
            {
                Name = Name,
                Family = Family,
                National_Number = National_Number,
                Unique_Payment_Identifier = Unique_Payment_Identifier,
                Description = Description,


            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult Delete(int CustomerId)
           {
               return Json(_removeUserService.Execute(CustomerId));
           }
           [HttpPost]
           public IActionResult UserSatusChange(int CustomerId)
           {
               return Json(_userSatusChangeService.Execute(CustomerId));
           }
           [HttpPost]
           public IActionResult Edit(int ID, string Name, string Family, string National_Number, int Unique_Payment_Identifier, string Description, DateTime InsertionTime)
           {
            
               return Json(_editUserService.Execute(new RequestEdituserDto
               {
                   ID=ID,
                   Name = Name,
                   Family = Family,
                   National_Number = National_Number,
                   Unique_Payment_Identifier = Unique_Payment_Identifier,
                   Description = Description,
                   InsertionTime = InsertionTime
               }));
           }
    }
}
