using System.Text.Json.Serialization;
[JsonDerivedType(typeof(SimpleGoal), "A")]
[JsonDerivedType(typeof(EternalGoal), "B")]
[JsonDerivedType(typeof(ChecklistGoal), "C")]
[JsonDerivedType(typeof(AntiGoal), "D")]
public abstract class Goal
{
    protected abstract string Title { get; }
    public string Name {get; private set;}
    public string Description {get; private set;}
    public bool Completed {get; protected set;} = false;
    public int Points {get; protected set;}
    public Goal() {}

    public Goal (string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public Goal (string name, string description, bool completed, int points)
    {
        Name = name;
        Description = description;
        Completed = completed;
        Points = points;
    }

    public virtual void InitGoal()
    {
        Console.Write("What is the name of your goal? ");
        Name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        Description = Console.ReadLine();
        Console.Write("What is the amount of points assosiated with this goal? ");
        Points = int.Parse(Console.ReadLine());
        
    }

    public virtual int CheckGoal()
    {
        Completed = true;
        return Points;
    }

    public virtual string GetDisplay()
    {
        return $"[{(Completed ? "X" : " ")}] {Name} ({Description})";
    }
}