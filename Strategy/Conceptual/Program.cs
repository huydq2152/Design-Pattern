public class Context
{
    private IStrategy _strategy;

    public Context()
    {
    }

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void DoSomeBusinessLogic()
    {
        Console.WriteLine("Context: Sorting data using the strategy (not sure how it'll do it)");
        var result = this._strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

        string resultStr = string.Empty;
        foreach (var element in result as List<string>)
        {
            resultStr += element + ",";
        }

        Console.WriteLine(resultStr);
    }
}

public interface IStrategy
{
    object DoAlgorithm(object data);
}

public class ConcreteStrategyA : IStrategy
{
    public object DoAlgorithm(object data)
    {
        var list = data as List<string>;
        list.Sort();

        return list;
    }
}

public class ConcreteStrategyB : IStrategy
{
    public object DoAlgorithm(object data)
    {
        var list = data as List<string>;
        list.Sort();
        list.Reverse();

        return list;
    }
}

public static class Program
{
    public static void Main()
    {
        var context1 = new Context();

        Console.WriteLine("Client: Strategy is set to normal sorting.");
        context1.SetStrategy(new ConcreteStrategyA());
        context1.DoSomeBusinessLogic();

        Console.WriteLine();

        Console.WriteLine("Client: Strategy is set to reverse sorting.");
        context1.SetStrategy(new ConcreteStrategyB());
        context1.DoSomeBusinessLogic();

        Console.WriteLine("Client: Strategy is set to normal sorting.");
        var context2 = new Context(new ConcreteStrategyA());
        context2.DoSomeBusinessLogic();
        
        Console.WriteLine();

        Console.WriteLine("Client: Strategy is set to reverse sorting.");
        var context3 = new Context(new ConcreteStrategyB());
        context3.DoSomeBusinessLogic();
    }
}