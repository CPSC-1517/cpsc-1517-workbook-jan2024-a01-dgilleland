namespace WebApp;

public class JobApplicant
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsFullTime { get; set; }
    public List<string> JobRoles { get; set; }

    public JobApplicant() : this(string.Empty, string.Empty, string.Empty, false, new()) { }
    public JobApplicant(string fullName, string email, string phoneNumber, bool isFullTime, List<string> jobRoles)
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        IsFullTime = isFullTime;
        JobRoles = jobRoles ?? new();
    }
}
