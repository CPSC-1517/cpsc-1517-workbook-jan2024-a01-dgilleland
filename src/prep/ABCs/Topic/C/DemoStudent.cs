using System;

namespace Topic.C
{
    public class DemoStudent
    {
        public static void Main(string[] args)
        {
            Student jack = new Student("Jack Hill", 'M', 123456, "Programming 101", 3.72, true);
            Student jill = new Student("Jill Roland", 'F', 144721, "Programming 101", 3.80, true);

            Console.WriteLine($"{jack} has a GPA of {jack.GradePointAverage}");
            Console.WriteLine($"{jill} has a GPA of {jill.GradePointAverage}");
        }
    }
}