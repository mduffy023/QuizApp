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
            while (true)
            {

            }
        }
    }
}