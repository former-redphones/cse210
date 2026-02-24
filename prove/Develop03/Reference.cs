public class Reference
{
    private string _book;
    private int _chapter;
    private string _verses;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verses = verse.ToString();
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verses = $"{startVerse}-{endVerse}";
    }

    public string GetString()
    {
        return $"{_book} {_chapter}:{_verses}";
    }
}