using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;

namespace Tasnim_Loan.Application.Services.Loans.Queries.GetTypes
{
    public class GetTypesService: IGetTypesService
    {
        private readonly IDataBaseContext _context;

        public GetTypesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<TypesDto>> Execute()
        {
            var roles = _context.Types.ToList().Select(p => new TypesDto
            {
                ID = p.ID,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<TypesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = "",
            };
        }


    }
}
