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
using Tasnim_Loan.Domain.Entities.Users;

namespace Tasnim_Loan.Application.Services.Customers.Commands.RegisterUser
{
    public interface IRegisterCustomerService
    {
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterCustomerDto request);

    }
    public class RegisterCustomerService : IRegisterCustomerService
    {
        private readonly IDataBaseContext _context;
        public RegisterCustomerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterCustomerDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام و نام خانوادگی را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد نمایید"
                    };
                }
                if (request.Password != request.RePasword)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن برابر نیست"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.National_Number))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره ملی را وارد نمایید"
                    };
                }

                if (request.Unique_Payment_Identifier == 0)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "شناسه منحصر به فرد پرداخت  را وارد نمایید"
                    };
                }
                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(request.Password);



                // piadeesazi method execute

                User user = new User()
                {
                    FullName=request.FullName,
                    Password = hashedPassword,
                    National_Number = request.National_Number,
                    Unique_Payment_Identifier = request.Unique_Payment_Identifier,
                    Description = request.Description,
                    IsActive = true,

                };
               
                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach (var item in request.roles)
                     {
                             var roles = _context.Roles.Find(item.Id);
                             userInRoles.Add(new UserInRole
                             {
                                 Role = roles,
                                 RoleId = roles.ID,
                                 User = user,
                                 UserId = user.ID,
                             });
                         }
                         user.UserInRoles = userInRoles;

                         _context.Users.Add(user);
           
                    _context.SaveChanges();

                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = user.ID,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد",
                };

            }
            catch (Exception)
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }

        }
        
    }
    public class RequestRegisterCustomerDto
    {
        public string FullName { get; set; }
        public string Password { get; set; }
        public string RePasword { get; set; }
        public string National_Number { get; set; }
        public int Unique_Payment_Identifier { get; set; }
        public string Description { get; set; }
        public List<RolesInRegisterUserDto> roles { get; set; }
        public ICollection<Loan> Loan { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }

    public class RolesInRegisterUserDto
    {
        public int Id { get; set; }
    }
    public class ResultRegisterUserDto
    {
        public int UserId { get; set; }
    }
}
