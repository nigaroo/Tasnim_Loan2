
using Microsoft.AspNetCore.Mvc;
using System;
using Tasnim_Loan.Application.Services.Customers.Commands.EditUser;
using Tasnim_Loan.Application.Services.Customers.Commands.RemoveUser;
using Tasnim_Loan.Application.Services.Customers.Commands.UserSatusChange;
using Tasnim_Loan.Application.Services.Customers.Commands.RegisterUser;
using Tasnim_Loan.Application.Services.Customers.Queries.GetCustomers;
using Tasnim_Loan.Application.Services.Customers.Queries.GetRoles;
using System.Collections.Generic;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetCustomersService _getCustomerService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterCustomerService _registerCustomerService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserSatusChangeService _userSatusChangeService;
        private readonly IEditUserService _editUserService;
        public UsersController(IGetCustomersService getCustomerService

           , IGetRolesService getRolesService
           , IRegisterCustomerService registerCustomerService
           , IRemoveUserService removeUserService
           , IUserSatusChangeService userSatusChangeService
           , IEditUserService editUserService)
        {
            _getCustomerService = getCustomerService;
            _getRolesService = getRolesService;
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
        public IActionResult Create(string Fullname, string Password, string RePassword, string National_Number, int Unique_Payment_Identifier, string Description, int RoleId)
        {
            var result = _registerCustomerService.Execute(new RequestRegisterCustomerDto
            {
                FullName = Fullname,
                Password = Password,
                National_Number = National_Number,
                Unique_Payment_Identifier = Unique_Payment_Identifier,
                Description = Description,
                roles = new List<RolesInRegisterUserDto>()
                   {
                       new RolesInRegisterUserDto
                        {
                          Id= RoleId
                        }
                   },


            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult Delete(int UseerId)
        {
            return Json(_removeUserService.Execute(UseerId));
        }
        [HttpPost]
        public IActionResult UserSatusChange(int UseerId)
        {
            return Json(_userSatusChangeService.Execute(UseerId));
        }
        [HttpPost]
        public IActionResult Edit(int ID, string Fullname, string Password, string National_Number, int Unique_Payment_Identifier, string Description, DateTime InsertionTime)
        {

            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                ID = ID,
                FullName = Fullname,
                Password = Password,
                National_Number = National_Number,
                Unique_Payment_Identifier = Unique_Payment_Identifier,
                Description = Description,
                InsertionTime = InsertionTime
            }));
        }

    }
}
