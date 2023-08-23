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
            var customer = _context.Customers.Find(request.ID);
            if (customer == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

           //فیلد های نیاز به ویرایش 
            customer.Name = request.Name;
            customer.Family = request.Family;
            customer.National_Number = request.National_Number;
            customer.Unique_Payment_Identifier = request.Unique_Payment_Identifier;
            customer.Description = request.Description;
            customer.InsertTime = request.InsertionTime;
           
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
        public string Name { get; set; }
        public string Family { get; set; }
        public string National_Number { get; set; }
        public int Unique_Payment_Identifier { get; set; }
        public string Description { get; set; }
        public DateTime InsertionTime { get; set; }
    }


}
