using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Tasnim_Loan.Application.Services.Customers.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEdituserDto request);
    }
    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;

        public EditUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEdituserDto request)
        {
            var user = _context.Userss.Find(request.ID);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            //فیلد های نیاز به ویرایش 
            user.FullName = request.FullName;
       //     user.Password = request.Password;
            user.National_Number = request.National_Number;
            user.Unique_Payment_Identifier = request.Unique_Payment_Identifier;
            user.Description = request.Description;
            user.InsertTime = request.InsertionTime;
           
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "ویرایش کاربر انجام شد"
            };

        }
    }


    public class RequestEdituserDto
    {
        public int ID { get; set; }
        public string FullName { get; set; }
      //  public string Password { get; set; }
        public string National_Number { get; set; }
        public int Unique_Payment_Identifier { get; set; }
        public string Description { get; set; }
        public DateTime InsertionTime { get; set; }
    }


}
