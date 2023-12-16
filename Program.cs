using static Menu;

namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Quiz quiz = new Quiz();
            Logic logic = new Logic(quiz);
            UIMethods uiMethods = new UIMethods(logic);

            UIMethods.DisplayIntro();

            bool isRunning = true;
            while (isRunning)
            {
                int choice = UIMethods.DisplayMenu();

                MenuOptions menuOptions = (MenuOptions)choice;

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
                        UIMethods.PlayQuiz(myQuiz);
                        Console.Clear();
                        break;
                    case MenuOptions.SAVEQUIZ:
                        // save quiz logic
                        uiMethods.SaveQuizPrompt(); 
                        break;
                    case MenuOptions.LOADQUIZ:
                        // load quiz logic 
                        uiMethods.LoadQuizPrompt();
                        break;
                    case MenuOptions.REMOVEQUESTION:
                        //remove question logic
                        uiMethods.GetAllQuizQuestions();
                        int indexToDelete = uiMethods.RemoveQuestionFromQuiz();
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