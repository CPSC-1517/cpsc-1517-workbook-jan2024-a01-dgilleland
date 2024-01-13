namespace Topic.B
{
    public class Student
    {
        /// <summary>The full name of the student</summary>
        public string Name;

        /// <summary>Status can be 'C' for Current, 'G' for Graduate or 'W' for Withdrawn</summary>
        public char Status;

        /// <summary>The school-provided student ID</summary>
        public int StudentId;

        /// <summary>The course program; e.g.: "COMP"</summary>
        public string Program;

        /// <summary>GPA is from 1.0 to 9.0</summary>
        public double GradePointAverage;

        /// <summary>If the student is enrolled full-time</summary>
        public bool FullTime;
    }
}