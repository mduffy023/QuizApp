using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

public class FileOperations
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="quiz"></param>
    /// <param name="filePath"></param>
    public void SaveQuiz(Quiz quiz, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Quiz));

        using (StreamWriter fileWriter  = new StreamWriter(filePath))
        {
            serializer.Serialize(fileWriter, quiz);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public Quiz LoadQuiz(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Quiz));
        Quiz quiz;

        using (StreamReader reader = new StreamReader(filePath))
        {
            quiz = (Quiz)serializer.Deserialize(reader);
        }

        return quiz;
    }
}
