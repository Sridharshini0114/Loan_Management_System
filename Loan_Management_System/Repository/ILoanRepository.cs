using Loan_Management_System.Model;
using System.Collections.Generic;

namespace Loan_Management_System.Repository
{
    public interface ILoanRepository 
    {
        bool ApplyLoan(Loan loan);
        List<Loan> GetAllLoans();
        Loan GetLoanById(int loanId);
        void LoanRepayment(int loanId, decimal repaymentAmount);
    }
}
