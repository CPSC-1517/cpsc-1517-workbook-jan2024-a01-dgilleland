namespace Topic.B
{
    public class DemoPerson
    {
        public static void Main(string[] args)
        {
            Person someGuy;
            someGuy = new Person();
            someGuy.FirstName = "Harry";
            someGuy.LastName = "Burns";
            someGuy.Age = 25;

            Person someGirl;
            someGirl = new Person();
            someGirl.FirstName = "Sally";
            someGirl.LastName = "Albright";
            someGirl.Age = 25;

            string fullName;

            fullName = someGuy.FirstName + " " + someGuy.LastName;
            System.Console.WriteLine("Hi. My name is " + fullName);

            fullName = someGirl.FirstName + " " + someGirl.LastName;
            System.Console.WriteLine("Hi " + someGuy.FirstName +
                                     ". My name is " + fullName);
        }
    }
}