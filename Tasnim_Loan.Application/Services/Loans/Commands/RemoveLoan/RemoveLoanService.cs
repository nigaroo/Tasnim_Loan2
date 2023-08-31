using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;

namespace Tasnim_Loan.Application.Services.Loans.Commands.RemoveLoan
{
    public class RemoveLoanService : IRemoveLoanService
    {
        private readonly IDataBaseContext _context;

        public RemoveLoanService(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultDto Execute(int ID)
        {

            var loan = _context.Loans.Find(ID);
            if (loan == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            loan.RemoveTime = DateTime.Now;
            loan.IsRemoved = true;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "کاربر با موفقیت حذف شد"
            };
        }
    }
}
