using Loan_Management_System.Model;
using Loan_Management_System.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Loan_Management_System.Repository
{
    public class LoanRepository : ILoanRepository
    {
        public bool ApplyLoan(Loan loan)
        {
            using (SqlConnection connection = DBUtil.GetConnection())
            {
                string query = "INSERT INTO Loan (CustomerID, PrincipalAmount, InterestRate, LoanTerm, LoanType, LoanStatus) VALUES (@CustomerID, @PrincipalAmount, @InterestRate, @LoanTerm, @LoanType, @LoanStatus)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", loan.CustomerID);
                command.Parameters.AddWithValue("@PrincipalAmount", loan.PrincipalAmount);
                command.Parameters.AddWithValue("@InterestRate", loan.InterestRate);
                command.Parameters.AddWithValue("@LoanTerm", loan.LoanTerm);
                command.Parameters.AddWithValue("@LoanType", loan.LoanType);
                command.Parameters.AddWithValue("@LoanStatus", loan.LoanStatus);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public List<Loan> GetAllLoans()
        {
            List<Loan> loans = new List<Loan>();
            using (SqlConnection connection = DBUtil.GetConnection())
            {
                string query = "SELECT * FROM Loan";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    loans.Add(new Loan
                    {
                        LoanID = (int)reader["LoanID"],
                        CustomerID = (int)reader["CustomerID"],
                        PrincipalAmount = (decimal)reader["PrincipalAmount"],
                        InterestRate = (decimal)reader["InterestRate"],
                        LoanTerm = (int)reader["LoanTerm"],
                        LoanType = (string)reader["LoanType"],
                        LoanStatus = (string)reader["LoanStatus"]
                    });
                }
            }
            return loans;
        }

        public Loan GetLoanById(int loanId)
        {
            using (SqlConnection connection = DBUtil.GetConnection())
            {
                string query = "SELECT * FROM Loan WHERE LoanID = @LoanID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LoanID", loanId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Loan
                    {
                        LoanID = (int)reader["LoanID"],
                        CustomerID = (int)reader["CustomerID"],
                        PrincipalAmount = (decimal)reader["PrincipalAmount"],
                        InterestRate = (decimal)reader["InterestRate"],
                        LoanTerm = (int)reader["LoanTerm"],
                        LoanType = (string)reader["LoanType"],
                        LoanStatus = (string)reader["LoanStatus"]
                    };
                }
            }
            return null;
        }

        public void LoanRepayment(int loanId, decimal repaymentAmount)
        {
         
            Console.WriteLine($"Repayment of {repaymentAmount} for Loan ID {loanId} processed.");
        }
    }
}
