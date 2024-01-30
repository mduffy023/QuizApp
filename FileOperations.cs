using System.Xml.Serialization;

public class FileOperations
{
    private const char YES = 'Y'; // Define YES here as well

    /// <summary>
    /// Checks if a quiz file exists at the given path and asks the user whether to overwrite it.
    /// If the file doesn't exist or the user chooses to overwrite, the quiz is saved.
    /// </summary>
    /// <param name="quiz">The Quiz object that should be saved.</param>
    /// <param name="filePath">The file path where the quiz should be saved.</param>
    public static void CheckAndSaveQuiz(Quiz quiz, string filePath)
    {
        if (File.Exists(filePath))
        {
            Console.WriteLine("\nFile already exists. Overwrite? Y or N");
            char overwritePrompt = Console.ReadKey().KeyChar;
            if (char.ToUpper(overwritePrompt) == YES)
            {
                SaveQuiz(quiz, filePath);
                Console.WriteLine("\nQuiz has been saved.");
            }
            else
            {
                Console.WriteLine("\nOverwrite cancelled. Returning to menu.");
            }
        }
        else
        {
            SaveQuiz(quiz, filePath);
            Console.WriteLine("\nQuiz has been saved.");
        }
    }

    /// <summary>
    /// Serializes a Quiz object into an XML format and saves it to the specified file path.
    /// </summary>
    /// <param name="quiz">The Quiz object to be serialized and saved.</param>
    /// <param name="filePath">The file path where the serialized Quiz object will be saved.</param>
    public static void SaveQuiz(Quiz quiz, string filePath)
    {

        XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, quiz);
        }
        Console.WriteLine("Quiz has been saved successfully.");
    }

    /// <summary>
    /// Verifies the existence of the specified file path and attempts to load a quiz from it.
    /// </summary>
    /// <param name="quiz">The Quiz object that will be updated with the loaded quiz data.</param>
    /// <param name="filePath">The file path from which the quiz is to be loaded.</param>
    public static void CheckAndLoadQuiz(Quiz quiz, string filePath)
    {
        filePath = filePath.Trim('"').Trim(); // Removes quotation marks and extra spaces
        if (!File.Exists(filePath))
        {
            Console.WriteLine("\nFile not found. Please ensure the file path is correct.");
            return;
        }

        try
        {
            Quiz loadedQuiz = LoadQuiz(filePath);
            if (loadedQuiz != null)
            {
                quiz.Questions = loadedQuiz.Questions; // Update the quiz reference with the loaded quiz
                Console.WriteLine("\nQuiz has been loaded.");
            }
            else
            {
                Console.WriteLine("\nFailed to load the quiz.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nFailed to load the quiz: {ex.Message}");
        }
    }

    /// <summary>
    /// Deserializes an XML file from the specified file path into a Quiz object.
    /// </summary>
    /// <param name="filePath">The file path of the XML file to be deserialized.</param>
    /// <returns>A Quiz object reconstructed from the XML file.</returns>
    public static Quiz LoadQuiz(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
        using (StreamReader reader = new StreamReader(filePath))
        {
            Quiz quiz = (Quiz)serializer.Deserialize(reader);
            Console.WriteLine("Quiz has been loaded successfully.");
            return quiz;
        }
    }
}
