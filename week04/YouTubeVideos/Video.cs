class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments = [];

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }
    public string GetVideoTitle()
    {
        return _title;
    }
    public string GetVideoAuthor()
    {
        return _author;
    }
    public int GetVideoLength()
    {
        return _length;
    }
    public int GetVideoCommentCount()
    {
        return _comments.Count;
    }
    public void AddComment(string author, string text)
    {
        _comments.Add(new Comment(author, text));
    }
    public void DisplayAllComments()
    {
        foreach (var comment in _comments)
        {
            Console.WriteLine($"{comment.GetCommenterName()}:");
            comment.DisplayCommentText();
            Console.Write("\n");
        }
    }
}