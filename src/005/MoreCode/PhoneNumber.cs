namespace Assorted;

public class PhoneNumber
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Number { get; private set; }

    public PhoneNumber(string first, string last, string number)
    {
        FirstName = first;
        LastName = last;
        Number = number;
    }
}

public class PhoneBook
{
    public List<PhoneNumber> Numbers { get; }
    public string Name { get; }
    public PhoneBook(string areaName)
    {
        Name = areaName;
        Numbers = new(); // empty list
    }

    public void Add(PhoneNumber entry)
    {
        // TODO: validation (e.g.: entry should not be null)
        Numbers.Add(entry); // appending, without consideration of maintaining a sort order.
    }

    public List<PhoneNumber> Find(string partialName)
    {
        // TODO: implement this later
        throw new NotImplementedException();
    }

    public PhoneNumber FindByNumber(string number)
    {
        PhoneNumber found = null;
        // Simple sequential search
        foreach(PhoneNumber entry in Numbers)
            if(entry.Number == number)
                found = entry;
        return found;       
    }
}
