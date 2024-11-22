using System;

namespace Loan_Management_System.Model
{
    public class CarLoan : Loan  
    {
        private string carModel;
        private int carValue;

        // Default Constructor
        public CarLoan() : base() { }

       
        public CarLoan(int loanID, int customerID, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus, string carModel, int carValue)
            : base(loanID, customerID, principalAmount, interestRate, loanTerm, loanType, loanStatus, 0)  
        {
            this.carModel = carModel;
            this.carValue = carValue;
        }

        // Getters and Setters
        public string CarModel { get => carModel; set => carModel = value; }
        public int CarValue { get => carValue; set => carValue = value; }

        // Method to print all information
        public new void PrintLoanInfo()
        {
            base.PrintLoanInfo();
            Console.WriteLine($"CarModel: {carModel}, CarValue: {carValue}");
        }
    }
}
