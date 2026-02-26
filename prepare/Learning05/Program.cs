using System;
using System.Drawing;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> shapes = [
            new Square("blue", 3),
            new Rectangle("red", 2, 4),
            new Circle("green", 8)
        ];
        foreach (Shape shape in shapes) {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
            Console.WriteLine();
        }

    }
}