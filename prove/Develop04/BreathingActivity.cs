using static Animations;

public class BreathingActivity : Activity
{
    protected override string Title => "Breathing Activity";
    protected override string Description => "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

    protected override void ActivityBehavior()
    {
        StartClock();
        while (!IsClockFinished()) {
            Console.Write("Breathe in...");
            DisplayCountdown(4);
            Console.WriteLine();
            Console.Write("Now breathe out...");
            DisplayCountdown(4);
            Console.WriteLine("\n");
        }
    }
}