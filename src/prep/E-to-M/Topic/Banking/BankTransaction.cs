using System;

namespace Topic.Banking
{
    public record BankTransaction(double Amount, DateTime Date, string FromAccount, string ToAccount, string Description);
}