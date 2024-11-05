using Newtonsoft.Json;

public class Car
{
    public string Owner { get; set; }

    public string Number { get; set; }

    public string Company { get; set; }

    public string Model { get; set; }

    public string Color { get; set; }
}

public class Flyweight
{
    private readonly Car _sharedState;

    public Flyweight(Car sharedState)
    {
        _sharedState = sharedState;
    }
    
    public void Operation(Car uniqueState)
    {
        var s = JsonConvert.SerializeObject(_sharedState);
        var u = JsonConvert.SerializeObject(uniqueState);
        Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
    }
}

public class FlyweightFactory
{
    private readonly List<Tuple<Flyweight, string>> _flyweights = [];

    private FlyweightFactory(params Car[] args)
    {
        foreach (var elem in args)
        {
            _flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), GetKey(elem)));
        }
    }

    // Returns a Flyweight's string hash for a given state.
    private string GetKey(Car key)
    {
        List<string> elements =
        [
            key.Model,
            key.Color,
            key.Company,
            key.Number,
            key.Owner
        ];

        elements.Sort();

        return string.Join("_", elements);
    }

    // Returns an existing Flyweight with a given state or creates a new
    // one.
    private Flyweight GetFlyweight(Car sharedState)
    {
        var key = GetKey(sharedState);

        if (_flyweights.All(t => t.Item2 != key))
        {
            Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
            this._flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
        }
        else
        {
            Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
        }
        return _flyweights.Where(t => t.Item2 == key).FirstOrDefault()?.Item1;
    }

    private void ListFlyweights()
    {
        var count = _flyweights.Count;
        Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
        foreach (var flyweight in _flyweights)
        {
            Console.WriteLine(flyweight.Item2);
        }
    }
    
    static class Program
    {
        static void Main(string[] args)
        {
            // The client code usually creates a bunch of pre-populated
            // flyweights in the initialization stage of the application.
            var factory = new FlyweightFactory(
                new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
                new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
                new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
                new Car { Company = "BMW", Model = "M5", Color = "red" },
                new Car { Company = "BMW", Model = "X6", Color = "white" }
            );
            factory.ListFlyweights();

            AddCarToPoliceDatabase(factory, new Car {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "M5",
                Color = "red"
            });

            AddCarToPoliceDatabase(factory, new Car {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "X1",
                Color = "red"
            });

            factory.ListFlyweights();
        }

        private static void AddCarToPoliceDatabase(FlyweightFactory factory, Car car)
        {
            Console.WriteLine("\nClient: Adding a car to database.");

            var flyweight = factory.GetFlyweight(new Car {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            // The client code either stores or calculates extrinsic state and
            // passes it to the flyweight's methods.
            flyweight.Operation(car);
        }
    }
}