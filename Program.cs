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
                       Question newQestion =  UIMethods.GetNewQuestion();
                        quiz.AddQuestion(newQestion);
                        Console.Clear();
                        break;
                    case MenuOptions.PLAYQUIZ:
                        // play quiz logic 
                        Quiz myQuiz = new Quiz();
                        int score = UIMethods.PlayQuiz(myQuiz);
                        UIMethods.DisplayScore(score);
                        Console.WriteLine($"Your Score:{score}/{quiz.Questions.Count}");
                        Console.Clear();
                        break;
                    case MenuOptions.SAVEQUIZ:
                        // save quiz logic
                        UIMethods.SaveQuizPrompt(quiz);
                        break;
                    case MenuOptions.LOADQUIZ:
                        // load quiz logic 
                        quiz = UIMethods.LoadQuizPrompt() ?? quiz;
                        break;
                    case MenuOptions.REMOVEQUESTION:
                        //remove question logic
                        UIMethods.GetAllQuizQuestions(quiz);
                        int indexToDelete = UIMethods.RemoveQuestionFromQuiz(quiz);
                        quiz.RemoveQuestion(indexToDelete);
                        break;
                        case MenuOptions.EXIT:
                        isRunning = false;
                        Console.Clear();
                        break;
                    default:
                        // invaild choice handler 
                        throw new NotImplementedException("not a optio"); 
                }
            }
        }
    }
}