[Serializable]
public class Quiz
{
    /// <summary>
    /// A list to store the questions.
    /// </summary>
    public List<Question> Questions { get; set; } = new List<Question>();

    /// <summary>
    /// Adds a new question to the list of questions.
    /// </summary>
    /// <param name="question">The question to be added.</param>
    public void AddQuestion(Question question)
    {
        Questions.Add(question);
    }

    /// <summary>
    ///  Remove a qustion from the quiz at the specified index 
    /// </summary>
    /// <param name="questionIndex">the index of the question to be removed. Indexing starts at 0, 
    /// so the first question has an index of 0, the second has an index of 1, ect</param>
    public void RemoveQuestion(int questionIndex)
    {
        if (questionIndex >= 0 && questionIndex < Questions.Count)
        {
            Questions.RemoveAt(questionIndex);
        }
    }

    /// <summary>
    /// Retrieves all questions from the current quiz.
    /// </summary>
    /// <returns>A List of Question objects representing 
    /// all the questions in the quiz.</returns>
    public List<Question> DisplayAllQuizQuestions()
    {
        return Questions;
    }
    public Quiz()
    {

    }
}
