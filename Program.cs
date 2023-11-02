namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Quiz quiz = new Quiz();


            while (true)
            {
                Question question = new Question();
               quiz.Questions.Add(question);

                Console.WriteLine("Would you like to add another question? (y/n): ");
                string userResponse = Console.ReadLine();
                if (userResponse != "y")
                {
                    break;
                }
            }

            string path = "quiz.bin";
            quiz.SaveToFile(path);

            Quiz loadedQuiz = FileOperations.LoadFromFile(path);
            loadedQuiz.SelectQuiz();
        }
    }
}