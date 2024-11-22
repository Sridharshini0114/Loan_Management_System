using Loan_Management_System.Service;
using Loan_Management_System.Model;

namespace Loan_Management_System
{
    public class LoanManagement
    {
        private readonly LoanService _loanService;

        public LoanManagement(LoanService loanService)
        {
            _loanService = loanService;
        }

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nLoan Management System");
                Console.WriteLine("1. Apply Loan");
                Console.WriteLine("2. Get All Loans");
                Console.WriteLine("3. Get Loan by ID");
                Console.WriteLine("4. Loan Repayment");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ApplyLoan();
                        break;
                    case "2":
                        GetAllLoans();
                        break;
                    case "3":
                        GetLoanById();
                        break;
                    case "4":
                        LoanRepayment();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting Loan Management System. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ApplyLoan()
        {
            try
            {
                Console.WriteLine("\nEnter Loan Details");
                Console.Write("Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());

                Console.Write("Principal Amount: ");
                decimal principalAmount = decimal.Parse(Console.ReadLine());

                Console.Write("Interest Rate: ");
                decimal interestRate = decimal.Parse(Console.ReadLine());

                Console.Write("Loan Term (months): ");
                int loanTerm = int.Parse(Console.ReadLine());

                Console.Write("Loan Type (CarLoan/HomeLoan): ");
                string loanType = Console.ReadLine();

                Console.Write("Loan Status (Pending/Approved): ");
                string loanStatus = Console.ReadLine();

                Console.Write("Credit Score: ");
                int creditScore = int.Parse(Console.ReadLine());

                Loan loan = new Loan
                {
                    CustomerID = customerId,
                    PrincipalAmount = principalAmount,
                    InterestRate = interestRate,
                    LoanTerm = loanTerm,
                    LoanType = loanType,
                    LoanStatus = loanStatus,
                    CreditScore = creditScore
                };

                bool result = _loanService.ApplyLoan(loan);
                Console.WriteLine(result ? "Loan application submitted successfully." : "Loan application failed.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter data in the correct format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void GetAllLoans()
        {
            Console.WriteLine("\nAll Loans:");
            var loans = _loanService.GetAllLoans();
            foreach (var loan in loans)
            {
                loan.PrintLoanInfo();
            }
        }

        private void GetLoanById()
        {
            try
            {
                Console.Write("\nEnter Loan ID: ");
                int loanId = int.Parse(Console.ReadLine());

                var loan = _loanService.GetLoanById(loanId);
                if (loan != null)
                {
                    loan.PrintLoanInfo();
                }
                else
                {
                    Console.WriteLine("Loan not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }

        private void LoanRepayment()
        {
            try
            {
                Console.Write("\nEnter Loan ID: ");
                int loanId = int.Parse(Console.ReadLine());

                Console.Write("Enter Repayment Amount: ");
                decimal repaymentAmount = decimal.Parse(Console.ReadLine());

                _loanService.LoanRepayment(loanId, repaymentAmount);
                Console.WriteLine("Loan repayment processed successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numeric values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
