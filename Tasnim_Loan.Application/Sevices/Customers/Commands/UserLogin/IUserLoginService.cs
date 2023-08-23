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


namespace Tasnim_Loan.Application.Services.Customers.Commands.UserLogin
{
    public interface IUserLoginService
    {
        ResultDto<ResultUserloginDto> Execute(string Username, string Pass);
    }

    public class UserLoginService : IUserLoginService
    {
        private readonly IDataBaseContext _context;
        public UserLoginService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultUserloginDto> Execute(string Username, string Pass)
        {

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Pass))
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


            /*  var user = _context.Users
               .Include(p => p.Username)
               .FirstOrDefault();
            */

             var user = _context.Users
           .Where(u => u.Username == Username)
           .FirstOrDefault();

            if (user == null)
            {
                return new ResultDto<ResultUserloginDto>
                {
                    IsSuccess = false,
                    Message = "کاربری با این نام کاربری یافت نشد"
                };
            }


            //  var passwordHasher = new PasswordHasher();
            //   bool resultVerifyPassword = passwordHasher.VerifyPassword(user.Pass, Pass);
            bool resultVerifyPassword = user.Pass == Pass;

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


            return new ResultDto<ResultUserloginDto>()
            {
                Data = new ResultUserloginDto()
                {
                    ID = user.ID,
                    Username = user.Username
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد",
            };


        }
    }

    public class ResultUserloginDto
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
    }
}
