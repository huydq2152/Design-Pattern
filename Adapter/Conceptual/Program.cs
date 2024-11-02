﻿public interface ITarget
{
    string GetRequest();
}

public class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Specific Request.";
    }
}

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public string GetRequest()
    {
        return $"This is '{_adaptee.GetSpecificRequest()}'";
    }
}

public class Program
{
    static void Main()
    {
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);

        Console.WriteLine("Adaptee interface is incompatible with the client.");
        Console.WriteLine("But with adapter client can call it's method.");

        Console.WriteLine(target.GetRequest());
    }
}

// client want to use GetRequest() of ITarget interface instead of GetSpecificRequest() of Adaptee