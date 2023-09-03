
using Microsoft.AspNetCore.Mvc;
using System;
using Tasnim_Loan.Application.Services.Customers.Commands.EditUser;
using Tasnim_Loan.Application.Services.Customers.Commands.RemoveUser;
using Tasnim_Loan.Application.Services.Customers.Commands.UserSatusChange;
using Tasnim_Loan.Application.Services.Customers.Commands.RegisterUser;
using Tasnim_Loan.Application.Services.Customers.Queries.GetCustomers;
using Tasnim_Loan.Application.Services.Customers.Queries.GetRoles;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Tasnim_Loan.Application.Interfaces.Contexts;
using System.IO;
using System.Data;
using ClosedXML.Excel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tasnim_Loan.Persistence.Migrations;



namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class UsersController : Controller
    {
        private readonly IDataBaseContext _context;



        private readonly IGetCustomersService _getCustomerService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterCustomerService _registerCustomerService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserSatusChangeService _userSatusChangeService;
        private readonly IEditUserService _editUserService;
        public UsersController(IDataBaseContext context

            , IGetCustomersService getCustomerService
           , IGetRolesService getRolesService
           , IRegisterCustomerService registerCustomerService
           , IRemoveUserService removeUserService
           , IUserSatusChangeService userSatusChangeService
           , IEditUserService editUserService)
        {
            _context = context;
            _getCustomerService = getCustomerService;
            _getRolesService = getRolesService;
            _registerCustomerService = registerCustomerService;
            _removeUserService = removeUserService;
            _userSatusChangeService = userSatusChangeService;
            _editUserService = editUserService;
        }

        [HttpGet]
        public async Task<FileResult> ExportUsersInExcel()
        {
            var resultDto = await _context.Userss
                .Select(user => new GetCustomerDto
                {
                    ID = user.ID,
                    FullName = user.FullName,
                    National_Number = user.National_Number,
                    Unique_Payment_Identifier = user.Unique_Payment_Identifier,
                    Description = user.Description,
                    InsertTime = user.InsertTime,
                    IsActive = user.IsActive,
                    IsRemoved = user.IsRemoved,
                    RemoveTime = user.RemoveTime,
                    UpdateTime =  user.UpdateTime,
                  
                })
                .ToListAsync();

            var fileName = "users.xlsx";
            return GenerateExcel(fileName, resultDto);
        }

        private FileResult GenerateExcel(string fileName, List<GetCustomerDto> users)
        {
            DataTable dataTable = new DataTable("Userss");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID"),
                new DataColumn("FullName"),
                new DataColumn("Password"),
                new DataColumn("National_Number"),
                new DataColumn("InsertTime"),
                new DataColumn("Unique_Payment_Identifier"),
                new DataColumn("Description"),
                new DataColumn("IsActive"),
                new DataColumn("IsRemoved"),
                new DataColumn("RemoveTime"),
                new DataColumn("UpdateTime"),
               
            });

            foreach (var user in users)
            {
                dataTable.Rows.Add(
                    user.ID,
                    user.FullName,
                    user.Password,
                    user.National_Number,
                    user.InsertTime,
                    user.Unique_Payment_Identifier,
                    user.Description,
                    user.IsActive,
                    user.IsRemoved,
                    user.RemoveTime,
                    user.UpdateTime
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

        
        public IActionResult Index(string serchkey, int page = 1)
        {
            return View(_getCustomerService.Execute(new RequestGetCustomerDto
            {

                Page = page,
                SearchKey = serchkey,

            }));
        }
        
        //  action لازم برای اضافه کردن کاربر جدید
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "ID", "Name");
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
                RePasword= RePassword,
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
        public IActionResult Delete(int UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }
        
        [HttpPost]
        public IActionResult UserSatusChange(int UserId)
        {
            return Json(_userSatusChangeService.Execute(UserId));
        }
        
        [HttpPost]
        public IActionResult Edit(int ID, string Fullname,  string National_Number, int Unique_Payment_Identifier, string Description, DateTime InsertionTime)
        {

            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                ID = ID,
                FullName = Fullname,
                National_Number = National_Number,
                Unique_Payment_Identifier = Unique_Payment_Identifier,
                Description = Description,
                InsertionTime = InsertionTime
            }));
        }

    }
}
