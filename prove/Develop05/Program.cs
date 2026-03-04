using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new();
        int points = 0;
        int input;
        do
        {
            Console.WriteLine($"\n\nYou have {points} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Create New Goal"); // Stretch idea: make menu selecting method or class
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Save Goals");
            Console.WriteLine("\t4. Load Goals");
            Console.WriteLine("\t5. Record Event");
            Console.WriteLine("\t6. Delete Goal");
            Console.WriteLine("\t7. Goal Info");
            Console.WriteLine("\t0. Quit");
            Console.Write("Select a choice from the menu: ");
            input = int.TryParse(Console.ReadLine(), out input) ? input : -1; // Default to -1 if non-integer input

            switch (input)
            {
                case 1: // CREATE NEW GOAL
                    CreateNewGoal(goals);
                    break;

                case 2: // LIST GOALS
                    Console.WriteLine("The goals are:");
                    for (int i = 0; i<goals.Count; i++)
                    {
                        Console.WriteLine($"{i+1}. {goals[i].GetDisplay()}");
                    }
                    break;
                
                case 3: // SAVE GOALS
                    Console.Write("Enter filename: ");
                    string filename = Console.ReadLine();
                    Directory.CreateDirectory("goals");
                    File.WriteAllText(Path.Join("goals",filename+".json"), JsonSerializer.Serialize(new SaveData{Goals = goals, Points = points}));
                    break;

                case 4: // LOAD GOALS
                    Console.Write("Enter filename: ");
                    filename = Console.ReadLine();
                    try {
                        SaveData saveData = JsonSerializer.Deserialize<SaveData>(File.ReadAllText(Path.Join("goals",filename+".json")));
                        goals = saveData.Goals;
                        points = saveData.Points;
                    } catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
                    {
                        Console.WriteLine("That file does not exist!");
                    }
                    break;

                case 5:
                    points += RecordGoal(goals);
                    Console.WriteLine($"You now have {points} points.");
                    break;

                case 6:
                    DeleteGoal(goals);
                    break;

                case 7:
                    Console.WriteLine("Goal types:");
                    Console.WriteLine("\tSimple goal: a goal meant to be checked once");
                    Console.WriteLine("\tEternal goal: a goal that can be checked infinitely");
                    Console.WriteLine("\tChecklist goal: a goal that can be checked a specified amount of times");
                    Console.WriteLine("\tAnti goal: a goal that takes away points");
                    break;

                case 0:
                    continue;

                default:
                    Console.WriteLine("That is not a valid menu option!");
                    continue;
            }
        } while (input != 0);
    }

    private static void CreateNewGoal(List<Goal> goals)
    {
        int input;
        Goal goal;
        do
        {
            Console.WriteLine("The types of goal are:");
            Console.WriteLine("\t1. Simple Goal");
            Console.WriteLine("\t2. Eternal Goal");
            Console.WriteLine("\t3. Checklist Goal");
            Console.WriteLine("\t4. Anti Goal");
            Console.Write("Select a choice from the menu: ");
            input = int.TryParse(Console.ReadLine(), out input) ? input : 0; // Default to 0 if non-integer input
            switch (input)
            {
                case 1:
                    goal = new SimpleGoal();
                    break;

                case 2:
                    goal = new EternalGoal();
                    break;
                    
                case 3:
                    goal = new ChecklistGoal();
                    break;

                case 4:
                    goal = new AntiGoal();
                    break;

                default:
                    Console.WriteLine("That is not a valid menu option!");
                    continue;
            }
            goal.InitGoal();
            goals.Add(goal);
        } while (input < 1 || input > 3);
    }

    private static int RecordGoal(List<Goal> goals)
    {
        int input;
        int points = 0;
        do
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i<goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {goals[i].Name}");
            }
            Console.WriteLine("Type 0 to quit");
            Console.Write("What goal did you accomplish? ");
            input = int.TryParse(Console.ReadLine(), out input) ? input : 0; // Default to 0 if non-integer input
            if (0 < input && input <= goals.Count)
            {
                points = goals[input-1].CheckGoal();

            } else if (input == 0)
            {
                return 0;

            } else
            {
                Console.WriteLine("That is not a valid menu item!");
            }
        } while (0 >= input || input > goals.Count);
        if (points >= 0) {
            Console.WriteLine($"Congratulations! You have earned {points} points!");
        } else
        {
            Console.WriteLine($"You lost {-points} points.");
        }
        return points;
    }

    private static void DeleteGoal(List<Goal> goals)
    {
        int input;
        int goalCount = goals.Count;
        do
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i<goalCount; i++)
            {
                Console.WriteLine($"{i+1}. {goals[i].Name}");
            }
            Console.WriteLine("Type 0 to quit");
            Console.Write("What goal do you want to remove? ");
            input = int.TryParse(Console.ReadLine(), out input) ? input : 0; // Default to 0 if non-integer input
            if (0 < input && input <= goalCount)
            {
                goals.Remove(goals[input-1]);

            } else if (0 == input)
            {
                return;
            } else
            {
                Console.WriteLine("That is not a valid menu item!");
            }
        } while (0 >= input || input > goalCount);
    }
}

/*
Requirement exceeded by:
 - Custom SaveData class for serializing data efficiently
 - New Anti-Goal (negative points)
 - Additional menu option with goal information
 - Ability to remove goals
 - Ability to quit out of some sub menus
 */