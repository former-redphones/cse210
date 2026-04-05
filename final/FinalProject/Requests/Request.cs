using System.Text.Json.Serialization;

public abstract class Request
{
    public abstract string HandleRequest();
    
    [JsonIgnore]
    public abstract string Type { get; }
}