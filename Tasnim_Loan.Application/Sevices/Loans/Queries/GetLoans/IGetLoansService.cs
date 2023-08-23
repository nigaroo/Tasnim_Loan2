using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Common.Dto;

namespace Tasnim_Loan.Application.Sevices.Loans.Queries.GetLoans
{

    public interface IGetLoansService
    {
        ResultDto<List<CategoriesDto>> Execute(long? ParentId);
    }
    public class GetLoansService : IGetLoansService
    {
        private readonly IDataBaseContext _context;
        public GetLoansService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<LoansDto>> Execute(long? Paren
        {
            var categories = _context.Categories
               .Include(p => p.ParentCategory)
               .Include(p => p.SubCategories)
               .Where(p => p.ParentCategoryId == ParentId)
               .ToList()
               .Select(p => new CategoriesDto
               {
                   Id = p.Id,
                   Name = p.Name,
                   Parent = p.ParentCategory != null ? new
                   ParentCategoryDto
                   {
                       Id = p.ParentCategory.Id,
                       name = p.ParentCategory.Name,
                   }
                   : null,
                   HasChild = p.SubCategories.Count() > 0 ? true
  
               }).ToList();
            return new ResultDto<List<CategoriesDto>>()
            {
                Data = categories,
                IsSuccess = true,
                Message = "لیست باموقیت برگشت داده شد"
            };
        }
    }
    public class LoansDto
    {
        public int ID { get; set; }
        public int Total_Amount { get; set; }
        public int Loan_Num { get; set; }
        public int Payment_Num { get; set; }
        public int Payment_Amount { get; set; }
        public string Guaranty { get; set; }
        public string Introducer { get; set; }
        public string Closed { get; set; }
        public string Cleared { get; set; }
        public DateTime Cleared_Date { get; set; }
        public int Customer_ID { get; set; }
        public bool IsActive { get; set; }
    }
  
}
