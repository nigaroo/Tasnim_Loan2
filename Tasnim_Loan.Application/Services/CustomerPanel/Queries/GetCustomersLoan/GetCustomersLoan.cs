using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasnim_Loan.Application.Interfaces.Contexts;
using Tasnim_Loan.Domain.Entities.Loans;

namespace Tasnim_Loan.Application.Services.CustomerPanel.Queries.GetCustomersLoan
{
    public class GetCustomersLoan : IGetCustomersLoan
    {
        private readonly IDataBaseContext _context;

        public GetCustomersLoan(IDataBaseContext context)
        {
                _context = context;
        }

        public List<CustomersLoanGetDto> Execute(int UserId)
        {
            List<Loan> customerLoan = _context.Loans.Where(p => p.User_ID == UserId).ToList();

            List<CustomersLoanGetDto> result = new List<CustomersLoanGetDto>();

            foreach(Loan Loans in customerLoan)
            {
                CustomersLoanGetDto loan = new CustomersLoanGetDto()
                {
                    FullName = Loans.FullName,
                    Total_Amount = Loans.Total_Amount,
                    Loan_Num = Loans.Loan_Num,
                    Payment_Amount = Loans.Payment_Amount,
                    Payment_Num = Loans.Payment_Num,
                    Guaranty = Loans.Guaranty,
                    Introducer = Loans.Introducer,
                    Accept = Loans.Accept,
                };
                result.Add(loan);
            }

            return result;
            
        }
    }
}
