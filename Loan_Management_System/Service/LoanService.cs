using Loan_Management_System.Model;
using Loan_Management_System.Repository;
using System;
using System.Collections.Generic;

namespace Loan_Management_System.Service
{
    public class LoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository ?? throw new ArgumentNullException(nameof(loanRepository), "LoanRepository cannot be null");
        }

        // Apply a loan
        public bool ApplyLoan(Loan loan)
        {
            if (loan == null)
            {
                throw new ArgumentNullException(nameof(loan), "Loan cannot be null");
            }

            // Evaluate credit score for automatic approval/rejection
            if (loan.CreditScore < 650)
            {
                loan.LoanStatus = "Rejected";
                Console.WriteLine("Loan rejected due to low credit score.");
                return false;
            }

            loan.LoanStatus = "Pending";
            return _loanRepository.ApplyLoan(loan);
        }

        // Get all loans
        public List<Loan> GetAllLoans() => _loanRepository.GetAllLoans();

        // Get loan by ID
        public Loan GetLoanById(int loanId) => _loanRepository.GetLoanById(loanId);

        // Loan repayment
        public void LoanRepayment(int loanId, decimal repaymentAmount)
        {
            var loan = _loanRepository.GetLoanById(loanId);
            if (loan == null)
            {
                throw new Exception("Loan not found.");
            }

            if (loan.LoanStatus == "Paid")
            {
                Console.WriteLine("Loan already fully repaid.");
                return;
            }

            _loanRepository.LoanRepayment(loanId, repaymentAmount);
        }

        // Calculate EMI
        public decimal CalculateEMI(int loanId)
        {
            var loan = _loanRepository.GetLoanById(loanId);
            if (loan == null)
            {
                throw new Exception("Loan not found.");
            }

            decimal r = loan.InterestRate / 12 / 100; // Monthly interest rate
            int n = loan.LoanTerm; // Loan term in months

            return (loan.PrincipalAmount * r * (decimal)Math.Pow((double)(1 + r), n)) /
                   ((decimal)Math.Pow((double)(1 + r), n) - 1);
        }

        // Calculate interest
        public decimal CalculateInterest(int loanId)
        {
            var loan = _loanRepository.GetLoanById(loanId);
            if (loan == null)
            {
                throw new Exception("Loan not found.");
            }

            return CalculateInterest(loan.PrincipalAmount, loan.InterestRate, loan.LoanTerm);
        }

        public decimal CalculateInterest(decimal principalAmount, decimal interestRate, int loanTerm)
        {
            return (principalAmount * interestRate * loanTerm) / 12;
        }
    }
}
