using System;

class Program
{
    static void Main(string[] args)
    {
        int number;
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        do
        {
            Console.Write("-->| ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        int max = 0;
        int sum = 0;
        for (int i = 0; i<numbers.Count; i++)
        {
            if (numbers[i] > max || max == 0)
            {
                max = numbers[i];
            }
            sum += numbers[i];
        }

        System.Console.WriteLine($"The sum is {sum}");
        System.Console.WriteLine($"The average is {sum/numbers.Count}");
        System.Console.WriteLine($"The largest number is {max}");
    }
}