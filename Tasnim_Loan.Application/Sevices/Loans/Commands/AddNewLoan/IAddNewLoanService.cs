using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;
using Tasnim_Loan.Domain.Entities;

namespace Tasnim_Loan.Application.Sevices.Loans.Commands.AddNewLoan
{
    public interface AddNewLoanService
    {
        ResultDto<ResultRegisterLoanDto> Execute(RequestRegisterLoanDto request);

    }
    public class RegisterCustomerService : AddNewLoanService
    {
        private readonly IDataBaseContext _context;
        public RegisterCustomerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterLoanDto> Execute(RequestRegisterLoanDto request)
        {
            try
            {
                if (request.Total_Amount == 0)
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }
                if (request.Loan_Num == 0)
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }
                if (request.Payment_Num == 0)
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }
                if (request.Payment_Amount == 0)
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Guaranty))
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام خانوادگی  را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Introducer))
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره ملی را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Closed))
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره ملی را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Cleared))
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره ملی را وارد نمایید"
                    };
                }
              /*  if (string.IsNullOrWhiteSpace(request.Cleared_Date))
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره ملی را وارد نمایید"
                    };
                }*/

                if (request.Customer_ID == 0)
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "شناسه منحصر به فرد پرداخت  را وارد نمایید"
                    };
                }



                // piadeesazi method execute
                Loan loan = new Loan()  // instance from customer

                {
                    Total_Amount = request.Total_Amount,
                    Loan_Num = request.Loan_Num,
                    Payment_Num = request.Payment_Num,
                    Payment_Amount = request.Payment_Amount,
                    Guaranty = request.Guaranty,
                    Introducer = request.Introducer,
                    Closed = request.Closed,
                    Cleared = request.Cleared,
                    Cleared_Date = request.Cleared_Date,
                    Customer_ID = request.Customer_ID,


                };
                _context.Loans.Add(loan);

                _context.SaveChanges();

                return new ResultDto<ResultRegisterLoanDto>()
                {
                    Data = new ResultRegisterLoanDto()
                    {
                        //    CustomerId = customer.ID,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد",
                };

            }
            catch (Exception)
            {
                return new ResultDto<ResultRegisterLoanDto>()
                {
                    Data = new ResultRegisterLoanDto()
                    {
                        LoanId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }

        }

    }
    public class RequestRegisterLoanDto
    {
        public int Total_Amount { get; set; }
        public int Loan_Num { get; set; }
        public int Payment_Num { get; set; }
        public int Payment_Amount { get; set; }
        public string Guaranty { get; set; }
        public string Introducer { get; set; }
        public string Closed { get; set; }
        public string Cleared { get; set; }
        public DateTime Cleared_Date { get; set; }
        public int Customer_ID { get; set; }
        public int User_ID { get; set; }

    }

    public class ResultRegisterLoanDto
    {
        public int LoanId { get; set; }

    }
}

