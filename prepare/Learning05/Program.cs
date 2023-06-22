using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square shape1 = new Square(5, "red");
        shapes.Add(shape1);
        Rectangle shape2 = new Rectangle(5, 10, "blue");
        shapes.Add(shape2);
        Circle shape3 = new Circle(5, "green");
        shapes.Add(shape3);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}");
        }
    }
}