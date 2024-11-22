using System;

namespace Loan_Management_System.Model
{
    public class HomeLoan : Loan  
    {
        private string propertyAddress;
        private int propertyValue;

        // Default Constructor
        public HomeLoan() : base() { }

        // Parameterized Constructor
        public HomeLoan(int loanID, int customerID, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus, string propertyAddress, int propertyValue)
            : base(loanID, customerID, principalAmount, interestRate, loanTerm, loanType, loanStatus, 0) 
        {
            this.propertyAddress = propertyAddress;
            this.propertyValue = propertyValue;
        }

        // Getters and Setters
        public string PropertyAddress { get => propertyAddress; set => propertyAddress = value; }
        public int PropertyValue { get => propertyValue; set => propertyValue = value; }

        // Method to print all information
        public new void PrintLoanInfo()
        {
            base.PrintLoanInfo();
            Console.WriteLine($"PropertyAddress: {propertyAddress}, PropertyValue: {propertyValue}");
        }
    }
}
