using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Common.Dto;

namespace Tasnim_Loan.Application.Sevices.Loans.Queries.GetLoans
{
    public interface IGetLoansService
    {
        ResultDto<List<LoansDto>> Execute();
    }  
}
