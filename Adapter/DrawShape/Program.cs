public interface IShape
{
    void Draw();
}

public class CircleShapeOf3rdLibrary
{
    public void DrawCircle(int x, int y, int radius)
    {
        Console.WriteLine($"Vẽ hình tròn tại ({x}, {y}) với bán kính {radius}");
    }
}

public class CircleShapeAdapter : IShape
{
    private readonly CircleShapeOf3rdLibrary _circleShapeOf3RdLibrary;
    private readonly int _x;
    private readonly int _y;
    private readonly int _radius;

    public CircleShapeAdapter(CircleShapeOf3rdLibrary circleShapeOf3RdLibrary, int x, int y, int radius)
    {
        _circleShapeOf3RdLibrary = circleShapeOf3RdLibrary;
        _x = x;
        _y = y;
        _radius = radius;
    }

    public void Draw()
    {
        _circleShapeOf3RdLibrary.DrawCircle(_x, _y, _radius);
    }
}

public static class Program
{
    public static void Main()
    {
        var circleShape = new CircleShapeOf3rdLibrary();
        var circleAdapter = new CircleShapeAdapter(circleShape, 10, 20, 30);

        circleAdapter.Draw();
    }
}

// Support draw circle shape from a 3rd library, this library has method DrawCircle(int x, int y, int radius) but our project need use IShape interface with Draw() method
// Use CircleShapeAdapter to convert CircleShape class with DrawCircle method to IShape interface with Draw method