namespace WebApp;

public class Applicant
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Street_1 { get; set; }
    public string Street_2 { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string PostalCode { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
