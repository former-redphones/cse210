using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int year;
        PromptUserBirthYear(out year);
        DisplayResult(name, SquareNumber(number), year);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static void PromptUserBirthYear(out int year)
    {
        Console.Write("Please enter the year your were born: ");
        year = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int a)
    {
        return a*a;
    }

    static void DisplayResult(string name, int number, int year)
    {
        System.Console.WriteLine($"{name}, the square of your number is {number}");
        System.Console.WriteLine($"{name}, you are turning {DateTime.Now.Year-year} this year");
    }
}