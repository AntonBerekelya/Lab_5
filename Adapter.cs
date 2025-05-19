using System;

public interface ITextFormat
{
    void Read();
}

public class TxtReader
{
    public void ReadTxt() => Console.WriteLine("Reading TXT file...");
}

public class JsonReader
{
    public void ReadJson() => Console.WriteLine("Reading JSON file...");
}

public class XmlReader
{
    public void ReadXml() => Console.WriteLine("Reading XML file...");
}

public class TextFormatAdapter : ITextFormat
{
    private readonly object _format;

    public TextFormatAdapter(object format)
    {
        _format = format;
    }

    public void Read()
    {
        switch (_format)
        {
            case TxtReader txt:
                txt.ReadTxt();
                break;
            case JsonReader json:
                json.ReadJson();
                break;
            case XmlReader xml:
                xml.ReadXml();
                break;
            default:
                Console.WriteLine("Unsupported format.");
                break;
        }
    }
}
