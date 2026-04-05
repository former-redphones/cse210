using System.Text.Json.Serialization;

public class Counter :  Request
{
    private int _count = 0;
    public int GetCount => _count;

    public const string RequestName = "counter";     // static access
    public override string Type => RequestName; // instance access

    public override string HandleRequest()
    {
        Console.WriteLine("ticky here wants to tick");
        IncrementCount();
        Console.WriteLine($"its counted to {_count}");
        return $"New counter value: {_count}";
    }

    private int IncrementCount()
    {
        _count++;
        return _count;
    }
}