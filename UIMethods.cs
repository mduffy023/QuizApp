public class UIMethods
{
    public const int choiceLimit = 4;
    public static void DisplayIntro()
    {
        Console.WriteLine("Welcome to the Quiz Maker! ");
    }

    public static int DisplayMenu()
    {
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Add a New Question");
        Console.WriteLine("2. Delete a Question");
        Console.WriteLine("3. Play Quiz");
        Console.WriteLine("4. Save the quiz");
        Console.WriteLine("5.");
        Console.WriteLine("0.");
        return int.Parse(Console.ReadLine());
    }

    public static Question GetNewQuestion()
    {
        Console.WriteLine("Enter the Question:");
        string usersQuestion = Console.ReadLine();

        List<string> userChoices = new List<string>();
        for (int i = 0; i < choiceLimit; i++)
        {
            Console.WriteLine($"Enter Choice {i + 1}");
            userChoices.Add(Console.ReadLine());
        }

        Console.WriteLine("enter the Correct answeer, separet by comm, if multiple: ");
        List<string> correctAnwers = Console.ReadLine().Split(',').Select(a => a.Trim()).ToList();

        return new Question(usersQuestion, userChoices, correctAnwers);
    }

    public void GetAllQuestions()
    {

    }

 
}
