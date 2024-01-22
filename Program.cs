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
                        UIMethods.ClearUserOutput();
                        break;
                    case MenuOptions.StartQuiz:
                        if (quiz.Questions.Count > 0)
                        {
                            int score = Logic.StartQuiz(quiz);
                            UIMethods.OutputScore(score, totalQuestions: quiz.Questions.Count);
                            UIMethods.WaitForKeyPress();
                            UIMethods.ClearUserOutput();
                        }
                        else
                        {
                            Console.WriteLine("No quiz loaded or quiz is empty. Load or add questions to a quiz first.");
                            Console.WriteLine("Press any key to return to the menu...");
                            UIMethods.WaitForKeyPress();
                            UIMethods.ClearUserOutput();
                        }
                        break;
                    case MenuOptions.SAVEQUIZ:
                        // save quiz logic
                        UIMethods.SaveQuizPrompt(quiz);
                        break;
                    case MenuOptions.LOADQUIZ:
                        // load quiz logic
                        quiz = UIMethods.LoadQuizPrompt();
                        Console.Clear();
                        break;
                    case MenuOptions.REMOVEQUESTION:
                        //remove question logic
                        UIMethods.DisplayAllQuizQuestions(quiz);
                        int indexToDelete = UIMethods.RemoveQuestionFromQuiz(quiz);
                        quiz.RemoveQuestion(indexToDelete);
                        UIMethods.ClearUserOutput();
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