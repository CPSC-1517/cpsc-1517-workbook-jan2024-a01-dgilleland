namespace Topic.B
{
    public class DemoSimpleStudentDriver
    {
        public static void Main(string[] args)
        {
            Student someStudent = new Student();
            someStudent.Name = "Bob McNalley";
            someStudent.Status = 'C'; // Current
            someStudent.Program = "COMP";
            someStudent.StudentId = 200765789;
            someStudent.GradePointAverage = 6.76;

            System.Console.WriteLine(someStudent.Name);
            System.Console.WriteLine(someStudent.Status);
            System.Console.WriteLine(someStudent.Program);
            System.Console.WriteLine(someStudent.StudentId);
            System.Console.WriteLine(someStudent.GradePointAverage);
        }
    }
}