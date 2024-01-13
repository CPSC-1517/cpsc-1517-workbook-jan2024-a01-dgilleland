using System;

namespace Topic.C
{
    public class DemoCompanyAndEmployee
    {
        public static void Main(string[] args)
{
    Company jdCompany = new Company("JD Consulting", "Edmonton", true, new DateTime(2012, 5, 15), 785646.45);
    Employee johnDoe = new Employee("John", "Doe", 123456789, 92500, new DateTime(2012, 5, 15), 'M');
    Employee analyst = new Employee("Anna", "Lyst", 112258899, 74500, new DateTime(2014, 7, 1), 'F');
    Employee student = new Employee("Stewart", "Dent", 314259876, 52000, new DateTime(2015, 5, 20), 'M');

    Console.WriteLine($"{jdCompany.Name} employs {johnDoe.FirstName}, {analyst.FirstName} and {student.FirstName}");
}
    }
}