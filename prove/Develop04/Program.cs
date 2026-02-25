using static Animations;

class Program
{
    static void Main(string[] args)
    {
        Activity activity;
        int input;
        do
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Start Breathing Activity");
            Console.WriteLine("\t2. Start Reflecting Activity");
            Console.WriteLine("\t3. Start Listening Activity");
            Console.WriteLine("\t0. Quit");
            Console.Write("Select a choice from the menu: ");
            input = int.TryParse(Console.ReadLine(), out input) ? input : -1; // Default to -1 if non-integer input

            switch (input)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectingActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;

                case 0:
                    continue;

                default:
                    Console.WriteLine("That is not a valid menu option!");
                    DisplaySpinner();
                    continue;
            }

            activity.StartActivity();
        } while (input != 0);
    }
}

/*
Requirements exceeded by:
 - Adding error handling for duration input
 - Efficient (and cool) error handling in menu
 - Containing animations in an additional static class
*/