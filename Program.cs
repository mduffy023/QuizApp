using static Menu;

namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Quiz quiz = new Quiz();
            FileOperations fileOperations = new FileOperations();
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
                        logic.AddQuestion(newQestion);
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

                        break;
                    case MenuOptions.LOADQUIZ:
                        // load quiz logic 
                       
                        break;
                    case MenuOptions.REMOVEQUESTION:
                        //remove question logic
                        uiMethods.GetAllQuizQuestions();
                        int indexToDelete = uiMethods.RemoveQuestionFromQuiz();
                        logic.RemoveQuestion(indexToDelete);
                        break;
                        case MenuOptions.EXIT:
                        isRunning = false;
                        Console.Clear();
                        break;
                    default:
                        // invaild choice handler 
                        break;
                }
            }
        }
    }
}