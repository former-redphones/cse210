using System.Text.Json.Serialization;

public class EternalGoal : Goal
{
    protected override string Title => "Eternal Goal";

    [JsonConstructor]
    public EternalGoal(string name, string description, bool completed, int points) : base(name, description, completed, points) { }
    public EternalGoal() { }

    public override int CheckGoal()
    {
        return Points;
    }
}