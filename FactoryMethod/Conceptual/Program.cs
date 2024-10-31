using Conceptual.Creators;

void ClientCode(Creator creator)
{
    Console.WriteLine($"Client: I'm not aware of the creator's class, but it still works. {creator.SomeOperation()}");
}

Console.WriteLine("Launched with the ConcreteCreator1");
ClientCode(new ConcreteCreator1());

Console.WriteLine("Launched with the ConcreteCreator2");
ClientCode(new ConcreteCreator2());