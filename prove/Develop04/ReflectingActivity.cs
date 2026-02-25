using static Animations;

public class ReflectingActivity : Activity
{
    protected override string Title => "Reflection Activity";

    protected override string Description => "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

    private static List<string> prompts = [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ];

    private Random random = new();

    private static List<string> questions = [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
    ];

    protected override void ActivityBehavior()
    {
        Console.WriteLine("Consider the following prompt:\n");

        Console.WriteLine($" --- {prompts[random.Next(0,prompts.Count)]} ---\n");

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they are related to this experience.");
        Console.Write("You may begin in: ");
        DisplayCountdown(5);

        Console.Clear();

        StartClock();
        while (!IsClockFinished())
        {
            Console.Write($"> {questions[random.Next(0,questions.Count)]} ");
            DisplaySpinner(10);
            Console.WriteLine();
        }
    }
}