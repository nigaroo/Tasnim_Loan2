using Tasnim_Loan.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasnim_Loan.Application.Services.Customers.Commands.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEdituserDto request);
    }


}
