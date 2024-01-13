namespace Topic.C
{
    public class Student
    {
        public readonly string Name;
        public readonly char Status;
        public readonly int StudentId;
        private string _Program;
        private double _GradePointAverage;
        private bool _IsFullTime;

        public string Program
        {
            get { return _Program; }
            set { _Program = value; }
        }
        public double GradePointAverage
        {
            get { return _GradePointAverage; }
            set { _GradePointAverage = value; }
        }
        public bool IsFullTime
        {
            get { return _IsFullTime; }
            set { _IsFullTime = value; }
        }

        public Student(string name,
                       char status,
                       int studentId,
                       string program,
                       double gradePointAverage,
                       bool isFullTime)
        {
            Name = name;
            Status = status;
            StudentId = studentId;
            Program = program;
            GradePointAverage = gradePointAverage;
            IsFullTime = isFullTime;
        }

        public override string ToString()
        {
            return $"({StudentId}) {Name}";
        }
    }
}