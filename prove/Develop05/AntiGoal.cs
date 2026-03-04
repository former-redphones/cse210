using System.Text.Json.Serialization;

public class AntiGoal : Goal
{
    protected override string Title => "Anti Goal";

    [JsonConstructor]
    public AntiGoal(string name, string description, bool completed, int points) : base(name, description, completed, points) { }
    public AntiGoal() { }

    public override int CheckGoal()
    {
        return -Points;
    }
}