using System;
namespace Topic.C
{
    public class Company
    {
        public string Name { get; set; }
        public string City { get; set; }
        public bool IsIncorporated { get; set; }
        public DateTime BusinessStartDate { get; set; }
        public double GrossIncomeToDate { get; set; }

        public Company(string name,
                        string city,
                        bool isIncorporated,
                        DateTime businessStartDate,
                        double grossIncomeToDate)
        {
            Name = name;
            City = city;
            IsIncorporated = isIncorporated;
            BusinessStartDate = businessStartDate;
            GrossIncomeToDate = grossIncomeToDate;
        }
    }
}