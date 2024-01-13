namespace Topic.B
{
    public class DemoStudentDriver
    {
        public static void Main(string[] args)
        {
            Student bob, mary, joe, susan, frank;
            bob = new Student();
            mary = new Student();
            joe = new Student();
            susan = new Student();
            frank = new Student();

            bob.Name = "Bob McNalley";
            bob.Status = 'C'; // Current
            bob.Program = "COMP";
            bob.StudentId = 200765789;
            bob.GradePointAverage = 6.76;

            mary.Name = "Mary McTavishski";
            mary.Status = 'C'; //Current
            mary.Program = "COMP";
            mary.StudentId = 200765790;
            mary.GradePointAverage = 5.76;

            joe.Name = "Joe Jetson";
            joe.Status = 'C'; // Current
            joe.Program = "COMP";
            joe.StudentId = 200765792;
            joe.GradePointAverage = 4.66;

            susan.Name = "Susan Orlando";
            susan.Status = 'C'; // Current
            susan.Program = "COMP";
            susan.StudentId = 200765795;
            susan.GradePointAverage = 8.54;

            frank.Name = "Frank Smith";
            frank.Status = 'C'; // Current
            frank.Program = "COMP";
            frank.StudentId = 200765797;
            frank.GradePointAverage = 8.52;

            displayStudentInformation(bob);
        }

        public static void displayStudentInformation(Student someStudent)
        {
            System.Console.WriteLine(someStudent.Name);
            System.Console.WriteLine(someStudent.Status);
            System.Console.WriteLine(someStudent.Program);
            System.Console.WriteLine(someStudent.StudentId);
            System.Console.WriteLine(someStudent.GradePointAverage);
        }
    }
}