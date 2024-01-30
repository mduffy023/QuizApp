using static Menu;

namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Quiz quiz = new Quiz();

            UIMethods.DisplayIntro();

            bool isRunning = true;
            while (isRunning)
            {
                MenuOptions menuOptions = UIMethods.DisplayMenu();

                switch (menuOptions)
                {
                    case MenuOptions.ADDQUESTION:
                        // add question logic 
                        UIMethods.GetNewQuestion(question => quiz.AddQuestion(question));
                        
                        break;
                    case MenuOptions.StartQuiz:
                        if (quiz.Questions.Count > 0)
                        {
                            // Randomize the questions before starting the quiz
                            quiz.Questions = Logic.RandomizeQuestions(quiz.Questions).ToList();
                            int score = Logic.StartQuiz(quiz);
                            UIMethods.OutputScore(score, totalQuestions: quiz.Questions.Count);
                            UIMethods.WaitForKeyPress();
                        }
                        else
                        {
                            UIMethods.noQuizLoaded();
                            UIMethods.WaitForKeyPress();
                        }
                        break;
                    case MenuOptions.SAVEQUIZ:
                        // save quiz logic           
                        UIMethods.SaveQuizPrompt(quiz);
                        UIMethods.WaitForKeyPress();
                        break;
                    case MenuOptions.LOADQUIZ:
                        // load quiz logic
                        UIMethods.LoadQuizPrompt(quiz);
                        UIMethods.WaitForKeyPress();
                        break;
                    case MenuOptions.REMOVEQUESTION:
                        //remove question logic
                        UIMethods.DisplayAllQuizQuestions(quiz);
                        int indexToDelete = UIMethods.RemoveQuestionFromQuiz(quiz);
                        quiz.RemoveQuestion(indexToDelete);
                        UIMethods.WaitForKeyPress();
                        break;
                    case MenuOptions.EXIT:
                        isRunning = false;
                        UIMethods.WaitForKeyPress();
                        break;
                    default:
                        // invaild choice handler 
                        throw new NotImplementedException("not a option");
                }
            }
        }
    }
}