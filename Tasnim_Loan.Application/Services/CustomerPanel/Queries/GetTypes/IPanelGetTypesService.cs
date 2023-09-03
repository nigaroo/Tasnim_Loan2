using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Common.Dto;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetTypes
{
    public interface IPanelGetTypesService
    {
        ResultDto<List<PanelTypesDto>> Execute();
    }
}
