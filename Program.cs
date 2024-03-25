using System;

public interface IResizeable
{
    void Resize(double percent);
    double Area();
}

public class Circle : IResizeable
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public void Resize(double percent)
    {
        Radius *= percent / 100.0;
    }
}

public class Rectangle : IResizeable
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Area()
    {
        return Width * Height;
    }

    public void Resize(double percent)
    {
        Width *= percent / 100.0;
        Height *= percent / 100.0;
    }
}

public class Square : IResizeable
{
    public double Side { get; set; }

    public Square(double side)
    {
        Side = side;
    }

    public double Area()
    {
        return Math.Pow(Side, 2);
    }

    public void Resize(double percent)
    {
        Side *= percent / 100.0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        IResizeable[] shapes = {
            new Circle(5),
            new Rectangle(4, 5),
            new Square(6)
        };

        foreach (var shape in shapes)
        {
            double originalArea = shape.Area();
            double resizePercent = rand.Next(1, 101);
            shape.Resize(resizePercent);
            double newArea = shape.Area();
            Console.WriteLine($"Original area: {originalArea}, after resizing: {newArea}");
            Console.ReadKey();
        }
    }
}