public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        System.Console.WriteLine($"Name: {_name}");
        System.Console.WriteLine("Jobs:");
        for (int i = 0; i < _jobs.Count; i++)
        {
            _jobs[i].Display();
        }
    }
}