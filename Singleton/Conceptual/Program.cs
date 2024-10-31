using Conceptual;

static void TestSingleton(string value)
{
    var singleton = Singleton.GetInstance(value);
    Console.WriteLine($"Current singleton value is {singleton.Value}");
}

var process1 = new Thread(() => TestSingleton("process1"));
var process2 = new Thread(() => TestSingleton("process2"));

process1.Start();
process2.Start();

process1.Join();
process2.Join();