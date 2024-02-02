namespace Assorted;

/// <summary>
/// Represent a selection of an option for a multiple-choice question
/// </summary>
public class MultipleChoice
{
    /// <summary>
    /// Represents a possible answer for a multiple-choice question (A through E)
    /// </summary>
    public enum Answer { NOT_ANSWERED, A, B, C, D, E }

    public Answer Choice { get; }

    /// <summary>
    /// Generate a MutlipleChoice where the answer is blank (<see cref="Answer.NOT_ANSWERED"/> )
    /// </summary>
    public MultipleChoice()
    {
        Choice = Answer.NOT_ANSWERED;
    }

    /// <summary>
    /// Generate a MultipleChoice object with the chosen answer
    /// </summary>
    /// <param name="chosenAnswer">An enum value from <see cref="Answer"/> type.</param>
    public MultipleChoice(Answer chosenAnswer)
    {
        Choice = chosenAnswer;
    }
}

/// <summary>
/// Represents a Mark on a assignment or quiz
/// </summary>
public class Mark
{
    public int Possible { get; }
    public int Earned { get; }
    public double Average { get { return 100.0 * Earned / Possible; } }

    public Mark(int possible, int earned)
    {
        // TODO: Validation
        Possible = possible;
        Earned = earned;
    }
}


public class MultipleChoiceMarker
{
    public List<MultipleChoice> Key { get; }
    public int Count { get; }

    public MultipleChoiceMarker(List<MultipleChoice> key)
    {
        // TODO: Validation
        Key = key;
    }

    /// <summary>
    /// Compare the supplied student answers against an answer key to produce a Mark.
    /// </summary>
    /// <param name="studentAnswers">A list of <see cref="MutlipleChoice"/> responses by a student for the exam</param>
    /// <returns>A <see cref="Mark"/> of the correct answers for the exam</returns>
    public Mark MarkExam(List<MultipleChoice> studentAnswers)
    {
        // TODO: Validation
        // Loop through the student answers and compare them against the answer key
        int correct = 0;
        for(int index = 0; index < Key.Count; index++)
        {
            var keyItem = Key[index];
            var student = studentAnswers[index];
            if(student.Choice != MultipleChoice.Answer.NOT_ANSWERED)
            {
                if(keyItem.Choice == student.Choice)
                    correct++;
            }
        }

        return new Mark(Key.Count, correct);
    }
}

public class Exam
{
    public string Name { get; }
    public List<MultipleChoice> Questions { get; }
    private Exam(string name)
    {
        Name = name;
        Questions = new();
    }

    /// <summary>
    /// Generate an Exam from a string of text
    /// </summary>
    /// <param name="text">Comma-delimited string of Exam information</param>
    /// <returns>An <see cref="Exam"/> object</returns>
    /// <remarks>
    /// The format of the string is expected to have the student name as the first delimited item
    /// and all the remaining items to be answers of the form A through E. Blanks are allowed.
    /// E.g.:
    /// <code>Stewart Dent,A,C,B,D,D,,E</code>
    /// </remarks>
    public static Exam Parse(string text)
    {
        // Split the text by commas to generate the Exam information
        string[] parts = text.Split(',');
        Exam result = new(parts[0]);
        string[] remaining = parts.Skip(1).ToArray();
        foreach(string item in remaining)
        {
            if(item.Length == 1)
            {
                // Parse it as a MultipleChoice.Answer value
                MultipleChoice.Answer answer = (MultipleChoice.Answer) Enum.Parse(typeof (MultipleChoice.Answer), item, true);
                result.Questions.Add(new(answer));
            }
            else
            {
                result.Questions.Add(new()); // not-answered question
            }
        }
        return result;
    }
}