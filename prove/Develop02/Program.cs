using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        int input = 0;
        do
        {
            Console.WriteLine("1: New Entry\n"+
            "2: Display Journal\n"+
            "3: Save Journal\n"+
            "4: Load Journal\n"+
            "0: Exit");
            Console.Write("-->| ");
            try {
                input = int.Parse(Console.ReadLine());
            } catch (FormatException) {
                Console.WriteLine("That is not a number!");
                continue;
            }

            switch (input)
            {
                case 1:
                    journal._entries.Add(Entry.NewEntry());
                    break;
                case 2:
                    journal.Display();
                    break;
                case 3:
                    Console.Write("Enter journal name: ");
                    journal.WriteToFile(Console.ReadLine());
                    break;
                case 4:
                    Console.Write("Enter journal name: ");
                    journal.ReadFromFile(Console.ReadLine());
                    break;
                
                case 0:
                    break;
                default:
                    Console.WriteLine("That is not a valid option!");
                    break;
            }
        } while (input != 0);
    }
}

/*
Requirements exceeded by:
 - Using XML file storage
 - Error handling when selecting menu items
 - Well-designed date handling
 - Use of static classes/attributes
*/