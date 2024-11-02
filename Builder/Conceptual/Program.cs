public class Product
{
    private readonly List<string> _parts = new List<string>();

    public void Add(string part)
    {
        _parts.Add(part);
    }

    public string GetParts()
    {
        var result = string.Empty;
        foreach (var part in _parts)
        {
            result += $"{part}, ";
        }

        result.Remove(result.Length - 2);

        return $"Product parts: {result} \n";
    }
}

public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
}

public class ConcreteBuilder1 : IBuilder
{
    private Product _product = new Product();

    public void BuildPartA()
    {
        _product.Add("PartA1");
    }

    public void BuildPartB()
    {
        _product.Add("PartB1");
    }

    public void BuildPartC()
    {
        _product.Add("PartC1");
    }

    private void Reset()
    {
        _product = new Product();
    }

    public Product GetProduct()
    {
        var result = _product;
        Reset();
        return result;
    }
}

public class Director
{
    private IBuilder _builder1;

    public IBuilder Builder1
    {
        set => _builder1 = value;
    }

    public void Builder1JustHaveAProduct()
    {
        _builder1.BuildPartA();
    }

    public void Builder1FullPartsProduct()
    {
        _builder1.BuildPartA();
        _builder1.BuildPartB();
        _builder1.BuildPartC();
    }
}

class Program
{
    static void Main()
    {
        var director = new Director();
        var builder1 = new ConcreteBuilder1();
        director.Builder1 = builder1;

        Console.WriteLine("Builder1 Just Have A Product:");
        director.Builder1JustHaveAProduct();
        Console.WriteLine(builder1.GetProduct().GetParts());

        Console.WriteLine("Standard full featured product:");
        director.Builder1FullPartsProduct();
        Console.WriteLine(builder1.GetProduct().GetParts());

        // Remember, the Builder pattern can be used without a Director class.
        Console.WriteLine("Custom product:");
        builder1.BuildPartA();
        builder1.BuildPartC();
        Console.Write(builder1.GetProduct().GetParts());
    }
}

// Can improve by add more concrete builder like ConcreteBuilder2, ConcreteBuilder3, ... to have multiple Builders with multiple Build methods to build multiple Products