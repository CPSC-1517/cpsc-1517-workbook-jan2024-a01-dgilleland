namespace Assorted;

public class Person
{
    // Fields and Properties describe what an object will look like
    #region Fields (as backing stores)
    private string _FirstName;
    private string _LastName;
    #endregion

    #region Properties
    public string FirstName
    {
        get { return _FirstName; }
        set
        {
            // This validation check is called a "guard clause"
            if (value.Trim() == string.Empty)
                throw new ArgumentException("First name cannot be an empty string");
            // If the code executes to the following line, it passes the validation
            _FirstName = value.Trim();
        }
    }

    public string LastName
    {
        get { return _LastName; }
        set
        {
            // This validation check is called a "guard clause"
            if (value.Trim() == string.Empty)
                throw new ArgumentException("Last name cannot be an empty string");
            // If the code executes to the following line, it passes the validation
            _LastName = value;
        }
    }

    // Auto-implemented property - the compiler generates/manages the backing store
    public DateTime BirthDate { get; private set; }
    #endregion

    // Constructors and Methods describe how the object will behave
    #region Constructors
    // Greedy constructor - one that needs values for all the fields/properties
    // The purpose of a constructor is to ensure that all fields and properties
    // have meaningful values.
    public Person(string firstName, string lastName, DateTime dateOfBirth)
    {
        // Ensure properties/fields have meaningful values
        FirstName = firstName;
        LastName = lastName;
        BirthDate = dateOfBirth;
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        return $"{FirstName} {LastName}"; // using string interpolation
    }

    #endregion
}
