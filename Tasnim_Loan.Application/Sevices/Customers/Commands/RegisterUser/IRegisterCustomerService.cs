using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common;
using Tasnim_Loan.Common.Dto;
using Tasnim_Loan.Domain.Entities;

namespace Tasnim_Loan.Application.Sevices.Customers.Commands.RegisterUser
{
    public interface IRegisterCustomerService
    {
        ResultDto<ResultRegisterCustomerDto> Execute(RequestRegisterCustomerDto request);

    }
    public class RegisterCustomerService : IRegisterCustomerService
    {
        private readonly IDataBaseContext _context;
        public RegisterCustomerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterCustomerDto> Execute(RequestRegisterCustomerDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return new ResultDto<ResultRegisterCustomerDto>()
                    {
                        Data = new ResultRegisterCustomerDto()
                        {
                            CustomerId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Family))
                {
                    return new ResultDto<ResultRegisterCustomerDto>()
                    {
                        Data = new ResultRegisterCustomerDto()
                        {
                            CustomerId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام خانوادگی  را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.National_Number))
                {
                    return new ResultDto<ResultRegisterCustomerDto>()
                    {
                        Data = new ResultRegisterCustomerDto()
                        {
                            CustomerId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره ملی را وارد نمایید"
                    };
                }

                if (request.Unique_Payment_Identifier == 0)
                {
                    return new ResultDto<ResultRegisterCustomerDto>()
                    {
                        Data = new ResultRegisterCustomerDto()
                        {
                            CustomerId = 0,
                        },
                        IsSuccess = false,
                        Message = "شناسه منحصر به فرد پرداخت  را وارد نمایید"
                    };
                }
                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(request.Password);



                // piadeesazi method execute
                Customer customer = new Customer()  // instance from customer

                {
                    Name = request.Name,
                    Family = request.Family,
                    Password = hashedPassword,
                    National_Number = request.National_Number,
                    Unique_Payment_Identifier = request.Unique_Payment_Identifier,
                    Description = request.Description,

                };
                _context.Customers.Add(customer);

                _context.SaveChanges();

                return new ResultDto<ResultRegisterCustomerDto>()
                {
                    Data = new ResultRegisterCustomerDto()
                    {
                    //    CustomerId = customer.ID,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد",
                };

            }
            catch (Exception)
            {
                return new ResultDto<ResultRegisterCustomerDto>()
                {
                    Data = new ResultRegisterCustomerDto()
                    {
                        CustomerId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }

        }
        
    }
    public class RequestRegisterCustomerDto
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Password { get; set; }
        public string RePasword { get; set; }
        public string National_Number { get; set; }
        public int Unique_Payment_Identifier { get; set; }
        public string Description { get; set; }
        public ICollection<Loan> Loan { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }

    public class ResultRegisterCustomerDto
    {
        public int CustomerId { get; set; }

    }
}
