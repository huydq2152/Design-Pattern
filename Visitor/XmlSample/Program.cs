public interface IXmlNode
{
    void Accept(IXmlVisitor visitor);
}

public class XmlElement : IXmlNode
{
    public string Name { get; set; }
    public string Text { get; set; }
    public List<IXmlNode> Children { get; set; } = new List<IXmlNode>();

    public void Accept(IXmlVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class XmlAttribute : IXmlNode
{
    public string Name { get; set; }
    public string Value { get; set; }

    public void Accept(IXmlVisitor visitor)
    {
        visitor.Visit(this);
    }
}


public interface IXmlVisitor
{
    void Visit(XmlElement element);
    void Visit(XmlAttribute attribute);
}

public class XmlPrintingVisitor : IXmlVisitor
{
    public void Visit(XmlElement element)
    {
        Console.WriteLine($"<{element.Name}>");
        foreach (var child in element.Children)
        {
            child.Accept(this);
        }
        Console.WriteLine($"</{element.Name}>");
    }

    public void Visit(XmlAttribute attribute)
    {
        Console.WriteLine($" {attribute.Name}=\"{attribute.Value}\"");
    }
}

public class XmlSearchingVisitor : IXmlVisitor
{
    private readonly string _targetName;

    public XmlSearchingVisitor(string targetName)
    {
        _targetName = targetName;
    }

    public void Visit(XmlElement element)
    {
        if (element.Name == _targetName)
        {
            Console.WriteLine($"Found element: {element.Name}");
        }
        foreach (var child in element.Children)
        {
            child.Accept(this);
        }
    }

    public void Visit(XmlAttribute attribute)
    {
        if (attribute.Name == _targetName)
        {
            Console.WriteLine($"Found attribute: {attribute.Name}");
        }
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        var root = new XmlElement { Name = "root" };
        root.Children.Add(new XmlAttribute { Name = "id", Value = "1" });
        root.Children.Add(new XmlElement { Name = "child", Text = "text" });
        
        var printingVisitor = new XmlPrintingVisitor();
        root.Accept(printingVisitor);

        Console.WriteLine();
        
        var searchingVisitor = new XmlSearchingVisitor("child");
        root.Accept(searchingVisitor);
    }
}