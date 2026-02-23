public class Entry
{
    public DateOnly _date;
    public string _prompt;
    public string _response;

    private static string[] prompts =
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one new thing I did today?",
        "Who was one person that you helped today?" 
    }; // Technically the rubric doesn't say that I need my own prompts, but the specification does. Is that because we do not need to worry about it, or should I still double check and adhere to both?

    public static Entry NewEntry()
    {
        Entry entry = new Entry();
        entry._date = DateOnly.FromDateTime(DateTime.Now);
        entry._prompt = prompts[new Random().Next(0, prompts.Length)];
        Console.WriteLine($"Prompt: {entry._prompt}");
        Console.Write("Response: ");
        entry._response = Console.ReadLine();
        return entry;
    }

    public void Display()
    {
        Console.WriteLine($"{_date}, Prompt: {_prompt}");
        Console.WriteLine(_response);
    }
}