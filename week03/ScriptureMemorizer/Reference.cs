public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book.Trim();
        _chapter = chapter;
        _verse = verse;
    }
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book.Trim();
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }
    public string GetDisplayText()
    {
        string reference = $"{_book} {_chapter}:{_verse}";
        if(_endVerse > 0)
        {
            reference += $"-{_endVerse}";
        }
        return reference;
    }
}