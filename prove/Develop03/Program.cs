using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures =
        [
            new Scripture("John", 3, 16, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture("Proverbs", 3, 5, 6, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.")
        ];

        Scripture scripture = scriptures[new Random().Next(0,scriptures.Count)];
        bool loop = true;
        scripture.Display();
        while (loop)
        {
            Console.WriteLine("Press enter to continue or type 'quit' to quit");
            Console.Write("-->| ");
            if (Console.ReadLine() == "quit")
            {
                break;
            } else
            {
                loop = scripture.HideWords();
            }
            scripture.Display();
        }
    }
}

/* 
Requirements exceeded by:
 - Always hiding new words
 - Multiple scriptures that are chosen from randomly
 - Not hiding non-letter characters
*/