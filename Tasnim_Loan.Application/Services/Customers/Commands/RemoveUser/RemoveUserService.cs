using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;
using System;
using System.Linq;

namespace  Tasnim_Loan.Application.Services.Customers.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;

        public RemoveUserService(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultDto Execute(int ID)
        {
 
            var customer = _context.Userss.Find(ID);
            if (customer == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            customer.RemoveTime = DateTime.Now;
            customer.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };
        }
    }
}
