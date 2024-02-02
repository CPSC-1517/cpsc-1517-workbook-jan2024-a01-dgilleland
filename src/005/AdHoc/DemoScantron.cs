using Assorted;

namespace AdHoc;

public class DemoScantron
{
    public static void Run(string[] args)
    {
        if(args.Length == 2 && args[0] == "-q")
        {
            // Load up a file of exam answers which can then be parsed and marked
            string path = args[1];

            // Read a file
            string[] lines = File.ReadAllLines(path);
            // Assume that the first exam item is the answer key
            Exam key = Exam.Parse(lines[0]);
            MultipleChoiceMarker scantron = new(key.Questions);

            // loop through the remaining lines and generate marks
            foreach(string singleLine in lines.Skip(1))
            {
                Exam student = Exam.Parse(singleLine);
                var result = scantron.MarkExam(student.Questions);
                Console.WriteLine($"{student.Name} - {result.Average}%");
            }
        }
    }
}
