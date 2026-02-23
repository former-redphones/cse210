using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter grade %: ");
        int percentage = int.Parse(Console.ReadLine());

        char letter = 'F';

        if (percentage >= 90)
        {
            letter = 'A';
        } else if (percentage >= 80)
        {
            letter = 'B';
        } else if (percentage >= 70)
        {
            letter = 'C';
        } else if (percentage >= 60)
        {
            letter = 'D';
        }

        Console.WriteLine(letter);

        if (percentage >= 70)
        {
            Console.WriteLine("You passed, congratulations!");
        } else
        {
            Console.WriteLine("You failed, maybe next time!");
        }
    }
}