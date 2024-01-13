using System;
using static System.Console;

namespace Topic.Banking
{
    public class DemoArrays
    {
        public static void Main(string[] args)
        {

        }

        public BankTransaction[] LoadTransactions()
        {
            BankTransaction[] transactions =
            {
        new BankTransaction(1200.00, new DateTime(2021, 5, 1), "123-123456-7654321", "247-125556-6543218", "Midtown Apartment Rentals"),
        new BankTransaction(8.95, new DateTime(2021, 5, 5), "123-123456-7654321", "123-123456-7654321", "McDonald's Purchase"),
        new BankTransaction(82.96, new DateTime(2021, 5, 7), "123-123456-7654321", "231-425361-9284720", "Esso Gas"),
        new BankTransaction(4.75, new DateTime(2021, 5, 7), "123-123456-7654321", "123-123456-7654321", "McDonald's Purchase"),
        new BankTransaction(88.32, new DateTime(2021, 5, 8), "123-123456-7654321", "123-443456-7654321", "Canadian Superstore Purchase"),
        new BankTransaction(4.95, new DateTime(2021, 5, 10), "123-123456-7654321", "123-443456-7654321", "Canadian Superstore Purchase"),
        new BankTransaction(88.60, new DateTime(2021, 5, 12), "123-123456-7654321", "123-987543-3957211", "Staples"),
        new BankTransaction(11.30, new DateTime(2021, 5, 12), "123-123456-7654321", "123-123456-7654321", "McDonald's Purchase"),
        new BankTransaction(1394.55, new DateTime(2021, 5, 14), "111-823456-9632587", "123-123456-7654321", "Sports Check Deposit"),
        new BankTransaction(103.24, new DateTime(2021, 5, 16), "123-123456-7654321", "123-443456-7654321", "Canadian Superstore Purchase"),
        new BankTransaction(9.50, new DateTime(2021, 5, 17), "123-123456-7654321", "123-123456-7654321", "McDonald's Purchase"),
        new BankTransaction(17.70, new DateTime(2021, 5, 18), "123-123456-7654321", "123-443456-7654321", "Canadian Superstore Purchase"),
        new BankTransaction(57.22, new DateTime(2021, 5, 18), "123-123456-7654321", "123-443456-7654321", "Canadian Superstore Purchase"),
        new BankTransaction(75.44, new DateTime(2021, 5, 19), "123-123456-7654321", "231-425361-9284720", "Esso Gas"),
        new BankTransaction(120.40, new DateTime(2021, 5, 20), "123-123456-7654321", "123-987543-3957211", "Staples"),
        new BankTransaction(22.40, new DateTime(2021, 5, 24), "123-123456-7654321", "123-443456-7654321", "Canadian Superstore Purchase"),
        new BankTransaction(82.18, new DateTime(2021, 5, 27), "123-123456-7654321", "123-223456-9835123", "Home Depot"),
        new BankTransaction(1394.55, new DateTime(2021, 5, 28), "111-823456-9632587", "123-123456-7654321", "Sports Check Deposit"),
        new BankTransaction(103.24, new DateTime(2021, 5, 28), "123-123456-7654321", "123-443456-7654321", "Canadian Superstore Purchase"),
        new BankTransaction(250.00, new DateTime(2021, 5, 29), "123-123456-7654321", "103-123937-7107321", "Epcore"),
        new BankTransaction(320.00, new DateTime(2021, 5, 30), "123-123456-7654321", "342-155456-1387421", "Als Auto Repair"),
        new BankTransaction(18.99, new DateTime(2021, 5, 30), "123-123456-7654321", "123-443456-7654321", "Canadian Superstore Purchase"),
        new BankTransaction(85.50, new DateTime(2021, 5, 31), "123-123456-7654321", "333-029456-7852365", "Rogers Internet")
    };
            return transactions;
        }

        public BankTransaction[] FindDeposits(BankTransaction[] transactions, string account)
        {
            int logicalSize = 0;
            BankTransaction[] found = new BankTransaction[transactions.Length]; // Allow for max found

            for (int index = 0; index < transactions.Length; index++)
            {
                if (transactions[index].ToAccount == account)
                {
                    found[logicalSize] = transactions[index];
                    logicalSize++;
                }
            }

            BankTransaction[] trimmed = new BankTransaction[logicalSize];
            for (int index = 0; index < logicalSize; index++)
                trimmed[index] = found[index];

            return trimmed;
        }
    }
}