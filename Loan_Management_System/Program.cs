using Loan_Management_System.Service;
using Loan_Management_System.Repository;

namespace Loan_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoanRepository loanRepository = new LoanRepository();
            LoanService loanService = new LoanService(loanRepository);

            LoanManagement loanManagement = new LoanManagement(loanService);
            loanManagement.Run();
        }
    }
}
