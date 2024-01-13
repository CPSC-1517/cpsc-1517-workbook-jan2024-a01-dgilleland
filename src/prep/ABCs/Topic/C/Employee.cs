using System;
namespace Topic.C
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SocialInsuranceNumber { get; set; }
        public double YearlySalary { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public char Gender { get; set; }

        public Employee(string firstName,
                        string lastName,
                        int socialInsuranceNumber,
                        double yearlySalary,
                        DateTime employmentStartDate,
                        char gender)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialInsuranceNumber = socialInsuranceNumber;
            YearlySalary = yearlySalary;
            EmploymentStartDate = employmentStartDate;
            Gender = gender;
        }
    }
}