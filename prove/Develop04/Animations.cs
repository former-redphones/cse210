public static class Animations
{
    public static void DisplayCountdown(int seconds)
    {
        Console.Write(seconds);
        for (int i = seconds; i>0; i--)
        {
            Console.Write($"\b{i}");
            Thread.Sleep(1000);
        }
        Console.Write("\b ");
    }

    public static void DisplaySpinner(int seconds = 3)
    {
        Console.Write("\\");
        for (int i = 0 ; i<seconds; i++)
        {
            Console.Write("\b|");
            Thread.Sleep(250);
            Console.Write("\b/");
            Thread.Sleep(250);
            Console.Write("\b-");
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
        }
        Console.Write("\b \b");
    }

}