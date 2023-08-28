using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common;
using Tasnim_Loan.Common.Dto;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Domain.Entities;
using Tasnim_Loan.Application.Singletons;

namespace Tasnim_Loan.Application.Services.Customers.Commands.UserLogin
{
    public interface IUserLoginService
    {
        ResultDto<ResultUserloginDto> Execute(string FullName, string Password);
    }

    public class UserLoginService : IUserLoginService
    {
        private readonly IDataBaseContext _context;
        public UserLoginService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultUserloginDto> Execute(string FullName, string Password)
        {

            if (string.IsNullOrWhiteSpace(FullName) || string.IsNullOrWhiteSpace(Password))
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "نام کاربری و رمز عبور را وارد نمایید",
                };
            }



            var user = _context.Userss
          .Include(p => p.UserInRoles)
          .ThenInclude(p => p.Role)
          .Where(p => p.FullName == FullName
           && p.IsActive == true)
         .FirstOrDefault();



            

            if (user == null)
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {
                    },
                    IsSuccess = false,
                    Message = "کاربری با این نام کاربری در  سایت  ثبت نام نکرده است",
                };
            }

            var passwordHasher = new PasswordHasher();
           //  bool resultVerifyPassword = user.Password == Password;
            bool resultVerifyPassword = passwordHasher.VerifyPassword(user.Password, Password);
            if (resultVerifyPassword == false)
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "رمز وارد شده اشتباه است!",
                };
            }

            List<string> roles = new List<string>();
            foreach (var item in user.UserInRoles)
            {
                roles.Add(item.Role.Name);
            }
            return new ResultDto<ResultUserloginDto>()
            {
                Data = new ResultUserloginDto()
                {
                    Roles = roles,
                    ID = user.ID,
                    FullName = user.FullName
                

                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد",
            };


        }
    }

    public class ResultUserloginDto
    {
        public int ID { get; set; }
        public List<string> Roles { get; set; }
        public string FullName { get; set; }
    }
}
