using System.Text.Json.Serialization;

public class ChecklistGoal : Goal
{
    protected override string Title => "Checklist Goal";

    public int CompletedChecks {get; private set;} = 0;
    public int NeededChecks {get; private set;}
    public int BonusPoints {get; private set;}

    public ChecklistGoal() { }

    [JsonConstructor]
    public ChecklistGoal (string name, string description, bool completed, int points, int completedChecks, int neededChecks, int bonusPoints) : base(name, description, completed, points)
    {
        CompletedChecks = completedChecks;
        NeededChecks = neededChecks;
        BonusPoints = bonusPoints;
    }

    public override void InitGoal()
    {
        base.InitGoal();
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        NeededChecks = int.Parse(Console.ReadLine());
        Console.Write($"What is the bonus for completing it {NeededChecks} times? ");
        BonusPoints = int.Parse(Console.ReadLine());
    }

    public override int CheckGoal()
    {
        CompletedChecks ++;
        if (CompletedChecks == NeededChecks)
        {
            Completed = true;
            return Points + BonusPoints;
        }
        return Points;
    }

    public override string GetDisplay()
    {
        return base.GetDisplay() + $" - Currently completed: {CompletedChecks}/{NeededChecks}";
    }
}