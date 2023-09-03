using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetTypes
{
    public class PanelGetTypesService: IPanelGetTypesService
    {
        private readonly IDataBaseContext _context;

        public PanelGetTypesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<PanelTypesDto>> Execute()
        {
            var roles = _context.Types.ToList().Select(p => new PanelTypesDto
            {
                ID = p.ID,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<PanelTypesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = "",
            };
        }


    }
}
