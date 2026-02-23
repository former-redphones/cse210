using System;

class Program
{
    static void Main(string[] args)
    {
        int number = new Random().Next(1,101);
        int guess;
        do
        {
            Console.Write("Enter guess: ");
            guess = int.Parse(Console.ReadLine());
            if (guess > number)
            {
                System.Console.WriteLine("Lower");
            } else if (guess < number)
            {
                System.Console.WriteLine("Higher");
            }

        } while (guess != number);
        Console.WriteLine("You guessed it!");
    }
}