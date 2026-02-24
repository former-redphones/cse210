public class Word
{
    public string String {get; private set;} // Property, so uses TitleCase
    private bool _isHidden = false;

    public Word(string word)
    {
        String = word;
    }

    public void Hide()
    {
        string newWord = "";
        foreach (char c in String)
        {
            if (Char.IsLetter(c))
            {
                newWord += "_";
            } else
            {
                newWord += c;
            }
        }
        String = newWord;
        _isHidden = true;
    }

    public bool CheckHidden() { return _isHidden; }
}