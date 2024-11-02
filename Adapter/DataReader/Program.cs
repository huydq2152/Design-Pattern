using System.Data;

public interface IDataReader
{
    DataSet ReadData(string filePath);
}

public class XmlReader 
{
    public DataSet ReadXml(string filePath)
    {
        // Read data from XML file and return a DataSet
        Console.WriteLine("Get DataSet From XML");
        return new DataSet();
    }
}

public class JsonReader 
{
    public DataSet ReadJson(string filePath)
    {
        // Read data from JSON file and return a DataSet
        Console.WriteLine("Get DataSet From JSON");
        return new DataSet();
    }
}

public class XmlDataReaderAdapter : IDataReader
{
    private readonly XmlReader _xmlReader;

    public XmlDataReaderAdapter(XmlReader xmlReader)
    {
        _xmlReader = xmlReader;
    }

    public DataSet ReadData(string filePath)
    {
        return _xmlReader.ReadXml(filePath);
    }
}

public class JsonDataReaderAdapter : IDataReader
{
    private readonly JsonReader _jsonReader;

    public JsonDataReaderAdapter(JsonReader jsonReader)
    {
        _jsonReader = jsonReader;
    }

    public DataSet ReadData(string filePath)
    {
        return _jsonReader.ReadJson(filePath);
    }
}

public static class Program
{
    public static void Main()
    {
        var xmlFilePath = "data.xml";
        var jsonFilePath = "data.json";

        // Use XmlDataReaderAdapter
        IDataReader xmlReader = new XmlDataReaderAdapter(new XmlReader());
        var xmlData = xmlReader.ReadData(xmlFilePath);

        // Use JsonDataReaderAdapter
        IDataReader jsonReader = new JsonDataReaderAdapter(new JsonReader());
        var jsonData = jsonReader.ReadData(jsonFilePath);
    }
}

// This project need to read data from multiple source data type: JSON, XML, ...
// Use IDataReader interface and ReadData method of this interface to get DataSet in multiple file type