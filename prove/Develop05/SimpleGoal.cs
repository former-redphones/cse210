using System.Text.Json.Serialization;

public class SimpleGoal : Goal
{
    protected override string Title => "Simple Goal";

    [JsonConstructor]
    public SimpleGoal(string name, string description, bool completed, int points) : base(name, description, completed, points) { }
    public SimpleGoal() { }
}