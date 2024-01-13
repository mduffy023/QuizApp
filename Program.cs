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
                    case MenuOptions.StartQuiz:
                        if (quiz.Questions.Count > 0)
                        {
                            int score = Logic.StartQuiz(quiz);
                            UIMethods.DisplayScore(score);
                            Console.WriteLine($"Your Score: {score}/{quiz.Questions.Count}");
                            Console.ReadKey(); // Wait for user input before clearing the screen
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("No quiz loaded or quiz is empty. Load or add questions to a quiz first.");
                            Console.WriteLine("Press any key to return to the menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case MenuOptions.SAVEQUIZ:
                        // save quiz logic
                        UIMethods.SaveQuizPrompt(quiz);
                        Console.Clear();
                        break;
                    case MenuOptions.LOADQUIZ:
                        // load quiz logic 
                        quiz = UIMethods.LoadQuizPrompt() ?? quiz;
                        Console.Clear();
                        break;
                    case MenuOptions.REMOVEQUESTION:
                        //remove question logic
                        UIMethods.DisplayAllQuizQuestions(quiz);
                        int indexToDelete = UIMethods.RemoveQuestionFromQuiz(quiz);
                        quiz.RemoveQuestion(indexToDelete);
                        Console.Clear();
                        break;
                        case MenuOptions.EXIT:
                        isRunning = false;
                        Console.Clear();
                        break;
                    default:
                        // invaild choice handler 
                        throw new NotImplementedException("not a option");
                }
            }
        }
    }
}