using System;

namespace Topic.Banking
{
    public class BankStatement
    {
        public readonly Month Month;
        public Account BankAccount { get; private set; }
        public double EndingBalance { get; }
        public double StartingBalance { get; }
        public int TotalDeposits { get; }
        public int TotalWithdrawals { get; }

        public BankStatement(Account bankAccount, Month month)
        {
            BankAccount = bankAccount ?? throw new ArgumentNullException("Cannot have a BankStatement without a BankAccount");
            Month = month != Month.NotSpecified ? month : throw new ArgumentException("A valid month is required");
        }
    }
}