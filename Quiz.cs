[Serializable]
public class Quiz
{
    /// <summary>
    /// A list to store the questions.
    /// </summary>
    public List<Question> Questions { get; set; } = new List<Question>();


    /// <summary>
    /// Retrieves a random question from the quiz.
    /// </summary>
    /// <returns>A random Question object from the quiz, or null if there are no questions.</returns>
    public Question GetRandomQuestion()
    {
        if (Questions.Count == 0)
        {
            return null; // No questions in the quiz
        }

        Random random = new Random();
        int randomIndex = random.Next(Questions.Count);
        return Questions[randomIndex];
    }

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
