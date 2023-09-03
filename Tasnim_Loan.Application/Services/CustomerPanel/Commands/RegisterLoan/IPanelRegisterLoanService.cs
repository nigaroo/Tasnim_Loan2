using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Application.Singletons;
using Tasnim_Loan.Common.Dto;
using Tasnim_Loan.Domain.Entities.Loans;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Commands.RegisterLoan
{
    public interface IPanelRegisterLoanService
    {
        ResultDto<ResultRegisterLoanDto> Execute(RequestRegisterLoanDto request);

    }
    public class PanelRegisterLoanService : IPanelRegisterLoanService
    {
        private readonly IDataBaseContext _context;
        public PanelRegisterLoanService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterLoanDto> Execute(RequestRegisterLoanDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام و نام خانوادگی را وارد نمایید"
                    };
                }
                if (request.Total_Amount == 0)
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = " مبلغ کل وام را وارد نمایید"
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
                        Message = "شماره ی وام را وارد کنید"
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
                        Message = "تعداد قسط  را وارد نمایید"
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
                        Message = "مبلغ قسط را واریز نمایید"
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
                        Message = "تضمین را وارد نمایید"
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
                        Message = "معرف را وارد نمایید"
                    };
                }
                if (request.User_ID == 0)
                {
                    return new ResultDto<ResultRegisterLoanDto>()
                    {
                        Data = new ResultRegisterLoanDto()
                        {
                            LoanId = 0,
                        },
                        IsSuccess = false,
                        Message = "شماره پرسنلی  را وارد نمایید"
                    };
                }
     
                // piadeesazi method execute

                Loan loan = new Loan()
                {
                    FullName = request.FullName,
                    User_ID = request.User_ID,
                    Total_Amount = request.Total_Amount,
                    Loan_Num = request.Loan_Num,
                    Payment_Num = request.Payment_Num,
                    Payment_Amount = request.Payment_Amount,
                    Guaranty = request.Guaranty,
                    Introducer = request.Introducer,
                };

                List<LoanInType> loanInTypes = new List<LoanInType>();
                foreach (var item in request.types)
                {
                    var types = _context.Types.Find(item.Id);
                    loanInTypes.Add(new LoanInType
                    {
                        Type = types,
                        TypeId = types.ID,
                        Loan = loan,
                        LoanId = loan.ID,
                    });
                }
                loan.LoanInType = loanInTypes;

                _context.Loans.Add(loan);

                _context.SaveChanges();

                return new ResultDto<ResultRegisterLoanDto>()
                {
                    Data = new ResultRegisterLoanDto()
                    {
                        LoanId = loan.ID,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام وام انجام شد",
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
        public string FullName { get; set; }
        public int Total_Amount { get; set; }
        public int Loan_Num { get; set; }
        public int Payment_Num { get; set; }
        public int Payment_Amount { get; set; }
        public string Guaranty { get; set; }
        public string Introducer { get; set; }
        public int User_ID { get; set; }
        public List<TypesInRegisterLoanDto> types { get; set; }

    }

    public class TypesInRegisterLoanDto
    {
        public int Id { get; set; }
    }
    public class ResultRegisterLoanDto
    {
        public int LoanId { get; set; }
    }
}
