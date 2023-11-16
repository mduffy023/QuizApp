using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class FileOperations
{
    //class needs to be refactored outdate method of Serialize
    public void SaveToFile(string path)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, this);
        stream.Close();
    }

    public static Quiz LoadFromFile(string path)
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        Quiz quiz = (Quiz)formatter.Deserialize(stream);
        stream.Close();
        return quiz;
    }
}
