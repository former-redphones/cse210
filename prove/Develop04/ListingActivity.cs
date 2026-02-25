using static Animations;

public class ListingActivity : Activity
{
    protected override string Title => "Listing Activity";

    protected override string Description => "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    private static List<string> prompts = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ];

    private Random random = new();

    protected override void ActivityBehavior()
    {
        Console.WriteLine("Consider the following prompt:\n");

        Console.WriteLine($" --- {prompts[random.Next(0,prompts.Count)]} ---\n");

        Console.Write("You may begin in: ");
        int items = 0;
        DisplayCountdown(5);
        Console.WriteLine();
        StartClock();
        while (!IsClockFinished()) {
            Console.Write("> ");
            Console.ReadLine();
            items++;
        }
        Console.WriteLine($"You listed {items} items!");
    }
}