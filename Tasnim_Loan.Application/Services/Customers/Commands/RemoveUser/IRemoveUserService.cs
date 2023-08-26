using Tasnim_Loan.Common.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Tasnim_Loan.Application.Services.Customers.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        ResultDto Execute(int UserId);
    }
}
