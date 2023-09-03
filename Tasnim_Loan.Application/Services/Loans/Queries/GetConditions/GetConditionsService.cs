using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;

namespace Tasnim_Loan.Application.Services.Loans.Queries.GetConditions
{
    public class GetConditionsService : IGetConditionsService
    {
        private readonly IDataBaseContext _context;

        public GetConditionsService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<ConditionsDto>> Execute()
        {
            var condition = _context.Conditions.ToList().Select(p => new ConditionsDto
            {
                ID = p.ID,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<ConditionsDto>>()
            {
                Data = condition,
                IsSuccess = true,
                Message = "",
            };
        }

    }
}

