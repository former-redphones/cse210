using System.Text.Json.Serialization;

public class SimpleMessage :  Request
{
    public string _message {get; set;}

    public const string RequestName = "test-json";     // static access
    public override string Type => RequestName; // instance access

    public override string HandleRequest()
    {
        Console.WriteLine("proper test json eh?");
        Console.WriteLine($"test boy here says {_message}");
        return $"Message recieved: {_message}";
    }
}
