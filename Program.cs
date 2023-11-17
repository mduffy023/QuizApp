namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Quiz quiz = new Quiz();
            FileOperations fileOperations = new FileOperations();
            QuizLogic quizLogic = new QuizLogic(quiz, fileOperations);
            QuizUI ui = new QuizUI();

            QuizUI.DisplayIntro();


            //will be a switch statment inside this while loop 
            //case 1 add question
            //case 2 play quiz 
            //case 3 save quiz
            //case 4 load quiz 
            //case 5 quit
            //default will display error when choice is not bewtween 1 - 5 
            bool isRunning = true;
            while (isRunning)
            {
                int choice = QuizUI.DisplayMenu();

                switch(choice)
                {
                    case 1:
                        // add question logic 
                        break;
                    case 2:
                        // play quiz logic 
                        break; 
                    case 3:
                        // save quiz logic
                        break;
                    case 4:
                        // load quiz logic 
                        break;
                    case 5:
                    isRunning = false;
                    break;
                        default:
                        // invaild choice handler 
                        break;
                }
            }
        }
    }
}