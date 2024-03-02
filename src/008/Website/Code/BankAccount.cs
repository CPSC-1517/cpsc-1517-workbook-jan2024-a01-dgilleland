namespace WebApp;

public class BankAccount
{
    public string Holder { get; set; }
    public string Number { get; set; }
    public double Balance { get; set;}
    public double OverdraftLimit { get; set; }
    public string Type { get; set; }

    public override string ToString()
    {
        return $"Account {Number} has a balance of {Balance:C}";
    }
}
