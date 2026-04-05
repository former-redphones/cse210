using System.Text.Json.Serialization;

public class Ping :  Request
{
    public DateTime Sent {get; set;}

    public const string RequestName = "ping";     // static access
    public override string Type => RequestName; // instance access

    public override string HandleRequest()
    {
        return Sent.ToBinary().ToString();
    }

    public Ping()
    {
        Sent = DateTime.UtcNow;
    }
}
