namespace offline;

public class Exam
{
    public string Name { get; }
    public ReadOnlyList<MultipleChoice> Questions { get; }
    private Exam()
    {

    }
}