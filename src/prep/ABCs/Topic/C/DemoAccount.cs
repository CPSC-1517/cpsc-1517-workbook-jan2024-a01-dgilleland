using System;

namespace Topic.C
{
    public class DemoAccount
    {
        public static void Main(string[] args)
        {
            Account savings = new Account(7654321, 100, 200);
            Console.WriteLine($"Account has a balance of ${savings.Balance}");
        }
    }
}