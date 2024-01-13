using System;
namespace Topic.B
{
    public class DemoCompanyAndEmployee
    {
        public static void Main(string[] args)
        {
            Company Acme = new Company();
            Employee Salesman = new Employee();
            Employee Shipper = new Employee();

            // Set the company's information
            Acme.Name = "Acme International";
            Acme.City = "Edmonton";
            Acme.BusinessStartDate = new DateTime(); // new Date() defaults to the current date
            Acme.IsIncorporated = false;
            Acme.NumberOfEmployess = 2;
            Acme.GrossIncomeToDate = 2152368.52; // $ 2 million, plus change

            // Set the salesman's information
            Salesman.FirstName = "Wiley";
            Salesman.LastName = "Coyote";
            Salesman.Gender = 'M';
            Salesman.SocialInsuranceNumber = 123456789;
            Salesman.EmploymentStartDate = DateTime.Today;
            Salesman.YearlySalary = 45250.00;

            // Set the shipper's information
            Shipper.FirstName = "Road";
            Shipper.LastName = "Runner";
            Shipper.Gender = 'F';
            Shipper.SocialInsuranceNumber = 7777777;
            Shipper.EmploymentStartDate = DateTime.Parse("June 1, 2008");
            Shipper.YearlySalary = 54520.00;


            // Show the information
            System.Console.WriteLine("The information for the company:");
            System.Console.WriteLine(Acme.Name);
            System.Console.WriteLine(Acme.City);
            System.Console.WriteLine(Acme.BusinessStartDate);
            System.Console.WriteLine(Acme.IsIncorporated);
            System.Console.WriteLine(Acme.NumberOfEmployess);
            System.Console.WriteLine(Acme.GrossIncomeToDate);

            System.Console.WriteLine("The employee information: Salesman");
            System.Console.WriteLine(Salesman.FirstName);
            System.Console.WriteLine(Salesman.LastName);
            System.Console.WriteLine(Salesman.Gender);
            System.Console.WriteLine(Salesman.SocialInsuranceNumber);
            System.Console.WriteLine(Salesman.EmploymentStartDate);
            System.Console.WriteLine(Salesman.YearlySalary);

            System.Console.WriteLine("The employee information: Shipper");
            System.Console.WriteLine(Shipper.FirstName);
            System.Console.WriteLine(Shipper.LastName);
            System.Console.WriteLine(Shipper.Gender);
            System.Console.WriteLine(Shipper.SocialInsuranceNumber);
            System.Console.WriteLine(Shipper.EmploymentStartDate.ToString("MMMM d, yyyy"));
            System.Console.WriteLine(Shipper.YearlySalary);
        }
    }
}