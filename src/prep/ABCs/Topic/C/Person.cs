namespace Topic.C
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;
        private int _Age;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
    }
}