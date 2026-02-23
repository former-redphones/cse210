using System.Xml.Serialization;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void Display()
    {
        Console.WriteLine("Entries:");
        for (int i = 0; i < _entries.Count; i++)
        {
            _entries[i].Display();
            Console.WriteLine();
        }
    }

    public void WriteToFile(string filename)
    {
        Directory.CreateDirectory("journals");
        XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
        using (TextWriter writer = new StreamWriter(Path.Join("journals",filename+".xml")))
        {
            serializer.Serialize(writer, _entries);
        }
    }

    public void ReadFromFile(string filename)
    {
        try {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
            using (TextReader reader = new StreamReader(Path.Join("journals",filename+".xml")))
            {
                _entries = (List<Entry>)serializer.Deserialize(reader);
            }
        } catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
        {
            Console.WriteLine("That file does not exist!");
        }
    }
}