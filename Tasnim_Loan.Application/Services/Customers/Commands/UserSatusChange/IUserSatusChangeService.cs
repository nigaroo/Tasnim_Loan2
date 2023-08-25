using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Tasnim_Loan.Application.Services.Customers.Commands.UserSatusChange
{
    public interface IUserSatusChangeService
    {
        ResultDto Execute(int UserId);
    }

    public class UserSatusChangeService : IUserSatusChangeService
    {
        private readonly IDataBaseContext _context;


        public UserSatusChangeService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(int UserId)
        {
            var customer = _context.Users.Find(UserId);
            if (customer == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            customer.IsActive = !customer.IsActive;
            _context.SaveChanges();
            string customerstate = customer.IsActive == true ? "فعال" : "غیر فعال";
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {customerstate} شد!",
            };
        }
    }
}
