public class Logic
{

    private Quiz quiz;
    private int score; 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="start"></param>
    public Logic(Quiz start)
    {
       quiz = start;
       score = 0;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="question"></param>
    public void AddQuestion(Question question)
    {
        quiz.AddQuestion(question);
    }

    /// <summary>
    ///  Remove a qustion from the quiz at the specified index 
    /// </summary>
    /// <param name="questionIndex">the index of the question to be removed. Indexing starts at 0, so the first question has an index of 0, the second has an index of 1, ect</param>
    public void RemoveQuestion(int questionIndex)
    {
        if(questionIndex >= 0 && questionIndex < quiz.Questions.Count)
        {
            quiz.Questions.RemoveAt(questionIndex);
        }
    }


}
