namespace Conceptual;

public class Singleton
{
    private Singleton()
    {
    }

    private static Singleton? _instance;
    private static readonly object Lock = new object();
    public string Value { get; set; }

    public static Singleton GetInstance(string value)
    {
        if (_instance is null)
        {
            lock (Lock)
            {
                _instance ??= new Singleton
                {
                    Value = value
                };
            }
        }

        return _instance;
    }
}