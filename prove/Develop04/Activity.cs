using static Animations;

public abstract class Activity
{
    protected abstract string Title { get; }
    protected abstract string Description { get; }
    private int _duration;
    private DateTime _endTime;

    protected void StartClock()
    {
        _endTime = DateTime.Now.AddSeconds(_duration);
    }

    protected bool IsClockFinished()
    {
        // Returns "true" if _endTime unset
        return DateTime.Now >= _endTime;
    }

    private void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {Title}.\n");
        Console.WriteLine($"{Description}\n");
        _duration = 0;
        do {
            try {
                Console.Write("How long, in seconds, would you like for your session? ");
                _duration = int.Parse(Console.ReadLine());
                break;
            } catch (FormatException)
            {
                Console.WriteLine("That is not a valid number!");
            }
        } while (_duration == 0);

        Console.Clear();
        Console.Write("Get ready...");
        DisplaySpinner();
        Console.WriteLine("\n\n");
    }

    private void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!");
        DisplaySpinner();
        Console.WriteLine($"You have completed another {_duration} seconds of {Title}.");
        DisplaySpinner();
    }
    protected abstract void ActivityBehavior();

    public void StartActivity()
    {
        DisplayStartMessage();
        ActivityBehavior();
        DisplayEndMessage();
    }
}