using System;

class Program
{
    static void Main(string[] args)
    {
        // Fraction one = new Fraction();
        // Fraction five = new Fraction(5);
        // Fraction three = new Fraction(3,4);
        // Fraction third = new Fraction(1,3);

        // Console.WriteLine(one.GetFractionString());
        // Console.WriteLine(one.GetDecimalValue());
        // Console.WriteLine(five.GetFractionString());
        // Console.WriteLine(five.GetDecimalValue());
        // Console.WriteLine(three.GetFractionString());
        // Console.WriteLine(three.GetDecimalValue());
        // Console.WriteLine(third.GetFractionString());
        // Console.WriteLine(third.GetDecimalValue());

        Random random = new Random();
        Fraction fraction = new Fraction();
        for (int i = 0; i<21; i++)
        {
            fraction.SetTop(random.Next());
            fraction.SetBottom(random.Next());
            Console.WriteLine($"Fraction {i+1}: string: {fraction.GetFractionString()} Number: {fraction.GetDecimalValue()}");
        }
    }
}