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

    public MultipleChoice()
    {
        Choice = Answer.NOT_ANSWERED;
    }

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