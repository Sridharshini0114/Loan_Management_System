using System;

namespace Loan_Management_System.Model
{
    public class Loan
    {
    
        public int LoanID { get; set; }
        public int CustomerID { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestRate { get; set; } 
        public int LoanTerm { get; set; } 
        public string LoanType { get; set; }
        public string LoanStatus { get; set; }
        public int CreditScore { get; set; } 

        // Default Constructor
        public Loan() { }

        // Parameterized Constructor
        public Loan(int loanID, int customerID, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus, int creditScore)
        {
            LoanID = loanID;
            CustomerID = customerID;
            PrincipalAmount = principalAmount;
            InterestRate = interestRate;
            LoanTerm = loanTerm;
            LoanType = loanType;
            LoanStatus = loanStatus;
            CreditScore = creditScore;
        }

     
        public void PrintLoanInfo()
        {
            Console.WriteLine($"LoanID: {LoanID}, CustomerID: {CustomerID}, PrincipalAmount: {PrincipalAmount}, InterestRate: {InterestRate}%, LoanTerm: {LoanTerm} months, LoanType: {LoanType}, LoanStatus: {LoanStatus}, CreditScore: {CreditScore}");
        }
    }
}
