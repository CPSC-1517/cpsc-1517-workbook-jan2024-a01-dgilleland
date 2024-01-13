namespace Topic.C
{
    public class Account
    {
        public readonly int AccountNumber;
        private double _Balance;
        private double _OverdraftLimit;

        public double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        public double OverdraftLimit
        {
            get { return _OverdraftLimit; }
            set { _OverdraftLimit = value; }
        }

        public Account(int accountNumber, double balance, double overdraftLimit)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            OverdraftLimit = overdraftLimit;
        }
    }
}