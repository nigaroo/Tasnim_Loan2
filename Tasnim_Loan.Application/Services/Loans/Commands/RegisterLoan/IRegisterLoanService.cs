using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Common.Dto;

namespace Tasnim_Loan.Application.Services.Loans.Commands.RegisterLoan
{
    public interface IRegisterLoanService
    {
        ResultDto<ResultRegisterLoanDto> Execute(RequestRegisterLoanDto request);

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
     //   public bool Cleared { get; set; }
     //   public DateTime? DateCleared { get; set; }
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
