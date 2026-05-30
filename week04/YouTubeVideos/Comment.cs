class Comment(string name, string text)
{
    private string _name = name;
    private string _text = text;

    public string GetCommenterName()
    {
        return _name;
    }
    public void DisplayCommentText()
    {
        Console.WriteLine( $"{_text}");
    }
}