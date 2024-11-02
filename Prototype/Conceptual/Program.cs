public class Person
{
    public int Age;
    public DateTime DoB;
    public string Name;
    public IdInfo IdInfo;

    public Person ShallowCopy()
    {
        return (Person)MemberwiseClone();
    }

    public Person DeepCopy()
    {
        var result = (Person)MemberwiseClone();
        result.IdInfo = new IdInfo(IdInfo.IdNumber);
        result.Name = Name;

        return result;
    }
}

public class IdInfo
{
    public int IdNumber;

    public IdInfo(int idNumber)
    {
        IdNumber = idNumber;
    }
}

static class Program
{
    public static void Main()
    {
        var p1 = new Person
        {
            Age = 42,
            DoB = Convert.ToDateTime("1977-01-01"),
            Name = "Jack Daniels",
            IdInfo = new IdInfo(666)
        };

        // Perform a shallow copy of p1 and assign it to p2.
        var p2 = p1.ShallowCopy();
        // Make a deep copy of p1 and assign it to p3.
        var p3 = p1.DeepCopy();

        // Display values of p1, p2 and p3.
        Console.WriteLine("Original values of p1, p2, p3:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(p1);
        Console.WriteLine("   p2 instance values:");
        DisplayValues(p2);
        Console.WriteLine("   p3 instance values:");
        DisplayValues(p3);

        // Change the value of p1 properties and display the values of p1,
        // p2 and p3.
        p1.Age = 32;
        p1.DoB = Convert.ToDateTime("1900-01-01");
        p1.Name = "Frank";
        p1.IdInfo.IdNumber = 7878;
        Console.WriteLine("\nValues of p1, p2 and p3 after changes p1:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(p1);
        Console.WriteLine("   p2 instance values (reference values have changed):");
        DisplayValues(p2);
        Console.WriteLine("   p3 instance values (everything was kept the same):");
        DisplayValues(p3);
    }

    private static void DisplayValues(Person p)
    {
        Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
            p.Name, p.Age, p.DoB);
        Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
    }
}

// With shallow copy, clone object just copy memory address of all reference type properties of original object
// So if original object change any reference type property, the value of memory address will change -> corresponding property of clone object will change value like original object
// With deep copy, it'll copy all property value (both value type and reference type ) of original object to clone object  -> corresponding property of clone object will not change value