namespace Conceptual.Creators;

public class ConcreteCreator2: Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct2();
    }
}