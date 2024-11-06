public class Receiver
{
    public void DoA(string a)
    {
        Console.WriteLine($"Receiver: Working on ({a}.)");
    }

    public void DoB(string b)
    {
        Console.WriteLine($"Receiver: Working on ({b}.)");
    }
}

public interface ICommand
{
    void Execute();
}

public class SimpleCommand : ICommand
{
    private readonly string _payload;

    public SimpleCommand(string payload)
    {
        _payload = payload;
    }

    public void Execute()
    {
        Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({_payload})");
    }
}

public class ComplexCommand : ICommand
{
    private readonly Receiver _receiver;
    private readonly string _a;
    private readonly string _b;

    public ComplexCommand(Receiver receiver, string a, string b)
    {
        _receiver = receiver;
        _a = a;
        _b = b;
    }

    public void Execute()
    {
        Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
        _receiver.DoA(_a);
        _receiver.DoB(_b);
    }
}

public class Invoker
{
    private ICommand _onStart;

    private ICommand _onFinish;

    public void SetOnStart(ICommand command)
    {
        _onStart = command;
    }

    public void SetOnFinish(ICommand command)
    {
        _onFinish = command;
    }

    public void DoSomethingImportant()
    {
        Console.WriteLine("Invoker: Does anybody want something done before I begin?");
        if (_onStart is ICommand)
        {
            _onStart.Execute();
        }
            
        Console.WriteLine("Invoker: ...doing something really important...");
            
        Console.WriteLine("Invoker: Does anybody want something done after I finish?");
        if (_onFinish is ICommand)
        {
            _onFinish.Execute();
        }
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        // The client code can parameterize an invoker with any commands.
        Invoker invoker = new Invoker();
        invoker.SetOnStart(new SimpleCommand("Say Hi!"));
        Receiver receiver = new Receiver();
        invoker.SetOnFinish(new ComplexCommand(receiver, "Send email", "Save report"));

        invoker.DoSomethingImportant();
    }
}