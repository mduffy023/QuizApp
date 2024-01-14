using System.Xml.Serialization;

public class FileOperations
{
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
