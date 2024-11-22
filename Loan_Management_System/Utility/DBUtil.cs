using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;

namespace Loan_Management_System.Utility
{
    public class DBUtil
    {
        private static string _connectionString;

        static DBUtil()
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) 
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                _connectionString = configuration.GetConnectionString("LOAN_MANAGEMENTDB");

                if (string.IsNullOrEmpty(_connectionString))
                {
                    throw new InvalidOperationException("Connection string 'LOAN_MANAGEMENTDB' not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing DBUtil: {ex.Message}");
                throw; 
            }
        }

        public static SqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string is not properly initialized.");
            }
            return new SqlConnection(_connectionString);
        }
    }
}
