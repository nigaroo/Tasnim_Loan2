using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetCustomerInfo
{
    public class GetCustomerInfo : IGetCustomerInfo
    {
        private readonly IDataBaseContext _context;

        public GetCustomerInfo(IDataBaseContext context)
        {
            _context = context;
        }
        public GetCustomerInfoDto Execute(int UserId)
        {
            var customerInfo = _context.Userss.Where(p => p.ID == UserId).FirstOrDefault();

            if (customerInfo != null)
            {
                GetCustomerInfoDto result = new GetCustomerInfoDto()
                {
                    FullName = customerInfo.FullName,
                    Password = customerInfo.Password,
                    National_Number = customerInfo.National_Number,
                    Unique_Payment_Identifier = customerInfo.Unique_Payment_Identifier,
                    Description = customerInfo.Description,
                    IsActive = customerInfo.IsActive,
                };

                return result;
            }

            return null;
        }
    }
}
