public class Scripture
{
    private List<Word> _scripture = new List<Word>();

    private int hidden = 0;

    public Reference _reference;

    private Random random = new Random();

    public Scripture() {}

    public Scripture (string book, int chapter, int verse, string text)
    {
        _reference = new Reference(book, chapter, verse);
        ParseScripture(text);
    }

    public Scripture (string book, int chapter, int startVerse, int endVerse, string text)
    {
        _reference = new Reference(book, chapter, startVerse, endVerse);
        ParseScripture(text);
    }

    public void ParseScripture(string text)
    {
        _scripture.Clear();
        string[] words = text.Split(" ");
        for (int i=0; i<words.Length; i++)
        {
            _scripture.Add(new Word(words[i]));
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.Write($"{_reference.GetString()}:");
        for (int i=0; i<_scripture.Count; i++)
        {
            Console.Write($" {_scripture[i].String}");
        }
        Console.WriteLine();
    }

    public bool IsCompletelyHidden()
    {
        return hidden == _scripture.Count;
    }

    public bool HideWords(int count = 3)
    {
        int i;
        while (count != 0 && hidden < _scripture.Count)
        {
            i = random.Next(0,_scripture.Count);
            if (!_scripture[i].CheckHidden())
            {
                _scripture[i].Hide();
                count--;
                hidden ++;
            }
        }
        return hidden != _scripture.Count;
    }


}